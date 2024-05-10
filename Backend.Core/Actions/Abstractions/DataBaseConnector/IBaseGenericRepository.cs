using Core.Models.Abstractions;

namespace Core.Actions.Abstractions.DataBaseConnector
{
    /// <summary>
    /// Базовая абстракция получения данных, в которой описан основные функции при работе с БД
    /// Сюда не помещаются фишечки EF или других инструментов получения данных, только базовый CRUD
    /// </summary>
    /// <typeparam name="BE"></typeparam>
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
        public int Add(BE item);

        /// <summary>
        /// Изменить
        /// </summary>
        /// <param name="item"> Изменяемый элемент </param>
        public bool Update(BE item);

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
        /// Добавить множество элементов
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        public void AddRange(IEnumerable<BE> items);

        /// <summary>
        /// Добавить множество элементов
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        public Task AddRangeAsync(IEnumerable<BE> items);
    }
}
