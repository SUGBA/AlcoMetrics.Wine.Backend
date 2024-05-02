using Core.Actions.Abstractions.EventCalculator;
using Core.Models.WineRealizations;

namespace Core.Actions.WineRealizations.WineEventCalculator
{
    /// <summary>
    /// Фасад для работы с мероприятиями в виноделии
    /// </summary>
    public class WineEventWorker : BaseEventWorker<WineEventTypes, WineIndicator>
    {
    
        public WineEventWorker(IBaseEventFactory<WineEventTypes, WineIndicator> eventFactory) : base(eventFactory)
        {
        }
    }
}
