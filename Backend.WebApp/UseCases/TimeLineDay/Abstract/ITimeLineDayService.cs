using WebApp.Models.Request.TimeLineDay;
using WebApp.Models.Response.TimeLineDay;

namespace WebApp.UseCases.TimeLineDay.Abstract
{
    /// <summary>
    /// Сервис для работы с контроллером TimeLineController
    /// </summary>
    public interface ITimeLineDayService
    {
        /// <summary>
        /// Получить показатели выбранного дня
        /// </summary>
        /// <param name="dayId"> Id выбранного дня </param>
        /// <returns></returns>
        Task<CurrentDayIndicatrosResponse?> GetCurrentDayIndicatorsAsync(int dayId);

        /// <summary>
        /// Получить список мероприятий выбранного дня
        /// </summary>
        /// <param name="dayId"> Id выбранного дня </param>
        /// <returns></returns>
        Task<IEnumerable<CurrentDayEventsResponse>?> GetEventsAsync(int dayId);

        /// <summary>
        /// Актуализировать значения текущего дня путем ввода всех параметров
        /// </summary>
        /// <param name="model"> Модель со всеми параметрами и id дня </param>
        /// <returns></returns>
        Task<string?> UpdateDayIndicatorsByAllParamsAsync(UpdateIndicatorsByAllParam model);

        /// <summary>
        /// Актуализировать значения текущего дня путем ввода текущих показаний ареометра
        /// </summary>
        /// <param name="model"> Модель с показаниями ареометра и id дня </param>
        /// <returns></returns>
        Task<string?> UpdateDayIndicatorsByAreometerAsync(UpdateIndicatorsByAllAreometer model);

        /// <summary>
        /// Добавить событие крепления вина
        /// </summary>
        /// <param name="request"> Модель с желаемыми показателями и крепостью спирта </param>
        /// <returns></returns>
        Task<CurrentDayEventsResponse?> AddAlcoholizationEventAsync(AddAlcoholizationEvent request);

        /// <summary>
        /// Добавить событие шаптализации
        /// </summary>
        /// <param name="request"> Модель с желаемыми показателями </param>
        /// <returns></returns>
        Task<CurrentDayEventsResponse?> AddShaptalizationEventAsync(AddShaptalizationEvent request);

        /// <summary>
        /// Добавить событие купажирования, по заданным параметрам
        /// </summary>
        /// <param name="request"> данные о купаже и желаемых показателях </param>
        /// <returns></returns>
        Task<CurrentDayEventsResponse?> AddBlendingEventByAllParamsAsync(AddBlendingEventByAllParams request);

        /// <summary>
        /// Добавить событие купажирования, по выбранному проекту
        /// </summary>
        /// <param name="request"> данные о купаже и желаемых показателях </param>
        /// <returns></returns>
        Task<CurrentDayEventsResponse?> AddBlendingEventByProjectAsync(AddBlendingEventByProject request);
    }
}
