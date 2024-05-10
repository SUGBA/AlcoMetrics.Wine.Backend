using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Controllers.Base;
using WebApp.Models.Response.GrapeVarieties;
using WebApp.UseCases.GrapeVarieties.Abstract;

namespace WebApp.Controllers.AdminControllers
{
    /// <summary>
    /// Контроллер для работы с модулем редактирования сортов винограда
    /// </summary>
    [Route("GrapeVariety")]
    public class GrapeVarietyController : BaseWineController
    {
        private readonly IGrapeVarietyService _service;

        public GrapeVarietyController(IGrapeVarietyService service)
        {
            _service = service;
        }

        /// <summary>
        /// Точка для получения списка сортов винограда, с показателями
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetGrapeVarieties")]
        [Authorize(Roles = "Admin")]
        public async Task<List<GrapeVarietyResponse>> GetGrapeVarieties()
        {
            return await _service.GetGrapeVarietiesAsync();
        }

        /// <summary>
        /// Точка для редактирования существующего сорта винограда
        /// </summary>
        /// <param name="updatedModel"> Обновленная модель </param>
        /// <returns></returns>
        [HttpPost("UpdateGrapeVariety")]
        [Authorize(Roles = "Admin")]
        public async Task<bool> UpdateGrapeVariety([FromBody] GrapeVarietyResponse updatedModel)
        {
            return await _service.UpdateGrapeVarietyAsync(updatedModel);
        }

        /// <summary>
        /// Точка для добавления нового сорта винограда
        /// </summary>
        /// <param name="updatedModel"> Новая модель </param>
        /// <returns></returns>
        [HttpPost("AddGrapeVariety")]
        [Authorize(Roles = "Admin")]
        public async Task<GrapeVarietyResponse> AddGrapeVariety([FromBody] GrapeVarietyResponse updatedModel)
        {
            return await _service.AddGrapeVarietyAsync(updatedModel);
        }

        /// <summary>
        /// Точка для удаления сорта винограда
        /// </summary>
        /// <param name="id"> Id удаляемого сорта </param>
        /// <returns></returns>
        [HttpPost("RemoveGrapeVariety/{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<bool> RemoveGrapeVariety(int id)
        {
            return await _service.RemoveGrapeVarietyAsync(id);
        }
    }
}
