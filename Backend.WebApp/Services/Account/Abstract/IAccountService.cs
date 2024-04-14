namespace WebApp.Services.Account.Abstract
{
    /// <summary>
    /// Сервси для работы с контроллером AccountController
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// Создание пользователя
        /// </summary>
        /// <param name="login"> Логин </param>
        /// <param name="password"> Пароль </param>
        /// <returns></returns>
        Task RegisterAsync(string? login, string? password);
    }
}
