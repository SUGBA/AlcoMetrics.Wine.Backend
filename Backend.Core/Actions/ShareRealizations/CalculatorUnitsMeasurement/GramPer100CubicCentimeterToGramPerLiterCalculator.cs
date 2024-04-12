using UnitsNet.Units;
using UnitsNet;
using Core.Actions.Abstractions.CalculatorUnitsMeasurement;

namespace Core.Actions.ShareRealizations.CalculatorUnitsMeasurement
{
    /// <summary>
    /// Перевести из Г/100см^3 в Г/л
    /// </summary>
    public class GramPer100CubicCentimeterToGramPerLiterCalculator : IBaseCalculator
    {
        public double Calculate(double fromValue)
        {
            return UnitConverter.Convert(fromValue, DensityUnit.GramPerCubicCentimeter, DensityUnit.GramPerLiter) / 100;
        }
    }
}
