using Core.Actions.ShareRealizations.CalculatorUnitsMeasurement;
using Core.Actions.WineRealizations.WineCurrentIndicatorsCalculator;
using Core.Models.WineRealizations;
using Core.Models.WineRealizations.Enums;
using DataBase.EF.ConnectionFroWine.Realizations;
using Xunit.Abstractions;

namespace Tests
{
    public class WineCurrentIndicatorsCalculatorTests : BaseTest
    {
        public WineCurrentIndicatorsCalculatorTests(ITestOutputHelper output) : base(output) { }

        #region WineCurrentIndicatorsCalculatorFactoryTests
        /// <summary>
        /// Проверка фабрики с корректными параметрами
        /// </summary>
        [Fact]
        public void CheckFactoryWithCorrectParameters()
        {
            var differenceAreometRrepository = new WineRepository<DifferenceAreometrDefaultValue>();
            var factory = new WineCurrentIndicatorsCalculatorFactory(differenceAreometRrepository);
            var type = UpdateIndicatorTypes.ByAreometr;
            var startValue = 1.040;
            var currentValue = 1.034;

            var result = factory.GetCurrentIndicatorsCalculator(type, new object[] { startValue, currentValue });

            Assert.IsType<ByAreometerDifferenceIndicatorsCalculator>(result);
        }

        /// <summary>
        /// Проверка фабрики с корректными параметрами
        /// </summary>
        [Fact]
        public void CheckFactoryWithInCorrectParameters1()
        {
            var differenceAreometRrepository = new WineRepository<DifferenceAreometrDefaultValue>();
            var factory = new WineCurrentIndicatorsCalculatorFactory(differenceAreometRrepository);
            var type = UpdateIndicatorTypes.ByAreometr;
            var startValue = 1.040;
            int currentValue = 1;

            Assert.Throws<Exception>(() => factory.GetCurrentIndicatorsCalculator(type, new object[] { startValue, currentValue }));
        }

        /// <summary>
        /// Проверка фабрики с корректными параметрами
        /// </summary>
        [Fact]
        public void CheckFactoryWithInCorrectParameters2()
        {
            var differenceAreometRrepository = new WineRepository<DifferenceAreometrDefaultValue>();
            var factory = new WineCurrentIndicatorsCalculatorFactory(differenceAreometRrepository);
            var type = UpdateIndicatorTypes.ByAreometr;
            var startValue = 1.040;
            var currentValue = "Lel";

            Assert.Throws<Exception>(() => factory.GetCurrentIndicatorsCalculator(type, new object[] { startValue, currentValue }));
        }
        #endregion

        #region ByAreometerDifferenceIndicatorsCalculatorTest
        /// <summary>
        /// Проверка фабрики + калькулятора с корректными значениями
        /// </summary>
        [Fact]
        public void CheckcalculatorWithCorrectParameters()
        {
            var differenceAreometRrepository = new WineRepository<DifferenceAreometrDefaultValue>();
            var factory = new WineCurrentIndicatorsCalculatorFactory(differenceAreometRrepository);
            var type = UpdateIndicatorTypes.ByAreometr;
            var startValue = 1.040;
            var currentValue = 1.034;

            var calcualtor = factory.GetCurrentIndicatorsCalculator(type, new object[] { startValue, currentValue });
            var result = calcualtor!.Calculate();

            Assert.NotNull(result);
            Assert.Equal(0.8, result!.EthanolValue);
            Assert.Equal(1.35, result!.SugarValue);
        }

        /// <summary>
        /// Проверка фабрики + калькулятора с корректными значениями
        /// </summary>
        [Fact]
        public void CheckcalculatorWithInCorrectParameters()
        {
            var differenceAreometRrepository = new WineRepository<DifferenceAreometrDefaultValue>();
            var factory = new WineCurrentIndicatorsCalculatorFactory(differenceAreometRrepository);
            var type = UpdateIndicatorTypes.ByAreometr;
            var startValue = 1.04;
            var currentValue = 1.05;

            var calcualtor = factory.GetCurrentIndicatorsCalculator(type, new object[] { startValue, currentValue });
            Assert.Throws<Exception>(() => calcualtor!.Calculate());
        }
        #endregion

        #region WineCurrentIndicatorCalculatorWorkerTest
        /// <summary>
        /// Проверка фасада по рассчету и корректировки с корректными данными
        /// </summary>
        [Fact]
        public void CheckCalculatorFacadeWithCorrectParameters()
        {
            var differenceAreometRrepository = new WineRepository<DifferenceAreometrDefaultValue>();
            var unitsFactory = new CalculatorFactory();
            var unitsCalculator = new UnitsCalculator(unitsFactory);
            var factory = new WineCurrentIndicatorsCalculatorFactory(differenceAreometRrepository);
            var worker = new WineCurrentIndicatorCalculatorWorker(unitsCalculator, factory);
            var type = UpdateIndicatorTypes.ByAreometr;
            var startValue = 1.04;
            var currentValue = 1.034;

            var result = worker.Calculate(type, new object[] { startValue, currentValue });

            Assert.NotNull(result);
            Assert.Equal(0.8, result!.EthanolValue);
            Assert.Equal(13.5, result!.SugarValue);
        }

        /// <summary>
        /// Проверка фасада по рассчету и корректировки с не корректными данными
        /// </summary>
        [Fact]
        public void CheckCalculatorFacadeWithInCorrectParameters()
        {
            var differenceAreometRrepository = new WineRepository<DifferenceAreometrDefaultValue>();
            var unitsFactory = new CalculatorFactory();
            var unitsCalculator = new UnitsCalculator(unitsFactory);
            var factory = new WineCurrentIndicatorsCalculatorFactory(differenceAreometRrepository);
            var worker = new WineCurrentIndicatorCalculatorWorker(unitsCalculator, factory);
            var type = UpdateIndicatorTypes.ByAreometr;
            var startValue = 1.04;
            var currentValue = 1.05;

            Assert.Throws<Exception>(() => worker.Calculate(type, new object[] { startValue, currentValue }));
        }
        #endregion
    }
}
