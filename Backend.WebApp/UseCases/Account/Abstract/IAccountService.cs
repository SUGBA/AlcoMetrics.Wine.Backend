namespace WebApp.UseCases.Account.Abstract
{
    /// <summary>
    /// Сервси для работы с контроллером AccountController
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// Создание пользователя
        /// </summary>
        /// <param name="id"> Id нового пользователя </param>
        /// <returns></returns>
        Task<bool> RegisterAsync(int id);
    }
}
