using System.Text.Json.Serialization;

namespace WebApp.Models.Request.ProjectsPage
{
    /// <summary>
    /// Модель создания проекта по показаниям ареометра
    /// </summary>
    public class CreateProjectModelByAreometer : BaseCreateProjectModel
    {
        /// <summary>
        /// Показания Ареометра
        /// </summary>
        [JsonPropertyName("AreometerValue")]
        public float? AreometerValue { get; set; }
    }
}
