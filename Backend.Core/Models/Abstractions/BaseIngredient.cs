namespace Core.Models.Abstractions
{
    /// <summary>
    /// Базовый ингридиент, который нужно добавить в событии
    /// </summary>
    public abstract class BaseIngredient : BaseEntity
    {
        /// <summary>
        /// Наименование ингридиента
        /// </summary>
        public string IngredientName { get; set; } = string.Empty;

        /// <summary>
        /// Значение ингридиента
        /// </summary>
        public double IngredientValue { get; set; }
    }
}
