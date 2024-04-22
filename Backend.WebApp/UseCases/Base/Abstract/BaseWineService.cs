using AutoMapper;
using WebApp.Extensions;
using WebApp.Services.AutoMap.Profiles;

namespace WebApp.UseCases.Base.Abstract
{
    /// <summary>
    /// Базовый сервис для всех сервисов в виноделии
    /// </summary>
    public class BaseWineService
    {
        private readonly IMapper _mapper;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public BaseWineService(IHttpContextAccessor httpContextAccessor)
        {
            _mapper = ConfigureAutoMaper();
            _httpContextAccessor = httpContextAccessor;
        }

        #region UserClaims

        /// <summary>
        /// Получить идентификатор текущего пользователя
        /// </summary>
        /// <returns></returns>
        protected int? GetUserId()
        {
            return _httpContextAccessor?.HttpContext?.User.GetUserId();
        }

        #endregion

        #region AuttoMapper

        /// <summary>
        /// Мап сущностей
        /// </summary>
        /// <typeparam name="TFrom"> Тип из которого мапим </typeparam>
        /// <typeparam name="TTo"> Тип в который мапим </typeparam>
        /// <param name="item"> Объект </param>
        /// <returns></returns>
        public TTo Map<TFrom, TTo>(TFrom item)
        {
            return _mapper.Map<TTo>(item);
        }

        /// <summary>
        /// Создаем экземпляр AutoMapper'а, чтобы не тянуть зависимость во все дочерние классы
        /// </summary>
        /// <returns></returns>
        private IMapper ConfigureAutoMaper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<IntegrationAPIProfile>();
                cfg.AddProfile<Client2DomenModeProfile>();
            });
            return config.CreateMapper();
        }
        #endregion
    }
}
