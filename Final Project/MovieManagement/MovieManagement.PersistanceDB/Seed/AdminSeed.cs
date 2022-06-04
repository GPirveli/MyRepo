using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieManagement.Domain.POCO;
using MovieManagement.PersistanceDB.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.PersistanceDB.Seed
{
    public static class AdminSeed
    {
        public static void Seed(UserManager<Account> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedAdminAccount(userManager);
        }

        public static void SeedAdminAccount(UserManager<Account> userManager)
        {
            if(userManager.FindByNameAsync("Admin").Result == null)
            {
                var admin = new Account()
                {
                    FirstName = "Admin",
                    LastName = "Admin",
                    Email = "admin@gmail.com",
                    UserName = "Admin",
                    Password = "AdminPass123$",
                    Role = "Admin",
                    IsActive = true
                };
                var result = userManager.CreateAsync(admin, "AdminPass123$").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(admin, "Admin").Wait();
                }
            }
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {

            var roles = new List<IdentityRole>()
            {
                new IdentityRole()
                {
                    Name = "Admin"
                },
                new IdentityRole()
                {
                    Name = "Moderator"
                },
                new IdentityRole()
                {
                    Name = "RegisteredUser"
                },
                new IdentityRole()
                {
                    Name = "Guest"
                }
            };

            foreach (var role in roles)
            {
                if (!roleManager.RoleExistsAsync(role.Name).Result)
                    roleManager.CreateAsync(role).Wait();
            }
        }
    }
}
