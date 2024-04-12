using Core.Actions.Abstractions.CalculatorUnitsMeasurement;
using Core.Actions.Abstractions.CurrentIndicatorsCalculator;
using Core.Actions.ShareRealizations.CalculatorUnitsMeasurement;
using Core.Models.WineRealizations;
using Core.Models.WineRealizations.Enums;

namespace Core.Actions.WineRealizations.WineCurrentIndicatorsCalculator
{
    public class WineCurrentIndicatorCalculatorWorker : BaseCurrentIndicatorCalculatorWorker<UpdateIndicatorTypes, WineIndicator>
    {
        public WineCurrentIndicatorCalculatorWorker(IBaseUnitsCalculator<MeasurementUnits> unitsCalculator,
            IBaseCurrentIndicatorsCalculatorFactory<UpdateIndicatorTypes, WineIndicator> indicatorCalculatorFactory) :
            base(unitsCalculator, indicatorCalculatorFactory)
        {
        }

        protected override WineIndicator? CorrectResult(WineIndicator indicator)
        {
            var convertedSugarValue = unitsCalculator.Calculate(MeasurementUnits.GramPer100CubicCentimeter, MeasurementUnits.GramPerLiter, indicator.SugarValue);
            if (convertedSugarValue == null) return indicator;

            indicator.SugarValue = (double)convertedSugarValue;

            return indicator;
        }
    }
}
