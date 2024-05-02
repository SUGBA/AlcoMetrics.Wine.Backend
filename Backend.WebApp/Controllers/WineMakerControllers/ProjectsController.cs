﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Controllers.Base;
using WebApp.Models.Request.Projects;
using WebApp.Models.Response.ProjectsPage;
using WebApp.UseCases.Projects.Abstract;

namespace WebApp.Controllers.WineMakerControllers
{
    /// <summary>
    /// Контроллер для модуля со списком проектов
    /// </summary>
    [Route("Projects")]
    public class ProjectsController : BaseWineController
    {
        private readonly IProjectsService _projectsPageService;

        public ProjectsController(IProjectsService projectsPageService)
        {
            _projectsPageService = projectsPageService;
        }

        /// <summary>
        /// Точка для удаления проекта
        /// </summary>
        /// <param name="id"> Id проекта </param>
        /// <returns></returns>
        [HttpPost("DeleteProject/{id}")]
        [Authorize(Roles = "WineMaker")]
        public async Task<bool> DeleteProject(int id)
        {
            return await _projectsPageService.DeleteProjectAsync(id);
        }

        /// <summary>
        /// Точка для изменения имени проекта
        /// </summary>
        /// <param name="model"> Модель с id проекта и новым именем </param>
        /// <returns></returns>
        [HttpPost("ChangeProjectName")]
        [Authorize(Roles = "WineMaker")]
        public async Task<bool> ChangeProjectName([FromBody] ChangeProjectModelNameRequest model)
        {
            return await _projectsPageService.ChangeProjectNameAsync(model.Id, model.NewProjectName);
        }

        /// <summary>
        /// Точка для изменения имени проекта
        /// </summary>
        /// <param name="model"> Модель с id проекта и новым именем </param>
        /// <returns></returns>
        [HttpPost("GetProjects")]
        [Authorize(Roles = "WineMaker")]
        public async Task<IEnumerable<ProjectResponse>> GetProjects()
        {
            return await _projectsPageService.GetListProjectsAsync();
        }

        /// <summary>
        /// Создание таймлайна по всем параметрам
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("CreateTimeLineByAllParams")]
        [Authorize(Roles = "WineMaker")]
        public async Task<CreateProjectResponse> CreateTimeLineByAllParams([FromBody] CreateProjectModelByAllParams model)
        {
            return await _projectsPageService.CreateTimeLineByAllParamsAsync(model);
        }

        /// <summary>
        /// Создание таймлайна по показанию ареометра
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("CreateTimeLineByAreometer")]
        [Authorize(Roles = "WineMaker")]
        public async Task<CreateProjectResponse> CreateTimeLineByAllParams([FromBody] CreateProjectModelByAreometer model)
        {
            return await _projectsPageService.CreateTimeLineByAreometerAsync(model);
        }

        /// <summary>
        /// Создание таймлайна по сорту винограда
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("CreateTimeLineByGrapeVarety")]
        [Authorize(Roles = "WineMaker")]
        public async Task<CreateProjectResponse> CreateTimeLineByAllParams([FromBody] CreateProjectModelByGrapeVarety model)
        {
            return await _projectsPageService.CreateTimeLineByGrapeVaretyAsync(model);
        }

        /// <summary>
        /// Получить список сортов винограда
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetGrapeVarieties")]
        [Authorize(Roles = "WineMaker")]
        public async Task<IEnumerable<string>> GetGrapeVarieties()
        {
            return await _projectsPageService.GetGrapeVarietiesAsync();
        }
    }
}
