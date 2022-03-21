using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Data;
using Project.Services;

namespace Project.Controllers
{
    public class SearchController : Controller
    {
        SearchService searchService;

        private readonly ApplicationDbContext db;

        public SearchController(ApplicationDbContext _db)
        {
            db = _db;
            searchService = new SearchService(db);
        }

        [HttpPost]
        public IActionResult Index(string searchQuery)
        {
            ViewBag.SearchQuery = searchQuery;
            ViewBag.SearchResult = searchService.GetReviews(searchQuery).ToArray();
            return View();
        }
    }
}