using AdopteDevWebApp.Interface;
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

        public UserController(IService<User> userService, IHashPw hashing)
        {
            _userService = userService;
        }

        [AuthorizationRequired]
        public IActionResult Index()
        {
            return View(_userService.GetAll(HttpContext.Session.GetUser().Token).Select(u => u.UserToWebApp()));
        }
        [AuthorizationRequired]
        [DevRequired]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id, HttpContext.Session.GetUser().Token);
            TempData["success"] = "Deleted with success! ";
            return RedirectToAction("Index");
        }

        [AuthorizationRequired]
        public IActionResult Logout()
        {
            HttpContext.Session.Disconnect();
            return RedirectToAction("index");
        }
    }
}
