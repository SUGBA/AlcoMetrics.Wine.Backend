using Core.Actions.ShareRealizations.CalculatorUnitsMeasurement;
using Xunit.Abstractions;

namespace Tests
{
    public class CalculatorUnitsMeasurementTests : BaseTest
    {
        public CalculatorUnitsMeasurementTests(ITestOutputHelper output) : base(output) { }

        #region Проверки фабрики
        /// <summary>
        /// Перевести из Кг/м^3 в Г/см^3
        /// </summary>
        [Fact]
        public void GetKilogramPerCubyMeterToGramPerCubyCentimeterCalculatorTest()
        {
            var factory = new CalculatorFactory();
            var fromType = MeasurementUnits.KilogramPerCubicMeter;
            var toType = MeasurementUnits.GramPer100CubicCentimeter;

            var result = factory.GetCalculator(fromType, toType);

            Assert.IsType<KilogramPerCubyMeterToGramPer100CubyCentimeterCalculator>(result);
        }

        /// <summary>
        /// Перевести из Г в Кг
        /// </summary>
        [Fact]
        public void GetGramToKilogramCalculatorTest()
        {
            var factory = new CalculatorFactory();
            var fromType = MeasurementUnits.Gram;
            var toType = MeasurementUnits.Kilogram;

            var result = factory.GetCalculator(fromType, toType);

            Assert.IsType<GramToKilogramCalculator>(result);
        }

        /// <summary>
        /// Перевести из Л в Мл
        /// </summary>
        [Fact]
        public void GetLitersToMillilitersCalculatorTest()
        {
            var factory = new CalculatorFactory();
            var fromType = MeasurementUnits.Liters;
            var toType = MeasurementUnits.Milliliters;

            var result = factory.GetCalculator(fromType, toType);

            Assert.IsType<LitersToMillilitersCalculator>(result);
        }

        /// <summary>
        /// Перевести из Г/см^3 в Г/дм^3
        /// </summary>
        [Fact]
        public void GetGramPerCubyCentimeterToGramPerCubyDecimeterCalculatorTest()
        {
            var factory = new CalculatorFactory();
            var fromType = MeasurementUnits.GramPer100CubicCentimeter;
            var toType = MeasurementUnits.GramPer100CubicDecimeter;

            var result = factory.GetCalculator(fromType, toType);

            Assert.IsType<GramPer100CubyCentimeterToGramPer100CubyDecimeterCalculator>(result);
        }

        /// <summary>
        /// Перевести из Кг/м^3 в Г/дм^3
        /// </summary>
        [Fact]
        public void GetKilogramPerCubyMeterToGramPerCubyDecimeterCalculatorTest()
        {
            var factory = new CalculatorFactory();
            var fromType = MeasurementUnits.KilogramPerCubicMeter;
            var toType = MeasurementUnits.GramPer100CubicDecimeter;

            var result = factory.GetCalculator(fromType, toType);

            Assert.IsType<KilogramPerCubyMeterToGramPer100CubyDecimeterCalculator>(result);
        }

        /// <summary>
        /// Перевести из Кг в Г
        /// </summary>
        [Fact]
        public void GetKilogramToGramCalculatorTest()
        {
            var factory = new CalculatorFactory();
            var fromType = MeasurementUnits.Kilogram;
            var toType = MeasurementUnits.Gram;

            var result = factory.GetCalculator(fromType, toType);

            Assert.IsType<KilogramToGramCalculator>(result);
        }

        /// <summary>
        /// Перевести из Мл в Л
        /// </summary>
        [Fact]
        public void GetMillilitersToLitersCalculatorTest()
        {
            var factory = new CalculatorFactory();
            var fromType = MeasurementUnits.Milliliters;
            var toType = MeasurementUnits.Liters;

            var result = factory.GetCalculator(fromType, toType);

            Assert.IsType<MillilitersToLitersCalculator>(result);
        }

        /// <summary>
        /// Перевести из Г/дм^3 в Г/см^3
        /// </summary>
        [Fact]
        public void GetGramPerCubyDecimeterToGramPerCubyCentimeterCalculatorTest()
        {
            var factory = new CalculatorFactory();
            var fromType = MeasurementUnits.GramPer100CubicDecimeter;
            var toType = MeasurementUnits.GramPer100CubicCentimeter;

            var result = factory.GetCalculator(fromType, toType);

            Assert.IsType<GramPer100CubyDecimeterToGramPer100CubyCentimeterCalculator>(result);
        }

        /// <summary>
        /// Перевести из Г/дм^3 в Кг/м^3
        /// </summary>
        [Fact]
        public void GetGramPerCubyDecimeterToKilogramPerCubyMeterCalculatorTest()
        {
            var factory = new CalculatorFactory();
            var fromType = MeasurementUnits.GramPer100CubicDecimeter;
            var toType = MeasurementUnits.KilogramPerCubicMeter;

            var result = factory.GetCalculator(fromType, toType);

            Assert.IsType<GramPer100CubyDecimeterToKilogramPerCubyMeterCalculator>(result);
        }

