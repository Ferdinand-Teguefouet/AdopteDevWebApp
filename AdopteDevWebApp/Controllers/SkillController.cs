using AdopteDevWebApp.Tools;
using DataAccess.Entities;
using DataAccess.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdopteDevWebApp.Controllers
{
    public class SkillController : Controller
    {
        private readonly IService<Skill> _skillService;

        public SkillController(IService<Skill> skillService)
        {
            _skillService = skillService;
        }

        [AuthorizationRequired]
        [DevRequired]
        public IActionResult SkillList()
        {
            return View(_skillService.GetAll(HttpContext.Session.GetUser().Token).Select(s => s.SkillToWebApp()));
        }
    }
}
