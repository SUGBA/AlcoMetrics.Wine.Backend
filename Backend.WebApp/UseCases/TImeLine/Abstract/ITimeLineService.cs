using WebApp.Models.Response.TimeLine;

namespace WebApp.UseCases.TImeLine.Abstract
{
    /// <summary>
    /// Сервис для работы с модулем списка дней таймлайна
    /// </summary>
    public interface ITimeLineService
    {
        /// <summary>
        /// Получить список дней проекта
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<IEnumerable<DayIndicatorsResponse>?> GetProjectDays(int projectId);
    }
}
