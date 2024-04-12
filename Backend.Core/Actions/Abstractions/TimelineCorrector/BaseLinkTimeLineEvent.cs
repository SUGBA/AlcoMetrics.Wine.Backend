using Core.Models.Abstractions;

namespace Core.Actions.Abstractions.TimelineCorrector
{
    /// <summary>
    /// Базовая цепочка обработки таймлайна
    /// </summary>
    /// <typeparam name="TL"> ТаймЛайн </typeparam>
    /// <typeparam name="I"> Индикатор </typeparam>
    public abstract class BaseLinkTimeLineEvent<TL, I> where I : BaseIndicator
    {
        /// <summary>
        /// Слудующее событие (Если null, значит последнее событие)
        /// </summary>
        protected BaseLinkTimeLineEvent<TL, I>? nextEvent;

        public BaseLinkTimeLineEvent(BaseLinkTimeLineEvent<TL, I>? nextEvent = null)
        {
            this.nextEvent = nextEvent;
        }

        /// <summary>
        /// Рассчитать цепь
        /// </summary>
        /// <param name="timeLine"> Таймлайн </param>
        /// <param name="desiredIndicator"> Желаемый показатель </param>
        public void Calculate(TL timeLine, I desiredIndicator)
        {
            CalculateCurrentEvent(timeLine, desiredIndicator);
            if (nextEvent != null)
                nextEvent.Calculate(timeLine, desiredIndicator);
        }

        /// <summary>
        /// Добавить системное событие к таймлайну для балансирвоки показателей
        /// </summary>
        /// <param name="timeLine"></param>
        /// <param name="indicator"></param>
        protected abstract void CalculateCurrentEvent(TL timeLine, I indicator);
    }
}
