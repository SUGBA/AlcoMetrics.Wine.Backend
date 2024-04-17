using Core.Actions.Abstractions.DataBaseConnector;
using Core.Models.Abstractions;
using Core.Models.WineRealizations;
using WebApp.Services.Account.Abstract;

namespace WebApp.Services.Account
{
    /// <summary>
    /// Сервси для работы с контроллером AccountController
    /// </summary>
    public class AccountService : IAccountService
    {
        private readonly IBaseGenericRepository<WineUser> _repository;

        public AccountService(IBaseGenericRepository<WineUser> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Создание пользователя
        /// </summary>
        /// <param name="login"> Логин </param>
        /// <param name="password"> Пароль </param>
        /// <returns></returns>
        public async Task<bool> RegisterAsync(string? login, string? password)
        {
            if (login == null || password == null)
                return false;

            return await Task.Run(() => Register(login, password));
        }

        /// <summary>
        /// Создание пользователя
        /// </summary>
        /// <param name="login"> Логин </param>
        /// <param name="password"> Пароль </param>
        /// <returns></returns>
        private bool Register(string login, string password)
        {
            var user = new WineUser() { Login = login, Password = password };
            _repository.Add(user);
            _repository.SaveChanges();
            return true;
        }
    }
}
