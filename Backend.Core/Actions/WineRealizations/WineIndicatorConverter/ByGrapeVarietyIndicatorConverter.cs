using Core.Actions.Abstractions.TImeLineIndicatorConverter;
using Core.Actions.Abstractions.CalculatorUnitsMeasurement;
using Core.Actions.Abstractions.DataBaseConnector;
using Core.Actions.ShareRealizations.CalculatorUnitsMeasurement;
using Core.Models.WineRealizations;

namespace Core.Actions.WineRealizations.WineIndicatorConverter
{
    /// <summary>
    /// Конвертер получения индикатора по сорту винограда
    /// </summary>
    public class ByGrapeVarietyIndicatorConverter : IIndicatorConverter<WineIndicator>
    {
        /// <summary>
        /// Дефолтное значение сахара при невозможности конвертации
        /// </summary>
        private const double DEFAULT_SUGAR_VALUE = 0;

        /// <summary>
        /// Дефолтное значение азота при невозможности конвертации
        /// </summary>
        private const double DEFAULT_NITROGEN_VALUE = 0;

        /// <summary>
        /// Наименование сорта винограда
        /// </summary>
        private string grapeName;

        private readonly IBaseGenericRepository<GrapeVariety> repository;

        private readonly IBaseUnitsCalculator<MeasurementUnits> unitsCalculator;

        public ByGrapeVarietyIndicatorConverter(string grapeName, IBaseGenericRepository<GrapeVariety> _repository,
            IBaseUnitsCalculator<MeasurementUnits> unitsCalculator)
        {
            this.grapeName = grapeName;
            this.repository = _repository;
            this.unitsCalculator = unitsCalculator;
        }

        public WineIndicator GetIndicator()
        {
            var indicatorValue = repository.GetAll().FirstOrDefault(x => x.GrapeVarietyName == grapeName);
            if (indicatorValue == null) throw new Exception("Некорректный сорт винограда");
            var result = new WineIndicator() { NitrogenValue = indicatorValue.AcidValue, SugarValue = indicatorValue.SugarValue };
            return Convert(result);
        }

        /// <summary>
        /// Преобразовать единицы измерения
        /// </summary>
        /// <param name="indicator"></param>
        /// <returns></returns>
        private WineIndicator Convert(WineIndicator indicator)
        {
            //Преобразовали
            var convertedSugarValue = unitsCalculator.Calculate(MeasurementUnits.GramPer100CubicCentimeter, MeasurementUnits.GramPerLiter, indicator.SugarValue);
            var convertedNitrogenValue = unitsCalculator.Calculate(MeasurementUnits.GramPer100CubicDecimeter, MeasurementUnits.GramPerLiter, indicator.NitrogenValue);

            //Если не получилось преобразовать устанавливеам в нули
            indicator.SugarValue = convertedSugarValue == null ? DEFAULT_SUGAR_VALUE : (double)convertedSugarValue;
            indicator.NitrogenValue = convertedNitrogenValue == null ? DEFAULT_NITROGEN_VALUE : (double)convertedNitrogenValue;

            return indicator;
        }
    }
}
