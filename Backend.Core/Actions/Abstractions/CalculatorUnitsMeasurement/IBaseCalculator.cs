namespace Core.Actions.Abstractions.CalculatorUnitsMeasurement
{
    /// <summary>
    /// Калькулятор единиц измерений
    /// </summary>
    public interface IBaseCalculator
    {
        /// <summary>
        /// Перевести
        /// </summary>
        /// <param name="fromValue"> Переводимое значение </param>
        /// <returns></returns>
        public double Calculate(double fromValue);
    }
}
