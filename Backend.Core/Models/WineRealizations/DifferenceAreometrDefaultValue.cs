using Core.Models.Abstractions;

namespace Core.Models.WineRealizations
{
    /// <summary>
    /// Показания сусла посредством сравнения начального и конечного состояния
    /// </summary>
    public class DifferenceAreometrDefaultValue : BaseEntity
    {
        /// <summary>
        /// Показания Ареометра: (areometerStartValue - areometerCurrentValue)*1000
        /// </summary>
        public int DifferenceAreometerValue { get; set; }

        /// <summary>
        /// Содержание сахара: г/100см^3
        /// </summary>
        public double SugarValue { get; set; }

        /// <summary>
        /// Содержание алкоголя в %
        /// </summary>
        public double EthanolValue { get; set; }
    }
}
