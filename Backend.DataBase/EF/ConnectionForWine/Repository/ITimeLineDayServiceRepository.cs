using Core.Models.WineRealizations;

namespace DataBase.EF.ConnectionForWine.Repository
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
        Task<IEnumerable<WineEvent>?> GetEventsForTable(int dayId, int userId);

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

        /// <summary>
        /// Получить показатели выбранного дня
        /// </summary>
        /// <param name="dayId"> Id дня </param>
        /// <param name="userId"> Id пользователя </param>
        /// <returns></returns>
        Task<WineIndicator?> GetIndicatorAsync(int dayId, int userId);

        /// <summary>
        /// Получить типичное событие по enum
        /// </summary>
        /// <param name="typeEvent"> Тип события </param>
        /// <returns></returns>
        Task<WineTypicalEvent> GetTypicalEventAsync(WineEventTypes typeEvent);

        /// <summary>
        /// Добавить событие к определенному дню
        /// </summary>
        /// <param name="newEvent"> Добавляемое событие </param>
        /// <param name="dayId"> id дня </param>
        /// <returns></returns>
        Task AddEventAsync(WineEvent newEvent, int dayId);

        /// <summary>
        /// Получить список проектов пользователя
        /// </summary>
        /// <param name="userId"> id пользователя </param>
        /// <returns></returns>
        Task<IEnumerable<WineTimeLine>> GetProjectsAsync(int userId);

        /// <summary>
        /// Получить событие
        /// </summary>
        /// <param name="eventId"> Id события </param>
        /// <param name="userId"> Id пользователя </param>
        /// <returns></returns>
        Task<WineEvent?> GetDayForEventAcceptAsync(int eventId, int userId);

        /// <summary>
        /// Удалить мероприятие
        /// </summary>
        /// <param name="eventId"> Id события </param>
        /// <param name="userId"> Id пользователя </param>
        /// <returns></returns>
        Task<bool> DeleteEventAsync(int eventId, int userId);

        /// <summary>
        /// Обновить день
        /// </summary>
        /// <param name="day"> Обновленный день </param>
        /// <returns></returns>
        Task UpdateDayAsync(WineDay day);
    }
}
