using Core.Actions.Abstractions.DataBaseConnector;
using Core.Models.WineRealizations;

namespace DataBase.EF.ConnectionFroWine.Repository
{
    /// <summary>
    /// Репозиторий для модуля ProjectPage
    /// </summary>
    public interface IProjectPageServiceRepository : IBaseGenericRepository<WineTimeLine>
    {
        /// <summary>
        /// Добавление нового таймлайна
        /// </summary>
        /// <param name="timeLine"></param>
        public Task AddTimeLineAsync(WineTimeLine timeLine);
    }
}
