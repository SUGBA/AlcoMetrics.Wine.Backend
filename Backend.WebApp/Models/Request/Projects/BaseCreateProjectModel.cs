using System.Text.Json.Serialization;

namespace WebApp.Models.Request.Projects
{
    /// <summary>
    /// Базовая модель для создания проекта
    /// </summary>
    public abstract class BaseCreateProjectModel
    {
        /// <summary>
        /// Наименование проекта
        /// </summary>
        [JsonPropertyName("ProjectName")]
        public string ProjectName { get; set; } = string.Empty;

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
        /// Объем сусла
        /// </summary>
        [JsonPropertyName("Wort")]
        public float Wort { get; set; }
    }
}
