using System.Text.Json.Serialization;

namespace WebApp.Models.Request.TimeLineDay
{
    /// <summary>
    /// Обновление показателей путем ввода значения ареометра
    /// </summary>
    public class UpdateIndicatorsByAllAreometer
    {
        /// <summary>
        /// Показание ареометра
        /// </summary>
        [JsonPropertyName("AreometerValue")]
        public int AreometerValue { get; set; }

        /// <summary>
        /// Id выбранного дня
        /// </summary>
        [JsonPropertyName("DayId")]
        public int DayId { get; set; }
    }
}
