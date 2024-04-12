using Core.Models.Abstractions;

namespace Core.Models.WineRealizations
{
    /// <summary>
    /// Модель типичного события для виноделия
    /// </summary>
    public class WineTypicalEvent : BaseTypicalEvent<WineEventTypes>
    {

    }

    /// <summary>
    /// Типы событий для виноделия
    /// </summary>
    public enum WineEventTypes
    {
        /// <summary>
        /// Шаптализация
        /// </summary>
        Shaptalization = 1,

        /// <summary>
        /// Купажирование
        /// </summary>
        Blending = 2,

        /// <summary>
        /// Крепление
        /// </summary>
        Alcoholization = 3
    }
}
