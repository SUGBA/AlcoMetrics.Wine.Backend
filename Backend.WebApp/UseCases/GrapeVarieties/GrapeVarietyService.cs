using Core.Actions.Abstractions.DataBaseConnector;
using Core.Models.WineRealizations;
using WebApp.Models.Response.GrapeVarieties;
using WebApp.UseCases.Base.Abstract;
using WebApp.UseCases.GrapeVarieties.Abstract;

namespace WebApp.UseCases.GrapeVarieties
{
    /// <summary>
    /// Имплементация сервиса для работы с сортами винограда
    /// </summary>
    public class GrapeVarietyService : BaseWineService, IGrapeVarietyService
    {
        private readonly IBaseGenericRepository<GrapeVariety> _repository;

        public GrapeVarietyService(IHttpContextAccessor httpContextAccessor, 
            IBaseGenericRepository<GrapeVariety> repository) : base(httpContextAccessor)
        {
            _repository = repository;
        }

        public Task<List<GrapeVarietyResponse>> GetGrapeVarietiesAsync()
        {
            return Task.Run(() => GetGrapeVarieties());
        }

        private List<GrapeVarietyResponse> GetGrapeVarieties()
        {
            return _repository.GetAll().Select(x => Map<GrapeVariety, GrapeVarietyResponse>(x)).ToList();
        }

        public Task<bool> UpdateGrapeVarietyAsync(GrapeVarietyResponse model)
        {
            return Task.Run(() => UpdateGrapeVariety(model));
        }

        private bool UpdateGrapeVariety(GrapeVarietyResponse model)
        {
            return _repository.Update(Map<GrapeVarietyResponse, GrapeVariety>(model));
        }

        public Task<GrapeVarietyResponse> AddGrapeVarietyAsync(GrapeVarietyResponse model)
        {
            return Task.Run(() => AddGrapeVariety(model));
        }

        private GrapeVarietyResponse AddGrapeVariety(GrapeVarietyResponse model)
        {
            var createdId = _repository.Add(Map<GrapeVarietyResponse, GrapeVariety>(model));
            if (createdId != default(int))
            {
                model.Id = createdId;
                return model;
            }
            throw new Exception("Ошибка в ходе создания нового сорта винограда. Id равен 0.");
        }

        public Task<bool> RemoveGrapeVarietyAsync(int id)
        {
            return Task.Run(() => RemoveGrapeVariety(id));
        }

        private bool RemoveGrapeVariety(int id)
        {
            return _repository.Delete(id);
        }
    }
}
