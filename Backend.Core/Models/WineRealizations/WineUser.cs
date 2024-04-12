using Core.Models.Abstractions;

namespace Core.Models.WineRealizations
{
    /// <summary>
    /// Пользователь в виноделии
    /// </summary>
    public class WineUser : BaseUser<UserRoles>
    {
        /// <summary>
        /// Список тайм-лайнов
        /// </summary>
        public WineTimeLine TimeLines { get; set; }
    }

    /// <summary>
    /// Пользовательские роли
    /// </summary>
    public enum UserRoles
    {
        /// <summary>
        /// Пользователь
        /// </summary>
        User = 1,
        /// <summary>
        /// Администратор
        /// </summary>
        Administrator = 2
    }
}
