using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdopteDevWebApp.Tools
{
    public class DevRequiredFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (SessionManager.userModel is null || SessionManager.userModel.IsClient)
            {
                context.Result = new RedirectToRouteResult(new { action = "Index", controller = "User" });
            }
        }
    }
}
