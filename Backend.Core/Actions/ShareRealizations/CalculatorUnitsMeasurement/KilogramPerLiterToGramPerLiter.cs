using Core.Actions.Abstractions.CalculatorUnitsMeasurement;
using UnitsNet;
using UnitsNet.Units;

namespace Core.Actions.ShareRealizations.CalculatorUnitsMeasurement
{
    /// <summary>
    /// Перевести из Кг/Л в Г/л
    /// </summary>
    public class KilogramPerLiterToGramPerLiter : IBaseCalculator
    {
        public double Calculate(double fromValue)
        {
            return UnitConverter.Convert(fromValue, DensityUnit.KilogramPerLiter, DensityUnit.GramPerLiter);
        }
    }
}
