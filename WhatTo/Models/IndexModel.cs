using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhatTo.Models
{
    public class IndexModel : PageModel
    {
        private IHttpContextAccessor Accessor;

        public IndexModel(IHttpContextAccessor _accessor)
        {
            this.Accessor = _accessor;
        }

        public void OnGet()
        {
            HttpContext context = this.Accessor.HttpContext;
        }
    }
}
