using Core.Actions.Abstractions.CalculatorUnitsMeasurement;
using Core.Actions.Abstractions.TimeLineCalculator;
using Core.Actions.Abstractions.TimeLineCreator;
using Core.Actions.ShareRealizations.CalculatorUnitsMeasurement;
using Core.Models.WineRealizations;
using MathNet.Numerics.LinearAlgebra;

namespace Core.Actions.WineRealizations.WineTimeLineCreator
{
    /// <summary>
    /// Генератор Тайм-лайнов
    /// </summary>
    public class WineTimeLineCreator : BaseTimeLineCreator<WineIndicator, WineTimeLine, WineDay>
    {
        /// <summary>
        /// Максимальное содержание этанола при котором живут дрожжи (В %)
        /// </summary>
        private const double MAX_ETHANOL_VALUE = 14;

        /// <summary>
        /// Дефолтное содержание алкоголя
        /// </summary>
        private const double DEFAULT_ETHANOL_VALUE = 0;

        /// <summary>
        /// Минимальное значение сахара, после которого показания спирта не будут меняться
        /// </summary>
        private const double MIN_SUGAR_VALUE = 0.5;

        private IBaseUnitsCalculator<MeasurementUnits> unitsCalculator;

        public WineTimeLineCreator(BaseTimeLineCalculator<WineIndicator> calculator, IBaseUnitsCalculator<MeasurementUnits> unitsCalculator)
            : base(calculator)
        {
            this.unitsCalculator = unitsCalculator;
        }

        protected override Vector<double>[] Calculate(WineIndicator indicator, int startTime, int endTime)
        {
            return calculator.CalculateTimeLine(indicator, startTime, endTime);
        }

        protected override WineTimeLine Convert(Vector<double>[] vectors, DateTime? startDateTime = null)
        {
            var resultStartDateTime = startDateTime ?? DateTime.UtcNow;     //Здесь, чтобы не парсить в not nullable в цикле каждый раз
            var res = new WineTimeLine() { Days = new List<WineDay>() };
            for (int i = 0; i < vectors.Length; i++)
            {
                var indicator = new WineIndicator()
                {
                    YeastValue = vectors[i][0],
                    NitrogenValue = vectors[i][1],
                    EthanolValue = vectors[i][2],
                    SugarValue = vectors[i][3],
                    WortValue = vectors[i][4]
                };
                var day = new WineDay() { Indicator = indicator, CurrentDate = resultStartDateTime.AddDays(i) };
                res.Days.Add(day);
            }

            return res;
        }

        protected override WineTimeLine Correct(WineTimeLine timeLine)
        {
            //Перевели алкоголь в процентное содержание
            foreach (var item in timeLine.Days)
            {
                var newEthanolValue = unitsCalculator.Calculate(MeasurementUnits.GramPerLiter, MeasurementUnits.Percentage, item.Indicator.EthanolValue);
                item.Indicator.EthanolValue = (double)newEthanolValue;
            }

            //Отфильтровали значения по возможному содержанию алкоголя
            //Фильтрация по сахару такая потому, что значение может стремится к нулю, но достигать нуля спустя месяца
            timeLine.Days = timeLine.Days
                .Where(x => x.Indicator.EthanolValue >= DEFAULT_ETHANOL_VALUE
                    && x.Indicator.EthanolValue <= MAX_ETHANOL_VALUE
                    && x.Indicator.SugarValue >= MIN_SUGAR_VALUE
                    && x.Indicator.YeastValue > 0)
                    .ToList();

            return timeLine;
        }
    }
}
