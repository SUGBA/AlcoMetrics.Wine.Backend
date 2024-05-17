using Core.Actions.Abstractions.CalculatorUnitsMeasurement;
using Core.Actions.Abstractions.CurrentIndicatorsCalculator;
using Core.Actions.Abstractions.DataBaseConnector;
using Core.Actions.Abstractions.EventCalculator;
using Core.Actions.Abstractions.TimeLineCreator;
using Core.Actions.ShareRealizations.CalculatorUnitsMeasurement;
using Core.Actions.WineRealizations.WineEventCalculator;
using Core.Models.Abstractions;
using Core.Models.WineRealizations;
using Core.Models.WineRealizations.Enums;
using DataBase.EF.ConnectionForWine.Repository;
using WebApp.Models.Request.TimeLineDay;
using WebApp.Models.Response.TimeLineDay;
using WebApp.UseCases.Base.Abstract;
using WebApp.UseCases.TimeLineDay.Abstract;

namespace WebApp.UseCases.TimeLineDay
{
    /// <summary>
    /// Имплементация сервиса для работы с контроллером TimeLineController
    /// </summary>
    public class TimeLineDayService : BaseWineService, ITimeLineDayService
    {
        /// <summary>
        /// Создатель TimeLine'a
        /// </summary>
        private readonly BaseTimeLineCreator<WineIndicator, WineTimeLine, WineDay> _timeLineCreator;

        /// <summary>
        /// Репозиторий для данного сервиса
        /// </summary>
        private readonly ITimeLineDayServiceRepository _repository;

        /// <summary>
        /// Калькулятор рассчета актуальных показателей
        /// </summary>
        private readonly BaseCurrentIndicatorCalculatorWorker<UpdateIndicatorTypes, WineIndicator> _currentIndicatorWorker;

        /// <summary>
        /// Калькулятор систем исчислений
        /// </summary>
        private readonly IBaseUnitsCalculator<MeasurementUnits> _calculator;

        /// <summary>
        /// Фасад для работы с мероприятиями
        /// </summary>
        private readonly BaseEventWorker<WineEventTypes, WineIndicator> _eventWorker;

        /// <summary>
        /// Максимальное число дней на которое будет перерасчитываться TimeLine
        /// </summary>
        private const int MAX_DAY_COUNT = 100;

        private const string UPDATE_ALL_PARAMAS_EMPTY_VALUE_ERROR = "Ошибка в ходе актуализации параметров. День или его показатели не должны быть пустыми.";

        private const string UPDATE_AREOMETER_EMPTY_VALUE_ERROR = "Ошибка в ходе актуализации параметров. День или его показатели не должны быть пустыми. Обратите внимание, что для актуализации на основе показаний ареометра, необходимо чтобы проект создавался на основ показателя ареометра";

        private const string DIFFERENCE_AREOMETER_VALUE_ERROR = "Ошибка в ходе актуализации параметров. Начальные показатели не могут быть меньше текущих";

        private readonly IBaseGenericRepository<WineDay> _dayRepository;

        public TimeLineDayService(IHttpContextAccessor httpContextAccessor,
            ITimeLineDayServiceRepository repository,
            BaseCurrentIndicatorCalculatorWorker<UpdateIndicatorTypes,
            WineIndicator> currentIndicatorWorker,
            BaseTimeLineCreator<WineIndicator, WineTimeLine, WineDay> timeLineCreator,
            IBaseGenericRepository<WineDay> baseRepository,
            IBaseUnitsCalculator<MeasurementUnits> calculator,
            BaseEventWorker<WineEventTypes, WineIndicator> eventWorker) : base(httpContextAccessor)
        {
            _repository = repository;
            _currentIndicatorWorker = currentIndicatorWorker;
            _timeLineCreator = timeLineCreator;
            _dayRepository = baseRepository;
            _calculator = calculator;
            _eventWorker = eventWorker;
        }

        public async Task<CurrentDayIndicatrosResponse?> GetCurrentDayIndicatorsAsync(int dayId)
        {
            var userId = GetUserId() ?? throw new Exception("Не удалось получит Id пользователя при формировании списка показателей конкретного дня");
            var day = await _repository.GetDayWithIndicatorsAndTimeLineAsync(dayId, userId);

            if (day == null) return null;

            return Map<WineDay, CurrentDayIndicatrosResponse>(day);
        }

        public async Task<IEnumerable<CurrentDayEventsResponse>?> GetEventsAsync(int dayId)
        {
            var userId = GetUserId() ?? throw new Exception("Не удалось получит Id пользователя при формировании списка показателей конкретного дня");
            var events = await _repository.GetEventsForTable(dayId, userId);

            if (events == null) return null;

            var res =  events.Select(x => Map<WineEvent, CurrentDayEventsResponse>(x));
            return res;
        }

