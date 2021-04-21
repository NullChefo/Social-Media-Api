using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SMA.MVC.Models;
using SMA.MVC.ViewModels;

namespace SMA.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (this.HttpContext.Session.GetString("LoggedUserId") != null)
                return RedirectToAction("Index", "Home");

            return View();
        }


        [HttpPost]
        public IActionResult Login(UserVM model)
        {
            if (this.HttpContext.Session.GetString("LoggedUserId") != null)
                return RedirectToAction("Index", "Home");

            if (!ModelState.IsValid)
                return View(model);

            UserVM vm = new UserVM();

             
            

            if (vm == null)
            {
                ModelState.AddModelError("AuthenticationFailed", "Wrong username or password");
                return View(model);
            }

            this.HttpContext.Session.SetInt32("LoggedUserId", vm.UserId);
            this.HttpContext.Session.SetString("LoggedUserUsername", vm.UserEmail);

            return RedirectToAction("Index", "Balance");
        }


    }
}
