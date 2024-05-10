﻿using Core.Models.WineRealizations;
using DataBase.EF.ConnectionForWine.DbContexts;
using DataBase.EF.ConnectionForWine.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataBase.EF.ConnectionForWine.Realizations
{
    /// <summary>
    /// Реализация репозитория для модуля ProjectPage
    /// </summary>
    public class ProjectServiceRepository : BaseWineRepository<WineTimeLine>, IProjectServiceRepository
    {
        /// <summary>
        /// Контекст
        /// </summary>
        private WineDbContext _context;

        public ProjectServiceRepository() => _context = new WineDbContext();

        public async Task AddTimeLineAsync(WineTimeLine timeLine)
        {
            foreach (var day in timeLine.Days)
            {
                foreach (var evnt in day.Events)
                {
                    _context.Entry(evnt.TypicalEvent).State = EntityState.Unchanged;
                }
            }

            await _context.WineTimeLines.AddAsync(timeLine);
            await _context.SaveChangesAsync();
        }
    }
}