        public async Task<string?> UpdateDayIndicatorsByAllParamsAsync(UpdateIndicatorsByAllParam model)
        {
            var userId = GetUserId() ?? throw new Exception("Не удалось получит Id пользователя при актуализации показателей по всем параметрам");
            var day = await _repository.GetDayWithIndicatorsAndTimeLineAsync(model.DayId, userId);
            if (day == null || day.Indicator == null)
                return UPDATE_ALL_PARAMAS_EMPTY_VALUE_ERROR;

            var currentIndicators = day.Indicator;
            currentIndicators.SugarValue = model.SugarValue;            //Получаем обновленный индикатор
            currentIndicators.EthanolValue = model.AlcoholPercentage;
            currentIndicators.WortValue = model.Wort;

            var newDays = await RecalculateTimeLineAsync(day.TimeLineId, model.DayId, currentIndicators);

            await _repository.UpdateDaysAsync(newDays, day.TimeLineId);   //Обновляем дни TimeLine'a

            return null;
        }

        public async Task<string?> UpdateDayIndicatorsByAreometerAsync(UpdateIndicatorsByAllAreometer model)
        {
            var userId = GetUserId() ?? throw new Exception("Не удалось получит Id пользователя при актуализации показателей по всем параметрам");
            var day = await _repository.GetDayWithIndicatorsAndTimeLineAsync(model.DayId, userId);
            if (day == null || day.Indicator == null || day.TimeLine.StartAreometerValue == null)
                return UPDATE_AREOMETER_EMPTY_VALUE_ERROR;

            if (day.TimeLine.StartAreometerValue < model.AreometerValue)
                return DIFFERENCE_AREOMETER_VALUE_ERROR;

            var currentIndicators = day.Indicator;
            var updatedIndicator = _currentIndicatorWorker.Calculate(UpdateIndicatorTypes.ByAreometr, new object[] { day.TimeLine.StartAreometerValue, model.AreometerValue });
            if (updatedIndicator == null) throw new Exception("Не удалось рассчитать показатель полученный сравнением показаний ареометра");

            currentIndicators.SugarValue = updatedIndicator.SugarValue;
            currentIndicators.EthanolValue = updatedIndicator.EthanolValue;

            var newDays = await RecalculateTimeLineAsync(day.TimeLineId, model.DayId, currentIndicators);

            await _repository.UpdateDaysAsync(newDays, day.TimeLineId);   //Обновляем дни TimeLine'a

            return null;
        }

        /// <summary>
        /// Пересчитать тайм лайн и получить новый список дней
        /// </summary>
        /// <param name="timeLineId"> id TimeLine'a который будет пересчитывать </param>
        /// <param name="dayId"> id текущего дня </param>
        /// <param name="updatedIndicator"> измененные показатели </param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private async Task<List<WineDay>> RecalculateTimeLineAsync(int timeLineId, int dayId, WineIndicator updatedIndicator)
        {
            var userId = GetUserId() ?? throw new Exception("Пользователь с заданным id не существует, при попытке получения списка дней для перерасчета");
            var days = await _repository.GetDaysWithIndicatorsAsync(timeLineId);
            if (days == null || days.Count() == 0) throw new Exception("Список дней был пустым при попытке его пересчета, после актуализации показателей");

            var firstDay = days.First();

            var currentDay = days.FirstOrDefault(x => x.Id == dayId);
            if (currentDay == null) throw new Exception("Ошибка при пересчете TimeLine'a, текущего дня не существует");

            var dayNumber = (currentDay.CurrentDate - firstDay.CurrentDate).Days;
            var maxDayCount = dayNumber + MAX_DAY_COUNT;

            updatedIndicator.EthanolValue = _calculator.Calculate(MeasurementUnits.Percentage, MeasurementUnits.GramPerLiter, updatedIndicator.EthanolValue);     //Показания спирта в Г/Л

            var firstPart = days.Where(x => x.CurrentDate < currentDay.CurrentDate);                                                //Дни до даты актуализации
            var secondPart = _timeLineCreator.GetTimeLine(updatedIndicator, dayNumber, maxDayCount, currentDay.CurrentDate).Days;  //Дни идущие после актуализирующего дня
            secondPart.First().Id = currentDay.Id;

            var result = firstPart.Concat(secondPart);

            return result.ToList();
        }

