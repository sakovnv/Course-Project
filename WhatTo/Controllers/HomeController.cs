using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;
using System.Linq;
using System.Threading.Tasks;
using WhatTo.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using WhatTo.Data;
using Microsoft.AspNetCore.Hosting;

namespace WhatTo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment environment;
        private readonly ILogger<HomeController> logger;
        private readonly ApplicationDbContext db;
        public HomeController(ILogger<HomeController> _logger, ApplicationDbContext _db, IWebHostEnvironment _env)
        {
            logger = _logger;
            db = _db;
            environment = _env;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CreateReview()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(IFormFile file, string reviewName)
        {
            if (file != null && file.Length > 0)
            {
                string imagePath = @"\Upload\Images\" + User.Identity.Name;
                string uploadPath = environment.WebRootPath + imagePath;

                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                string uniqfileName = Guid.NewGuid().ToString();
                string fileName = Path.GetFileName(uniqfileName + "." + file.FileName.Split(".")[1].ToLower());
                string fullPath = uploadPath + fileName;

                imagePath = imagePath + @"\";
                string filePath = @".." + Path.Combine(imagePath, fileName);
                
                using (FileStream fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                ViewData["FileLocation"] = filePath;
            }
            return View("../Home/Index");
        }

        public IActionResult ChangeTheme()
        {
            if (Request.Cookies["theme"] == null)
            {
                Response.Cookies.Append("theme","dark");
            }
            else
            {
                if (Request.Cookies["theme"] == "dark")
                {
                    Response.Cookies.Append("theme", "light");
                }
                else if (Request.Cookies["theme"] == "light")
                {
                    Response.Cookies.Append("theme", "dark");
                }
            }
            return RedirectToAction("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
