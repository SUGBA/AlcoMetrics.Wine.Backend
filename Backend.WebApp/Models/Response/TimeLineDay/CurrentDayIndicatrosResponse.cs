using System.Text.Json.Serialization;

namespace WebApp.Models.Response.TimeLineDay
{
    /// <summary>
    /// Показатели конкретного дня для формирования карточек
    /// </summary>
    public class CurrentDayIndicatrosResponse
    {
        /// <summary>
        /// Текущая дата
        /// </summary>
        [JsonPropertyName("CurrentDateTime")]
        public DateTime CurrentDateTime { get; set; }

        /// <summary>
        /// Содержание алкоголя в %
        /// </summary>
        [JsonPropertyName("EthanolValue")]
        public double EthanolValue { get; set; }

        /// <summary>
        /// Содержание сахара в Г./Л.
        /// </summary>
        [JsonPropertyName("SugarValue")]
        public double SugarValue { get; set; }

        /// <summary>
        /// Объем сусла
        /// </summary>
        [JsonPropertyName("Wort")]
        public double Wort { get; set; }
    }
}
