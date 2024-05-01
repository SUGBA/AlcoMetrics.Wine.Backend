using Core.Actions.Abstractions.CurrentIndicatorsCalculator;
using Core.Actions.Abstractions.DataBaseConnector;
using Core.Models.WineRealizations;
using Core.Models.WineRealizations.Enums;

namespace Core.Actions.WineRealizations.WineCurrentIndicatorsCalculator
{
    /// <summary>
    /// Фабрика получения калькулятора актуальных состояний для виноделия
    /// </summary>
    public class WineCurrentIndicatorsCalculatorFactory : IBaseCurrentIndicatorsCalculatorFactory<UpdateIndicatorTypes, WineIndicator>
    {
        private IBaseGenericRepository<DifferenceAreometrDefaultValue> differenceAreometRrepository;

        public WineCurrentIndicatorsCalculatorFactory(IBaseGenericRepository<DifferenceAreometrDefaultValue> differenceAreometRrepository)
        {
            this.differenceAreometRrepository = differenceAreometRrepository;
        }

        public IBaseCurrentIndicatorsCalculator<WineIndicator> GetCurrentIndicatorsCalculator(UpdateIndicatorTypes type, object[] param)
        {
            switch (type)
            {
                case UpdateIndicatorTypes.ByAreometr:
                    if (param[0] is int && param[1] is int)
                        return new ByAreometerDifferenceIndicatorsCalculator((int)param[0], (int)param[1], differenceAreometRrepository);
                    throw new Exception("Некорректные параметры");
                default:
                    throw new Exception("Несущесвтующий способ определения актуальных показатеелй");
            }
        }
    }
}
