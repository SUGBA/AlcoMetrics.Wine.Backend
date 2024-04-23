using System.Text.Json.Serialization;

namespace WebApp.Models.Response.ProjectsPage
{
    /// <summary>
    /// Модель ответа при создании проекта
    /// </summary>
    public class CreateProjectResponse
    {
        /// <summary>
        /// Созданный проект в случае успеха
        /// </summary>
        [JsonPropertyName("CreatedProject")]
        public ProjectResponse? CreatedProject { get; set; }

        /// <summary>
        /// Ошибка в случае неуспеха
        /// </summary>
        [JsonPropertyName("Error")]
        public string? Error { get; set; }
    }
}
