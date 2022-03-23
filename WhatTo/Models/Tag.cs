using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public int ReviewId { get; set; }
        public string Item { get; set; }
    }
}
