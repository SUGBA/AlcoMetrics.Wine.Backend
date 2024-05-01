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
    }
}
