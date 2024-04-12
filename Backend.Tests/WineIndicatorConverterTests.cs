using Core.Actions.ShareRealizations.CalculatorUnitsMeasurement;
using Core.Actions.WineRealizations.WineIndicatorConverter;
using Core.Models.WineRealizations;
using Core.Models.WineRealizations.Enums;
using DataBase.EF.ConnectionFroWine.Realizations;
using Xunit.Abstractions;

namespace Tests
{
    public class WineIndicatorConverterTests : BaseTest
    {
        public WineIndicatorConverterTests(ITestOutputHelper output) : base(output) { }

        #region WineIndicatorConverterFactory Tests
        /// <summary>
        /// Проверка на корректность получения ByAreometerIndicatorConverter с верным типом
        /// </summary>
        [Fact]
        public void GettingAreometerWithCorrectParameter()
        {
            var type = InitialIndicatorTypes.ByAreometr;
            var parameter = 1096;
            var _areometrRepository = new WineRepository<AreometrDefaultValue>();
            var _grapeVarietyRepository = new WineRepository<GrapeVariety>();
            var _calculatorFactory = new CalculatorFactory();
            var _calculator = new UnitsCalculator(_calculatorFactory);
            var factory = new WineIndicatorConverterFactory(_areometrRepository, _grapeVarietyRepository, _calculator);

            var result = factory.GetIndicatorConverter(type, parameter);

            Assert.IsType<ByAreometerIndicatorConverter>(result);
        }
        /// <summary>
        /// Проверка на корректность получения ByAreometerIndicatorConverter с не верным типом
        /// </summary>
        [Fact]
        public void GettingAreometerWithIncorrectParameter()
        {
            var type = InitialIndicatorTypes.ByAreometr;
            var parameter = "some type";
            var _areometrRepository = new WineRepository<AreometrDefaultValue>();
            var _grapeVarietyRepository = new WineRepository<GrapeVariety>();
            var _calculatorFactory = new CalculatorFactory();
            var _calculator = new UnitsCalculator(_calculatorFactory);
            var factory = new WineIndicatorConverterFactory(_areometrRepository, _grapeVarietyRepository, _calculator);

            Assert.Throws<Exception>(() => factory.GetIndicatorConverter(type, parameter));
        }

        /// <summary>
        /// Проверка на корректность получения ByWineIndicatorConverter с верным типом
        /// </summary>
        [Fact]
        public void GettingWineWithCorrectParameter()
        {
            var type = InitialIndicatorTypes.ByIndicator;
            var parameter = new WineIndicator() { NitrogenValue = 12, EthanolValue = 0, SugarValue = 5, WortValue = 40 };
            var _areometrRepository = new WineRepository<AreometrDefaultValue>();
            var _grapeVarietyRepository = new WineRepository<GrapeVariety>();
            var _calculatorFactory = new CalculatorFactory();
            var _calculator = new UnitsCalculator(_calculatorFactory);
            var factory = new WineIndicatorConverterFactory(_areometrRepository, _grapeVarietyRepository, _calculator);

            var result = factory.GetIndicatorConverter(type, parameter);

            Assert.IsType<ByWineIndicatorConverter>(result);
        }
        /// <summary>
        /// Проверка на корректность получения ByWineIndicatorConverter с не верным типом
        /// </summary>
        [Fact]
        public void GettingWineWithIncorrectParameter()
        {
            var type = InitialIndicatorTypes.ByIndicator;
            var parameter = "some type";
            var _areometrRepository = new WineRepository<AreometrDefaultValue>();
            var _grapeVarietyRepository = new WineRepository<GrapeVariety>();
            var _calculatorFactory = new CalculatorFactory();
            var _calculator = new UnitsCalculator(_calculatorFactory);
            var factory = new WineIndicatorConverterFactory(_areometrRepository, _grapeVarietyRepository, _calculator);

            Assert.Throws<Exception>(() => factory.GetIndicatorConverter(type, parameter));
        }

