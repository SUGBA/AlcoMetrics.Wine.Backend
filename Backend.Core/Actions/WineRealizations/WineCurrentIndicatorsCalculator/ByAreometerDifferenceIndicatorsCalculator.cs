using Core.Actions.Abstractions.CurrentIndicatorsCalculator;
using Core.Actions.Abstractions.DataBaseConnector;
using Core.Models.WineRealizations;

namespace Core.Actions.WineRealizations.WineCurrentIndicatorsCalculator
{
    /// <summary>
    /// Калькулятор текущих показателей по показаниям ареометра
    /// </summary>
    public class ByAreometerDifferenceIndicatorsCalculator : IBaseCurrentIndicatorsCalculator<WineIndicator>
    {
        private IBaseGenericRepository<DifferenceAreometrDefaultValue> repository;

        /// <summary>
        /// Начальное показание ареометра
        /// </summary>
        private double areometerStartValue;

        /// <summary>
        /// Текущее показание ареометра
        /// </summary>
        private double areometerCurrentValue;

        public ByAreometerDifferenceIndicatorsCalculator(int areometerStartValue, int areometerCurrentValue,
            IBaseGenericRepository<DifferenceAreometrDefaultValue> repository)
        {
            this.areometerStartValue = areometerStartValue;
            this.areometerCurrentValue = areometerCurrentValue;
            this.repository = repository;
        }

        public WineIndicator Calculate()
        {
            //Сахар: г/100см3
            //Спирт: %
            var differenceValue = (int)(areometerStartValue - areometerCurrentValue);
            var indicator = repository.GetAll().Where(x => x.DifferenceAreometerValue == differenceValue).FirstOrDefault();
            if (indicator == null) throw new Exception("Некорректное значение разницы показаний Ареометра");
            return new WineIndicator() { SugarValue = indicator.SugarValue, EthanolValue = indicator.EthanolValue };
        }
    }
}
