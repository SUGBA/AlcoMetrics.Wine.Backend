using Core.Actions.ShareRealizations.CalculatorUnitsMeasurement;
using Core.Actions.WineRealizations.WineTimeLineCalculator;
using Core.Actions.WineRealizations.WineTimelineCorrector;
using Core.Actions.WineRealizations.WineTimeLineCreator;
using Core.Models.WineRealizations;
using DataBase.EF.ConnectionForWine.Realizations;
using Xunit.Abstractions;

namespace Tests
{
    /// <summary>
    /// Тесты корректоров таймлайнов
    /// </summary>
    public class WineTimelineCorrectorTests : BaseTest
    {
        public WineTimelineCorrectorTests(ITestOutputHelper output) : base(output) { }

        #region ShaptalizationAlcoholizationChainCreaterTests
        /// <summary>
        /// Проверка колличества событий шаптализации
        /// </summary>
        [Fact]
        public void CheckingCircuitWithCorrectParameters()
        {
            var repository = new BaseWineRepository<WineTypicalEvent>();
            var chainCreator = new ShaptalizationAlcoholizationChainCreater(repository);
            var corrector = new WineTimelineCorrector(chainCreator);

            var indicator = new WineIndicator() { };
            var desiredIndicator = new WineIndicator() { SugarValue = 50, EthanolValue = 10 };
            var startTime = 0;
            var endTime = 100;
            var timeLineCalculator = new WIneTimeLineCalculator();
            var _calculatorFactory = new CalculatorFactory();
            var _unitsCalculator = new UnitsCalculator(_calculatorFactory);
            var calculator = new WineTimeLineCreator(timeLineCalculator, _unitsCalculator);
            var timeLine = calculator.GetTimeLine(indicator, startTime, endTime);

            corrector.CorrectTimeLIne(timeLine, desiredIndicator);

            var eventCount = timeLine.Days.Sum(x => x.Events.Count);

            Assert.Equal(2, eventCount);
        }

        /// <summary>
        /// Проверка колличества событий крепление
        /// </summary>
        [Fact]
        public void CheckingCircuitWithCorrectParameters2()
        {
            var repository = new BaseWineRepository<WineTypicalEvent>();
            var chainCreator = new ShaptalizationAlcoholizationChainCreater(repository);
            var corrector = new WineTimelineCorrector(chainCreator);

            var indicator = new WineIndicator() { };
            var desiredIndicator = new WineIndicator() { SugarValue = 50, EthanolValue = 14 };
            var startTime = 0;
            var endTime = 100;
            var timeLineCalculator = new WIneTimeLineCalculator();
            var _calculatorFactory = new CalculatorFactory();
            var _unitsCalculator = new UnitsCalculator(_calculatorFactory);
            var calculator = new WineTimeLineCreator(timeLineCalculator, _unitsCalculator);
            var timeLine = calculator.GetTimeLine(indicator, startTime, endTime);

            corrector.CorrectTimeLIne(timeLine, desiredIndicator);

            var eventCount = timeLine.Days.Sum(x => x.Events.Where(x => x.TypicalEvent.EventType == WineEventTypes.Alcoholization).Count());

            Assert.Equal(1, eventCount);
        }
        #endregion
    }
}
