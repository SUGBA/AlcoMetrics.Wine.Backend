using System.Globalization;
using AutoMapper;
using Core.Models.WineRealizations;
using WebApp.Extensions;
using WebApp.Models.Response.TimeLine;
using WebApp.Models.Response.TimeLineDay;

namespace WebApp.Services.AutoMap.Profiles
{
    /// <summary>
    /// Профиль для мапер Клиентские модели (DTO) <-> Доменные модели (Сущности БД)
    /// </summary>
    public class Client2DomenModeProfile : Profile
    {
        public Client2DomenModeProfile()
        {
            #region TimeLine

            CreateMap<WineDay, DayIndicatorsResponse>()
                .ForMember(to => to.EthanolValue, from => from.MapFrom(src => src.Indicator.EthanolValue))
                .ForMember(to => to.SugarValue, from => from.MapFrom(src => src.Indicator.SugarValue))
                .ForMember(to => to.DayNumber, from => from.MapFrom(src => src.CurrentDate.Day))
                .ForMember(to => to.Month, from => from.MapFrom(src => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(src.CurrentDate.ToString("MMMM"))))
                .ForMember(to => to.EventCount, from => from.MapFrom(src => src.Events.Count))
                .ForMember(to => to.DayId, from => from.MapFrom(src => src.Id));

            #endregion

            #region TimeLineDay

            CreateMap<WineDay, CurrentDayIndicatrosResponse>()
                .ForMember(to => to.EthanolValue, from => from.MapFrom(src => src.Indicator.EthanolValue))
                .ForMember(to => to.SugarValue, from => from.MapFrom(src => src.Indicator.SugarValue))
                .ForMember(to => to.CurrentDateTime, from => from.MapFrom(src => src.CurrentDate))
                .ForMember(to => to.Wort, from => from.MapFrom(src => src.Indicator.WortValue));

            CreateMap<WineEvent, CurrentDayEventsResponse>()
                .ForMember(to => to.EventName, from => from.MapFrom(src => src.TypicalEvent.Name))
                .ForMember(to => to.IsReady, from => from.MapFrom(src => src.IsCompleted))
                .ForMember(to => to.Type, from => from.MapFrom(src => src.EventType.ToStringFormat()))
                .ForMember(to => to.Id, from => from.MapFrom(src => src.Id))
                .ForMember(to => to.Ingridients, from => from.MapFrom(src => src.Ingridients.Select(x => $"{x.IngredientName}: {Math.Round(x.IngredientValue, 2)}")))
                .ForPath(to => to.Indicators.EthanolValue, from => from.MapFrom(src => src.ResultIndicator!.EthanolValue))
                .ForPath(to => to.Indicators.SuagrValue, from => from.MapFrom(src => src.ResultIndicator!.SugarValue))
                .ForPath(to => to.Indicators.WortValue, from => from.MapFrom(src => src.ResultIndicator!.WortValue));

            #endregion
        }
    }
}
