using Core.Actions.Abstractions.CalculatorUnitsMeasurement;
using Core.Actions.Abstractions.EventCalculator;
using Core.Actions.ShareRealizations.CalculatorUnitsMeasurement;
using Core.Models.WineRealizations;

namespace Core.Actions.WineRealizations.WineEventCalculator
{
    /// <summary>
    /// Фабрика получения события для виноделия
    /// </summary>
    public class WineEventFactory : IBaseEventFactory<WineEventTypes, WineIndicator>
    {
        private IBaseUnitsCalculator<MeasurementUnits> unitsCalculator;

        public WineEventFactory(IBaseUnitsCalculator<MeasurementUnits> unitsCalculator)
        {
            this.unitsCalculator = unitsCalculator;
        }

        /// <summary>
        /// Фабрика выбора событий для виноделия
        /// </summary>
        /// <param name="eventType"> Тип события </param>
        /// <param name="currentIndicator"> Текущие показатели </param>
        /// <param name="param"> Параметры </param>
        /// <returns></returns>
        public BaseEventCalculator<WineIndicator> GetEventCalculater(WineEventTypes eventType, WineIndicator currentIndicator, object[]? param = null)
        {
            switch (eventType)
            {
                case WineEventTypes.Shaptalization:
                    return new ShaptalizationEventCalculater(currentIndicator, unitsCalculator);
                case WineEventTypes.Blending:
                    if (param is not null && param.Count() == 2 && param[0] is WineIndicator && param[1] is BasedSubstanceType)
                        return new BlendingEventCalculater(currentIndicator, (WineIndicator)param[0], (BasedSubstanceType)param[1], unitsCalculator);
                    throw new Exception("Некорректные параметры");
                case WineEventTypes.Alcoholization:
                    return new AlcoholizationEventCalculater(currentIndicator);
                default:
                    throw new Exception("Несущесвтующий тип события");
            }
        }
    }
}
