using System.Text.Json.Serialization;

namespace WebApp.Models.Request.Projects
{
    /// <summary>
    /// Модель для создания таймлайна вводом всех параметров
    /// </summary>
    public class CreateProjectModelByAllParams : BaseCreateProjectModel
    {
        /// <summary>
        /// Содержание алкоголя
        /// </summary>
        [JsonPropertyName("AlcoholValue")]
        public float AlcoholValue { get; set; }

        /// <summary>
        /// Содрежание сахара
        /// </summary>
        [JsonPropertyName("SugarValue")]
        public float SugarValue { get; set; }
    }
}
