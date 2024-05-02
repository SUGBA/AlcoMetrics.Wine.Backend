using System.Text.Json.Serialization;

namespace WebApp.Models.Request.Projects
{
    /// <summary>
    /// Модель изменения имени проекта
    /// </summary>
    public class ChangeProjectModelNameRequest
    {
        /// <summary>
        /// Id изменяемого проекта
        /// </summary>
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        /// <summary>
        /// Новое имя проекта
        /// </summary>
        [JsonPropertyName("ProjectName")]
        public string NewProjectName { get; set; } = string.Empty;
    }
}
