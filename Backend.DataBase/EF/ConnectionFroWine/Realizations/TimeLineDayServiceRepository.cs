using Core.Models.WineRealizations;
using DataBase.EF.ConnectionFroWine.DbContexts;
using DataBase.EF.ConnectionFroWine.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataBase.EF.ConnectionFroWine.Realizations
{
    /// <summary>
    /// Имплементация для сервиса-репозитория модуля TimeLineDay
    /// </summary>
    public class TimeLineDayServiceRepository : ITimeLineDayServiceRepository
    {
        /// <summary>
        /// Контекст
        /// </summary>
        private WineDbContext _context;

        public TimeLineDayServiceRepository() => _context = new WineDbContext();

        public async Task<IEnumerable<WineEvent>?> GetEventsWithDayAndTimeLineAsync(int dayId, int userId)
        {
            return await _context.WineEvents
                .Include(x => x.TypicalEvent)
                .Include(x => x.Day)
                .ThenInclude(x => x.TimeLine)
                .Where(x => x.DayId == dayId && x.Day.TimeLine.UserId == userId)
                .ToListAsync();
        }

        public async Task<WineDay?> GetDayWithIndicatorsAndTimeLineAsync(int dayId, int userId)
        {
            return await _context.WineDays
                .Include(x => x.Indicator)
                .Include(x => x.TimeLine)
                .Where(x => x.Id == dayId && x.TimeLine.UserId == userId)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateDaysAsync(List<WineDay> days, int timeLineId)
        {
            var updatedTimeLine = await _context.WineTimeLines
                .Include(x=>x.Days)
                .ThenInclude(x=>x.Indicator)
                .FirstOrDefaultAsync(x => x.Id == timeLineId);
            if (updatedTimeLine == null) return;

            updatedTimeLine.Days = days;

            foreach (var day in updatedTimeLine.Days)
            {
                foreach (var evnt in day.Events)
                {
                    _context.Entry(evnt.TypicalEvent).State = EntityState.Unchanged;     //Помечаем Unchanged, чтобы EF не создавал новые записи TypicalEvent
                }
            }

            _context.WineTimeLines.Update(updatedTimeLine);
            await _context.SaveChangesAsync();
        }

        public Task<IEnumerable<WineDay>> GetDaysWithIndicatorsAsync(int timeLineId)
        {
            return Task.Run(() => GetDaysWithIndicators(timeLineId));
        }

        private IEnumerable<WineDay> GetDaysWithIndicators(int timeLineId)
        {
            return _context.WineDays.Include(x => x.Indicator).Where(x => x.TimeLineId == timeLineId);
        }
    }
}
