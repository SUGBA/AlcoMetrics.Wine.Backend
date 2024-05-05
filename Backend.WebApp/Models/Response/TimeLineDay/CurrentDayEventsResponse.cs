using System.Text.Json.Serialization;
using Core.Models.Abstractions;
using WebApp.Extensions;

namespace WebApp.Models.Response.TimeLineDay
{
    /// <summary>
    /// Список мероприятий в выбранном дне, для таблицы в модуле конкретный день
    /// </summary>
    public class CurrentDayEventsResponse
    {
        /// <summary>
        /// Id мероприятия
        /// </summary>
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        /// <summary>
        /// Наименование мероприятия
        /// </summary>
        [JsonPropertyName("EventName")]
        public string EventName { get; set; } = string.Empty;

        /// <summary>
        /// Флаг завершонности мероприятия
        /// </summary>
        [JsonPropertyName("IsReady")]
        public bool IsReady { get; set; }

        /// <summary>
        /// Тип события Пользовательское/Системное
        /// </summary>
        [JsonPropertyName("Type")]
        public string Type { get; set; } = EventCustomTypes.System.ToStringFormat();

        /// <summary>
        /// Список ингридиентов для выполнения данного события
        /// </summary>
        [JsonPropertyName("Ingridients")]
        public List<string> Ingridients { get; set; } = new();

        /// <summary>
        /// Показатели которые будут после принятия мероприятия
        /// </summary>
        [JsonPropertyName("Indicators")]
        public ResultEventIndicatorsResponse Indicators { get; set; } = new();
    }
}
