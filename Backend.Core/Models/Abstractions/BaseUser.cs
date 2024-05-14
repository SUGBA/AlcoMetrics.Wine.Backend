namespace Core.Models.Abstractions
{
    /// <summary>
    /// Базовый пользователь
    /// </summary>
    public abstract class BaseUser<TL> : BaseEntity where TL : BaseEntity
    {
        /// <summary>
        /// Список проектов пользователя
        /// </summary>
        public List<TL> TimeLines { get; set; } = new();
    }
}
