using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhatTo.Models
{
    public class Review
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string[] Tags { get; set; }
        public string Text { get; set; }
        public short Rating { get; set; }
        public Picture[] Pictures { get; set; }

    }
}
