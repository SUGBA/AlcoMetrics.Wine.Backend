using System.Text.Json.Serialization;

namespace WebApp.Models.Response.TimeLineDay
{
    /// <summary>
    /// Модель итоговых показателей, после принятия события
    /// </summary>
    public class ResultEventIndicatorsResponse
    {
        /// <summary>
        /// Содержание сахара
        /// </summary>
        [JsonPropertyName("SuagrValue")]
        public double SuagrValue { get; set; }

        /// <summary>
        /// Содержание спирта
        /// </summary>
        [JsonPropertyName("EthanolValue")]
        public double EthanolValue { get; set; }

        /// <summary>
        /// Объем
        /// </summary>
        [JsonPropertyName("WortValue")]
        public double WortValue { get; set; }
    }
}
