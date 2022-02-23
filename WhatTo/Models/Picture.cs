using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhatTo.Models
{
    public class Picture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
    }

    public class PictureViewModel
    {
        public string Name { get; set; }
        public IFormFile Picture { get; set; }
    }
}
