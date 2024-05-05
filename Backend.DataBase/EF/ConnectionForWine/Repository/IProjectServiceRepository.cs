using Core.Actions.Abstractions.DataBaseConnector;
using Core.Models.WineRealizations;

namespace DataBase.EF.ConnectionForWine.Repository
{
    /// <summary>
    /// Репозиторий для модуля ProjectPage
    /// </summary>
    public interface IProjectServiceRepository : IBaseGenericRepository<WineTimeLine>
    {
        /// <summary>
        /// Добавление нового таймлайна
        /// </summary>
        /// <param name="timeLine"></param>
        public Task AddTimeLineAsync(WineTimeLine timeLine);
    }
}
