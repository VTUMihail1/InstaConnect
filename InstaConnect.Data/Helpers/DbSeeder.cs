using InstaConnect.Data.Abstraction.Helpers;
using InstaConnect.Data.Models.Entities;
using InstaConnect.Data.Models.Models.Options;
using InstaConnect.Data.Models.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Data.Helpers
{
    public class DbSeeder : IDbSeeder
    {
        private readonly InstaConnectContext _instaConnectContext;
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly AdminOptions _adminOptions;

        public DbSeeder(
            InstaConnectContext instaConnectContext,
            RoleManager<Role> roleManager,
            UserManager<User> userManager,
            AdminOptions adminOptions)
        {
            _instaConnectContext = instaConnectContext;
            _roleManager = roleManager;
            _userManager = userManager;
            _adminOptions = adminOptions;
        }

        public async Task SeedAsync()
        {
            await SeedRolesAsync();
            await SeedAdminAsync();
        }

        private async Task SeedRolesAsync()
        {
            if (await _instaConnectContext.Roles.AnyAsync())
            {
                return;
            }

            await _roleManager.CreateAsync(new Role(InstaConnectDataConstants.AdminRole));
            await _roleManager.CreateAsync(new Role(InstaConnectDataConstants.UserRole));
        }

        private async Task SeedAdminAsync()
        {
            if (await _instaConnectContext.Users.AnyAsync())
            {
                return;
            }

            var adminUser = new User
            {
                FirstName = "Admin",
                LastName = "Admin",
                Email = _adminOptions.Email,
                UserName = "InstaConnectAdmin"
            };

            await _userManager.CreateAsync(adminUser, _adminOptions.Password);
            await _userManager.AddToRoleAsync(adminUser, InstaConnectDataConstants.AdminRole);

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(adminUser);
            await _userManager.ConfirmEmailAsync(adminUser, token);
        }
    }
}
