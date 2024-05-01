using Core.Models.WineRealizations;

namespace DataBase.EF.ConnectionFroWine.Repository
{
    /// <summary>
    /// Репозиторий для модуля TimeLineDayService
    /// </summary>
    public interface ITimeLineDayServiceRepository
    {
        /// <summary>
        /// Получить день с показателями
        /// </summary>
        /// <param name="dayId"> Id выбранного дня </param>
        /// <param name="userId"> Id текущего пользователя </param>
        /// <returns></returns>
        Task<WineDay?> GetDayWithIndicatorsAndTimeLineAsync(int dayId, int userId);

        /// <summary>
        /// Получить день с мероприятиями
        /// </summary>
        /// <param name="dayId"> Id выбранного дня </param>
        /// <param name="userId"> Id текущего пользователя </param>
        /// <returns></returns>
        Task<IEnumerable<WineEvent>?> GetEventsWithDayAndTimeLineAsync(int dayId, int userId);

        /// <summary>
        /// Обновить список дней
        /// </summary>
        /// <param name="days"> Новый список дней </param>
        /// <param name="timeLineId"> Id таймлайна </param>
        /// <returns></returns>
        Task UpdateDaysAsync(List<WineDay> days, int timeLineId);

        /// <summary>
        /// Получить список дней с показателями
        /// </summary>
        /// <param name="timeLineId"> id проекта </param>
        /// <returns></returns>
        Task<IEnumerable<WineDay>> GetDaysWithIndicatorsAsync(int timeLineId);
    }
}
