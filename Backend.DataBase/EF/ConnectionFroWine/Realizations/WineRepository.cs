using System.Linq.Expressions;
using Core.Actions.Abstractions.DataBaseConnector;
using Core.Models.Abstractions;
using DataBase.EF.ConnectionFroWine.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace DataBase.EF.ConnectionFroWine.Realizations
{
    /// <summary>
    /// Контект для виноделия
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class WineRepository<T> : IBaseGenericRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Контекст
        /// </summary>
        private WineDbContext _context;

        /// <summary>
        /// Таблица
        /// </summary>
        private DbSet<T> table;

        public WineRepository()
        {
            _context = new WineDbContext();

            table = _context.Set<T>();
        }

        public WineRepository(WineDbContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }

        public void Add(T item)
        {
            table.Add(item);
            SaveChanges();
        }

        public bool Delete(int id)
        {
            T? existing = table.FirstOrDefault(x => x.Id == id);
            if (existing == null) return false;
            table.Remove(existing);
            SaveChanges();
            return true;
        }

        public bool Delete(T item)
        {
            T? existing = table.FirstOrDefault(item);
            if (existing == null) return false;
            table.Remove(existing);
            SaveChanges();
            return true;
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T? GetById(int id)
        {
            return table.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<T> GetWithInclude(Expression<Func<T, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }

        public IEnumerable<T> GetWithInclude(Func<T, bool> predicate, Expression<Func<T, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToList();
        }

        private IQueryable<T> Include(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = table.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(T item)
        {
            table.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await table.ToListAsync<T>();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await table.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            T? existing = await table.FirstOrDefaultAsync(x => x.Id == id);
            if (existing == null) return false;
            table.Remove(existing);
            await SaveChangesAsync();
            return true;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
