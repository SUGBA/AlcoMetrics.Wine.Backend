namespace Core.Models.Abstractions
{
    /// <summary>
    /// Базовое типичное событие
    /// </summary>
    /// <typeparam name="TE"> Enum с типами событий </typeparam>
    public abstract class BaseTypicalEvent<TE> : BaseEntity where TE : Enum
    {
        /// <summary>
        /// Наименование события
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Тип события
        /// </summary>
        public TE EventType { get; set; }
    }
}
