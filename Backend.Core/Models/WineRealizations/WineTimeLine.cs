using Core.Models.Abstractions;

namespace Core.Models.WineRealizations
{
    /// <summary>
    /// TimeLine для виноделия
    /// </summary>
    public class WineTimeLine : BaseTimeLine<WineUser, WineDay>
    {
        /// <summary>
        /// Начальные показания ареометра
        /// </summary>
        public int? StartAreometerValue { get; set; }
    }
}
