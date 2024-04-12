using Core.Actions.Abstractions.EventCalculator;
using Core.Models.WineRealizations;

namespace Core.Actions.WineRealizations.WineEventCalculator
{
    /// <summary>
    /// Событие Крепление вина
    /// </summary>
    public class AlcoholizationEventCalculater : BaseEventCalculator<WineIndicator>
    {
        /// <summary>
        /// Крепость спирта в %
        /// </summary>
        private double alcoholStrength;

        public AlcoholizationEventCalculater(WineIndicator currentIndicator, double alcoholStrength = 95) : base(currentIndicator)
        {
            this.alcoholStrength = alcoholStrength;
        }

        public override Dictionary<string, double> Calculate(WineIndicator indicator)
        {
            var result = new Dictionary<string, double>();

            var addedAlcohol = GetAcoholVolume(indicator.EthanolValue, currentIndicator.EthanolValue, currentIndicator.WortValue);

            result.Add($"Спирт {alcoholStrength}% (Л)", addedAlcohol);

            UpdateIndicator(addedAlcohol, indicator.EthanolValue);

            return result;
        }

        /// <summary>
        /// Получить объем добалвяемого спирта в Л
        /// </summary>
        /// <param name="desiredAcohol"> Желаемое содеражние алкоголя </param>
        /// <param name="currentAcohol"> Текущее содержание алкоголя </param>
        /// <returns></returns>
        private double GetAcoholVolume(double desiredAcohol, double currentAcohol, double currentWortValue)
        {
            return MixingCalculator.GetVolume(currentAcohol, alcoholStrength, currentWortValue, desiredAcohol);
        }

        /// <summary>
        /// Обновить значение 
        /// </summary>
        /// <param name="alcoholWort"> Объем спирта </param>
        /// <param name="alcoholPercentValue"> Итоговое содержание спирта </param>
        private void UpdateIndicator(double alcoholWort, double alcoholPercentValue)
        {
            ResultIndicator.EthanolValue = alcoholPercentValue;
            ResultIndicator.WortValue += alcoholWort;
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
    }
}
