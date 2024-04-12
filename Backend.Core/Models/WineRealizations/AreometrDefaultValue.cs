using Core.Models.Abstractions;

namespace Core.Models.WineRealizations
{
    /// <summary>
    /// Таблица перевода Ареометер <-> Содержание сахара
    /// </summary>
    public class AreometrDefaultValue : BaseEntity
    {
        /// <summary>
        /// Показания Ареометра: кг/м^3
        /// </summary>
        public int AreometerValue { get; set; }

        /// <summary>
        /// Содержание сахара: г/100см^3
        /// </summary>
        public double SugarValue { get; set; }
    }
}
