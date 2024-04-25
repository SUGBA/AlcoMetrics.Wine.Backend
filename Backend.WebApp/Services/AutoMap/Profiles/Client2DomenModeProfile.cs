using System.Globalization;
using AutoMapper;
using Core.Models.WineRealizations;
using WebApp.Models.Response.TimeLine;

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
        }
    }
}
