using Core.Actions.Abstractions.CalculatorUnitsMeasurement;

namespace Core.Actions.ShareRealizations.CalculatorUnitsMeasurement
{
    /// <summary>
    /// Перевести из % в Г/Л
    /// </summary>
    public class PercentageToGramPerLiterCalculator : IBaseCalculator
    {
        private const double MILTIPLICATION_FACTOR = 10;

        public double Calculate(double fromValue)
        {
            return fromValue * MILTIPLICATION_FACTOR;       //Для перевода из % в Г/Л, необходимо домножить на 10
        }
    }
}
