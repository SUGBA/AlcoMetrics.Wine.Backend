using Core.Actions.Abstractions.DataBaseConnector;
using Core.Actions.Abstractions.TimelineCorrector;
using Core.Models.WineRealizations;

namespace Core.Actions.WineRealizations.WineTimelineCorrector
{
    /// <summary>
    /// Звено добавляющее событие крепление
    /// </summary>
    public class AlcoholizationLinkTimeLineEvent : BaseLinkTimeLineEvent<WineTimeLine, WineIndicator>
    {
        private IBaseGenericRepository<WineTypicalEvent> repository;

        public AlcoholizationLinkTimeLineEvent(IBaseGenericRepository<WineTypicalEvent> repository,
            BaseLinkTimeLineEvent<WineTimeLine, WineIndicator>? nextEvent = null) : base(nextEvent)
        {
            this.repository = repository;
        }

        protected override void CalculateCurrentEvent(WineTimeLine timeLine, WineIndicator indicator)
        {
            var lastDay = timeLine.Days.LastOrDefault();
            if (lastDay == null)
                throw new Exception("Список дней пуст");

            if (lastDay.Indicator.EthanolValue < indicator.EthanolValue)
            {
                var typicalEvent = repository.GetAll().FirstOrDefault(x => x.EventType == WineEventTypes.Alcoholization);
                if (typicalEvent == null) throw new Exception("Отсутствует событие при заполнении системных событий");

                var newEvent = new WineEvent()
                {
                    DesiredIndicator = indicator,
                    EventType = Models.Abstractions.EventCustomTypes.System,
                    IsCompleted = false,
                    TypicalEvent = typicalEvent,
                };

                lastDay.Events.Add(newEvent);
            }
        }
    }
}
