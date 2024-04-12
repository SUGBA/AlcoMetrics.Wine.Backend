using Core.Models.Abstractions;

namespace Core.Models.WineRealizations
{
    public class WineReferenceInfo : BaseReferenceInfo<Modules>
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
