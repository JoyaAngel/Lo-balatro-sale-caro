using GameStore.Models;
using Microsoft.AspNetCore.Identity;

namespace GameStore.Data
{
    public static class SeedUsersRoles
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<GameStoreUser>>();

            // Creamos estos roles por defecto
            string[] roles = new[] { "Administrador", "Cliente" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

            // Crear usuario administrador por defecto
            string adminEmail = "admin@gamestore.com";
            string password = "Admin123UmDelta!";

            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var user = new GameStoreUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    Nombre = "Admin",
                    Apellido = "Principal",
                    FechaRegistro = DateTime.Now
                };

                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(user, "Administrador");
            }
        }
    }
}
