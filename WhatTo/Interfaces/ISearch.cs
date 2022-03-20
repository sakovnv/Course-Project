using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatTo.Models;

namespace WhatTo.Interfaces
{
    public interface ISearch
    {
        IEnumerable<Review> GetReviews(string searchQuery);
        IEnumerable<Comment> GetComments(string searchQuery);
    }
}
