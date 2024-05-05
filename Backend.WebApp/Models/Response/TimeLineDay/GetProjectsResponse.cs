using System.Text.Json.Serialization;

namespace WebApp.Models.Response.TimeLineDay
{
    /// <summary>
    /// Ответ на запрос о получении списка проектов
    /// </summary>
    public class GetProjectsResponse
    {
        /// <summary>
        /// Id проекта
        /// </summary>
        [JsonPropertyName("ProjectId")]
        public int ProjectId { get; set; }

        /// <summary>
        /// Имя проекта
        /// </summary>
        [JsonPropertyName("ProjectName")]
        public string ProjectName { get; set; } = string.Empty;
    }
}
