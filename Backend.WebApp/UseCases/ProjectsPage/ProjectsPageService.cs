using Core.Actions.Abstractions.DataBaseConnector;
using Core.Models.WineRealizations;
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
        private readonly IBaseGenericRepository<WineTimeLine> _timeLineRepository;

        public ProjectsPageService(IBaseGenericRepository<WineTimeLine> timeLineRepository)
        {
            _timeLineRepository = timeLineRepository;
        }

        /// <summary>
        /// Изменить имя проекта
        /// </summary>
        /// <param name="id"> Идентификатор проекта </param>
        /// <param name="changedName"> Новое имя проекта </param>
        /// <returns></returns>
        public async Task<bool> ChangeProjectName(int id, string changedName)
        {
            var project = await _timeLineRepository.GetByIdAsync(id);
            if (project == null) return false;
            project.TimeLineName = changedName;
            await _timeLineRepository.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Удалить проект
        /// </summary>
        /// <param name="id"> Идентификатор проекта </param>
        /// <returns></returns>
        public async Task<bool> DeleteProjectAsync(int id)
        {
            return await _timeLineRepository.DeleteAsync(id);
        }

        /// <summary>
        /// Получить список мероприятий
        /// </summary>
        /// <param name="userId"> Идентификкатор пользователя </param>
        /// <returns></returns>
        public async Task<IEnumerable<ProjectResponse>> GetListProjects(int userId)
        {
            var projects = await _timeLineRepository.GetAllAsync();
            var currentUserProjects = projects.Where(x => x.UserId == userId);
            var result = projects.Select(x => new ProjectResponse()
            {
                Id = x.Id,
                EventCount = x.Days.FirstOrDefault(d => d.CurrentDate == DateTime.Now)?.Events.Count ?? 0,
                ProjectName = x.TimeLineName
            });

            return result;
        }
    }
}
