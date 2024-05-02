using System.Text.Json.Serialization;

namespace WebApp.Models.Request.TimeLineDay
{
    /// <summary>
    /// Модель добавления события шаптализация
    /// </summary>
    public class AddShaptalizationEvent
    {
        /// <summary>
        /// Желаемое содрежание сахара
        /// </summary>
        [JsonPropertyName("DesiredSugarValue")]
        public float DesiredSugarValue { get; set; }

        /// <summary>
        /// Id дня
        /// </summary>
        [JsonPropertyName("DayId")]
        public int DayId { get; set; }
    }
}
