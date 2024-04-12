using Core.Actions.Abstractions.TimelineCorrector;
using Core.Actions.Abstractions.DataBaseConnector;
using Core.Models.WineRealizations;

namespace Core.Actions.WineRealizations.WineTimelineCorrector
{
    /// <summary>
    /// Генератор цепи, состоящей из шаптализации и крепления
    /// </summary>
    public class ShaptalizationAlcoholizationChainCreater : ITimeLineEventChainCreator<WineTimeLine, WineIndicator>
    {
        private IBaseGenericRepository<WineTypicalEvent> typicalEventRepository;

        public ShaptalizationAlcoholizationChainCreater(IBaseGenericRepository<WineTypicalEvent> typicalEventRepository)
        {
            this.typicalEventRepository = typicalEventRepository;
        }

        public BaseLinkTimeLineEvent<WineTimeLine, WineIndicator> GetChains()
        {
            var secondLink = new AlcoholizationLinkTimeLineEvent(typicalEventRepository);             //Последний элемент цепи
            var firstLink = new ShaptalizationLinkTimeLineEvent(typicalEventRepository, secondLink);    //Первый элемент цепи

            return firstLink;
        }
    }
}
