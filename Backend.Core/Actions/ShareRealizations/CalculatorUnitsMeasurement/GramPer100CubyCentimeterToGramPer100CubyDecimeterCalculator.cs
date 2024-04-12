using Core.Actions.Abstractions.CalculatorUnitsMeasurement;

namespace Core.Actions.ShareRealizations.CalculatorUnitsMeasurement
{
    /// <summary>
    /// Перевести из Г/100см^3 в Г/100дм^3
    /// </summary>
    public class GramPer100CubyCentimeterToGramPer100CubyDecimeterCalculator : IBaseCalculator
    {
        private const double MILTIPLICATION_FACTOR = 1000;
        public double Calculate(double fromValue)
        {
            return MILTIPLICATION_FACTOR * fromValue;   //для перевода из Г/100см^3 в Г/100дм^3 нужно искомую величину умножить на 1000
        }
    }
}
