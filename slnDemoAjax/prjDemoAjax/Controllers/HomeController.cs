﻿using Microsoft.AspNetCore.Mvc;
using prjDemoAjax.Models;
using System.Diagnostics;

namespace prjDemoAjax.Controllers
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

        public IActionResult First()
        {
            return View();
        }
        public IActionResult Travel()
        {
            return View();
        }
        public IActionResult GetDemo()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Address()
        {
            return View();
        }
        public IActionResult City()
        {
            return View();
        }
        public IActionResult Promise()
        {
            return View();
        }
        public IActionResult Fetch()
        {
            return View();
        }
        public IActionResult History()
        {
            return View();
        }
        public IActionResult jQuery()
        {
            return View();
        }        
        public IActionResult Partial1()
        {
            return PartialView();
        }        
        public IActionResult Partial2()
        {
            ViewBag.message = "來自Action的內容";
            return PartialView();
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
    }
}