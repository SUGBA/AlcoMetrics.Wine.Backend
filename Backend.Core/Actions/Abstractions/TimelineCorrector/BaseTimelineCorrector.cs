using Core.Models.Abstractions;

namespace Core.Actions.Abstractions.TimelineCorrector
{
    /// <summary>
    /// Редактор таймлайна
    /// </summary>
    /// <typeparam name="TL"> Таймлайн </typeparam>
    /// <typeparam name="I"> Индикатор </typeparam>
    public abstract class BaseTimelineCorrector<TL, I> where I : BaseIndicator
    {
        /// <summary>
        /// Создать цепи
        /// </summary>
        protected ITimeLineEventChainCreator<TL, I> chainCreator;

        public BaseTimelineCorrector(ITimeLineEventChainCreator<TL, I> chainCreator)
        {
            this.chainCreator = chainCreator;
        }

        /// <summary>
        /// Скорректировать таймлайн
        /// </summary>
        /// <param name="timeLine"> Искомый таймлайн </param>
        /// <param name="desiredIndicator"> Желаемые показатели </param>
        public void CorrectTimeLIne(TL timeLine, I desiredIndicator)
        {
            var chain = ConfigureChain();
            chain.Calculate(timeLine, desiredIndicator);
        }

        /// <summary>
        /// Получить цепь
        /// </summary>
        /// <returns></returns>
        protected virtual BaseLinkTimeLineEvent<TL, I> ConfigureChain()
        {
            return chainCreator.GetChains();
        }
    }
}
