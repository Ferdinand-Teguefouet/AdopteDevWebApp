using AdopteDevWebApp.Interface;
using AdopteDevWebApp.Models.Login;
using AdopteDevWebApp.Models.User;
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
    public class UserController : Controller
    {
        private readonly IService<User> _userService;
        private readonly ILoginService _logService;
        private readonly IHashPw _hashService;

        public UserController(IService<User> userService, ILoginService logService, IHashPw hashing)
        {
            _userService = userService;
            _logService = logService;
            _hashService = hashing;
        }

        public IActionResult Index()
        {
            return View(_userService.GetAll().Select(u => u.UserToWebApp()));
        }

        #region Add an user
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register([FromForm] AddUser cu)
        {
            if (!ModelState.IsValid)
            {
                return View(cu);
            }
            cu.Password = _hashService.HashPassword(cu.Password);
            _userService.Insert(cu.UserToWebApi());
            TempData["success"] = "Inserted with success! ";
            return RedirectToAction("Login");
        }
        #endregion

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginForm logForm)
        {
            UserLog uLog = _logService.GetByEmail(logForm.Email);

            if (uLog == null || uLog.Password != _hashService.HashPassword(logForm.Password))
            {
                TempData["error"] = "Connection problem!";
                return View(logForm);
            }
            // if(client.Password == password) rediriger
            TempData["success"] = "Welcome " + uLog.Email;
            //HttpContext.Session.SetString("Rôle", user.IsClient ? "Client" : "Developper");
            //HttpContext.Session.SetInt32("Id", user.Id);

            return RedirectToAction("Index", "Home");
        }
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            TempData["success"] = "Deleted with success! ";
            return RedirectToAction("Index");
        }
    }
}
