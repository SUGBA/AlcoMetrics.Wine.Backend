using Core.Actions.ShareRealizations.CalculatorUnitsMeasurement;
using Core.Actions.WineRealizations.WineEventCalculator;
using Core.Models.WineRealizations;
using Xunit.Abstractions;

namespace Tests
{
    public class WineEventCalculator : BaseTest
    {
        public WineEventCalculator(ITestOutputHelper output) : base(output) { }

        #region WineEventFactoryTests
        /// <summary>
        /// Получение шаптализации с верными параметрами
        /// </summary>
        [Fact]
        public void GettingCalculatorWithCorrectParameters1()
        {
            var unitsCalculatorFactory = new CalculatorFactory();
            var unitsCalculator = new UnitsCalculator(unitsCalculatorFactory);
            var factory = new WineEventFactory(unitsCalculator);
            var indicator = new WineIndicator() { EthanolValue = 0, SugarValue = 45, WortValue = 10 };

            var result = factory.GetEventCalculater(WineEventTypes.Shaptalization, indicator);

            Assert.IsType<ShaptalizationEventCalculater>(result);
        }

        /// <summary>
        /// Получение шаптализации с верными параметрами
        /// </summary>
        [Fact]
        public void GettingCalculatorWithCorrectParameters2()
        {
            var unitsCalculatorFactory = new CalculatorFactory();
            var unitsCalculator = new UnitsCalculator(unitsCalculatorFactory);
            var factory = new WineEventFactory(unitsCalculator);
            var desiredIndicator = new WineIndicator() { SugarValue = 50 };
            var currentIndicator = new WineIndicator() { SugarValue = 30, WortValue = 10 };

            var res = factory.GetEventCalculater(WineEventTypes.Blending, currentIndicator, new object[] { desiredIndicator, BasedSubstanceType.Sugar });

            Assert.IsType<BlendingEventCalculater>(res);
        }

        /// <summary>
        /// Получение шаптализации с не верными параметрами
        /// </summary>
        [Fact]
        public void GettingCalculatorWithInCorrectParameters1()
        {
            var unitsCalculatorFactory = new CalculatorFactory();
            var unitsCalculator = new UnitsCalculator(unitsCalculatorFactory);
            var factory = new WineEventFactory(unitsCalculator);
            var indicator = new WineIndicator() { EthanolValue = 0, SugarValue = 45, WortValue = 10 };
            var param = "Привит";

            Assert.Throws<Exception>(() => factory.GetEventCalculater(WineEventTypes.Blending, indicator, new object[] { param }));
        }

        /// <summary>
        /// Получение шаптализации с не верными параметрами
        /// </summary>
        [Fact]
        public void GettingCalculatorWithInCorrectParameters2()
        {
            var unitsCalculatorFactory = new CalculatorFactory();
            var unitsCalculator = new UnitsCalculator(unitsCalculatorFactory);
            var factory = new WineEventFactory(unitsCalculator);
            var indicator = new WineIndicator() { EthanolValue = 0, SugarValue = 45, WortValue = 10 };

            Assert.Throws<Exception>(() => factory.GetEventCalculater(WineEventTypes.Blending, indicator, new object[] { }));
        }

        /// <summary>
        /// Получение шаптализации с не верными параметрами
        /// </summary>
        [Fact]
        public void GettingCalculatorWithInCorrectParameters3()
        {
            var unitsCalculatorFactory = new CalculatorFactory();
            var unitsCalculator = new UnitsCalculator(unitsCalculatorFactory);
            var factory = new WineEventFactory(unitsCalculator);
            var indicator = new WineIndicator() { EthanolValue = 0, SugarValue = 45, WortValue = 10 };

            Assert.Throws<Exception>(() => factory.GetEventCalculater(WineEventTypes.Blending, indicator, null));
        }

        /// <summary>
        /// Получение шаптализации с не верными параметрами
        /// </summary>
        [Fact]
        public void GettingCalculatorWithInCorrectParameters4()
        {
            var unitsCalculatorFactory = new CalculatorFactory();
            var unitsCalculator = new UnitsCalculator(unitsCalculatorFactory);
            var factory = new WineEventFactory(unitsCalculator);
            var desiredIndicator = new WineIndicator() { SugarValue = 50 };
            var currentIndicator = new WineIndicator() { SugarValue = 30, WortValue = 10 };

            Assert.Throws<Exception>(() => factory.GetEventCalculater(WineEventTypes.Blending, currentIndicator, new object[] { desiredIndicator, "Хай" }));
        }
        #endregion

