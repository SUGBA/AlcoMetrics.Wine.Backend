using UnitsNet.Units;
using UnitsNet;
using Core.Actions.Abstractions.CalculatorUnitsMeasurement;

namespace Core.Actions.ShareRealizations.CalculatorUnitsMeasurement
{
    /// <summary>
    /// Перевести из Л в Мл
    /// </summary>
    public class LitersToMillilitersCalculator : IBaseCalculator
    {
        public double Calculate(double fromValue)
        {
            return UnitConverter.Convert(fromValue, VolumeUnit.Liter, VolumeUnit.Milliliter);
        }
    }
}
