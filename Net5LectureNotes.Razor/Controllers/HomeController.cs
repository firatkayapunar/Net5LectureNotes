﻿using Microsoft.AspNetCore.Mvc;

namespace Net5LectureNotes.Razor.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
