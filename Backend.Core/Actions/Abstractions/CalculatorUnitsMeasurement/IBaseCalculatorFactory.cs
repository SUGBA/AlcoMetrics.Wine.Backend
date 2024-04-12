namespace Core.Actions.Abstractions.CalculatorUnitsMeasurement
{
    /// <summary>
    /// Фабрика получения калькуляторов систем счислений
    /// </summary>
    /// <typeparam name="T"> enum с описанием единиц измерения </typeparam>
    public interface IBaseCalculatorFactory<T> where T : Enum
    {
        /// <summary>
        /// Получить калькулятор переводящий из fromType в toType
        /// </summary>
        /// <param name="fromType"> Из чего переводить </param>
        /// <param name="toType"> Во что переводить </param>
        /// <returns></returns>
        public IBaseCalculator GetCalculator(T fromType, T toType);
    }
}
