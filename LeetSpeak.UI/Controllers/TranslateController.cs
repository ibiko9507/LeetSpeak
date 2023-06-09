﻿using LeetSpeak.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LeetSpeak.UI.Controllers
{
    public class TranslateController : Controller
    {
        private readonly ILogger<TranslateController> _logger;

        public TranslateController(ILogger<TranslateController> logger)
        {
            _logger = logger;
        }

        public IActionResult Translation()
        {
			var token = TempData["token"] as string;

			return View();
        }

        public IActionResult Navbar()
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