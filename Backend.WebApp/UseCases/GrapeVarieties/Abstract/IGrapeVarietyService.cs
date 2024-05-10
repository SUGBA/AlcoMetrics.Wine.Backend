using WebApp.Models.Response.GrapeVarieties;

namespace WebApp.UseCases.GrapeVarieties.Abstract
{
    /// <summary>
    /// Интерфейс для работы с контроллером работы с сортами винограда
    /// </summary>
    public interface IGrapeVarietyService
    {
        /// <summary>
        /// Получить список сортов винограда
        /// </summary>
        /// <returns></returns>
        Task<List<GrapeVarietyResponse>> GetGrapeVarietiesAsync();

        /// <summary>
        /// Отредактировать сорт винограда
        /// </summary>
        /// <param name="model"> Измененная модель </param>
        /// <returns></returns>
        Task<bool> UpdateGrapeVarietyAsync(GrapeVarietyResponse model);

        /// <summary>
        /// Точка для добавления сорта винограда
        /// </summary>
        /// <param name="model"> Добавляемый сорт винограда </param>
        /// <returns></returns>
        Task<GrapeVarietyResponse> AddGrapeVarietyAsync(GrapeVarietyResponse model);

        /// <summary>
        /// Точка для удаления сорта винограда
        /// </summary>
        /// <param name="id"> Id сорта винограда </param>
        /// <returns></returns>
        Task<bool> RemoveGrapeVarietyAsync(int id);
    }
}
