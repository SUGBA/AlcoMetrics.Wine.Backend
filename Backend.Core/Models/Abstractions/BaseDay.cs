using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Abstractions
{
    /// <summary>
    /// Базовый день
    /// </summary>
    /// <typeparam name="BE"> Таймлайн, для выбранного направления </typeparam>
    /// <typeparam name="E"> Событие, для выбранного направления </typeparam>
    /// <typeparam name="I"> Показатель, для выбранного направления </typeparam>
    public abstract class BaseDay<BE, E, I> : BaseEntity
    {
        /// <summary>
        /// Текущая дата
        /// </summary>
        public DateTime CurrentDate { get; set; }

        /// <summary>
        /// TimeLine к которому привзяан этот день
        /// </summary>
        public BE TimeLine { get; set; }

        /// <summary>
        /// TimeLine к которому привзяан этот день
        /// </summary>
        public int TimeLineId { get; set; }

        /// <summary>
        /// События данного дня
        /// </summary>
        public List<E> Events { get; set; } = new List<E>();

        /// <summary>
        /// Показатели данного дня
        /// </summary>
        public I Indicator { get; set; }
    }
}
