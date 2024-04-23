using Core.Actions.Abstractions.CalculatorUnitsMeasurement;
using Core.Actions.Abstractions.CurrentIndicatorsCalculator;
using Core.Actions.Abstractions.DataBaseConnector;
using Core.Actions.Abstractions.TimeLineCalculator;
using Core.Actions.Abstractions.TimelineCorrector;
using Core.Actions.Abstractions.TimeLineCreator;
using Core.Actions.Abstractions.TImeLineIndicatorConverter;
using Core.Actions.ShareRealizations.CalculatorUnitsMeasurement;
using Core.Actions.WineRealizations.WineCurrentIndicatorsCalculator;
using Core.Actions.WineRealizations.WineIndicatorConverter;
using Core.Actions.WineRealizations.WineTimeLineCalculator;
using Core.Actions.WineRealizations.WineTimelineCorrector;
using Core.Actions.WineRealizations.WineTimeLineCreator;
using Core.Models.WineRealizations;
using Core.Models.WineRealizations.Enums;
using DataBase.EF.ConnectionFroWine.Realizations;

namespace WebApp.Extensions
{
    /// <summary>
    /// Расширение для добавления сервисов ядра
    /// </summary>
    public static class AddWineCoreServicesExtensions
    {
        /// <summary>
        /// Добавить сервисы ядра
        /// </summary>
        /// <param name="applicationBuilder"></param>
        public static void AddWineCoreServices(this WebApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Services.AddTransient<ITimeLineEventChainCreator<WineTimeLine, WineIndicator>, ShaptalizationAlcoholizationChainCreater>();
            applicationBuilder.Services.AddTransient<BaseTimelineCorrector<WineTimeLine, WineIndicator>, WineTimelineCorrector>();
            applicationBuilder.Services.AddTransient<IBaseCalculatorFactory<MeasurementUnits>, CalculatorFactory>();
            applicationBuilder.Services.AddTransient<IBaseUnitsCalculator<MeasurementUnits>, UnitsCalculator>();
            applicationBuilder.Services.AddTransient<BaseTimeLineCalculator<WineIndicator>, WIneTimeLineCalculator>();
            applicationBuilder.Services.AddTransient<IIndicatorConverterFactory<InitialIndicatorTypes, WineIndicator>, WineIndicatorConverterFactory>();
            applicationBuilder.Services.AddTransient<BaseTimeLineCreator<WineIndicator, WineTimeLine, WineDay>, WineTimeLineCreator>();
            applicationBuilder.Services.AddTransient<IBaseCurrentIndicatorsCalculatorFactory<UpdateIndicatorTypes, WineIndicator>, WineCurrentIndicatorsCalculatorFactory>();
            applicationBuilder.Services.AddTransient<BaseCurrentIndicatorCalculatorWorker<UpdateIndicatorTypes, WineIndicator>, WineCurrentIndicatorCalculatorWorker>();
        }
    }
}
