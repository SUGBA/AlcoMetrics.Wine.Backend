using System.Linq.Expressions;
using Core.Models.Abstractions;

namespace Core.Actions.Abstractions.DataBaseConnector
{
    public interface IBaseGenericRepository<BE> where BE : BaseEntity
    {
        /// <summary>
        /// Получить все
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BE> GetAll();

        /// <summary>
        /// Получить все асинхронно
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<BE>> GetAllAsync();

        /// <summary>
        /// Получить экземпляр по id
        /// </summary>
        /// <param name="id"> Id получаемого экземпляра </param>
        /// <returns></returns>
        public BE? GetById(int id);

        /// <summary>
        /// Получить экземпляр по id асинхронно
        /// </summary>
        /// <param name="id"> Id получаемого экземпляра </param>
        /// <returns></returns>
        public Task<BE?> GetByIdAsync(int id);

        /// <summary>
        /// Добавить
        /// </summary>
        /// <param name="item"> Добавляемый элемент</param>
        public void Add(BE item);

        /// <summary>
        /// Добавить асинхронно
        /// </summary>
        /// <param name="item"> Добавляемый элемент</param>
        public Task AddAsync(BE item);

        /// <summary>
        /// Изменить
        /// </summary>
        /// <param name="item"> Изменяемый элемент </param>
        public void Update(BE item);

        /// <summary>
        /// Удалить
        /// </summary>
        /// <param name="id"> Id удаляемого элемента </param>
        public bool Delete(int id);

        /// <summary>
        /// Удалить асинхронно
        /// </summary>
        /// <param name="id"> Id удаляемого элемента </param>
        public Task<bool> DeleteAsync(int id);

        /// <summary>
        /// Удалить
        /// </summary>
        /// <param name="item"> Удаляемый элемент </param>
        public bool Delete(BE item);

        /// <summary>
        /// Сохранить изменения
        /// </summary>
        public void SaveChanges();

        /// <summary>
        /// Сохранить изменения асинхронно
        /// </summary>
        public Task SaveChangesAsync();

        /// <summary>
        /// Получить с вложенными сущностями
        /// </summary>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public IEnumerable<BE> GetWithInclude(Expression<Func<BE, object>>[] includeProperties);

        /// <summary>
        /// Получить с вложенными сущностями
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public IEnumerable<BE> GetWithInclude(Func<BE, bool> predicate, Expression<Func<BE, object>>[] includeProperties);
    }
}
