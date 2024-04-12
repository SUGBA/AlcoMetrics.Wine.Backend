using Core.Actions.Abstractions.CalculatorUnitsMeasurement;
using Core.Actions.Abstractions.EventCalculator;
using Core.Actions.ShareRealizations.CalculatorUnitsMeasurement;
using Core.Models.WineRealizations;

namespace Core.Actions.WineRealizations.WineEventCalculator
{
    /// <summary>
    /// Событие Шаптализация
    /// </summary>
    public class ShaptalizationEventCalculater : BaseEventCalculator<WineIndicator>
    {
        /// <summary>
        /// коэффициент, учитывающий соотношение объёмов воды, необходимой для получения сахарного сиропа, и исходного сусла;
        /// </summary>
        private const float K = 0.5f;

        /// <summary>
        /// Плотность сахара Г/Л
        /// </summary>
        private const short p = 900;

        private IBaseUnitsCalculator<MeasurementUnits> unitsCalculator;

        public ShaptalizationEventCalculater(WineIndicator currentIndicator, IBaseUnitsCalculator<MeasurementUnits> unitsCalculator) : base(currentIndicator)
        {
            this.unitsCalculator = unitsCalculator;
        }

        /// <summary>
        /// Ингридиенты шаптализации
        /// </summary>
        /// <param name="desiredIndicator"> Желаемое значение </param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override Dictionary<string, double> Calculate(WineIndicator desiredIndicator)
        {
            var result = new Dictionary<string, double>();

            var sugarValue = GetSugarAmount(currentIndicator.WortValue, currentIndicator.SugarValue, desiredIndicator.SugarValue);

            result.Add("Сахар (Г)", sugarValue);

            var waterValue = GetWatterWort(currentIndicator.WortValue);

            result.Add("Вода (Л)", waterValue);

            UpdateIndicator(sugarValue, waterValue);       //Изменение показателей результирующего индикатора

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
        /// Получить колличество сахара в г
        /// К нам приходит содержание сахара в Г/Л, а формула оперирует процентами
        /// Поэтому также нам нужно переводить в проценты
        /// </summary>
        /// <param name="v0"> Объем текущего сусла </param>
        /// <param name="c0"> концентрация сахара в исходном сусле </param>
        /// <param name="c1"> –концентрация сахара, которая должна быть в получаемом виноматериале </param>
        /// <returns></returns>
        private double GetSugarAmount(double v0, double c0, double c1)
        {
            var convertedC0 = unitsCalculator.Calculate(MeasurementUnits.GramPerLiter, MeasurementUnits.Percentage, c0);

            var convertedC1 = unitsCalculator.Calculate(MeasurementUnits.GramPerLiter, MeasurementUnits.Percentage, c1);

            return p * v0 * ((convertedC1 - convertedC0) / 100 + K * convertedC1 / 100);   //Формула
        }

        /// <summary>
        /// Получение воды для искомого сусла
        /// </summary>
        /// <param name="v0"> Объем текущего сусла </param>
        /// <returns></returns>
        private double GetWatterWort(double v0)
        {
            return K * v0;
        }

        /// <summary>
        /// Обновить показатели результирующего индикатора
        /// </summary>
        /// <param name="sugar"></param>
        /// <param name="watterLier"></param>
        private void UpdateIndicator(double sugar, double watterLier)
        {
            double totalSugar = ResultIndicator.SugarValue * ResultIndicator.WortValue;     //Текущий объем сахара в граммах

            double resultSugarGram = totalSugar + sugar;                        //Общее колличество сахара в граммах
            double addedWort = watterLier + sugar / p;                          //Объем добавляемого сиропа
            double resultWater = ResultIndicator.WortValue + addedWort;               //Текущий объем + доблавленная вода + объем сахара (в литрах)

            double resultSugarValue = resultSugarGram / resultWater;            //Результат в Г/Л

            ResultIndicator.WortValue = resultWater;
            ResultIndicator.SugarValue = resultSugarValue;

            var ethanolResult = MixingCalculator.GetContent(ResultIndicator.EthanolValue, ResultIndicator.WortValue, 0, addedWort);

            ResultIndicator.EthanolValue = ethanolResult;
        }
    }
}
