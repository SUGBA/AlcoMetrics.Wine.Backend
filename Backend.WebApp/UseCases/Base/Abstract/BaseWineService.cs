using AutoMapper;
using WebApp.Services.AutoMap.Profiles;

namespace WebApp.UseCases.Base.Abstract
{
    /// <summary>
    /// Базовый сервис для всех сервисов в виноделии
    /// </summary>
    public class BaseWineService
    {
        private readonly IMapper _mapper;

        private readonly HttpContextAccessor _httpContextAccessor;

        protected BaseWineService(IMapper mapper, HttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        protected BaseWineService()
        {
            //_mapper = ConfigureAutoMaper();
        }

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
        /// Создаем экземпляр AutoMapper'а, чтобы не тянуть все дочерние классы
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
