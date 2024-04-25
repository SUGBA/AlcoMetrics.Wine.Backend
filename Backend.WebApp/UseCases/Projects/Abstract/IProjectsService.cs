using WebApp.Models.Request.ProjectsPage;
using WebApp.Models.Response.ProjectsPage;

namespace WebApp.UseCases.Projects.Abstract
{
    /// <summary>
    /// Сервис для контроллера ProjectsPage
    /// </summary>
    public interface IProjectsService
    {
        /// <summary>
        /// Получить список мероприятий
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ProjectResponse>> GetListProjectsAsync();

        /// <summary>
        /// Изменить имя проекта
        /// </summary>
        /// <param name="id"> Идентификатор проекта </param>
        /// <param name="changedName"> Новое имя проекта </param>
        /// <returns></returns>
        Task<bool> ChangeProjectNameAsync(int id, string changedName);

        /// <summary>
        /// Удалить проект
        /// </summary>
        /// <param name="id"> Идентификатор проекта </param>
        /// <returns></returns>
        Task<bool> DeleteProjectAsync(int id);

        /// <summary>
        /// Создать таймлайн путем ввода всех параметров
        /// </summary>
        /// <param name="request"> Данные для генерации таймлайна </param>
        /// <returns></returns>
        Task<CreateProjectResponse> CreateTimeLineByAllParamsAsync(CreateProjectModelByAllParams request);

        /// <summary>
        /// Создать таймлайн путем ввода показаний ареометра
        /// </summary>
        /// <param name="request"> Данные для генерации таймлайна </param>
        /// <returns></returns>
        Task<CreateProjectResponse> CreateTimeLineByAreometerAsync(CreateProjectModelByAreometer request);

        /// <summary>
        /// Создать таймлайн путем выбора сорта винограда
        /// </summary>
        /// <param name="request"> Данные для генерации таймлайна </param>
        /// <returns></returns>
        Task<CreateProjectResponse> CreateTimeLineByGrapeVaretyAsync(CreateProjectModelByGrapeVarety request);

        /// <summary>
        /// Получить список сортов винограда
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<string>> GetGrapeVarietiesAsync();
    }
}
