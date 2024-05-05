using Core.Actions.Abstractions.CalculatorUnitsMeasurement;
using Core.Actions.Abstractions.DataBaseConnector;
using Core.Actions.Abstractions.TimelineCorrector;
using Core.Actions.Abstractions.TimeLineCreator;
using Core.Actions.Abstractions.TImeLineIndicatorConverter;
using Core.Actions.ShareRealizations.CalculatorUnitsMeasurement;
using Core.Models.WineRealizations;
using Core.Models.WineRealizations.Enums;
using DataBase.EF.ConnectionForWine.Repository;
using WebApp.Models.Request.Projects;
using WebApp.Models.Response.ProjectsPage;
using WebApp.UseCases.Base.Abstract;
using WebApp.UseCases.Projects.Abstract;

namespace WebApp.UseCases.Projects
{
    /// <summary>
    /// Сервис для контроллера ProjectsPage
    /// </summary>
    public class ProjectsService : BaseWineService, IProjectsService
    {
        private const string NULL_PROJECT_NAME_ERRPR = "Имени проекта не было присвоено значение";

        private const string NULL_USER_ID_ERROR = "Не удалось получить данные о пользователе";

        private const string NULL_GRAPE_VARETY_ERROR = "Не удалось получить данные о пользователе";

        /// <summary>
        /// Калькулятор систем исчислений
        /// </summary>
        private readonly IBaseUnitsCalculator<MeasurementUnits> _calculator;

        /// <summary>
        /// Создатель TimeLine'a
        /// </summary>
        private readonly BaseTimeLineCreator<WineIndicator, WineTimeLine, WineDay> _timeLineCreator;

        /// <summary>
        /// Корректировщик TimeLine'а
        /// </summary>
        private readonly BaseTimelineCorrector<WineTimeLine, WineIndicator> _timelineCorrector;

        /// <summary>
        /// Фабрика для получения конвертера по типу начальных данных
        /// </summary>
        private readonly IIndicatorConverterFactory<InitialIndicatorTypes, WineIndicator> _indicatorFactory;

        private readonly IProjectServiceRepository _repository;

        private readonly IBaseGenericRepository<GrapeVariety> _grapeVarietyRepository;

        public ProjectsService(IProjectServiceRepository repository,
            IHttpContextAccessor httpContextAccessor,
             BaseTimeLineCreator<WineIndicator, WineTimeLine, WineDay> timeLineCreator,
             BaseTimelineCorrector<WineTimeLine, WineIndicator> timelineCorrector,
             IIndicatorConverterFactory<InitialIndicatorTypes, WineIndicator> indicatorFactory,
             IBaseGenericRepository<GrapeVariety> grapeVarietyRepository,
             IBaseUnitsCalculator<MeasurementUnits> calculator) : base(httpContextAccessor)
        {
            _repository = repository;
            _timeLineCreator = timeLineCreator;
            _timelineCorrector = timelineCorrector;
            _indicatorFactory = indicatorFactory;
            _grapeVarietyRepository = grapeVarietyRepository;
            _calculator = calculator;
        }

        /// <summary>
        /// Изменить имя проекта
        /// </summary>
        /// <param name="id"> Идентификатор проекта </param>
        /// <param name="changedName"> Новое имя проекта </param>
        /// <returns></returns>
        public async Task<bool> ChangeProjectNameAsync(int id, string changedName)
        {
            var project = await _repository.GetByIdAsync(id);
            if (project == null) return false;

            project.TimeLineName = changedName;
            _repository.Update(project);

            return true;
        }

        /// <summary>
        /// Создать таймлайн путем ввода всех параметров
        /// </summary>
        /// <param name="request"> Данные для генерации таймлайна </param>
        /// <returns></returns>
        public async Task<CreateProjectResponse> CreateTimeLineByAllParamsAsync(CreateProjectModelByAllParams request)
        {
            if (string.IsNullOrEmpty(request.ProjectName))
                return new CreateProjectResponse() { Error = NULL_PROJECT_NAME_ERRPR };

            //Получаем из модельки текущие показатели и желаемые
            WineIndicator indicator = new WineIndicator() { EthanolValue = request.AlcoholValue, SugarValue = request.SugarValue, WortValue = request.Wort };
            WineIndicator desiredIndicator = new WineIndicator() { SugarValue = request.DesiredSugarValue, EthanolValue = request.DesiredAlcoholValue };

            indicator.EthanolValue = _calculator.Calculate(MeasurementUnits.Percentage, MeasurementUnits.GramPerLiter, indicator.EthanolValue);     //Показания спирта в Г/Л

            var timeLine = _timeLineCreator.GetTimeLine(indicator);        //Генерируем TimeLine
            timeLine.TimeLineName = request.ProjectName;
            _timelineCorrector.CorrectTimeLIne(timeLine, desiredIndicator); //Корректируем события согласно заданым мероприятиям

            var currentUserId = GetUserId();
            if (currentUserId == null)
                return new CreateProjectResponse() { Error = NULL_USER_ID_ERROR };
            timeLine.UserId = (int)currentUserId;

            await _repository.AddTimeLineAsync(timeLine);

            var response = new ProjectResponse()        //Формируем ответ
            {
                ProjectName = timeLine.TimeLineName,
                Id = timeLine.Id,
                EventCount = timeLine.Days.FirstOrDefault(d => d.CurrentDate == DateTime.Now)?.Events.Count ?? 0
            };

            return new CreateProjectResponse() { CreatedProject = response };
        }

