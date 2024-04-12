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
        /// Получить экземпляр по id
        /// </summary>
        /// <param name="id"> Id получаемого экземпляра </param>
        /// <returns></returns>
        public BE GetById(int id);

        /// <summary>
        /// Добавить
        /// </summary>
        /// <param name="item"> Добавляемый элемент</param>
        public void Add(BE item);

        /// <summary>
        /// Изменить
        /// </summary>
        /// <param name="item"> Изменяемый элемент </param>
        public void Update(BE item);

        /// <summary>
        /// Удалить
        /// </summary>
        /// <param name="id"> Id удаляемого элемента </param>
        public void Delete(int id);

        /// <summary>
        /// Удалить
        /// </summary>
        /// <param name="item"> Удаляемый элемент </param>
        public void Delete(BE item);

        /// <summary>
        /// Сохранить изменения
        /// </summary>
        public void SaveChanges();

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
