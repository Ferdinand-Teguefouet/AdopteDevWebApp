using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdopteDevWebApp.Tools
{
    public class DevRequiredAttribute : TypeFilterAttribute
    {
        public DevRequiredAttribute() : base(typeof(DevRequiredFilter))
        {

        }
    }
}
