using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Request.Account;
using WebApp.Services.Account.Abstract;

namespace WebApp.Controllers
{
    /// <summary>
    /// Контроллер для работы с аккаунтами пользователей
    /// </summary>
    [Route("Account")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        /// <summary>
        /// Зарегестрировать пользователя
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Register")]
        public async Task Register([FromBody] RegisterViewModel model)
        {
            await _accountService.RegisterAsync(model.Login, model.Password);
        }
    }
}
