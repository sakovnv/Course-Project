using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            Reviews = new List<Review>();
        }
        public string Nickname { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public DateTime LastLoginTime { get; set; }
        public DateTime RegistrationTime { get; set; }
    }
}
