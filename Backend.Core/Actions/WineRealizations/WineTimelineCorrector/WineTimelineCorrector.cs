using Core.Actions.Abstractions.TimelineCorrector;
using Core.Models.WineRealizations;

namespace Core.Actions.WineRealizations.WineTimelineCorrector
{
    public class WineTimelineCorrector : BaseTimelineCorrector<WineTimeLine, WineIndicator>
    {
        public WineTimelineCorrector(ITimeLineEventChainCreator<WineTimeLine, WineIndicator> chainCreator) : base(chainCreator) { }
    }
}
