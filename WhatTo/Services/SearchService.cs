using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatTo.Data;
using WhatTo.Interfaces;
using WhatTo.Models;

namespace WhatTo.Services
{
    public class SearchService : ISearch
    {
        private readonly ApplicationDbContext db;
        public SearchService(ApplicationDbContext _db)
        {
            db = _db;
        }
        public IEnumerable<Comment> GetComments(string searchQuery)
        {
            IEnumerable<Review> reviews = db.Reviews.Include(review => review.Comments)
                .Where(review => review.Comments.Where(comment => comment.Text.Contains(searchQuery)).Count() > 0);
            throw new NotImplementedException();
        }

        public IEnumerable<Review> GetReviews(string searchQuery)
        {
            IEnumerable<Review> reviews = db.Reviews
                .Include(review => review.Comments)
                .Include(review => review.FileUrls)
                .Where(review => review.Text.Contains(searchQuery) || review.Name.Contains(searchQuery));
            return reviews;
        }
    }
}
