using AdopteDevWebApp.Tools;
using DataAccess.Entities.FromViewsDb;
using DataAccess.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdopteDevWebApp.Controllers
{
    public class DevelopperController : Controller
    {
        private readonly IService<ProfilDev> _pdService;

        public DevelopperController(IService<ProfilDev> pdService)
        {
            _pdService = pdService;
        }

        [AuthorizationRequired]
        [ClientRequired]
        public IActionResult DevList()
        {
            return View(_pdService.GetAll(HttpContext.Session.GetUser().Token).Select(pd => pd.ProfilDevToWebApi()));
        }
    }
}
