using AdopteDevWebApp.Interface;
using AdopteDevWebApp.Models.User;
using AdopteDevWebApp.Security;
using AdopteDevWebApp.Tools;
using DataAccess.Entities;
using DataAccess.Interface;
using DataAccess.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdopteDevWebApp.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IHashPw _hashService;
        private readonly IRegisterService _userService;

        public RegisterController(IHashPw hashService, IRegisterService userService)
        {
            _hashService = hashService;
            _userService = userService;

        }
        #region Add an user
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register([FromForm] RegisterModel rm)
        {
            if (!ModelState.IsValid)
            {
                return View(rm);
            }
            //rm.Password = _hashService.HashPassword(rm.Password);
            _userService.Insert(rm.UserToWebApi()/*, HttpContext.Session.GetUser().Token*/);
            TempData["success"] = "Inserted with success!";
            return RedirectToAction("Login", "Login");
        }
        #endregion
    }
}
