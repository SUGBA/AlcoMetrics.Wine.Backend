using System.Security.Claims;
using IdentityModel;

namespace WebApp.Extensions
{
    /// <summary>
    /// Расширения для ClaimPrincipal
    /// </summary>
    public static class ClaimPrincipalExtensions
    {
        /// <summary>
        /// Расширение для получения id пользователя из UserClaims
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int? GetUserId(this ClaimsPrincipal user)
        {
            var idClaim = user.Claims.FirstOrDefault(x => x.Type == JwtClaimTypes.Id);
            if (idClaim == null) return null;
            if (int.TryParse(idClaim.Value, out var id))
                return id;
            return null;
        }
    }
}
