using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApp.Models.Request.TimeLineDay
{
    /// <summary>
    /// Модель добавления события купажирования путем выбора проекта
    /// </summary>
    public class AddBlendingEventByProject
    {
        /// <summary>
        /// Id выбранного проекта
        /// </summary>
        [JsonPropertyName("SelectedProjectId")]
        public int SelectedProjectId { get; set; }

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
