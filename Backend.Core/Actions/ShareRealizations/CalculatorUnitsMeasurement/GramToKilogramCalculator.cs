using Core.Actions.Abstractions.CalculatorUnitsMeasurement;
using UnitsNet;
using UnitsNet.Units;

namespace Core.Actions.ShareRealizations.CalculatorUnitsMeasurement
{
    /// <summary>
    /// Перевести из Г в Кг
    /// </summary>
    public class GramToKilogramCalculator : IBaseCalculator
    {
        public double Calculate(double fromValue)
        {
            return UnitConverter.Convert(fromValue, MassUnit.Gram, MassUnit.Kilogram);
        }
    }
}
