using Core.Actions.Abstractions.CalculatorUnitsMeasurement;
using Core.Actions.Abstractions.CurrentIndicatorsCalculator;
using Core.Actions.Abstractions.DataBaseConnector;
using Core.Actions.Abstractions.EventCalculator;
using Core.Actions.Abstractions.TimeLineCreator;
using Core.Actions.ShareRealizations.CalculatorUnitsMeasurement;
using Core.Models.Abstractions;
using Core.Models.WineRealizations;
using Core.Models.WineRealizations.Enums;
using DataBase.EF.ConnectionFroWine.Repository;
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
            var events = await _repository.GetEventsWithDayAndTimeLineAsync(dayId, userId);

            if (events == null) return null;

            return events.Select(x => Map<WineEvent, CurrentDayEventsResponse>(x));
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

            var newDays = await RecalculateTimeLine(day.TimeLineId, model.DayId, currentIndicators);

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

            var newDays = await RecalculateTimeLine(day.TimeLineId, model.DayId, currentIndicators);

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
        private async Task<List<WineDay>> RecalculateTimeLine(int timeLineId, int dayId, WineIndicator updatedIndicator)
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
            var recalculatedDays = _timeLineCreator.GetTimeLine(updatedIndicator, dayNumber, maxDayCount, currentDay.CurrentDate);  //Дни идущие после актуализирующего дня

            var result = firstPart.Concat(recalculatedDays.Days);

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

            var typicalEvent = await _repository.GetTypicalEventAsync(WineEventTypes.Alcoholization);
            var newEvent = new WineEvent()
            {
                DesiredIndicator = desiredIndicator,
                EventType = EventCustomTypes.Custom,
                IsCompleted = false,
                TypicalEvent = typicalEvent
            };

            await _repository.AddEventAsync(newEvent, request.DayId);
            return Map<WineEvent, CurrentDayEventsResponse>(newEvent);
        }

        public Task<CurrentDayEventsResponse?> AddShaptalizationEventAsync(AddShaptalizationEvent request)
        {
            throw new NotImplementedException();
        }

        public Task<CurrentDayEventsResponse?> AddBlendingEventByAllParamsAsync(AddBlendingEventByAllParams request)
        {
            throw new NotImplementedException();
        }

        public Task<CurrentDayEventsResponse?> AddBlendingEventByProjectAsync(AddBlendingEventByProject request)
        {
            throw new NotImplementedException();
        }
    }
}
