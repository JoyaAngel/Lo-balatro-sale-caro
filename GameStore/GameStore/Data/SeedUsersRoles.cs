using GameStore.Models;
using Microsoft.AspNetCore.Identity;

namespace GameStore.Data
{
    public class SeedUsersRoles
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<GameStoreUser>>();

            // Create admin role if it do not exist
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                var role = new IdentityRole("Admin");
                await roleManager.CreateAsync(role);
            }

            // Create user by default if it do not exist
            string adminEmail = "admin@gamestore.com";
            string adminPassword = "Admin123!";
            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var user = new GameStoreUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FirstName = "Administrador",
                    LastName = "Default",
                    DateSignUp = DateTime.Now
                };
                var result = await userManager.CreateAsync(user, adminPassword);
                if (result.Succeeded)
                {
                    // Assign the admin role to the user
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }
        }
    }
}