        public async Task<CurrentDayEventsResponse?> AddAlcoholizationEventAsync(AddAlcoholizationEvent request)
        {
            var userId = GetUserId() ?? throw new Exception("Пользователь с заданным Id не существует, при попытке получения показателей дня для добавления события крепления");

            var currentDay = await _repository.GetDayWithIndicatorsAndTimeLineAsync(request.DayId, userId);
            if (currentDay == null) return null;
            var currentIndicator = currentDay.Indicator;

            var desiredDay = await _repository.GetDayWithIndicatorsAndTimeLineAsync(request.DayId, userId);
            if (desiredDay == null) return null;
            var desiredIndicator = desiredDay.Indicator;
            desiredIndicator.EthanolValue = request.DesiredAlcoholValue;
            desiredIndicator.Id = 0;

            var ingridients = _eventWorker.CalculateEventIngredients(WineEventTypes.Alcoholization, desiredIndicator, currentIndicator, new object[] { request.AlcoholValue });
            var dbIngridients = ingridients?.Select(x => new WineIngredient() { IngredientName = x.Key, IngredientValue = x.Value }).ToList() ?? new List<WineIngredient>();

            var typicalEvent = await _repository.GetTypicalEventAsync(WineEventTypes.Alcoholization);
            var newEvent = new WineEvent()
            {
                DesiredIndicator = desiredIndicator,
                EventType = EventCustomTypes.Custom,
                IsCompleted = false,
                TypicalEvent = typicalEvent,
                Ingridients = dbIngridients,
                ResultIndicator = _eventWorker.ResultIndicator ?? new()
            };

            await _repository.AddEventAsync(newEvent, request.DayId);
            return Map<WineEvent, CurrentDayEventsResponse>(newEvent);
        }

        public async Task<CurrentDayEventsResponse?> AddShaptalizationEventAsync(AddShaptalizationEvent request)
        {
            var userId = GetUserId() ?? throw new Exception("Пользователь с заданным Id не существует, при добавлении события шаптализации");

            var currentDay = await _repository.GetDayWithIndicatorsAndTimeLineAsync(request.DayId, userId);
            if (currentDay == null) return null;
            var currentIndicator = currentDay.Indicator;

            var desiredDay = await _repository.GetDayWithIndicatorsAndTimeLineAsync(request.DayId, userId);
            if (desiredDay == null) return null;
            var desiredIndicator = desiredDay.Indicator;
            desiredIndicator.SugarValue = request.DesiredSugarValue;
            desiredIndicator.Id = 0;

            var ingridients = _eventWorker.CalculateEventIngredients(WineEventTypes.Shaptalization, desiredIndicator, currentIndicator);
            var dbIngridients = ingridients?.Select(x => new WineIngredient() { IngredientName = x.Key, IngredientValue = x.Value }).ToList() ?? new List<WineIngredient>();

            var typicalEvent = await _repository.GetTypicalEventAsync(WineEventTypes.Shaptalization);
            var newEvent = new WineEvent()
            {
                DesiredIndicator = desiredIndicator,
                EventType = EventCustomTypes.Custom,
                IsCompleted = false,
                TypicalEvent = typicalEvent,
                Ingridients = dbIngridients,
                ResultIndicator = _eventWorker.ResultIndicator ?? new()
            };

            await _repository.AddEventAsync(newEvent, request.DayId);
            return Map<WineEvent, CurrentDayEventsResponse>(newEvent);
        }

        public async Task<CurrentDayEventsResponse?> AddBlendingEventByAllParamsAsync(AddBlendingEventByAllParams request)
        {
            var userId = GetUserId() ?? throw new Exception("Пользователь с заданным Id не существует, при купажировании на основе всех параметров");

            var substanceIndicator = new WineIndicator() { EthanolValue = request.AlcoholValue, SugarValue = request.SugarValue };

            var currentDay = await _repository.GetDayWithIndicatorsAndTimeLineAsync(request.DayId, userId);
            if (currentDay == null) return null;
            var currentIndicator = currentDay.Indicator;

            var desiredDay = await _repository.GetDayWithIndicatorsAndTimeLineAsync(request.DayId, userId);
            if (desiredDay == null) return null;
            var desiredIndicator = desiredDay.Indicator;
            desiredIndicator.SugarValue = request.DesiredSugarValue;
            desiredIndicator.EthanolValue = request.DesiredAlcoholValue;
            desiredIndicator.Id = 0;

            var ingridients = _eventWorker.CalculateEventIngredients(WineEventTypes.Blending, desiredIndicator, currentIndicator, new object[] { substanceIndicator, BasedSubstanceType.Sugar });
            var dbIngridients = ingridients?.Select(x => new WineIngredient() { IngredientName = x.Key, IngredientValue = x.Value }).ToList() ?? new List<WineIngredient>();

            var typicalEvent = await _repository.GetTypicalEventAsync(WineEventTypes.Blending);
            var newEvent = new WineEvent()
            {
                DesiredIndicator = desiredIndicator,
                EventType = EventCustomTypes.Custom,
                IsCompleted = false,
                TypicalEvent = typicalEvent,
                Ingridients = dbIngridients,
                ResultIndicator = _eventWorker.ResultIndicator ?? new()
            };

            await _repository.AddEventAsync(newEvent, request.DayId);
            return Map<WineEvent, CurrentDayEventsResponse>(newEvent);
        }

