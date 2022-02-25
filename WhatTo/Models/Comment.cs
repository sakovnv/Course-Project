using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhatTo.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int ReviewId { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public DateTime PostingTime { get; set; }
    }
}
