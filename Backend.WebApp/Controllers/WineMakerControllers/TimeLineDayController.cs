using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Controllers.Base;
using WebApp.Models.Request.TimeLineDay;
using WebApp.Models.Response.TimeLineDay;
using WebApp.UseCases.TimeLineDay.Abstract;

namespace WebApp.Controllers.WineMakerControllers
{
    /// <summary>
    /// Контроллер модуля конкретного дня
    /// </summary>
    [Route("TimeLineDay")]
    public class TimeLineDayController : BaseWineController
    {
        private readonly ITimeLineDayService _timeLineDayService;

        public TimeLineDayController(ITimeLineDayService timeLineDayService)
        {
            _timeLineDayService = timeLineDayService;
        }

        /// <summary>
        /// Точка для получения показателя выбранного дня
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetIndicators/{dayId:int}")]
        [Authorize(Roles = "WineMaker")]
        public async Task<CurrentDayIndicatrosResponse?> GetIndicators(int dayId)
        {
            return await _timeLineDayService.GetCurrentDayIndicatorsAsync(dayId);
        }

        /// <summary>
        /// Точка для получения спсика мероприятий выбранного дня
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetEvents/{dayId:int}")]
        [Authorize(Roles = "WineMaker")]
        public async Task<IEnumerable<CurrentDayEventsResponse>?> GetEvents(int dayId)
        {
            return await _timeLineDayService.GetEventsAsync(dayId);
        }

        /// <summary>
        /// Точка для получения спсика мероприятий выбранного дня
        /// </summary>
        /// <returns></returns>
        [HttpPost("UpdateByAllParam")]
        [Authorize(Roles = "WineMaker")]
        public async Task<string?> UpdateByAllParam([FromBody] UpdateIndicatorsByAllParam model)
        {
            return await _timeLineDayService.UpdateDayIndicatorsByAllParamsAsync(model);
        }

        /// <summary>
        /// Точка для получения спсика мероприятий выбранного дня
        /// </summary>
        /// <returns></returns>
        [HttpPost("UpdateByAreometer")]
        [Authorize(Roles = "WineMaker")]
        public async Task<string?> UpdateByAreometer([FromBody] UpdateIndicatorsByAllAreometer model)
        {
            return await _timeLineDayService.UpdateDayIndicatorsByAreometerAsync(model);
        }

        /// <summary>
        /// Точка для добавления события крепления
        /// </summary>
        /// <returns></returns>
        [HttpPost("AddAlcoholizationEvent")]
        [Authorize(Roles = "WineMaker")]
        public async Task<CurrentDayEventsResponse?> AddAlcoholizationEvent([FromBody] AddAlcoholizationEvent model)
        {
            return await _timeLineDayService.AddAlcoholizationEventAsync(model);
        }

        /// <summary>
        /// Точка для добавления события шаптализации
        /// </summary>
        /// <returns></returns>
        [HttpPost("AddShaptalizationEvent")]
        [Authorize(Roles = "WineMaker")]
        public async Task<CurrentDayEventsResponse?> AddShaptalizationEvent([FromBody] AddShaptalizationEvent model)
        {
            return await _timeLineDayService.AddShaptalizationEventAsync(model);
        }

        /// <summary>
        /// Точка для добавления события купажирования по всем параметрам
        /// </summary>
        /// <returns></returns>
        [HttpPost("AddBlendingEventByAllParams")]
        [Authorize(Roles = "WineMaker")]
        public async Task<CurrentDayEventsResponse?> AddBlendingEventByAllParams([FromBody] AddBlendingEventByAllParams model)
        {
            return await _timeLineDayService.AddBlendingEventByAllParamsAsync(model);
        }

        /// <summary>
        /// Точка для добавления события купажирования по проекту
        /// </summary>
        /// <returns></returns>
        [HttpPost("AddBlendingEventByProject")]
        [Authorize(Roles = "WineMaker")]
        public async Task<CurrentDayEventsResponse?> AddBlendingEventByProject([FromBody] AddBlendingEventByProject model)
        {
            return await _timeLineDayService.AddBlendingEventByProjectAsync(model);
        }

        /// <summary>
        /// Точка для добавления события шаптализации
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetProjects/{currentProjectId:int}")]
        [Authorize(Roles = "WineMaker")]
        public async Task<IEnumerable<GetProjectsResponse>> GetProjects(int currentProjectId)
        {
            return await _timeLineDayService.GetProjectsAsync(currentProjectId);
        }

        /// <summary>
        /// Точка для удаления события
        /// </summary>
        /// <returns></returns>
        [HttpPost("RemoveEvent/{eventId:int}")]
        [Authorize(Roles = "WineMaker")]
        public async Task<bool> RemoveEvent(int eventId)
        {
            return await _timeLineDayService.DeleteEventAsync(eventId);
        }

        /// <summary>
        /// Точка для удаления события
        /// </summary>
        /// <returns></returns>
        [HttpPost("AcceptEvent/{eventId:int}")]
        [Authorize(Roles = "WineMaker")]
        public async Task<bool> AcceptEvent(int eventId)
        {
            return await _timeLineDayService.AcceptEventAsync(eventId);
        }
    }
}
