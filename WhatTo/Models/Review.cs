using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WhatTo.Models
{
    public class Review
    {
        public Review()
        {
            Tags = new List<Tag>();
            //Comments = new List<Comment>();
        }
        public int Id { get; set; }
        public string Author { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Text { get; set; }
        public short Rating { get; set; }
        public DateTime PostingTime { get; set; }
        public ICollection<Tag> Tags { get; set; }
        //public ICollection<Comment> Comments { get; set; }

    }

    public class Tag
    {
        public int Id { get; set; }
        public int ReviewId { get; set; }
        public string Tags { get; set; }
    }
}
