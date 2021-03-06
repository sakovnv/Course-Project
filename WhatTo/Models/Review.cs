 using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{

    public class Review
    {
        public Review()
        {
            Tags = new List<Tag>();
            Comments = new List<Comment>();
            FileUrls = new List<FileUrl>();
            Likes = new List<Like>();
            OverallRating = new List<UsersRating>();
        }
        public int Id { get; set; }

        public string Author { get; set; }
        public User User { get; set; }

        [Required(ErrorMessage = "The fieid must be set")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The fieid must be set")]
        public string Category { get; set; }

        [Required(ErrorMessage = "The fieid must be set")]
        [MinLength(100, ErrorMessage = "The length of the text must be more than 100 charachters")]
        public string Text { get; set; }

        [Required(ErrorMessage = "The rate must be choosen")]
        [Range(1, 5, ErrorMessage = "The rate must be choosen")]
        public short Rating { get; set; }
        public DateTime PostingTime { get; set; }

        [Required(ErrorMessage = "The field must be set")]
        public List<Tag> Tags { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public List<FileUrl> FileUrls { get; set; }
        public List<Like> Likes { get; set; }
        public List<UsersRating> OverallRating { get; set; }
    }
}
