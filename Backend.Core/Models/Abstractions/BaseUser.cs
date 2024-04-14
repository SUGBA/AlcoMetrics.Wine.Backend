using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Abstractions
{
    /// <summary>
    /// Базовый пользователь
    /// </summary>
    /// <typeparam name="TE"> Enum с описанием ролей </typeparam>
    public abstract class BaseUser<TE> : BaseEntity where TE : Enum
    {
        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Роль пользователя
        /// </summary>
        public TE UserRole { get; set; }
    }

}
