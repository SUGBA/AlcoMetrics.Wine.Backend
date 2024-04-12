using Core.Models.Abstractions;

namespace Core.Actions.Abstractions.EventCalculator
{
    /// <summary>
    /// Фабрика получения калькулятора событий
    /// </summary>
    /// <typeparam name="T"> Enum с описанием типов событий </typeparam>
    /// <typeparam name="I"> Индикатор напитка </typeparam>
    public interface IBaseEventFactory<T, I> where T : Enum where I : BaseIndicator
    {
        /// <summary>
        /// Получить событие
        /// </summary>
        /// <param name="eventType"> Тип события </param>
        /// <param name="desiredIndicator"> Желаемый показатель </param>
        /// <param name="param"> Необязательные параметры </param>
        /// <returns></returns>
        public BaseEventCalculator<I> GetEventCalculater(T eventType, I desiredIndicator, object[]? param = null);
    }
}
