using Core.Actions.Abstractions.CalculatorUnitsMeasurement;
using Core.Actions.ShareRealizations.CalculatorUnitsMeasurement;
using Core.Models.WineRealizations;

namespace Core.Actions.Abstractions.CurrentIndicatorsCalculator
{
    public abstract class BaseCurrentIndicatorCalculatorWorker<T, I> where T : Enum where I : WineIndicator
    {
        protected readonly IBaseUnitsCalculator<MeasurementUnits> unitsCalculator;

        protected readonly IBaseCurrentIndicatorsCalculatorFactory<T, I> indicatorCalculatorFactory;

        protected BaseCurrentIndicatorCalculatorWorker(IBaseCurrentIndicatorsCalculatorFactory<T, I> indicatorCalculatorFactory)
        {
            this.indicatorCalculatorFactory = indicatorCalculatorFactory;
        }

        public BaseCurrentIndicatorCalculatorWorker(IBaseUnitsCalculator<MeasurementUnits> unitsCalculator,
            IBaseCurrentIndicatorsCalculatorFactory<T, I> indicatorCalculatorFactory)
        {
            this.unitsCalculator = unitsCalculator;
            this.indicatorCalculatorFactory = indicatorCalculatorFactory;
        }

        public I? Calculate(T type, object[] param)
        {
            var calculator = GetCalculator(type, param);

            var result = calculator.Calculate();

            return CorrectResult(result);
        }

        /// <summary>
        /// Получить калькулятор
        /// </summary>
        /// <param name="type"> Тип рассчета </param>
        /// <param name="param"> Параметры для рассчета </param>
        /// <returns></returns>
        protected virtual IBaseCurrentIndicatorsCalculator<I> GetCalculator(T type, object[] param)
        {
            return indicatorCalculatorFactory.GetCurrentIndicatorsCalculator(type, param);
        }

        /// <summary>
        /// Скорректировать значение
        /// </summary>
        /// <param name="calculator"> Калькулятор </param>
        /// <returns></returns>
        protected virtual I? CorrectResult(I indicator)
        {
            //Базовый случай, когда никаке корректировки не требуются
            return indicator;
        }
    }
}