        /// <summary>
        /// Проверка на корректность получения ByGrapeVarietyIndicatorConverter с верным типом
        /// </summary>
        [Fact]
        public void GettingGrapeVarietyWithCorrectParameter()
        {
            var type = InitialIndicatorTypes.ByGrapeVariety;
            var parameter = "eine sehr gute wine";
            var _areometrRepository = new WineRepository<AreometrDefaultValue>();
            var _grapeVarietyRepository = new WineRepository<GrapeVariety>();
            var _calculatorFactory = new CalculatorFactory();
            var _calculator = new UnitsCalculator(_calculatorFactory);
            var factory = new WineIndicatorConverterFactory(_areometrRepository, _grapeVarietyRepository, _calculator);

            var result = factory.GetIndicatorConverter(type, parameter);

            Assert.IsType<ByGrapeVarietyIndicatorConverter>(result);
        }
        /// <summary>
        /// Проверка на корректность получения ByGrapeVarietyIndicatorConverter с не верным типом
        /// </summary>
        [Fact]
        public void GettingGrapeVarietyWithIncorrectParameter()
        {
            var type = InitialIndicatorTypes.ByGrapeVariety;
            var parameter = 1785;
            var _areometrRepository = new WineRepository<AreometrDefaultValue>();
            var _grapeVarietyRepository = new WineRepository<GrapeVariety>();
            var _calculatorFactory = new CalculatorFactory();
            var _calculator = new UnitsCalculator(_calculatorFactory);
            var factory = new WineIndicatorConverterFactory(_areometrRepository, _grapeVarietyRepository, _calculator);

            Assert.Throws<Exception>(() => factory.GetIndicatorConverter(type, parameter));
        }
        #endregion

        #region ByWineIndicatorConverter Tests
        /// <summary>
        /// Проверка на корректность получения ByGrapeVarietyIndicatorConverter с верным названием сорта
        /// </summary>
        [Fact]
        public void GettingIndicatorByGrapeVarietyWithExistName()
        {
            var parameter = "Агадаи";
            var _grapeVarietyRepository = new WineRepository<GrapeVariety>();
            var _calculatorFactory = new CalculatorFactory();
            var _calculator = new UnitsCalculator(_calculatorFactory);
            var converter = new ByGrapeVarietyIndicatorConverter(parameter, _grapeVarietyRepository, _calculator);

            var result = converter.GetIndicator();

            Assert.NotNull(result);
            Assert.Equal(0.069, result.NitrogenValue);
            Assert.Equal(145, result.SugarValue);
        }

        /// <summary>
        /// Проверка на корректность получения ByGrapeVarietyIndicatorConverter с не верным названием сорта
        /// </summary>
        [Fact]
        public void GettingIndicatorByGrapeVarietyWithNonExistName()
        {
            var parameter = "Бубылдочка";
            var _grapeVarietyRepository = new WineRepository<GrapeVariety>();
            var _calculatorFactory = new CalculatorFactory();
            var _calculator = new UnitsCalculator(_calculatorFactory);
            var converter = new ByGrapeVarietyIndicatorConverter(parameter, _grapeVarietyRepository, _calculator);

            Assert.Throws<Exception>(() => converter.GetIndicator());
        }
        #endregion

        #region ByAreometerIndicatorConverter Tests
        /// <summary>
        /// Проверка на корректность получения ByAreometerIndicatorConverter с существующим показателем ареометра
        /// </summary>
        [Fact]
        public void GettingIndicatorByAreometerWithExistValue()
        {
            var parameter = 1040;
            var _grapeVarietyRepository = new WineRepository<AreometrDefaultValue>();
            var _calculatorFactory = new CalculatorFactory();
            var _calculator = new UnitsCalculator(_calculatorFactory);
            var converter = new ByAreometerIndicatorConverter(parameter, _grapeVarietyRepository, _calculator);

            var result = converter.GetIndicator();

            Assert.NotNull(result);
            Assert.Equal(80, result.SugarValue);
        }

        /// <summary>
        /// Проверка на корректность получения ByAreometerIndicatorConverter с не существующим показателем ареометра
        /// </summary>
        [Fact]
        public void GettingIndicatorByAreometerWithNonExistValue()
        {
            var parameter = 0;
            var _grapeVarietyRepository = new WineRepository<AreometrDefaultValue>();
            var _calculatorFactory = new CalculatorFactory();
            var _calculator = new UnitsCalculator(_calculatorFactory);
            var converter = new ByAreometerIndicatorConverter(parameter, _grapeVarietyRepository, _calculator);

            Assert.Throws<Exception>(() => converter.GetIndicator());
        }
        #endregion
    }
}