        /// <summary>
        /// Перевести из Г/см^3 в Кг/м^3
        /// </summary>
        [Fact]
        public void GetGramPerCubyCentimeterToKilogramPerCubyMeterCalculatorTest()
        {
            var factory = new CalculatorFactory();
            var fromType = MeasurementUnits.GramPer100CubicCentimeter;
            var toType = MeasurementUnits.KilogramPerCubicMeter;

            var result = factory.GetCalculator(fromType, toType);

            Assert.IsType<GramPer100CubyCentimeterToKilogramPerCubyMeterCalculator>(result);
        }

        /// <summary>
        /// Перевести из Г/л в % Алкоголя
        /// </summary>
        [Fact]
        public void GetGramPerLiterToAlcoholPercentageCaltulatorTest()
        {
            var factory = new CalculatorFactory();
            var fromType = MeasurementUnits.GramPerLiter;
            var toType = MeasurementUnits.Percentage;

            var result = factory.GetCalculator(fromType, toType);

            Assert.IsType<GramPerLiterToPercentageCaltulator>(result);
        }

        /// <summary>
        /// Перевести из Г/л в Г/см^3
        /// </summary>
        [Fact]
        public void GetGramPerLiterToGramPerCubicCentimeterCalculatorTest()
        {
            var factory = new CalculatorFactory();
            var fromType = MeasurementUnits.GramPerLiter;
            var toType = MeasurementUnits.GramPer100CubicCentimeter;

            var result = factory.GetCalculator(fromType, toType);

            Assert.IsType<GramPerLiterToGramPer100CubicCentimeterCalculator>(result);
        }

        /// <summary>
        /// Перевести из Г/см^3 в Г/л
        /// </summary>
        [Fact]
        public void GetGramPerCubicCentimeterToGramPerLiterCalculatorTest()
        {
            var factory = new CalculatorFactory();
            var fromType = MeasurementUnits.GramPer100CubicCentimeter;
            var toType = MeasurementUnits.GramPerLiter;

            var result = factory.GetCalculator(fromType, toType);

            Assert.IsType<GramPer100CubicCentimeterToGramPerLiterCalculator>(result);
        }

        /// <summary>
        /// Перевести из Г/л в Г/дм^3
        /// </summary>
        [Fact]
        public void GetGramPerLiterToGramPerCubicDecimeterCalculatorTest()
        {
            var factory = new CalculatorFactory();
            var fromType = MeasurementUnits.GramPerLiter;
            var toType = MeasurementUnits.GramPer100CubicDecimeter;

            var result = factory.GetCalculator(fromType, toType);

            Assert.IsType<GramPerLiterToGramPer100CubicDecimeterCalculator>(result);
        }

        /// <summary>
        /// Перевести из Г/дм^3 в Г/л
        /// </summary>
        [Fact]
        public void GetGramPerCubicDecimeterToGramPerLiterCalculatorTest()
        {
            var factory = new CalculatorFactory();
            var fromType = MeasurementUnits.GramPer100CubicDecimeter;
            var toType = MeasurementUnits.GramPerLiter;

            var result = factory.GetCalculator(fromType, toType);

            Assert.IsType<GramPer100CubicDecimeterToGramPerLiterCalculator>(result);
        }
        #endregion

