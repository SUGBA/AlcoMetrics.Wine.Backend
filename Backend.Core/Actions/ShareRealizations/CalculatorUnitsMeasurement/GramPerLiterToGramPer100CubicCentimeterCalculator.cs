using UnitsNet.Units;
using UnitsNet;
using Core.Actions.Abstractions.CalculatorUnitsMeasurement;

namespace Core.Actions.ShareRealizations.CalculatorUnitsMeasurement
{
    /// <summary>
    /// Перевести из Г/л в Г/100см^3
    /// </summary>
    public class GramPerLiterToGramPer100CubicCentimeterCalculator : IBaseCalculator
    {
        public double Calculate(double fromValue)
        {
            return UnitConverter.Convert(fromValue, DensityUnit.GramPerLiter, DensityUnit.GramPerCubicCentimeter) * 100;
        }
    }
}
