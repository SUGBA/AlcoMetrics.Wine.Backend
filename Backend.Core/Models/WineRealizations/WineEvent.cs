using Core.Models.Abstractions;

namespace Core.Models.WineRealizations
{
    /// <summary>
    /// Событие в виноделии
    /// </summary>
    public class WineEvent : BaseEvent<WineTypicalEvent, WineDay, WineIndicator>
    {
    }
}
