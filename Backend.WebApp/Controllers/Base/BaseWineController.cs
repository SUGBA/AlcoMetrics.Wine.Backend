using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers.Base
{
    /// <summary>
    /// Базовый контроллер для всех контроллеров в виноделии
    /// </summary>
    [EnableCors("AllowAll")]
    public abstract class BaseWineController : Controller
    {
    }
}
