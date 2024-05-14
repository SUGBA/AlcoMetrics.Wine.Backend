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
        /// <param name="id"> Id нового пользователя </param>
        /// <returns></returns>
        public Task<bool> RegisterAsync(int id)
        {
            return Task.Run(() => Register(id));
        }

        /// <summary>
        /// Создание пользователя
        /// </summary>
        /// <param name="id"> Id нового пользователя </param>
        /// <returns></returns>
        private bool Register(int id)
        {
            var user = new WineUser() { Id = id };
            _repository.Add(user);
            return true;
        }
    }
}
