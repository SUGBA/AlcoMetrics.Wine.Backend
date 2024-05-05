using Core.Models.WineRealizations;
using DataBase.EF.ConnectionForWine.Repository;
using WebApp.Models.Response.TimeLine;
using WebApp.UseCases.Base.Abstract;
using WebApp.UseCases.TImeLine.Abstract;

namespace WebApp.UseCases.TImeLine
{
    /// <summary>
    /// Имплементация сервиса работы с модулем списка дней проекта
    /// </summary>
    public class TimeLineService : BaseWineService, ITimeLineService
    {
        private readonly ITimeLineServiceRepository _timeLineServiceRepository;

        public TimeLineService(IHttpContextAccessor httpContextAccessor,
            ITimeLineServiceRepository timeLineServiceRepository) : base(httpContextAccessor)
        {
            _timeLineServiceRepository = timeLineServiceRepository;
        }

        /// <summary>
        /// Получить список дней проекта
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<DayIndicatorsResponse>?> GetProjectDays(int projectId)
        {
            var userId = GetUserId() ?? throw new Exception("Не удалось получить Id текущего пользователя, при получении списка дней проекта");
            var result = await _timeLineServiceRepository.GetDaysAsync(projectId, userId);
            return result?.Select(x => Map<WineDay, DayIndicatorsResponse>(x));
        }
    }
}
