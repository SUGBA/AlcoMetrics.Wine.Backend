using Core.Models.WineRealizations;
using DataBase.EF.ConnectionFroWine.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataBase.EF.ConnectionFroWine.Realizations
{
    /// <summary>
    /// Реализация репозитория для модуля ProjectPage
    /// </summary>
    public class ProjectPageServiceRepository : BaseWineRepository<WineTimeLine>, IProjectPageServiceRepository
    {
        public async Task AddTimeLineAsync(WineTimeLine timeLine)
        {

            foreach (var day in timeLine.Days)
            {
                foreach (var evnt in day.Events)
                {
                    _context.Entry(evnt.TypicalEvent).State = EntityState.Unchanged;     //Почемаем Unchanged, чтобы EF не создавал новые записи TypicalEvent
                }
            }

            await _context.WineTimeLines.AddAsync(timeLine);
            await _context.SaveChangesAsync();
        }
    }
}
