using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace RepartidorOnline.UI.Helpers
{
    public class SecurityHelpers
    {
        public static List<Claim> CreateUserClaims(string nombresUsuario, string loginUsuario, string email, string usuarioId)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, nombresUsuario));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, loginUsuario));
            claims.Add(new Claim(ClaimTypes.Email, email));
            claims.Add(new Claim("UsuarioID", usuarioId));
            
            return claims;

        }

        public static List<Claim> GetClaimByType(string type)
        {
            var identity = (ClaimsIdentity)HttpContext.Current.User.Identity;
            var claims = identity.Claims.Where(item => item.Type == type).ToList();

            return claims;
        }

        public static string GetUserFullName()
        {
            var claimValue = GetClaimByType(ClaimTypes.Name).FirstOrDefault()?.Value;

            return claimValue;
        }

        public static bool IsLogged()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }
    }
}