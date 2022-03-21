using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Data;
using Project.Interfaces;
using Project.Models;

namespace Project.Services
{
    public class SearchService : ISearch
    {
        private readonly ApplicationDbContext db;
        public SearchService(ApplicationDbContext _db)
        {
            db = _db;
        }

        public IEnumerable<Review> GetReviews(string searchQuery)
        {
            IEnumerable<Review> reviews = db.Reviews
                .Include(review => review.Comments)
                .Include(review => review.FileUrls)
                .Where(review => review.Text.Contains(searchQuery) 
                    || review.Name.Contains(searchQuery) 
                    || review.Comments.Any(comment => comment.Text.Contains(searchQuery))
                    || review.Tags.Any(tag => tag.Item.Contains(searchQuery)));

            return reviews;
        }
    }
}
