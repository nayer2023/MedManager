using MediHarbor.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;

namespace MediHarbor.Data
{
    public class UserSeeder
    {
        public static async Task SeedUsersAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            await CreateUserWithRole(userManager, "Manager@MediHarbor.com", "Manager123!", Roles.Manager);
            await CreateUserWithRole(userManager, "Doctor@MediHarbor.com", "Doctor123!", Roles.Doctor);
            await CreateUserWithRole(userManager, "Patient@MediHarbor.com", "Patient123!", Roles.Patient);
        }
        public static async Task CreateUserWithRole(
            UserManager<IdentityUser> userManager, string email, string password, string role)
        {
            if (await userManager.FindByEmailAsync(email) == null)
            {
                var user = new IdentityUser
                {
                    Email = email,
                    EmailConfirmed = true,
                    UserName = email

                };
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
                else
                {
                    throw new Exception($"Failed creating user with email {user.Email}. Errors: {string.Join(", ", result.Errors)}");
                }


            }
        }
    }
}
