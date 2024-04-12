using Core.Models.Abstractions;

namespace Core.Actions.Abstractions.EventCalculator
{
    /// <summary>
    /// Базовый калькулятор событий
    /// </summary>
    /// <typeparam name="I"></typeparam>
    public abstract class BaseEventCalculator<I> where I : BaseIndicator
    {
        /// <summary>
        /// Желаемые показатели
        /// </summary>
        protected I currentIndicator;

        /// <summary>
        /// Результирующий индикатор
        /// </summary>
        public I ResultIndicator { get; set; }

        public BaseEventCalculator(I currentIndicator)
        {
            this.currentIndicator = currentIndicator;
            ResultIndicator = CopyItem(currentIndicator);
        }

        /// <summary>
        /// Рассчитать ингридиенты требуемые для достижения заданных показателей
        /// </summary>
        /// <param name="Indicator"></param>
        /// <returns></returns>
        public abstract Dictionary<string, double> Calculate(I Indicator);

        /// <summary>
        /// Метод копирования исходного экземпляра
        /// </summary>
        /// <param name="indicator"> Исходный индикатор </param>
        /// <returns></returns>
        protected abstract I CopyItem(I indicator);
    }
}
