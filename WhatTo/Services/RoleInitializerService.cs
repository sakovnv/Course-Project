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
            if (await userManager.FindByNameAsync("admin@admin.ru") == null)
            {
                User user = new User { UserName = "admin@admin.ru", Email = "admin@admin.ru", EmailConfirmed = true};
                await userManager.CreateAsync(user, "123");
                await userManager.UpdateAsync(user);

                await userManager.AddToRoleAsync(user, "admin");

            }

        }
    }
}
