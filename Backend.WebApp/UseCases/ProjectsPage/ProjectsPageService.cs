using System.Reflection.Metadata.Ecma335;
using Core.Actions.Abstractions.DataBaseConnector;
using Core.Actions.Abstractions.TimelineCorrector;
using Core.Actions.Abstractions.TimeLineCreator;
using Core.Actions.Abstractions.TImeLineIndicatorConverter;
using Core.Models.WineRealizations;
using Microsoft.EntityFrameworkCore.Internal;
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

        private readonly IBaseGenericRepository<WineTimeLine> _timeLineRepository;

        private readonly IBaseGenericRepository<WineTypicalEvent> _typicalEventRepository;

        private readonly IBaseGenericRepository<WineEvent> _eventRepository;

        public ProjectsPageService(IBaseGenericRepository<WineTimeLine> timeLineRepository,
            IHttpContextAccessor httpContextAccessor,
             BaseTimeLineCreator<WineIndicator, WineTimeLine, WineDay> timeLineCreator,
             BaseTimelineCorrector<WineTimeLine, WineIndicator> timelineCorrector,
             IBaseGenericRepository<WineTypicalEvent> eventRepository,
             IBaseGenericRepository<WineEvent> ventRepository) : base(httpContextAccessor)
        {
            _timeLineRepository = timeLineRepository;
            _timeLineCreator = timeLineCreator;
            _timelineCorrector = timelineCorrector;
            _typicalEventRepository = eventRepository;
            _eventRepository = ventRepository;
        }

        /// <summary>
        /// Изменить имя проекта
        /// </summary>
        /// <param name="id"> Идентификатор проекта </param>
        /// <param name="changedName"> Новое имя проекта </param>
        /// <returns></returns>
        public async Task<bool> ChangeProjectNameAsync(int id, string changedName)
        {
            var project = await _timeLineRepository.GetByIdAsync(id);
            if (project == null) return false;

            project.TimeLineName = changedName;
            await _timeLineRepository.SaveChangesAsync();

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

            //Помечаем все событие, как не измененные, чтобы EF не пытался создать новые сущности справочника с днями
            foreach (var day in timeLine.Days)
            {
                foreach (var evnt in day.Events)
                {
                    _typicalEventRepository.SetItemUnchanged(evnt.TypicalEvent);
                }
                await _eventRepository.AddRangeAsync(day.Events);
            }

            _timeLineRepository.Add(timeLine);
            await _timeLineRepository.SaveChangesAsync();

            var dbTimeLine = _timeLineRepository.GetAll().FirstOrDefault(timeLine);

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
            var result = await _timeLineRepository.DeleteAsync(id);
            await _timeLineRepository.SaveChangesAsync();
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

            var projects = await _timeLineRepository.GetAllAsync();
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
