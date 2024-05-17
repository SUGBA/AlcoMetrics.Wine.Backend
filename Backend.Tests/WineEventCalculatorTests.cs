using Core.Actions.ShareRealizations.CalculatorUnitsMeasurement;
using Core.Actions.WineRealizations.WineEventCalculator;
using Core.Models.WineRealizations;
using Xunit.Abstractions;

namespace Tests
{
    public class WineEventCalculatorTests : BaseTest
    {
        public WineEventCalculatorTests(ITestOutputHelper output) : base(output) { }

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
        /// Получение купажирования с верными параметрами
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
        /// Получение купажирования с не верными параметрами
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
        /// Получение купажирования с не верными параметрами
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
        /// Получение купажирования с не верными параметрами
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
        /// Получение купажирования с не верными параметрами
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

            Assert.Equal(50d, Math.Round(calcualtor.ResultIndicator.SugarValue, 0));
            Assert.Equal(13.35d, Math.Round(calcualtor.ResultIndicator.WortValue, 2));
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

        #region WineEventWorkerTests

        /// <summary>
        /// Получение ингридиентов для крепления через фасад
        /// </summary>
        [Fact]
        public void GetIngredientsForAlcoholization()
        {
            var unitsCalculatorFactory = new CalculatorFactory();
            var unitsCalculator = new UnitsCalculator(unitsCalculatorFactory);
            var eventFactory = new WineEventFactory(unitsCalculator);
            var worker = new WineEventWorker(eventFactory);

            var desiredIndicator = new WineIndicator() { EthanolValue = 16 };
            var currentIndicator = new WineIndicator() { EthanolValue = 10, WortValue = 10 };

            var result = worker.CalculateEventIngredients(WineEventTypes.Alcoholization, desiredIndicator, currentIndicator);

            Assert.NotNull(result);
            Assert.Equal(0.76, Math.Round(result!.First().Value, 2));
        }

        /// <summary>
        /// Получение ингридиентов для шаптализации через фасад
        /// </summary>
        [Fact]
        public void GetIngredientsForShaptaliszation()
        {
            var unitsCalculatorFactory = new CalculatorFactory();
            var unitsCalculator = new UnitsCalculator(unitsCalculatorFactory);
            var eventFactory = new WineEventFactory(unitsCalculator);
            var worker = new WineEventWorker(eventFactory);

            var desiredIndicator = new WineIndicator() { SugarValue = 50 };
            var currentIndicator = new WineIndicator() { SugarValue = 30, WortValue = 10 };

            var result = worker.CalculateEventIngredients(WineEventTypes.Shaptalization, desiredIndicator, currentIndicator);

            Assert.NotNull(result);
            Assert.Equal(315, Math.Round(result!.First().Value, 0));
            Assert.Equal(3, Math.Round(result!.Last().Value, 0));
        }

        /// <summary>
        /// Получение ингридиентов для купажирования через фасад
        /// </summary>
        [Fact]
        public void GetIngredientsForBlending()
        {
            var unitsCalculatorFactory = new CalculatorFactory();
            var unitsCalculator = new UnitsCalculator(unitsCalculatorFactory);
            var eventFactory = new WineEventFactory(unitsCalculator);
            var worker = new WineEventWorker(eventFactory);

            var desiredIndicator = new WineIndicator() { SugarValue = 50, WortValue = 15, EthanolValue = 12 };
            var currentIndicator = new WineIndicator() { SugarValue = 30, WortValue = 10, EthanolValue = 10 };
            var substanceIndicator = new WineIndicator() { SugarValue = 65, WortValue = 10, EthanolValue = 14 };

            var result = worker.CalculateEventIngredients(WineEventTypes.Blending, desiredIndicator, currentIndicator, new object[] { substanceIndicator, BasedSubstanceType.Sugar });

            Assert.NotNull(result);
            Assert.Equal(13.33, Math.Round(result!.First().Value, 2));
        }
        #endregion
    }
}
