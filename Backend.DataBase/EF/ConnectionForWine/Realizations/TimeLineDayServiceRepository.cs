using Core.Models.WineRealizations;
using DataBase.EF.ConnectionForWine.DbContexts;
using DataBase.EF.ConnectionForWine.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataBase.EF.ConnectionForWine.Realizations
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

        public async Task<IEnumerable<WineEvent>?> GetEventsForTable(int dayId, int userId)
        {
            return await _context.WineEvents
                .AsNoTracking()
                .Include(x => x.TypicalEvent)
                .Include(x => x.ResultIndicator)
                .Include(x=>x.Ingridients)
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
                .FirstOrDefaultAsync(x => x.Id == timeLineId);
            if (updatedTimeLine == null) return;

            updatedTimeLine.Days = days;

            _context.WineTimeLines.UpdateRange(updatedTimeLine);
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
            var typicalEvent = await _context.WineTypicalEvents
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.EventType == typeEvent);
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

        public async Task<IEnumerable<WineTimeLine>> GetProjectsAsync(int userId)
        {
            return await _context.WineTimeLines
                .AsNoTracking()
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }

        public async Task<WineEvent?> GetDayForEventAcceptAsync(int eventId, int userId)
        {
            return await _context.WineEvents
                .AsNoTracking()
                .Include(x => x.ResultIndicator)
                .Include(x=>x.Ingridients)
                .Include(x=>x.Day)
                .ThenInclude(x => x.TimeLine)
                .FirstOrDefaultAsync(x => x.Id == eventId && x.Day.TimeLine.UserId == userId);
        }

        public async Task<bool> DeleteEventAsync(int eventId, int userId)
        {
            var deletedItem = await _context.WineEvents
                .AsNoTracking()
                .Include(x => x.Day)
                .ThenInclude(x => x.TimeLine)
                .FirstOrDefaultAsync(x => x.Id == eventId && x.Day.TimeLine.UserId == userId);
            if (deletedItem == null)
                return false;

            _context.WineEvents.Remove(deletedItem);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task UpdateDayAsync(WineDay day)
        {
            _context.ChangeTracker.Clear();
            _context.WineDays.Update(day);
            await _context.SaveChangesAsync();
        }
    }
}
