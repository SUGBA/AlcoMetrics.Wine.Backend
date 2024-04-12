using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Abstractions
{
    /// <summary>
    /// Базовый таймлайн
    /// </summary>
    /// <typeparam name="U"> Пользователь, для конкрентного направления </typeparam>
    /// <typeparam name="D"> День, для конкрентного направления </typeparam>
    public abstract class BaseTimeLine<U, D> : BaseEntity
    {
        /// <summary>
        /// Имя таймлайна
        /// </summary>
        public string TimeLineName { get; set; }

        /// <summary>
        /// Владелец таймлайна
        /// </summary>
        public U User { get; set; }

        /// <summary>
        /// Владелец таймлайна
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Список дней таймлайна
        /// </summary>
        public List<D> Days { get; set; } = new List<D>();
    }
}
