using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApp.Models.Request.TimeLineDay
{
    /// <summary>
    /// Обновление показателей путем ввода всех параметров
    /// </summary>
    public class UpdateIndicatorsByAllParam
    {
        /// <summary>
        /// Объем
        /// </summary>
        [JsonPropertyName("Wort")]
        public double Wort { get; set; }

        /// <summary>
        /// Процент алкоголя
        /// </summary>
        [JsonPropertyName("AlcoholPercentage")]
        public double AlcoholPercentage { get; set; }

        /// <summary>
        /// Содержание сахара
        /// </summary>
        [JsonPropertyName("SugarValue")]
        public double SugarValue { get; set; }

        /// <summary>
        /// Id выбранного дня
        /// </summary>
        [JsonPropertyName("DayId")]
        public int DayId { get; set; }
    }
}
