using Core.Actions.Abstractions.CalculatorUnitsMeasurement;
using Core.Actions.Abstractions.EventCalculator;
using Core.Actions.ShareRealizations.CalculatorUnitsMeasurement;
using Core.Models.WineRealizations;

namespace Core.Actions.WineRealizations.WineEventCalculator
{
    /// <summary>
    /// Событие Купажирование
    /// </summary>
    public class BlendingEventCalculater : BaseEventCalculator<WineIndicator>
    {
        /// <summary>
        /// Смешиваемое вещество
        /// </summary>
        private WineIndicator substanceIndicator;

        /// <summary>
        /// Тип на основе которого определяется объем добавляемого купажа
        /// </summary>
        private BasedSubstanceType type;

        private IBaseUnitsCalculator<MeasurementUnits> unitsCalculator;

        public BlendingEventCalculater(WineIndicator currentIndicator, WineIndicator substanceindicator, BasedSubstanceType type,
            IBaseUnitsCalculator<MeasurementUnits> unitsCalculator) : base(currentIndicator)
        {
            this.substanceIndicator = substanceindicator;
            this.unitsCalculator = unitsCalculator;
            this.type = type;
        }

        /// <summary>
        /// Рассчитать ингридиенты требуемые для достижения заданных показателей
        /// Отрицательный результат, если достичь заданных характеристик смешиванием невозможно
        /// </summary>
        /// <param name="Indicator"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public override Dictionary<string, double> Calculate(WineIndicator Indicator)
        {
            var res = new Dictionary<string, double>();
            switch (type)
            {
                case BasedSubstanceType.Sugar:
                    var volumeFromSugar = CalculateSugar(currentIndicator.SugarValue, substanceIndicator.SugarValue, currentIndicator.WortValue, Indicator.SugarValue);
                    res.Add("Смешиваемое вещество (Л)", volumeFromSugar);
                    UpdateResultIndicator(volumeFromSugar);
                    return res;
                case BasedSubstanceType.Ethanol:
                    var volumeFromEthanol = CalculateEthanol(currentIndicator.EthanolValue, substanceIndicator.EthanolValue, currentIndicator.WortValue, Indicator.EthanolValue);
                    res.Add("Смешиваемое вещество (Л)", volumeFromEthanol);
                    UpdateResultIndicator(volumeFromEthanol);
                    return res;
                default:
                    throw new Exception("Некорректное свойство для рессчета шаптализации вина");
            }
        }

        /// <summary>
        /// Калькулятор рассчета объема ориентируясь на сахар
        /// </summary>
        /// <param name="currentSugar"> Текущее содержание сахара </param>
        /// <param name="substanceSugar"> Содержание сахара в смешиваемом виноматериале </param>
        /// <param name="currentVolume"> Текущий объем </param>
        /// <param name="desiredSugar"> Желаемое содержание сахара </param>
        /// <returns></returns>
        private double CalculateSugar(double currentSugar, double substanceSugar, double currentVolume, double desiredSugar)
        {
            var currentSugarPercent = unitsCalculator.Calculate(MeasurementUnits.GramPerLiter, MeasurementUnits.Percentage, currentSugar);
            var substanceSugarPercent = unitsCalculator.Calculate(MeasurementUnits.GramPerLiter, MeasurementUnits.Percentage, substanceSugar);
            var desireSugarPercent = unitsCalculator.Calculate(MeasurementUnits.GramPerLiter, MeasurementUnits.Percentage, desiredSugar);

            var result = MixingCalculator.GetVolume(currentSugarPercent, substanceSugarPercent, currentVolume, desireSugarPercent);

            return result;
        }

        /// <summary>
        /// Калькулятор рассчета объема ориентируясь на спирт
        /// </summary>
        /// <param name="currentEthanol"> Текущее содержание спирта </param>
        /// <param name="substanceEthanol"> Содержание спирта в смешиваемом виноматериале </param>
        /// <param name="currentVolume"> Текущий объем </param>
        /// <param name="desiredEthanol"> Желаемое содержание сахара </param>
        /// <returns></returns>
        private double CalculateEthanol(double currentEthanol, double substanceEthanol, double currentVolume, double desiredEthanol)
        {
            var result = MixingCalculator.GetVolume(currentEthanol, substanceEthanol, currentVolume, desiredEthanol);

            return result;
        }

        protected override WineIndicator CopyItem(WineIndicator indicator)
        {
            return new WineIndicator()
            {
                EthanolValue = indicator.EthanolValue,
                Id = indicator.Id,
                NitrogenValue = indicator.NitrogenValue,
                SugarValue = indicator.SugarValue,
                WortValue = indicator.WortValue,
                YeastValue = indicator.YeastValue
            };
        }

        /// <summary>
        /// Обновить значение результирующего вещества
        /// </summary>
        /// <param name="volume"> Объем добавляемого вещества </param>
        private void UpdateResultIndicator(double volume)
        {
            var currentSugarPercent = unitsCalculator.Calculate(MeasurementUnits.GramPerLiter, MeasurementUnits.Percentage, currentIndicator.SugarValue);
            var substanceSugarPercent = unitsCalculator.Calculate(MeasurementUnits.GramPerLiter, MeasurementUnits.Percentage, substanceIndicator.SugarValue);

            var resultSugarPercent = MixingCalculator.GetContent(currentSugarPercent, currentIndicator.WortValue, substanceSugarPercent, volume);
            var resultEthanolPercent = MixingCalculator.GetContent(currentIndicator.EthanolValue, currentIndicator.WortValue, substanceIndicator.EthanolValue, volume);

            var resultSugar = unitsCalculator.Calculate(MeasurementUnits.Percentage, MeasurementUnits.GramPerLiter, resultSugarPercent);

            ResultIndicator.SugarValue = resultSugar;
            ResultIndicator.EthanolValue = resultEthanolPercent;
            ResultIndicator.WortValue += volume;
        }
    }

    /// <summary>
    /// Тип вещества на основе которого будет вычислять объем купажированного вина
    /// </summary>
    public enum BasedSubstanceType
    {
        /// <summary>
        /// На основе сахара
        /// </summary>
        Sugar = 1,

        /// <summary>
        /// На основе спирта
        /// </summary>
        Ethanol = 2,
    }
}
