using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Models;

namespace Project.Interfaces
{
    public interface ISearch
    {
        IEnumerable<Review> GetReviews(string searchQuery);
    }
}
