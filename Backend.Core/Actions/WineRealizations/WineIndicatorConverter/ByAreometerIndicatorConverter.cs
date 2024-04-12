using Core.Actions.Abstractions.DataBaseConnector;
using Core.Actions.Abstractions.TImeLineIndicatorConverter;
using Core.Actions.ShareRealizations.CalculatorUnitsMeasurement;
using Core.Models.WineRealizations;
using Core.Actions.Abstractions.CalculatorUnitsMeasurement;

namespace Core.Actions.WineRealizations.WineIndicatorConverter
{
    /// <summary>
    /// Конвертер получения индикатора по показаниям ареометра (только уровень сахара)
    /// </summary>
    public class ByAreometerIndicatorConverter : IIndicatorConverter<WineIndicator>
    {
        /// <summary>
        /// Дефолтное значение сахара при невозможности конвертации
        /// </summary>
        private const double DEFAULT_SUGAR_VALUE = 0;

        /// <summary>
        /// Показание ареометра кг/м^3
        /// </summary>
        private int areometrValue;

        private readonly IBaseGenericRepository<AreometrDefaultValue> _repository;

        private readonly IBaseUnitsCalculator<MeasurementUnits> unitsCalculator;

        public ByAreometerIndicatorConverter(int areometrValue, IBaseGenericRepository<AreometrDefaultValue> _repository,
            IBaseUnitsCalculator<MeasurementUnits> unitsCalculator)
        {
            this.areometrValue = areometrValue;
            this._repository = _repository;
            this.unitsCalculator = unitsCalculator;
        }

        public WineIndicator GetIndicator()
        {
            var indicatorValue = _repository.GetAll().FirstOrDefault(x => x.AreometerValue == areometrValue);
            if (indicatorValue == null) throw new Exception("Некорректные показания Ареометра");
            var result = new WineIndicator() { SugarValue = indicatorValue.SugarValue };
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

            //Если не получилось преобразовать устанавливеам в нули
            indicator.SugarValue = convertedSugarValue == null ? DEFAULT_SUGAR_VALUE : (double)convertedSugarValue;

            return indicator;
        }
    }
}
