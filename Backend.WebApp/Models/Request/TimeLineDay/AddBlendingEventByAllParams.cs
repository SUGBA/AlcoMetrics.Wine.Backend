using System.Text.Json.Serialization;

namespace WebApp.Models.Request.TimeLineDay
{
    /// <summary>
    /// Модель для добавления события купажирования по всем параметрам
    /// </summary>
    public class AddBlendingEventByAllParams
    {
        /// <summary>
        /// Содержание алкоголя в купаже
        /// </summary>
        [JsonPropertyName("AlcoholValue")]
        public float AlcoholValue { get; set; }

        /// <summary>
        /// Содрежание сахара в купаже
        /// </summary>
        [JsonPropertyName("SugarValue")]
        public float SugarValue { get; set; }

        /// <summary>
        /// Желаемое содержание алкоголя
        /// </summary>
        [JsonPropertyName("DesiredAlcoholValue")]
        public float DesiredAlcoholValue { get; set; }

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
