using Core.Actions.ShareRealizations.CalculatorUnitsMeasurement;
using Core.Actions.WineRealizations.WineTimeLineCalculator;
using Core.Actions.WineRealizations.WineTimeLineCreator;
using Core.Models.WineRealizations;
using Xunit.Abstractions;

namespace Tests
{
    public class WIneTimeLineCreatorTests : BaseTest
    {
        public WIneTimeLineCreatorTests(ITestOutputHelper output) : base(output){}

        /// <summary>
        /// Проверка на получение этанола, с обрезанием
        /// (до 100 дней оно точно должно быть обрезано)
        /// </summary>
        [Fact]
        public void GettinTimeLineFromStart()
        {
            var indicator = new WineIndicator() { };
            var startTime = 0;
            var endTime = 100;
            var timeLineCalculator = new WIneTimeLineCalculator();
            var _calculatorFactory = new CalculatorFactory();
            var _unitsCalculator = new UnitsCalculator(_calculatorFactory);
            var calculator = new WineTimeLineCreator(timeLineCalculator, _unitsCalculator);

            var res = calculator.GetTimeLine(indicator, startTime, endTime);

            output.WriteLine(string.Join("\n", res.Days.Select(x => x.Indicator.EthanolValue)));
        }

        /// <summary>
        /// Проверка на рассчет с 20 дня
        /// Начальные показания - это показания модели рассчитанные к 20 дню
        /// </summary>
        [Fact]
        public void GettinTimeLineMiddle()
        {
            var indicator = new WineIndicator()
            {
                YeastValue = 2.25,
                NitrogenValue = 0.01,
                EthanolValue = 16.98,
                SugarValue = 176
            };
            var startTime = 20;
            var endTime = 100;
            var timeLineCalculator = new WIneTimeLineCalculator();
            var _calculatorFactory = new CalculatorFactory();
            var _unitsCalculator = new UnitsCalculator(_calculatorFactory);
            var calculator = new WineTimeLineCreator(timeLineCalculator, _unitsCalculator);

            var res = calculator.GetTimeLine(indicator, startTime, endTime);

            output.WriteLine(string.Join("\n", res.Days.Select(x => x.Indicator.EthanolValue)));
        }
    }
}