        /// <summary>
        /// Создать таймлайн путем ввода показаний ареометра
        /// </summary>
        /// <param name="request"> Данные для генерации таймлайна </param>
        /// <returns></returns>
        public async Task<CreateProjectResponse> CreateTimeLineByAreometerAsync(CreateProjectModelByAreometer request)
        {
            if (string.IsNullOrEmpty(request.ProjectName))
                return new CreateProjectResponse() { Error = NULL_PROJECT_NAME_ERRPR };

            WineIndicator desiredIndicator = new WineIndicator() { SugarValue = request.DesiredSugarValue, EthanolValue = request.DesiredAlcoholValue };

            var indicatorConverter = _indicatorFactory.GetIndicatorConverter(InitialIndicatorTypes.ByAreometr, request.AreometerValue);
            if (indicatorConverter == null) throw new Exception("Не удалось получить конвертер для получения показателя по показаниям ареометра");
            var indicator = indicatorConverter.GetIndicator();

            var timeLine = _timeLineCreator.GetTimeLine(indicator);        //Генерируем TimeLine
            timeLine.TimeLineName = request.ProjectName;
            timeLine.StartAreometerValue = request.AreometerValue;
            _timelineCorrector.CorrectTimeLIne(timeLine, desiredIndicator); //Корректируем события согласно заданым мероприятиям

            var currentUserId = GetUserId();
            if (currentUserId == null)
                return new CreateProjectResponse() { Error = NULL_USER_ID_ERROR };
            timeLine.UserId = (int)currentUserId;

            await _repository.AddTimeLineAsync(timeLine);

            var response = new ProjectResponse()        //Формируем ответ
            {
                ProjectName = timeLine.TimeLineName,
                Id = timeLine.Id,
                EventCount = timeLine.Days.FirstOrDefault(d => d.CurrentDate == DateTime.Now)?.Events.Count ?? 0
            };

            return new CreateProjectResponse() { CreatedProject = response };
        }

        /// <summary>
        /// Создать таймлайн путем выбора сорта винограда
        /// </summary>
        /// <param name="request"> Данные для генерации таймлайна </param>
        /// <returns></returns>
        public async Task<CreateProjectResponse> CreateTimeLineByGrapeVaretyAsync(CreateProjectModelByGrapeVarety request)
        {
            if (string.IsNullOrEmpty(request.ProjectName))
                return new CreateProjectResponse() { Error = NULL_PROJECT_NAME_ERRPR };

            if (string.IsNullOrEmpty(request.GrapeName))
                return new CreateProjectResponse() { Error = NULL_GRAPE_VARETY_ERROR };

            WineIndicator desiredIndicator = new WineIndicator() { SugarValue = request.DesiredSugarValue, EthanolValue = request.DesiredAlcoholValue};

            var indicatorConverter = _indicatorFactory.GetIndicatorConverter(InitialIndicatorTypes.ByGrapeVariety, request.GrapeName);
            if (indicatorConverter == null) throw new Exception("Не удалось получить конвертер для получения показателя по сорту винограда");
            var indicator = indicatorConverter.GetIndicator();
            indicator.WortValue = request.Wort;

            var timeLine = _timeLineCreator.GetTimeLine(indicator);        //Генерируем TimeLine
            timeLine.TimeLineName = request.ProjectName;
            _timelineCorrector.CorrectTimeLIne(timeLine, desiredIndicator); //Корректируем события согласно заданым мероприятиям

            var currentUserId = GetUserId();
            if (currentUserId == null)
                return new CreateProjectResponse() { Error = NULL_USER_ID_ERROR };
            timeLine.UserId = (int)currentUserId;

            await _repository.AddTimeLineAsync(timeLine);

            var response = new ProjectResponse()        //Формируем ответ
            {
                ProjectName = timeLine.TimeLineName,
                Id = timeLine.Id,
                EventCount = timeLine.Days.FirstOrDefault(d => d.CurrentDate == DateTime.Now)?.Events.Count ?? 0
            };

            return new CreateProjectResponse() { CreatedProject = response };
        }

        /// <summary>
        /// Удалить проект
        /// </summary>
        /// <param name="id"> Идентификатор проекта </param>
        /// <returns></returns>
        public async Task<bool> DeleteProjectAsync(int id)
        {
            var result = await _repository.DeleteAsync(id);
            return result;
        }

        /// <summary>
        /// Получить список сортов винограда
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<string>> GetGrapeVarietiesAsync()
        {
            var grapeVarieties = await _grapeVarietyRepository.GetAllAsync();
            return grapeVarieties.Select(x => x.GrapeVarietyName);
        }

        /// <summary>
        /// Получить список мероприятий
        /// </summary>
        /// <param name="userId"> Идентификкатор пользователя </param>
        /// <returns></returns>
        public async Task<IEnumerable<ProjectResponse>> GetListProjectsAsync()
        {
            var userId = GetUserId();
            if (userId == null) return Enumerable.Empty<ProjectResponse>();

            var projects = await _repository.GetAllAsync();
            var currentUserProjects = projects.Where(x => x.UserId == userId);

            var result = currentUserProjects.Select(x => new ProjectResponse()
            {
                Id = x.Id,
                EventCount = x.Days.FirstOrDefault(d => d.CurrentDate == DateTime.Now)?.Events.Count ?? 0,
                ProjectName = x.TimeLineName
            });

            return result;
        }
    }
}
