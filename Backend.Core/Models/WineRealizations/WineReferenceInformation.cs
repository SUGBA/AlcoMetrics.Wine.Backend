using System.ComponentModel.DataAnnotations.Schema;
using Core.Models.Abstractions;

namespace Core.Models.WineRealizations
{
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
