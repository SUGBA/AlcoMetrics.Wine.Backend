using Core.Actions.Abstractions.DataBaseConnector;
using Core.Actions.Abstractions.TimelineCorrector;
using Core.Models.WineRealizations;

namespace Core.Actions.WineRealizations.WineTimelineCorrector
{
    /// <summary>
    /// Звено добавляющее событие шаптализацию
    /// </summary>
    public class ShaptalizationLinkTimeLineEvent : BaseLinkTimeLineEvent<WineTimeLine, WineIndicator>
    {
        /// <summary>
        /// Константа определяющая шаг, через которые будем добавлять сахар в сусло
        /// </summary>
        private const byte TimeLineStem = 10;

        private IBaseGenericRepository<WineTypicalEvent> repository;

        public ShaptalizationLinkTimeLineEvent(IBaseGenericRepository<WineTypicalEvent> repository,
            BaseLinkTimeLineEvent<WineTimeLine, WineIndicator>? nextEvent = null) : base(nextEvent)
        {
            this.repository = repository;
        }

        protected override void CalculateCurrentEvent(WineTimeLine timeLine, WineIndicator indicator)
        {
            if (timeLine.Days.Count == 0)
                throw new Exception("Список дней пуст");


            for (int i = 0; i < timeLine.Days.Count; i += TimeLineStem)
            {
                if (timeLine.Days[i].Indicator.SugarValue < indicator.SugarValue)
                {
                    var typicalEvent = repository.GetAll().FirstOrDefault(x => x.EventType == WineEventTypes.Shaptalization);
                    if (typicalEvent == null) throw new Exception("Отсутствует событие при заполнении системных событий");

                    var newEvent = new WineEvent()
                    {
                        DesiredIndicator = indicator,
                        EventType = Models.Abstractions.EventCustomTypes.System,
                        IsCompleted = false,
                        TypicalEventId = typicalEvent.Id,
                    };

                    timeLine.Days[i].Events.Add(newEvent);
                }
            }
        }
    }
}
