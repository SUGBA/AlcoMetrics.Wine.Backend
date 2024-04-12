using Core.Actions.Abstractions.TImeLineIndicatorConverter;
using Core.Models.WineRealizations;

namespace Core.Actions.WineRealizations.WineIndicatorConverter
{
    /// <summary>
    /// Конвертер получения индикатора по заданному пользователем индикатору (хз, зачем)
    /// </summary>
    public class ByWineIndicatorConverter : IIndicatorConverter<WineIndicator>
    {
        private readonly WineIndicator _indicator;

        public ByWineIndicatorConverter(WineIndicator indicator)
        {
            _indicator = indicator;
        }

        public WineIndicator GetIndicator()
        {
            return _indicator;
        }
    }
}
