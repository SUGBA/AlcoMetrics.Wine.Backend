using Core.Actions.Abstractions.CalculatorUnitsMeasurement;

namespace Core.Actions.ShareRealizations.CalculatorUnitsMeasurement
{
    /// <summary>
    /// Перевести из Г/100дм^3 в Кг/м^3
    /// </summary>
    public class GramPer100CubyDecimeterToKilogramPerCubyMeterCalculator : IBaseCalculator
    {
        private const double MILTIPLICATION_FACTOR = 0.01;

        public double Calculate(double fromValue)
        {
            return MILTIPLICATION_FACTOR * fromValue;       //Для перевод из Г/100дм^3 в Кг/м^3 необходимо домножить на 0.01
        }
    }
}
