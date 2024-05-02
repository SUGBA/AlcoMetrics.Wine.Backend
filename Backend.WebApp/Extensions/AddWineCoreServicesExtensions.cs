using Core.Actions.Abstractions.CalculatorUnitsMeasurement;
using Core.Actions.Abstractions.CurrentIndicatorsCalculator;
using Core.Actions.Abstractions.DataBaseConnector;
using Core.Actions.Abstractions.EventCalculator;
using Core.Actions.Abstractions.TimeLineCalculator;
using Core.Actions.Abstractions.TimelineCorrector;
using Core.Actions.Abstractions.TimeLineCreator;
using Core.Actions.Abstractions.TImeLineIndicatorConverter;
using Core.Actions.ShareRealizations.CalculatorUnitsMeasurement;
using Core.Actions.WineRealizations.WineCurrentIndicatorsCalculator;
using Core.Actions.WineRealizations.WineEventCalculator;
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
            applicationBuilder.Services.AddScoped<ITimeLineEventChainCreator<WineTimeLine, WineIndicator>, ShaptalizationAlcoholizationChainCreater>();
            applicationBuilder.Services.AddScoped<BaseTimelineCorrector<WineTimeLine, WineIndicator>, WineTimelineCorrector>();
            applicationBuilder.Services.AddScoped<IBaseCalculatorFactory<MeasurementUnits>, CalculatorFactory>();
            applicationBuilder.Services.AddScoped<IBaseUnitsCalculator<MeasurementUnits>, UnitsCalculator>();
            applicationBuilder.Services.AddScoped<BaseTimeLineCalculator<WineIndicator>, WIneTimeLineCalculator>();
            applicationBuilder.Services.AddScoped<IIndicatorConverterFactory<InitialIndicatorTypes, WineIndicator>, WineIndicatorConverterFactory>();
            applicationBuilder.Services.AddScoped<BaseTimeLineCreator<WineIndicator, WineTimeLine, WineDay>, WineTimeLineCreator>();
            applicationBuilder.Services.AddScoped<IBaseCurrentIndicatorsCalculatorFactory<UpdateIndicatorTypes, WineIndicator>, WineCurrentIndicatorsCalculatorFactory>();
            applicationBuilder.Services.AddScoped<BaseCurrentIndicatorCalculatorWorker<UpdateIndicatorTypes, WineIndicator>, WineCurrentIndicatorCalculatorWorker>();
            applicationBuilder.Services.AddScoped<IBaseEventFactory<WineEventTypes, WineIndicator>, WineEventFactory>();
            applicationBuilder.Services.AddScoped<BaseEventWorker<WineEventTypes, WineIndicator>, WineEventWorker>();
        }
    }
}
