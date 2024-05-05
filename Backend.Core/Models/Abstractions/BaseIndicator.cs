namespace Core.Models.Abstractions
{
    /// <summary>
    /// Базовые показатели вещества
    /// </summary>
    public abstract class BaseIndicator : BaseEntity
    {
        /// <summary>
        /// Содержание алкоголя в %
        /// </summary>
        public double EthanolValue { get; set; }        
    }
}
