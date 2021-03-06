using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Project.Data;
using Project.Models;
using Project.Models.Services;
using Microsoft.EntityFrameworkCore;

namespace Project.Controllers
{
    public class ReviewController : Controller
    {

        ImageService imageService;

        private readonly IConfiguration settings;
        private readonly UserManager<User> userManager;
        private readonly IWebHostEnvironment environment;
        private readonly ILogger<HomeController> logger;
        private readonly ApplicationDbContext db;

        private static List<FileUrl> CurrentFilesUrl = new List<FileUrl>();

        public ReviewController(UserManager<User> _userManager, ILogger<HomeController> _logger, ApplicationDbContext _db,
            IWebHostEnvironment _env, IConfiguration _settings)
        {
            settings = _settings;
            userManager = _userManager;
            logger = _logger;
            db = _db;
            environment = _env;
            imageService = new ImageService(settings);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<List<FileUrl>> Upload(IFormFile file)
        {
            string fullPath = await imageService.UploadImageAsync(file, "review-images");
            CurrentFilesUrl.Add(new FileUrl { Url = fullPath });
            return CurrentFilesUrl;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Review review, string Tags)
        {
            User user = await userManager.FindByEmailAsync(User.Identity.Name);

            ICollection<Tag> tags = new List<Tag>();
            foreach (string item in Tags.Split('|'))
            {
                tags.Add(new Tag { Item = item });
            }
            
            DateTime time = DateTime.Now;
            review.PostingTime = time;
            review.Author = user.Nickname;
            review.Tags.AddRange(tags);
            review.FileUrls.AddRange(CurrentFilesUrl);
            user.Reviews.Add(review);

            CurrentFilesUrl.Clear();

            db.Reviews.Add(review);
            await db.SaveChangesAsync();

            return RedirectToRoute(new { controller = "Review", action = "Index", id = review.Id });
        }
        public async Task<IActionResult> CreateComment(int id, string commentText)
        {
            User user = await userManager.FindByEmailAsync(User.Identity.Name);

            Review review = db.Reviews.Where(review => review.Id == id).First();

            Comment comment = new Comment { Author = user.Nickname, Text = commentText, PostingTime = DateTime.Now };
            review.Comments.Add(comment);

            db.Reviews.Update(review);
            db.SaveChanges();

            return RedirectToRoute(new { controller = "Review", action = "Index", id = id });
        }

        public IActionResult AddUsersRating(int usersRating, int reviewId, string userId)
        {
            Review review = db.Reviews.Find(reviewId);
            User user = db.Users.Find(userId);

            UsersRating rating = new UsersRating { RatedUser = user, Rating = usersRating };
            review.OverallRating.Add(rating);

            db.Reviews.Update(review);
            db.SaveChanges();

            return RedirectToRoute(new { controller = "Review", action = "Index", id = reviewId });
        }

        public IActionResult Like(string userId, int reviewId)
        {
            Review review = db.Reviews.Find(reviewId);
            User user = db.Users.Find(userId);

            Like like = new Like { LikedUser = user };
            review.Likes.Add(like);

            db.Reviews.Update(review);
            db.SaveChanges();

            return RedirectToRoute(new { controller = "Review", action = "Index", id = reviewId });
        }
    }
}
