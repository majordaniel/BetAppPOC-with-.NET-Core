using IdentityCore.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityCore.Data
{
    public class DummyData
    {
        public static async Task Initialize(ApplicationDbContext context,
                              UserManager<ApplicationUser> userManager,
                              RoleManager<ApplicationRole> roleManager)
        {
            context.Database.EnsureCreated();

            String adminId1 = "";
            String adminId2 = "";

            string role1 = "Punter";
            string desc1 = "This is the Punter role";

            string role2 = "OddHandler";
            string desc2 = "This is the Odd Hadler role";

            string password = "P@$$w0rd";

            if (await roleManager.FindByNameAsync(role1) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role1, desc1, DateTime.Now));
            }
            if (await roleManager.FindByNameAsync(role2) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role2, desc2, DateTime.Now));
            }

            if (await userManager.FindByNameAsync("Punter@gmail.com") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "Punter@gmail.com",
                    Email = "Punter@gmail.com",
                    FirstName = "Punter",
                    LastName = "",
                    Street = "Lagos",
                    City = "Lagos",
                    Province = "Lagos",
                    PostalCode = "LG 041",
                    Country = "Nigeria",
                    PhoneNumber = "07038974135",
                   // PasswordHash= "AQAAAAEAACcQAAAAEGqlS5TwBubk9ZOT7qd0ubnW91DSFh5YBrO1hyo6gyEE8L2tehTXGCqInsYwoTiNtQ=="
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                   await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role1);
                }
                adminId1 = user.Id;
            }

            if (await userManager.FindByNameAsync("Oddhandler@gmail.com") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "Oddhandler@gmail.com",
                    Email = "Oddhandler@gmail.com",
                    FirstName = "Punter",
                    LastName = "",
                    Street = "Lagos",
                    City = "Lagos",
                    Province = "Lagos",
                    PostalCode = "LG 002",
                    Country = "Nigeria",
                    PhoneNumber = "089078739939",
                   // PasswordHash = "AQAAAAEAACcQAAAAEGKP6YzkPqhs4svsfkPoEcRkplW+ARnMf35plpIUuMe60DLdQKElU24rImL/SCr2tQ=="
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                   await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role2);
                }
                adminId2 = user.Id;
            }

        }
    }
}
