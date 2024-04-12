using Core.Models.Abstractions;

namespace Core.Models.WineRealizations
{
    /// <summary>
    /// Показатели вина
    /// </summary>
    public class WineIndicator : BaseIndicator
    {
        /// <summary>
        /// Объем
        /// </summary>
        public double WortValue { get; set; }

        /// <summary>
        /// Показатели сахара: г/Л
        /// </summary>
        public double SugarValue { get; set; }

        /// <summary>
        /// Содержание азота: Милиграмм/Литр
        /// </summary>
        public double NitrogenValue { get; set; }

        /// <summary>
        /// Содержание дрожжей: Милиграмм/Литр
        /// </summary>
        public double YeastValue { get; set; }
    }
}
