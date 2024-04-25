using System.Text.Json.Serialization;

namespace WebApp.Models.Response.TimeLine
{
    /// <summary>
    /// Моделька с показателями конкретного дня
    /// </summary>
    public class DayIndicatorsResponse
    {
        /// <summary>
        /// Id дня
        /// </summary>
        [JsonPropertyName("DayId")]
        public int DayId { get; set; }

        /// <summary>
        /// Номер дня
        /// </summary>
        [JsonPropertyName("DayNumber")]
        public byte DayNumber { get; set; }

        /// <summary>
        /// Месяц
        /// </summary>
        [JsonPropertyName("Month")]
        public string Month { get; set; } = string.Empty;

        /// <summary>
        /// Содержание спирта
        /// </summary>
        [JsonPropertyName("EthanolValue")]
        public float EthanolValue { get; set; }

        /// <summary>
        /// Содержание сахара
        /// </summary>
        [JsonPropertyName("SugarValue")]
        public float SugarValue { get; set; }

        /// <summary>
        /// Количество событий
        /// </summary>
        [JsonPropertyName("EventCount")]
        public int EventCount { get; set; }
    }
}
