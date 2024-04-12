using Core.Actions.Abstractions.CalculatorUnitsMeasurement;

namespace Core.Actions.ShareRealizations.CalculatorUnitsMeasurement
{
    /// <summary>
    /// Перевести из Г/100дм^3 в Г/л
    /// </summary>
    public class GramPer100CubicDecimeterToGramPerLiterCalculator : IBaseCalculator
    {
        private const double MILTIPLICATION_FACTOR = 0.01;

        public double Calculate(double fromValue)
        {
            return MILTIPLICATION_FACTOR * fromValue;       //Для перевода из Г/дм^3 в Г/л, необходимо домножить на 0.01
        }
    }
}
