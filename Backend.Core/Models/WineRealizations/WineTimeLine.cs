using Core.Models.Abstractions;

namespace Core.Models.WineRealizations
{
    public class WineTimeLine : BaseTimeLine<WineUser, WineDay>
    {
        /// <summary>
        /// Начальные показания ареометра
        /// </summary>
        public int? StartAreometerValue { get; set; }
    }
}
