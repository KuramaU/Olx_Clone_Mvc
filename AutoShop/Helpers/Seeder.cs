using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Shop.Helpers;
using System;
using static System.Formats.Asn1.AsnWriter;

namespace MVC_BagShop.Helpers
{
    public class Seeder
    {
        public static async Task SeedRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();



            foreach (var role in Enum.GetNames(typeof(Roles)))
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
        public static async Task SeedAdmins(IServiceProvider serviceProvider)
        {

            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            const string USERNAME = "myadmin@myadmin.com";
            const string PASSWORD = "Admin1@";
            var existingUser = await userManager.FindByNameAsync(USERNAME);

            if (existingUser == null)
            {
                var admin = new User()
                {
                    UserName = USERNAME,
                    Email = USERNAME
                };

                var result = await userManager.CreateAsync(admin, PASSWORD);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, Roles.Administrator.ToString());
                }
            }
        }
    }
}