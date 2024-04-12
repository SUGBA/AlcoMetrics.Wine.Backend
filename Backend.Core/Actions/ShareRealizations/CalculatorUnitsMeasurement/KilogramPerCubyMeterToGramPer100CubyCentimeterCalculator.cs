using UnitsNet.Units;
using UnitsNet;
using Core.Actions.Abstractions.CalculatorUnitsMeasurement;

namespace Core.Actions.ShareRealizations.CalculatorUnitsMeasurement
{
    /// <summary>
    /// Перевести из Кг/м^3 в Г/100см^3
    /// </summary>
    public class KilogramPerCubyMeterToGramPer100CubyCentimeterCalculator : IBaseCalculator
    {
        public double Calculate(double fromValue)
        {
            return UnitConverter.Convert(fromValue, DensityUnit.KilogramPerCubicMeter, DensityUnit.GramPerCubicCentimeter) * 100;
        }
    }
}
