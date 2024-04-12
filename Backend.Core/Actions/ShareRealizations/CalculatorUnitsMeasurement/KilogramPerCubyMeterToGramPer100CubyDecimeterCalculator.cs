using Core.Actions.Abstractions.CalculatorUnitsMeasurement;

namespace Core.Actions.ShareRealizations.CalculatorUnitsMeasurement
{
    /// <summary>
    /// Перевести из Кг/м^3 в Г/100дм^3
    /// </summary>
    public class KilogramPerCubyMeterToGramPer100CubyDecimeterCalculator : IBaseCalculator
    {
        private const double MILTIPLICATION_FACTOR = 100;
        public double Calculate(double fromValue)
        {
            return MILTIPLICATION_FACTOR * fromValue;       //Для перевода из Кг/м^3 в Г/100дм^3, нужно добножить на 100
        }
    }
}
