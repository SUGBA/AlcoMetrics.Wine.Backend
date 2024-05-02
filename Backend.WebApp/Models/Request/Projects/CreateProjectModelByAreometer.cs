using System.Text.Json.Serialization;

namespace WebApp.Models.Request.Projects
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
        public int AreometerValue { get; set; }
    }
}
