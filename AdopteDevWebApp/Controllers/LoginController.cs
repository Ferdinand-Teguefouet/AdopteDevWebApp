using AdopteDevWebApp.Interface;
using AdopteDevWebApp.Models.User;
using AdopteDevWebApp.Security;
using AdopteDevWebApp.Tools;
using DataAccess.Entities;
using DataAccess.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdopteDevWebApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _logService;
        private readonly IHashPw _hashService;

        public LoginController(ILoginService logService, IHashPw hashService)
        {
            _logService = logService;
            _hashService = hashService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromForm] LoginModel logForm)
        {
            if (!ModelState.IsValid)
            {
                return View(logForm);
            }

            GetUserModel currentUser = _logService.Login(logForm.Email, logForm.Password).UserToWebApp();
            // il faut utiliser le HttpContext.Session pour écrire en Session
            HttpContext.Session.SetUser(currentUser);

            //if (uLog == null || uLog.Password != _hashService.HashPassword(logForm.Password))
            //{
            //    TempData["error"] = "Connection problem!";
            //    return View(logForm);
            //}
            // if(client.Password == password) rediriger
            TempData["success"] = "Welcome " + currentUser.Email;
            //HttpContext.Session.SetString("Rôle", user.IsClient ? "Client" : "Developper");
            //HttpContext.Session.SetInt32("Id", user.Id);

            return RedirectToAction("Index", "Home");
        }
    }
}
