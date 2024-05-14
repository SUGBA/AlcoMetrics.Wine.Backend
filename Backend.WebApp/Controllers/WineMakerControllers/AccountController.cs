using Microsoft.AspNetCore.Mvc;
using WebApp.Controllers.Base;
using WebApp.UseCases.Account.Abstract;

namespace WebApp.Controllers.WineMakerControllers
{
    /// <summary>
    /// Контроллер для работы с аккаунтами пользователей
    /// </summary>
    [Route("Account")]
    public class AccountController : BaseWineController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        /// <summary>
        /// Зарегестрировать пользователя
        /// </summary>
        /// <param name="id"> Id нового пользователя </param>
        /// <returns></returns>
        [HttpPost("Register/{id:int}")]
        public async Task<bool> Register(int id)
        {
            return await _accountService.RegisterAsync(id);
        }
    }
}
