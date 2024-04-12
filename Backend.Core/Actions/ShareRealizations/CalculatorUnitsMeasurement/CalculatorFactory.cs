using Core.Actions.Abstractions.CalculatorUnitsMeasurement;

namespace Core.Actions.ShareRealizations.CalculatorUnitsMeasurement
{
    public class CalculatorFactory : IBaseCalculatorFactory<MeasurementUnits>
    {
        public IBaseCalculator GetCalculator(MeasurementUnits fromType, MeasurementUnits toType)
        {
            switch ((fromType, toType))
            {
                case (MeasurementUnits.KilogramPerCubicMeter, MeasurementUnits.GramPer100CubicCentimeter):
                    return new KilogramPerCubyMeterToGramPer100CubyCentimeterCalculator();
                case (MeasurementUnits.Gram, MeasurementUnits.Kilogram):
                    return new GramToKilogramCalculator();
                case (MeasurementUnits.Liters, MeasurementUnits.Milliliters):
                    return new LitersToMillilitersCalculator();
                case (MeasurementUnits.GramPer100CubicCentimeter, MeasurementUnits.GramPer100CubicDecimeter):
                    return new GramPer100CubyCentimeterToGramPer100CubyDecimeterCalculator();
                case (MeasurementUnits.KilogramPerCubicMeter, MeasurementUnits.GramPer100CubicDecimeter):
                    return new KilogramPerCubyMeterToGramPer100CubyDecimeterCalculator();
                case (MeasurementUnits.Kilogram, MeasurementUnits.Gram):
                    return new KilogramToGramCalculator();
                case (MeasurementUnits.Milliliters, MeasurementUnits.Liters):
                    return new MillilitersToLitersCalculator();
                case (MeasurementUnits.GramPer100CubicDecimeter, MeasurementUnits.GramPer100CubicCentimeter):
                    return new GramPer100CubyDecimeterToGramPer100CubyCentimeterCalculator();
                case (MeasurementUnits.GramPer100CubicDecimeter, MeasurementUnits.KilogramPerCubicMeter):
                    return new GramPer100CubyDecimeterToKilogramPerCubyMeterCalculator();
                case (MeasurementUnits.GramPer100CubicCentimeter, MeasurementUnits.KilogramPerCubicMeter):
                    return new GramPer100CubyCentimeterToKilogramPerCubyMeterCalculator();
                case (MeasurementUnits.GramPerLiter, MeasurementUnits.Percentage):
                    return new GramPerLiterToPercentageCaltulator();
                case (MeasurementUnits.Percentage, MeasurementUnits.GramPerLiter):
                    return new PercentageToGramPerLiterCalculator();
                case (MeasurementUnits.GramPerLiter, MeasurementUnits.GramPer100CubicCentimeter):
                    return new GramPerLiterToGramPer100CubicCentimeterCalculator();
                case (MeasurementUnits.GramPer100CubicCentimeter, MeasurementUnits.GramPerLiter):
                    return new GramPer100CubicCentimeterToGramPerLiterCalculator();
                case (MeasurementUnits.GramPerLiter, MeasurementUnits.GramPer100CubicDecimeter):
                    return new GramPerLiterToGramPer100CubicDecimeterCalculator();
                case (MeasurementUnits.GramPer100CubicDecimeter, MeasurementUnits.GramPerLiter):
                    return new GramPer100CubicDecimeterToGramPerLiterCalculator();
                case (MeasurementUnits.KilogramPerLiter, MeasurementUnits.GramPerLiter):
                    return new KilogramPerLiterToGramPerLiter();
                default:
                    throw new Exception($"Не найден соответствующий калькулятор: \n{fromType}->{toType}");
            }
        }
    }

    /// <summary>
    /// Единицы измерения
    /// </summary>
    public enum MeasurementUnits
    {
        /// <summary>
        /// Грамм
        /// </summary>
        Gram = 1,

        /// <summary>
        /// Килограмм
        /// </summary>
        Kilogram = 2,

        /// <summary>
        /// Килограм/Метр^3
        /// </summary>
        KilogramPerCubicMeter = 3,

        /// <summary>
        /// Грам/100сантиметр^3
        /// </summary>
        GramPer100CubicCentimeter = 4,

        /// <summary>
        /// Грам/100дицеметр^3
        /// </summary>
        GramPer100CubicDecimeter = 5,

        /// <summary>
        /// Литры
        /// </summary>
        Liters = 6,

        /// <summary>
        /// Милилитры
        /// </summary>
        Milliliters = 7,

        /// <summary>
        /// Грамм/Литр
        /// </summary>
        GramPerLiter = 8,

        /// <summary>
        /// Процентное содержание
        /// </summary>
        Percentage = 9,

        /// <summary>
        /// Килограмм/Литр
        /// </summary>
        KilogramPerLiter = 10
    }
}
