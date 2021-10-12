using AdopteDevWebApp.Models.Contract;
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
    public class ContractController : Controller
    {
        private readonly IService<Contract> _contractService;

        public ContractController(IService<Contract> contractservice)
        {
            _contractService = contractservice;
        }

        public IActionResult Index()
        {
            return View(_contractService.GetAll().Select(c => c.ToWebApp()));
        }

        #region Insert a contract
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] CreateContract cc)
        {
            if (!ModelState.IsValid)
            {
                return View(cc);
            }
            _contractService.Insert(cc.ContractToWebApi());
            TempData["success"] = "Created with success! ";
            return RedirectToAction("Index");
        }
        #endregion
    }
}