        #region Проверки калькуляторов
        /// <summary>
        /// Перевести из Кг/м^3 в Г/100см^3
        /// </summary>
        [Fact]
        public void ValuesKilogramPerCubyMeterToGramPer100CubyCentimeterCalculatorTest()
        {
            var calculator = new KilogramPerCubyMeterToGramPer100CubyCentimeterCalculator();
            var value = 1000d;
            var expectedValue = 100d;

            var result = calculator.Calculate(value);

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void ValuesPercentageToGramPerLiterCalculatorCalculatorTest()
        {
            var calculator = new PercentageToGramPerLiterCalculator();
            var value = 1d;
            var expectedValue = 10d;

            var result = calculator.Calculate(value);

            Assert.Equal(expectedValue, result);
        }

        /// <summary>
        /// Перевести из Г в Кг
        /// </summary>
        [Fact]
        public void ValuesGramToKilogramCalculatorTest()
        {
            var calculator = new GramToKilogramCalculator();
            var value = 1000d;
            var expectedValue = 1d;

            var result = calculator.Calculate(value);

            Assert.Equal(expectedValue, result);
        }

        /// <summary>
        /// Перевести из Л в Мл
        /// </summary>
        [Fact]
        public void ValuesLitersToMillilitersCalculatorTest()
        {
            var calculator = new LitersToMillilitersCalculator();
            var value = 1d;
            var expectedValue = 1000d;

            var result = calculator.Calculate(value);

            Assert.Equal(expectedValue, result);
        }

        /// <summary>
        /// Перевести из Г/100см^3 в Г/100дм^3
        /// </summary>
        [Fact]
        public void ValuesGramPer100CubyCentimeterToGramPer100CubyDecimeterCalculatorTest()
        {
            var calculator = new GramPer100CubyCentimeterToGramPer100CubyDecimeterCalculator();
            var value = 1d;
            var expectedValue = 1000d;

            var result = calculator.Calculate(value);

            Assert.Equal(expectedValue, result);
        }

        /// <summary>
        /// Перевести из Кг/м^3 в Г/100дм^3
        /// </summary>
        [Fact]
        public void ValuesKilogramPerCubyMeterToGramPer100CubyDecimeterCalculatorTest()
        {
            var calculator = new KilogramPerCubyMeterToGramPer100CubyDecimeterCalculator();
            var value = 1d;
            var expectedValue = 100d;

            var result = calculator.Calculate(value);

            Assert.Equal(expectedValue, result);
        }

        /// <summary>
        /// Перевести из Кг в Г
        /// </summary>
        [Fact]
        public void ValuesKilogramToGramCalculatorTest()
        {
            var calculator = new KilogramToGramCalculator();
            var value = 1d;
            var expectedValue = 1000d;

            var result = calculator.Calculate(value);

            Assert.Equal(expectedValue, result);
        }

        /// <summary>
        /// Перевести из Мл в Л
        /// </summary>
        [Fact]
        public void ValuesMillilitersToLitersCalculatorTest()
        {
            var calculator = new MillilitersToLitersCalculator();
            var value = 1000d;
            var expectedValue = 1d;

            var result = calculator.Calculate(value);

            Assert.Equal(expectedValue, result);
        }

        /// <summary>
        /// Перевести из Г/100дм^3 в Г/100см^3
        /// </summary>
        [Fact]
        public void ValuesGramPer100CubyDecimeterToGramPer100CubyCentimeterCalculatorTest()
        {
            var calculator = new GramPer100CubyDecimeterToGramPer100CubyCentimeterCalculator();
            var value = 1000d;
            var expectedValue = 1d;

            var result = calculator.Calculate(value);

            Assert.Equal(expectedValue, result);
        }

        /// <summary>
        /// Перевести из Г/100дм^3 в Кг/м^3
        /// </summary>
        [Fact]
        public void ValuesGramPer100CubyDecimeterToKilogramPerCubyMeterCalculatorTest()
        {
            var calculator = new GramPer100CubyDecimeterToKilogramPerCubyMeterCalculator();
            var value = 100d;
            var expectedValue = 1d;

            var result = calculator.Calculate(value);

            Assert.Equal(expectedValue, result);
        }

        /// <summary>
        /// Перевести из Г/100см^3 в Кг/м^3
        /// </summary>
        [Fact]
        public void ValuesGramPer100CubyCentimeterToKilogramPerCubyMeterCalculatorTest()
        {
            var calculator = new GramPer100CubyCentimeterToKilogramPerCubyMeterCalculator();
            var value = 1;
            var expectedValue = 10d;

            var result = calculator.Calculate(value);

            Assert.Equal(expectedValue, result);
        }

        /// <summary>
        /// Перевести из Г/л в % Алкоголя
        /// </summary>
        [Fact]
        public void ValuesGramPerLiterToAlcoholPercentageCaltulatorTest()
        {
            var calculator = new GramPerLiterToPercentageCaltulator();
            var value = 100d;
            var expectedValue = 10d;

            var result = calculator.Calculate(value);

            Assert.Equal(expectedValue, result);
        }

        /// <summary>
        /// Перевести из Г/л в Г/100см^3
        /// </summary>
        [Fact]
        public void ValuesGramPerLiterToGramPer100CubicCentimeterCalculatorTest()
        {
            var calculator = new GramPerLiterToGramPer100CubicCentimeterCalculator();
            var value = 1000d;
            var expectedValue = 100d;

            var result = calculator.Calculate(value);

            Assert.Equal(expectedValue, result);
        }

        /// <summary>
        /// Перевести из Г/100см^3 в Г/л
        /// </summary>
        [Fact]
        public void ValuesGramPer100CubicCentimeterToGramPerLiterCalculatorTest()
        {
            var calculator = new GramPer100CubicCentimeterToGramPerLiterCalculator();
            var value = 1d;
            var expectedValue = 10d;

            var result = calculator.Calculate(value);

            Assert.Equal(expectedValue, result);
        }

        /// <summary>
        /// Перевести из Г/л в Г/100дм^3
        /// </summary>
        [Fact]
        public void ValuesGramPerLiterToGramPer100CubicDecimeterCalculatorTest()
        {
            var calculator = new GramPerLiterToGramPer100CubicDecimeterCalculator();
            var value = 1d;
            var expectedValue = 100d;

            var result = calculator.Calculate(value);

            Assert.Equal(expectedValue, result);
        }

        /// <summary>
        /// Перевести из Г/100дм^3 в Г/л
        /// </summary>
        [Fact]
        public void ValuesGramPer100CubicDecimeterToGramPerLiterCalculatorTest()
        {
            var calculator = new GramPer100CubicDecimeterToGramPerLiterCalculator();
            var value = 1d;
            var expectedValue = 0.01d;

            var result = calculator.Calculate(value);

            Assert.Equal(expectedValue, result);
        }
        #endregion
    }
}
