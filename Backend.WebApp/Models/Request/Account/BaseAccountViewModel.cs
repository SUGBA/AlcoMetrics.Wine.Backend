using System.Text.Json.Serialization;

namespace WebApp.Models.Request.Account
{
    /// <summary>
    /// Базовый класс для работы с аккаунтом. (Часто используются поля логин и пароль)
    /// </summary>
    public abstract class BaseAccountViewModel
    {
        /// <summary>
        /// Логин пользователя
        /// </summary>
        [JsonPropertyName("Login")]
        public string? Login { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        [JsonPropertyName("Password")]
        public string? Password { get; set; }
    }
}
