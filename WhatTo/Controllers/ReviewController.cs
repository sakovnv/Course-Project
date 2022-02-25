using Microsoft.AspNetCore.Mvc;

namespace WhatTo.Controllers
{
    public class ReviewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
