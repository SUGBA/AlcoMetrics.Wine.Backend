using Core.Actions.Abstractions.CalculatorUnitsMeasurement;

namespace Core.Actions.ShareRealizations.CalculatorUnitsMeasurement
{
    /// <summary>
    /// Перевести из Г/л в % Алкоголя
    /// </summary>
    public class GramPerLiterToPercentageCaltulator : IBaseCalculator
    {
        private const double MILTIPLICATION_FACTOR = 0.1;

        public double Calculate(double fromValue)
        {
            return MILTIPLICATION_FACTOR * fromValue;       //Для перевода из Г/л в % Алкоголя, необходимо домножить на 0.1
        }
    }
}
