using Core.Actions.Abstractions.DataBaseConnector;
using Core.Models.WineRealizations;

namespace DataBase.EF.ConnectionFroWine.Repository
{
    /// <summary>
    /// Репозиторий для модуля со списком дней для проекта
    /// </summary>
    public interface ITimeLineServiceRepository : IBaseGenericRepository<WineDay>
    {
        /// <summary>
        /// Получить список дней с включением показателей
        /// Дополнительно передается иднтификатор текущего пользователя, чтобы другие пользователи не могли получать доступ к чужим дням
        /// </summary>
        /// <param name="projectId"> Id проекта </param>
        /// <param name="userId"> Id текущего пользователя </param>
        /// <returns></returns>
        public Task<IEnumerable<WineDay>> GetDaysAsync(int projectId, int userId);
    }
}
