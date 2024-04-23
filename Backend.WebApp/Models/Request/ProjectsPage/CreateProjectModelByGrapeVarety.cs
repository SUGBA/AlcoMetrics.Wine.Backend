using System.Text.Json.Serialization;

namespace WebApp.Models.Request.ProjectsPage
{
    /// <summary>
    /// Модель создания проекта по сорту винограда
    /// </summary>
    public class CreateProjectModelByGrapeVarety : BaseCreateProjectModel
    {
        /// <summary>
        /// Наименование сорта винограда
        /// </summary>
        [JsonPropertyName("GrapeName")]
        public string? GrapeName { get; set; } = null;
    }
}
