using Core.Models.WineRealizations;
using DataBase.EF.ConnectionFroWine.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataBase.EF.ConnectionFroWine.Realizations
{
    /// <summary>
    /// Имплементация репозитория для получения данных для модуля TimeLine
    /// </summary>
    public class TimeLineServiceRepository : BaseWineRepository<WineDay>, ITimeLineServiceRepository
    {
        /// <summary>
        /// Получить список дней с включением показателей
        /// Дополнительно передается иднтификатор текущего пользователя, чтобы другие пользователи не могли получать доступ к чужим дням
        /// </summary>
        /// <param name="timeLineId"> Id проекта </param>
        /// <param name="userId"> Id текущего пользователя </param>
        public async Task<IEnumerable<WineDay>> GetDaysAsync(int timeLineId, int userId)
        {
            return await _context.WineDays
                .Include(x => x.Indicator)
                .Include(x => x.Events)
                .Include(x => x.TimeLine)
                .Include(x => x.TimeLine)
                .Where(x => x.TimeLineId == timeLineId && x.TimeLine.UserId == userId)
                .ToListAsync();
        }
    }
}
