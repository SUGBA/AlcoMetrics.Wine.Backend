using UnitsNet.Units;
using UnitsNet;
using Core.Actions.Abstractions.CalculatorUnitsMeasurement;

namespace Core.Actions.ShareRealizations.CalculatorUnitsMeasurement
{
    /// <summary>
    /// Перевести из Кг в Г
    /// </summary>
    public class KilogramToGramCalculator : IBaseCalculator
    {
        public double Calculate(double fromValue)
        {
            return UnitConverter.Convert(fromValue, MassUnit.Kilogram, MassUnit.Gram);
        }
    }
}
