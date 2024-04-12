using Core.Models.WineRealizations;

namespace Core.Actions.Abstractions.CurrentIndicatorsCalculator
{
    /// <summary>
    /// Фабрика получения калькулятора актуального состояния
    /// </summary>
    /// <typeparam name="T"> Enum с видом определения актуального состояния </typeparam>
    /// <typeparam name="I"> Показатель напитка </typeparam>
    public interface IBaseCurrentIndicatorsCalculatorFactory<T, I> where T : Enum where I : WineIndicator
    {
        public IBaseCurrentIndicatorsCalculator<I> GetCurrentIndicatorsCalculator(T type, object[] param);
    }
}
