using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Controllers.Base;
using WebApp.UseCases.ProjectsPage.Abstract;

namespace WebApp.Controllers
{
    /// <summary>
    /// Контроллер для модуля со списком проектов
    /// </summary>
    [Route("ProjectsPage")]
    public class ProjectsPageController : BaseWineController
    {
        private readonly IProjectsPageService _projectsPageService;

        public ProjectsPageController(IProjectsPageService projectsPageService)
        {
            _projectsPageService = projectsPageService;
        }

        /// <summary>
        /// Точка для удаления проекта
        /// </summary>
        /// <param name="id"> Id проекта </param>
        /// <returns></returns>
        [HttpPost("DeleteProject")]
        [Authorize(Roles = "WineMaker")]
        public async Task<bool> DeleteProject(int id)
        {
            return await _projectsPageService.DeleteProjectAsync(id);
        }
    }
}
