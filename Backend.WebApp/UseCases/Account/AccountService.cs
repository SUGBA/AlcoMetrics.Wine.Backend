using Core.Actions.Abstractions.DataBaseConnector;
using Core.Models.WineRealizations;
using WebApp.UseCases.Account.Abstract;
using WebApp.UseCases.Base.Abstract;

namespace WebApp.UseCases.Account
{
    /// <summary>
    /// Сервси для работы с контроллером AccountController
    /// </summary>
    public class AccountService : BaseWineService, IAccountService
    {
        private readonly IBaseGenericRepository<WineUser> _repository;

        public AccountService(IBaseGenericRepository<WineUser> repository,
            IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _repository = repository;
        }

        /// <summary>
        /// Создание пользователя
        /// </summary>
        /// <param name="login"> Логин </param>
        /// <param name="password"> Пароль </param>
        /// <returns></returns>
        public async Task<bool> RegisterAsync(string? login, string? password, int? id)
        {
            if (login == null || password == null || id == null)
                return false;

            return await Task.Run(() => Register(login, password, (int)id));
        }

        /// <summary>
        /// Создание пользователя
        /// </summary>
        /// <param name="login"> Логин </param>
        /// <param name="password"> Пароль </param>
        /// <returns></returns>
        private bool Register(string login, string password, int id)
        {
            var user = new WineUser() { Login = login, Password = password, Id = id };
            _repository.Add(user);
            _repository.SaveChanges();
            return true;
        }
    }
}
