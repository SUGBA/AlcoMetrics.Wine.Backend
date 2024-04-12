using Core.Models.Abstractions;

namespace Core.Actions.Abstractions.CurrentIndicatorsCalculator
{
    /// <summary>
    /// Рассчет актуальных показателей сусла
    /// </summary>
    /// <typeparam name="I"> Индикатор напитка </typeparam>
    public interface IBaseCurrentIndicatorsCalculator<I> where I : BaseIndicator
    {
        /// <summary>
        /// Рассчитать актуальное показание
        /// </summary>
        /// <returns></returns>
        public I Calculate();
    }
}
