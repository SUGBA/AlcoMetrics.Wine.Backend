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
                .AsNoTracking()
                .Include(x => x.TypicalEvent)
                .Include(x => x.Day)
                .ThenInclude(x => x.TimeLine)
                .Where(x => x.DayId == dayId && x.Day.TimeLine.UserId == userId)
                .ToListAsync();
        }

        public async Task<WineDay?> GetDayWithIndicatorsAndTimeLineAsync(int dayId, int userId)
        {
            return await _context.WineDays
                .AsNoTracking()
                .Include(x => x.Indicator)
                .Include(x => x.TimeLine)
                .Where(x => x.Id == dayId && x.TimeLine.UserId == userId)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateDaysAsync(List<WineDay> days, int timeLineId)
        {
            var updatedTimeLine = await _context.WineTimeLines
                .Include(x => x.Days)
                .ThenInclude(x => x.Indicator)
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
            return _context.WineDays.AsNoTracking().Include(x => x.Indicator).Where(x => x.TimeLineId == timeLineId);
        }

        public Task<WineIndicator?> GetIndicatorAsync(int dayId, int userId)
        {
            return _context.WineDays
                .AsNoTracking()
                .Include(x => x.Indicator)
                .Include(x => x.TimeLine)
                .Where(x => x.Id == dayId && x.TimeLine.UserId == userId)
                .Select(x => x.Indicator)
                .FirstOrDefaultAsync();
        }

        public async Task<WineTypicalEvent> GetTypicalEventAsync(WineEventTypes typeEvent)
        {
            var typicalEvent = await _context.WineTypicalEvents.AsNoTracking().FirstOrDefaultAsync(x => x.EventType == WineEventTypes.Alcoholization);
            if (typicalEvent == null) throw new Exception("Отсутствует событие при заполнении системных событий");
            return typicalEvent;
        }

        public async Task AddEventAsync(WineEvent newEvent, int dayId)
        {
            var day = await _context.WineDays.FirstOrDefaultAsync(x => x.Id == dayId);
            if (day == null) return;

            day.Events.Add(newEvent);
            await _context.SaveChangesAsync();
        }
    }
}
