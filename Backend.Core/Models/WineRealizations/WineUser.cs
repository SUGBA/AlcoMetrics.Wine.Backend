using Core.Models.Abstractions;

namespace Core.Models.WineRealizations
{
    /// <summary>
    /// Пользователь в виноделии
    /// </summary>
    public class WineUser : BaseUser
    {
        /// <summary>
        /// Список тайм-лайнов
        /// </summary>
        public WineTimeLine TimeLines { get; set; }
    }
}
