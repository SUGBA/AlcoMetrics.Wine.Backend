using Core.Models.Abstractions;

namespace Core.Models.WineRealizations
{
    /// <summary>
    /// Показатели сорта винограда
    /// </summary>
    public class GrapeVariety : BaseEntity
    {
        /// <summary>
        /// Название сорта винограда
        /// </summary>
        public string GrapeVarietyName { get; set; }

        /// <summary>
        /// Содержание сахара: г/100см^3
        /// </summary>
        public double SugarValue { get; set; }

        /// <summary>
        /// Кислотность сорта винограда: г/дм^3
        /// </summary>
        public double AcidValue { get; set; }
    }
}
