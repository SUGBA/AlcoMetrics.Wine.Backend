using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Abstractions
{
    /// <summary>
    /// Базовое событие
    /// </summary>
    /// <typeparam name="S"> Типичное событие, для выбранного направления </typeparam>
    /// <typeparam name="BE"> День, для выбранного направления </typeparam>
    /// <typeparam name="I"> Индикатор </typeparam>
    public abstract class BaseEvent<S, BE, I> : BaseEntity
    {
        /// <summary>
        /// Тип события (Системное/Пользовательское)
        /// </summary>
        public EventCustomTypes EventType { get; set; }

        /// <summary>
        /// Типовое событие, для данного события
        /// </summary>
        public S TypicalEvent { get; set; }

        /// <summary>
        /// Типовое событие, для данного события
        /// </summary>
        public int TypicalEventId { get; set; }

        /// <summary>
        /// Выполненность события
        /// </summary>
        public bool IsCompleted { get; set; }

        /// <summary>
        /// День к которому привязано данное событие
        /// </summary>
        public BE Day { get; set; }

        /// <summary>
        /// День к которому привязано данное событие
        /// </summary>
        public int DayId { get; set; }

        /// <summary>
        /// Желаемые показатели
        /// </summary>
        public int DesiredIndicatorId { get; set; }

        /// <summary>
        /// Желаемые показатели
        /// </summary>
        public I DesiredIndicator { get; set; }
    }

    /// <summary>
    /// Тип события
    /// </summary>
    public enum EventCustomTypes
    {
        System = 1,
        Custom = 2
    }
}
