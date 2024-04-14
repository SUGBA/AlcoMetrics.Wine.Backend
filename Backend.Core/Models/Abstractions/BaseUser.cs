namespace Core.Models.Abstractions
{
    /// <summary>
    /// Базовый пользователь
    /// </summary>
    public abstract class BaseUser : BaseEntity
    {
        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }
    }
}