        #region ShaptalizationEventCalculaterTests
        /// <summary>
        /// Получение шаптализации с верными параметрами
        /// </summary>
        [Fact]
        public void CheckingСorrectnessСalculationsWithCorrectParam1()
        {
            var desiredIndicator = new WineIndicator() { SugarValue = 50 };
            var currentIndicator = new WineIndicator() { SugarValue = 30, WortValue = 10 };
            var unitsCalculatorFactory = new CalculatorFactory();
            var unitsCalculator = new UnitsCalculator(unitsCalculatorFactory);
            var calcualtor = new ShaptalizationEventCalculater(currentIndicator, unitsCalculator);

            var result = calcualtor.Calculate(desiredIndicator);

            Assert.Equal(46d, Math.Round(calcualtor.ResultIndicator.SugarValue, 0));
            Assert.Equal(15.45d, Math.Round(calcualtor.ResultIndicator.WortValue, 2));
        }

        #endregion

        #region BlendingEventCalculaterTests
        /// <summary>
        /// Получить купажирование с верными параметрами (по сахару)
        /// </summary>
        [Fact]
        public void GettingCalculatorWithCorrectParameters21()
        {
            var desiredIndicator = new WineIndicator() { SugarValue = 50, WortValue = 15, EthanolValue = 12 };
            var currentIndicator = new WineIndicator() { SugarValue = 30, WortValue = 10, EthanolValue = 10 };
            var substanceIndicator = new WineIndicator() { SugarValue = 65, WortValue = 10, EthanolValue = 14 };
            var unitsCalculatorFactory = new CalculatorFactory();
            var unitsCalculator = new UnitsCalculator(unitsCalculatorFactory);
            var calcualtor = new BlendingEventCalculater(currentIndicator, substanceIndicator, BasedSubstanceType.Sugar, unitsCalculator);

            var result = calcualtor.Calculate(desiredIndicator);

            Assert.Equal(50, Math.Round(calcualtor.ResultIndicator.SugarValue, 0));
            Assert.Equal(12, Math.Round(calcualtor.ResultIndicator.EthanolValue, 0));
            Assert.Equal(23, Math.Round(calcualtor.ResultIndicator.WortValue, 0));
        }

        /// <summary>
        /// Получить купажирование с верными параметрами (по спирту)
        /// </summary>
        [Fact]
        public void GettingCalculatorWithCorrectParameters22()
        {
            var desiredIndicator = new WineIndicator() { SugarValue = 50, WortValue = 15, EthanolValue = 12 };
            var currentIndicator = new WineIndicator() { SugarValue = 30, WortValue = 10, EthanolValue = 10 };
            var substanceIndicator = new WineIndicator() { SugarValue = 65, WortValue = 10, EthanolValue = 14 };
            var unitsCalculatorFactory = new CalculatorFactory();
            var unitsCalculator = new UnitsCalculator(unitsCalculatorFactory);
            var calcualtor = new BlendingEventCalculater(currentIndicator, substanceIndicator, BasedSubstanceType.Ethanol, unitsCalculator);

            var result = calcualtor.Calculate(desiredIndicator);

            Assert.Equal(48, Math.Round(calcualtor.ResultIndicator.SugarValue, 0));
            Assert.Equal(12, Math.Round(calcualtor.ResultIndicator.EthanolValue, 0));
            Assert.Equal(20, Math.Round(calcualtor.ResultIndicator.WortValue, 0));
        }

        /// <summary>
        /// Получить купажирование с не верными параметрами (по спирту)
        /// </summary>
        [Fact]
        public void GettingCalculatorWithInCorrectParameters21()
        {
            var desiredIndicator = new WineIndicator() { SugarValue = 50, WortValue = 15, EthanolValue = 16 };
            var currentIndicator = new WineIndicator() { SugarValue = 30, WortValue = 10, EthanolValue = 10 };
            var substanceIndicator = new WineIndicator() { SugarValue = 65, WortValue = 10, EthanolValue = 14 };
            var unitsCalculatorFactory = new CalculatorFactory();
            var unitsCalculator = new UnitsCalculator(unitsCalculatorFactory);
            var calcualtor = new BlendingEventCalculater(currentIndicator, substanceIndicator, BasedSubstanceType.Ethanol, unitsCalculator);

            calcualtor.Calculate(desiredIndicator);

            Assert.True(calcualtor.ResultIndicator.WortValue < 0);
        }
        #endregion

        #region AlcoholizationEventCalculaterTests
        /// <summary>
        /// Получить Крепление вина с верными параметрами
        /// </summary>
        [Fact]
        public void GettingCalculatorWithCorrectParameters31()
        {
            var desiredIndicator = new WineIndicator() { EthanolValue = 16 };
            var currentIndicator = new WineIndicator() { EthanolValue = 10, WortValue = 10 };
            var calcualtor = new AlcoholizationEventCalculater(currentIndicator);

            calcualtor.Calculate(desiredIndicator);

            Assert.Equal(10.759, Math.Round(calcualtor.ResultIndicator.WortValue, 3));
            Assert.Equal(16, Math.Round(calcualtor.ResultIndicator.EthanolValue));
        }
        #endregion
    }
}
