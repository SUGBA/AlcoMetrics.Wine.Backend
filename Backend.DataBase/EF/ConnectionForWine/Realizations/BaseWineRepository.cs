using Core.Actions.Abstractions.DataBaseConnector;
using Core.Models.Abstractions;
using DataBase.EF.ConnectionForWine.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace DataBase.EF.ConnectionForWine.Realizations
{
    /// <summary>
    /// Контект для виноделия
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseWineRepository<T> : IBaseGenericRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Контекст
        /// </summary>
        private WineDbContext _context;

        /// <summary>
        /// Таблица
        /// </summary>
        private DbSet<T> table;

        public BaseWineRepository()
        {
            _context = new WineDbContext();

            table = _context.Set<T>();
        }

        public BaseWineRepository(WineDbContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }

        public void Add(T item)
        {
            table.Add(item);
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            T? existing = table.FirstOrDefault(x => x.Id == id);
            if (existing == null) return false;
            table.Remove(existing);
            _context.SaveChanges();
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
            _context.SaveChanges();
            return true;
        }

        public void AddRange(IEnumerable<T> items)
        {
            table.AddRange(items);
            _context.SaveChanges();
        }

        public async Task AddRangeAsync(IEnumerable<T> items)
        {
            await table.AddRangeAsync(items);
            _context.SaveChanges();
        }
    }
}
