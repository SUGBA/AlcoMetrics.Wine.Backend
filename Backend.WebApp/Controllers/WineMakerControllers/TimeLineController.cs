using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Controllers.Base;
using WebApp.Models.Response.TimeLine;
using WebApp.UseCases.TImeLine.Abstract;

namespace WebApp.Controllers.WineMakerControllers
{
    /// <summary>
    /// Контроллер для работы с модулем TimeLine
    /// </summary>
    [Route("TimeLine")]
    public class TimeLineController : BaseWineController
    {
        private readonly ITimeLineService _timeLineService;

        public TimeLineController(ITimeLineService timeLineService)
        {
            _timeLineService = timeLineService;
        }

        /// <summary>
        /// Получить список дней конкретного TimeLine'a
        /// </summary>
        /// <param name="projectId"> Id таймлайна </param>
        /// <returns></returns>
        [HttpGet("GetDays/{projectId:int}")]
        [Authorize(Roles = "WineMaker")]
        public async Task<IEnumerable<DayIndicatorsResponse>?> GetDays(int projectId)
        {
            return await _timeLineService.GetProjectDays(projectId);
        }
    }
}
