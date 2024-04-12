using Core.Models.Abstractions;

namespace Core.Actions.Abstractions.TImeLineIndicatorConverter
{
    /// <summary>
    /// Фабрика получения ковертера начальных значений
    /// </summary>
    /// <typeparam name="T"> Enum с типом начальных показаний</typeparam>
    /// <typeparam name="I"> BaseIndicator </typeparam>
    public interface IIndicatorConverterFactory<T, I> where I : BaseIndicator
    {
        /// <summary>
        /// Получить конвертер
        /// </summary>
        /// <param name="type"> Тип начальных показаний </param>
        /// <param name="param"> Параметр </param>
        /// <returns></returns>
        public IIndicatorConverter<I>? GetIndicatorConverter(T type, object param);
    }
}
