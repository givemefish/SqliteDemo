// =================================================================
// File: HomeController.cs
// Editor: 陳佳駿 chiachunchen (Yuanta)
// Create Date: 2018/03/15 下午 05:26
// Update Date: 2018/03/16 上午 08:56
// =================================================================
using System;
using Microsoft.AspNetCore.Mvc;

namespace SqliteApi.Controllers
{
    public class HomeController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("/error")]
        public IActionResult Error()
        {
            return View();
        }
    }
}