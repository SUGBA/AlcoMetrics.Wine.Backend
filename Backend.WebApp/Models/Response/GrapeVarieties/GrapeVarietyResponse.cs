using System.Text.Json.Serialization;

namespace WebApp.Models.Response.GrapeVarieties
{
    /// <summary>
    /// Модель сорта винограда
    /// </summary>
    public class GrapeVarietyResponse
    {
        /// <summary>
        /// Идентификатор записи о сорте винограда
        /// </summary>
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        /// <summary>
        /// Название сорта винограда
        /// </summary>
        [JsonPropertyName("GrapeVarietyName")]
        public string GrapeVarietyName { get; set; } = string.Empty;

        /// <summary>
        /// Содержание сахара: г/100см^3
        /// </summary>
        [JsonPropertyName("SugarValue")]
        public double SugarValue { get; set; }

        /// <summary>
        /// Кислотность сорта винограда: г/дм^3
        /// </summary>
        [JsonPropertyName("AcidValue")]
        public double AcidValue { get; set; }
    }
}
