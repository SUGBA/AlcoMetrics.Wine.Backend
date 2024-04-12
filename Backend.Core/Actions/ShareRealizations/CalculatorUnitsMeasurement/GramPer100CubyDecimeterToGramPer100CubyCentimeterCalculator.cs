using Core.Actions.Abstractions.CalculatorUnitsMeasurement;

namespace Core.Actions.ShareRealizations.CalculatorUnitsMeasurement
{
    /// <summary>
    /// Перевести из Г/100дм^3 в Г/100см^3
    /// </summary>
    public class GramPer100CubyDecimeterToGramPer100CubyCentimeterCalculator : IBaseCalculator
    {
        private const double MILTIPLICATION_FACTOR = 0.001;

        public double Calculate(double fromValue)
        {
            return MILTIPLICATION_FACTOR * fromValue;       //Для перевода из Г/100дм^3 в Г/100см^3 на 0.001
        }
    }
}
