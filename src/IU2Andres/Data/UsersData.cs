using IU2Andres.Data;
using IU2Andres.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IU2Andres.Data
{
    public static class UsersData
    {

        private static List<ApplicationRole> Roles = new List<ApplicationRole>
        {
            new ApplicationRole {Name = "Admin",Description = "Site Administrator",CreatedDate = DateTime.UtcNow,IPAddress = ""/*Request.HttpContext.Connection.RemoteIpAddress.ToString()*/},
            new ApplicationRole {Name = "User",Description = "Site User",CreatedDate = DateTime.UtcNow,IPAddress = ""/*Request.HttpContext.Connection.RemoteIpAddress.ToString()*/},
            new ApplicationRole {Name = "SuperUser",Description = "Site SuperUser",CreatedDate = DateTime.UtcNow,IPAddress = ""/*Request.HttpContext.Connection.RemoteIpAddress.ToString()*/}
        };
        private static List<ApplicationUser> Users = new List<ApplicationUser>
        {
            new ApplicationUser {UserName = "admin@admin.com",Email = "admin@admin.com"},
        };

        public static async Task SeedUsersAndRoles(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                if (await db.Database.EnsureCreatedAsync())
                {
                    //Creating Roles
                    var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

                    foreach (ApplicationRole role in Roles)
                    {
                        if (!await roleManager.RoleExistsAsync(role.Name))
                        {
                            await roleManager.CreateAsync(role);
                        }
                    }
                    //Creating Admin User
                    var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                    foreach (ApplicationUser user in Users)
                    {

                        IdentityResult result = await userManager.CreateAsync(user, "Admin-1234");
                        if (result.Succeeded)
                        {
                            ApplicationRole applicationRole = await roleManager.FindByNameAsync("Admin");
                            if (applicationRole != null)
                            {
                                IdentityResult roleResult = await userManager.AddToRoleAsync(user, applicationRole.Name);
                                int x = 0;
                                if (roleResult.Succeeded)
                                {
                                    x = 1;
                                }
                            }
                        }

                    }
                }
            }
        }
    }
}
