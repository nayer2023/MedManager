using MediHarbor.Constants;
using Microsoft.AspNetCore.Identity;

namespace MediHarbor.Data
{
    public class RoleSeeder
    {
        public static async Task SeedRolesAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            if (!await roleManager.RoleExistsAsync(Roles.Manager))
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.Manager));
            }
            if (!await roleManager.RoleExistsAsync(Roles.Doctor))
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.Doctor));
            }

            if (!await roleManager.RoleExistsAsync(Roles.Patient))
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.Patient));
            }
        }
    }
}
