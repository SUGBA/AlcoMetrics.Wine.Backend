using Core.Actions.Abstractions.CalculatorUnitsMeasurement;

namespace Core.Actions.ShareRealizations.CalculatorUnitsMeasurement
{
    /// <summary>
    /// Перевести из Г/л в Г/100дм^3
    /// </summary>
    public class GramPerLiterToGramPer100CubicDecimeterCalculator : IBaseCalculator
    {
        private const double MILTIPLICATION_FACTOR = 100;

        public double Calculate(double fromValue)
        {
            return MILTIPLICATION_FACTOR * fromValue;       //Для перевода из Г/л в Г/100дм^3, необходимо домножить на 100
        }
    }
}
