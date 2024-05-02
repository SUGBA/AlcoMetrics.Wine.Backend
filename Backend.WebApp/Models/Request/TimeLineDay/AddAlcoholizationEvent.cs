using System.Text.Json.Serialization;

namespace WebApp.Models.Request.TimeLineDay
{
    /// <summary>
    /// Модель для создания события крепления
    /// </summary>
    public class AddAlcoholizationEvent
    {
        /// <summary>
        /// Желаемое содержание алкоголя
        /// </summary>
        [JsonPropertyName("DesiredAlcoholValue")]
        public float DesiredAlcoholValue { get; set; }

        /// <summary>
        /// Крепость спирта
        /// </summary>
        [JsonPropertyName("AlcoholValue")]
        public float AlcoholValue { get; set; }

        /// <summary>
        /// Id дня
        /// </summary>
        [JsonPropertyName("DayId")]
        public int DayId { get; set; }
    }
}
