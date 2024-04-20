using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Abstractions
{
    /// <summary>
    /// Базовая справочная информация
    /// </summary>
    /// <typeparam name="TE"> Enum с модулем интерфейса, где используется памятка </typeparam>
    public abstract class BaseReferenceInformation<TE> : BaseEntity where TE : Enum
    {
        /// <summary>
        /// Информация
        /// </summary>
        public string Information { get; set; }

        /// <summary>
        /// Модуль в котором информация используется
        /// </summary>
        public TE UsedModule { get; set; }
    }
}
