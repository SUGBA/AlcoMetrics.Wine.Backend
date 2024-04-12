using Core.Actions.Abstractions.TimelineCorrector;
using Core.Models.Abstractions;

namespace Core.Actions.Abstractions.TimelineCorrector
{
    /// <summary>
    /// Генератор цепей событий
    /// </summary>
    /// <typeparam name="TL"> ТаймЛайн </typeparam>
    /// <typeparam name="I"> Индикатор </typeparam>
    public interface ITimeLineEventChainCreator<TL, I> where I : BaseIndicator
    {
        /// <summary>
        /// Получить цепь
        /// Цепь - это набор связанных компонентов, которые добавляют системные события к таймлайну
        /// </summary>
        /// <returns></returns>
        public BaseLinkTimeLineEvent<TL, I> GetChains();
    }
}
