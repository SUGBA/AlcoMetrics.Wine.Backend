using Core.Models.Abstractions;

namespace Core.Models.WineRealizations
{
    /// <summary>
    /// Информация в виноделии
    /// </summary>
    public class WineReferenceInformation : BaseReferenceInformation<Modules>
    {

    }

    public enum Modules
    {
        TimeLine = 1,
        Shaptalization = 2,
        Blending = 3,
        Alcoholization = 4
    }
}
