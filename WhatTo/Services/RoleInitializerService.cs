using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Models;

namespace Project.Services
{
    public class RoleInitializerService
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                IdentityRole role = new IdentityRole("admin");
                await roleManager.CreateAsync(role);
                await roleManager.UpdateAsync(role);

            }
        }
    }
}
