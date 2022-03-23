using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class UsersRating
    {
        public int Id { get; set; }
        public int ReviewId { get; set; }
        public int Rating { get; set; }
        public User RatedUser { get; set; }
    }
}
