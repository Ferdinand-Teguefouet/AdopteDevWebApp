using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdopteDevWebApp.Tools
{
    public class AuthorizationRequiredAttribute : TypeFilterAttribute
    {
        public AuthorizationRequiredAttribute() : base(typeof(AuthorizationFilter))
        {

        }
    }
}
