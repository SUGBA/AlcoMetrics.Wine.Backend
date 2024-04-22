using System.Text.Json.Serialization;

namespace WebApp.Models.Request.ProjectsPage
{
    /// <summary>
    /// Модель изменения имени проекта
    /// </summary>
    public class ChangeProjectNameRequest
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
