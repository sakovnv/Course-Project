using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhatTo.Models
{
    public class User : IdentityUser
    {
        public string Nickname { get; set; }
        public int ReviewsCount { get; set; }
    }
}
