using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdopteDevWebApp.Tools
{
    public class AuthorizationFilter : IAuthorizationFilter
    {
        // vérifie si l'on a l'autorisation à la requête voulue
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // on teste si l'on a aucun User stocké en session
            if (SessionManager.userModel is null)
            {
                // On redirige l'utilisateur vers la page "Login" (action du contrôleur spécifique)
                context.Result = new RedirectToRouteResult(new { action = "Login", controller = "Login" });
            }
        }
    }
}