        public async Task<CurrentDayEventsResponse?> AddBlendingEventByProjectAsync(AddBlendingEventByProject request)
        {
            var userId = GetUserId() ?? throw new Exception("Пользователь с заданным Id не существует, при добавления события купажирования по проекту");

            var currentDay = await _repository.GetDayWithIndicatorsAndTimeLineAsync(request.DayId, userId);
            if (currentDay == null) return null;
            var currentIndicator = currentDay.Indicator;

            //В качестве индикатор купажа выбираем день с минимальной дельтой между датами купажа и нашего сусла. То есть выбирается день максимально близкий по дате к дате изменяемого дня.
            var substanceTimeLine = await _repository.GetDaysWithIndicatorsAsync(request.SelectedProjectId);
            if (substanceTimeLine == null) return null;
            var substanceDay = substanceTimeLine.OrderBy(x => Math.Abs((x.CurrentDate - currentDay.CurrentDate).TotalMinutes)).FirstOrDefault();
            if (substanceDay == null) return null;
            var substanceIndicator = substanceDay.Indicator;

            var desiredDay = await _repository.GetDayWithIndicatorsAndTimeLineAsync(request.DayId, userId);
            if (desiredDay == null) return null;
            var desiredIndicator = desiredDay.Indicator;
            desiredIndicator.SugarValue = request.DesiredSugarValue;
            desiredIndicator.EthanolValue = request.DesiredAlcoholValue;
            desiredIndicator.Id = 0;

            var ingridients = _eventWorker.CalculateEventIngredients(WineEventTypes.Blending, desiredIndicator, currentIndicator, new object[] { substanceIndicator, BasedSubstanceType.Sugar });
            var dbIngridients = ingridients?.Select(x => new WineIngredient() { IngredientName = x.Key, IngredientValue = x.Value }).ToList() ?? new List<WineIngredient>();

            var typicalEvent = await _repository.GetTypicalEventAsync(WineEventTypes.Blending);
            var newEvent = new WineEvent()
            {
                DesiredIndicator = desiredIndicator,
                EventType = EventCustomTypes.Custom,
                IsCompleted = false,
                TypicalEvent = typicalEvent,
                Ingridients = dbIngridients,
                ResultIndicator = _eventWorker.ResultIndicator ?? new()
            };

            await _repository.AddEventAsync(newEvent, request.DayId);
            return Map<WineEvent, CurrentDayEventsResponse>(newEvent);
        }

        public async Task<IEnumerable<GetProjectsResponse>> GetProjectsAsync(int currentProjectId)
        {
            var userId = GetUserId() ?? throw new Exception("Пользователь с заданным Id не существует, при получении списка проектов для купажирования");
            var projects = await _repository.GetProjectsAsync(userId);
            var resultProjects = projects?.Where(x => x.Id != currentProjectId) ?? Enumerable.Empty<WineTimeLine>();
            var result = resultProjects.Select(x => new GetProjectsResponse() { ProjectId = x.Id, ProjectName = x.TimeLineName });
            return result;
        }

        public async Task<bool> AcceptEventAsync(int eventId)
        {
            var userId = GetUserId() ?? throw new Exception("Отсутствует Id пользователя при попытке подтверждения мероприятия");
            var evn = await _repository.GetDayForEventAcceptAsync(eventId, userId);
            if (evn == null || evn.Day == null)
                return false;

            var updatedDay = evn.Day;
            var newIndicator = updatedDay.Events.First(x => x.Id == eventId).ResultIndicator;
            if (newIndicator == null)
                return false;

            updatedDay.Indicator = newIndicator;
            updatedDay.Events.Remove(evn);
            await _repository.DeleteEventAsync(eventId, userId);
            await _repository.UpdateDayAsync(updatedDay);

            var newDays = await RecalculateTimeLineAsync(updatedDay.TimeLineId, updatedDay.Id, newIndicator);

            await _repository.UpdateDaysAsync(newDays, updatedDay.TimeLineId);   //Обновляем дни TimeLine'a

            return true;
        }

        public async Task<bool> DeleteEventAsync(int eventId)
        {
            var userId = GetUserId() ?? throw new Exception("Отсутствует Id пользователя при попытке удалении мероприятия");
            return await _repository.DeleteEventAsync(eventId, userId);
        }
    }
}
