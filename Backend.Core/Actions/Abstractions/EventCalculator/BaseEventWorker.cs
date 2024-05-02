using Core.Models.Abstractions;

namespace Core.Actions.Abstractions.EventCalculator
{
    /// <summary>
    /// Базовый фасад для работы с событиями
    /// </summary>
    /// <typeparam name="T"> Enum для с типом добавляемого события </typeparam>
    /// <typeparam name="I"> Тип показателя </typeparam>
    public abstract class BaseEventWorker<T, I> where T : Enum where I : BaseIndicator
    {
        /// <summary>
        /// Фабрика
        /// </summary>
        protected IBaseEventFactory<T, I> eventFactory;

        /// <summary>
        /// Результирующий показатель
        /// </summary>
        public I? ResultIndicator { get; set; }

        public BaseEventWorker(IBaseEventFactory<T, I> eventFactory)
        {
            this.eventFactory = eventFactory;
        }

        /// <summary>
        /// Рассчитать ингридиенты
        /// </summary>
        /// <param name="eventType"> Типы события </param>
        /// <param name="desiredIndicator"> Желаемые показатели </param>
        /// <param name="currentIndicator"> Текущие показатели </param>
        /// <param name="param"> Параметры </param>
        /// <returns></returns>
        public Dictionary<string, double>? CalculateEventIngredients(T eventType, I desiredIndicator, I currentIndicator, object[]? param = null)
        {
            var calculator = GetCalculator(eventType, currentIndicator, param);

            var ingredients = calculator.Calculate(desiredIndicator);

            ResultIndicator = calculator.ResultIndicator;

            return CorrectEventIngredients(ingredients);
        }

        /// <summary>
        /// Получение калькулятора
        /// </summary>
        /// <param name="eventType"> Тип события </param>
        /// <param name="desiredIndicator"> Желаемый индикатор </param>
        /// <param name="param"> Параметры </param>
        /// <returns></returns>
        protected virtual BaseEventCalculator<I> GetCalculator(T eventType, I desiredIndicator, object[]? param = null)
        {
            return eventFactory.GetEventCalculater(eventType, desiredIndicator, param);
        }

        /// <summary>
        /// Корректировки результатов
        /// </summary>
        /// <param name="ingredients"> Полученные ингридиенты </param>
        /// <returns></returns>
        protected virtual Dictionary<string, double> CorrectEventIngredients(Dictionary<string, double> ingredients)
        {
            return ingredients;     //Базовый случай, когда никакие корректировки не требуются
        }
    }
}
