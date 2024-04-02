using HamburgerciUygulamasi.DAL.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerciUygulamasi.DAL.Seed
{
    public static class SeedData
    {
        //program çalıştığında oluşur
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<AppRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();

            await EnsureRolesAsync(roleManager);

            await EnsureAdminUserAsync(userManager);
        }

        //Veri tabanında customer ve admin rolleri oluştur
        public static async Task EnsureRolesAsync(RoleManager<AppRole> roleManager)
        {
            await roleManager.CreateAsync(new AppRole { Name = "customer" });
            await roleManager.CreateAsync(new AppRole { Name = "admin" });
        }

        //Admin adında yöneticiyi belirleme
        public static async Task EnsureAdminUserAsync(UserManager<AppUser> userManager)
        {
            var adminUserName = "admin";
            var adminEmail = "admin@admin.com";
            var adminPassword = "123"; 

            var adminUser = await userManager.FindByNameAsync(adminUserName);
            if (adminUser == null)
            {
                adminUser = new AppUser
                {
                    UserName = adminUserName,
                    Email = adminEmail,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(adminUser, adminPassword);
                await userManager.AddToRoleAsync(adminUser, "admin");
            }
        }

    }
}
