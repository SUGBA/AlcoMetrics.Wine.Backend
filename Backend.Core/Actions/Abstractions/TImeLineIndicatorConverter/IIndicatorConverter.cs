using Core.Models.Abstractions;

namespace Core.Actions.Abstractions.TImeLineIndicatorConverter
{
    /// <summary>
    /// Конвертер из заданных данных в индикатор
    /// </summary>
    /// <typeparam name="I"> Возвращаемый индикатор </typeparam>
    public interface IIndicatorConverter<I> where I : BaseIndicator
    {
        /// <summary>
        /// Получить индикатор
        /// </summary>
        /// <returns></returns>
        public I GetIndicator();
    }
}
