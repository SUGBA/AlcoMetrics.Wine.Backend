using Core.Actions.Abstractions.TImeLineIndicatorConverter;
using Core.Actions.Abstractions.CalculatorUnitsMeasurement;
using Core.Actions.Abstractions.DataBaseConnector;
using Core.Actions.ShareRealizations.CalculatorUnitsMeasurement;
using Core.Models.WineRealizations;
using Core.Models.WineRealizations.Enums;

namespace Core.Actions.WineRealizations.WineIndicatorConverter
{
    /// <summary>
    /// Фабрика для выбора IIndicatorConverter
    /// Поскольку для каждого IIndicatorConverter нужны параметры разных типов, на фабрику подавался enum с типом и object который потом парсился
    /// </summary>
    public class WineIndicatorConverterFactory : IIndicatorConverterFactory<InitialIndicatorTypes, WineIndicator>
    {
        private readonly IBaseGenericRepository<AreometrDefaultValue> areometrRepository;
        private readonly IBaseGenericRepository<GrapeVariety> grapeVarietyRepository;
        private readonly IBaseUnitsCalculator<MeasurementUnits> unitsCalculator;

        public WineIndicatorConverterFactory(
            IBaseGenericRepository<AreometrDefaultValue> _areometrRepository,
            IBaseGenericRepository<GrapeVariety> _grapeVarietyRepository,
            IBaseUnitsCalculator<MeasurementUnits> unitsCalculator)
        {
            this.areometrRepository = _areometrRepository;
            this.grapeVarietyRepository = _grapeVarietyRepository;
            this.unitsCalculator = unitsCalculator;
        }
        public IIndicatorConverter<WineIndicator>? GetIndicatorConverter(InitialIndicatorTypes type, object param)
        {
            switch (type)
            {
                case InitialIndicatorTypes.ByAreometr:
                    if (param is int) return new ByAreometerIndicatorConverter((int)param, areometrRepository, unitsCalculator);
                    throw new Exception("Некорректные параметры");
                case InitialIndicatorTypes.ByGrapeVariety:
                    if (param is string) return new ByGrapeVarietyIndicatorConverter((string)param, grapeVarietyRepository, unitsCalculator);
                    throw new Exception("Некорректные параметры");
                default:
                    throw new Exception("Некорректный способ получения начальных показателей");
            }
        }
    }
}
