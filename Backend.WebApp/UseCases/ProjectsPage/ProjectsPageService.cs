using Core.Actions.Abstractions.TimelineCorrector;
using Core.Actions.Abstractions.TimeLineCreator;
using Core.Models.WineRealizations;
using DataBase.EF.ConnectionFroWine.Repository;
using WebApp.Models.Request.ProjectsPage;
using WebApp.Models.Response.ProjectsPage;
using WebApp.UseCases.Base.Abstract;
using WebApp.UseCases.ProjectsPage.Abstract;

namespace WebApp.UseCases.ProjectsPage
{
    /// <summary>
    /// Сервис для контроллера ProjectsPage
    /// </summary>
    public class ProjectsPageService : BaseWineService, IProjectsPageService
    {
        private const string NULL_PROJECT_NAME_ERRPR = "Имени проекта не было присвоено значение";

        private const string NULL_USER_ID_ERROR = "Не удалось получить данные о пользователе";

        /// <summary>
        /// Создатель TimeLine'a
        /// </summary>
        private readonly BaseTimeLineCreator<WineIndicator, WineTimeLine, WineDay> _timeLineCreator;

        /// <summary>
        /// Корректировщик TimeLine'а
        /// </summary>
        private readonly BaseTimelineCorrector<WineTimeLine, WineIndicator> _timelineCorrector;

        private readonly IProjectPageServiceRepository _repository;

        public ProjectsPageService(IProjectPageServiceRepository repository,
            IHttpContextAccessor httpContextAccessor,
             BaseTimeLineCreator<WineIndicator, WineTimeLine, WineDay> timeLineCreator,
             BaseTimelineCorrector<WineTimeLine, WineIndicator> timelineCorrector) : base(httpContextAccessor)
        {
            _repository = repository;
            _timeLineCreator = timeLineCreator;
            _timelineCorrector = timelineCorrector;
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

            var timeLine = _timeLineCreator.GetTimeLine(indicator);        //Генерируем TimeLine
            timeLine.TimeLineName = request.ProjectName;
            _timelineCorrector.CorrectTimeLIne(timeLine, desiredIndicator); //Корректируем события согласно заданым мероприятиям

            var currentUserId = GetUserId();
            if (currentUserId == null)
                return new CreateProjectResponse() { Error = NULL_USER_ID_ERROR };
            timeLine.UserId = (int)currentUserId;

            await _repository.AddTimeLineAsync(timeLine);

            var dbTimeLine = _repository.GetAll().FirstOrDefault(timeLine);

            var response = new ProjectResponse()        //Формируем ответ
            {
                ProjectName = dbTimeLine.TimeLineName,
                Id = dbTimeLine.Id,
                EventCount = dbTimeLine.Days.FirstOrDefault(d => d.CurrentDate == DateTime.Now)?.Events.Count ?? 0
            };

            return new CreateProjectResponse() { CreatedProject = response };
        }

        /// <summary>
        /// Создать таймлайн путем ввода показаний ареометра
        /// </summary>
        /// <param name="request"> Данные для генерации таймлайна </param>
        /// <returns></returns>
        public Task<CreateProjectResponse> CreateTimeLineByAreometerAsync(CreateProjectModelByAreometer request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Создать таймлайн путем выбора сорта винограда
        /// </summary>
        /// <param name="request"> Данные для генерации таймлайна </param>
        /// <returns></returns>
        public Task<CreateProjectResponse> CreateTimeLineByGrapeVaretyAsync(CreateProjectModelByGrapeVarety request)
        {
            throw new NotImplementedException();
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
