using WebApp.Models.Response.ProjectsPage;

namespace WebApp.UseCases.ProjectsPage.Abstract
{
    /// <summary>
    /// Сервис для контроллера ProjectsPage
    /// </summary>
    public interface IProjectsPageService
    {
        /// <summary>
        /// Получить список мероприятий
        /// </summary>
        /// <param name="userId"> Идентификкатор пользователя </param>
        /// <returns></returns>
        Task<IEnumerable<ProjectResponse>> GetListProjects(int id);

        /// <summary>
        /// Изменить имя проекта
        /// </summary>
        /// <param name="id"> Идентификатор проекта </param>
        /// <param name="changedName"> Новое имя проекта </param>
        /// <returns></returns>
        Task<bool> ChangeProjectName(int id, string changedName);

        /// <summary>
        /// Удалить проект
        /// </summary>
        /// <param name="id"> Идентификатор проекта </param>
        /// <returns></returns>
        Task<bool> DeleteProjectAsync(int id);
    }
}
