using Core.Models.Abstractions;

namespace WebApp.Extensions
{
    /// <summary>
    /// Расширения для енама списка мероприятий
    /// </summary>
    public static class EventCustomTypesExtensions
    {
        public static string ToStringFormat(this EventCustomTypes type)
        {
            switch (type)
            {
                case EventCustomTypes.System:
                    return "Системное";
                case EventCustomTypes.Custom:
                    return "Пользовательское";
                default:
                    return "Системное";
            }
        }
    }
}
