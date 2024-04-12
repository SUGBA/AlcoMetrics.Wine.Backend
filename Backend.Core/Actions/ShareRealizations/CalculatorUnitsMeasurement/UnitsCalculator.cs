using Core.Actions.Abstractions.CalculatorUnitsMeasurement;

namespace Core.Actions.ShareRealizations.CalculatorUnitsMeasurement
{
    public class UnitsCalculator : IBaseUnitsCalculator<MeasurementUnits>
    {
        /// <summary>
        /// Фабрика получения калькулятора
        /// </summary>
        private IBaseCalculatorFactory<MeasurementUnits> factory;

        public UnitsCalculator(IBaseCalculatorFactory<MeasurementUnits> factory)
        {
            this.factory = factory;
        }

        /// <summary>
        /// Перевести value из fromType в toType
        /// </summary>
        /// <param name="fromType"> Искомая единица измерения </param>
        /// <param name="toType"> Конечная единица измерения </param>
        /// <param name="value"> Значение </param>
        /// <returns></returns>
        public double Calculate(MeasurementUnits fromType, MeasurementUnits toType, double value)
        {
            IBaseCalculator calculator = factory.GetCalculator(fromType, toType);
            return calculator.Calculate(value);
        }
    }
}
