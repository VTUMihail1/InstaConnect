using InstaConnect.Data.Abstraction.Helpers;
using InstaConnect.Data.Models.Entities;
using InstaConnect.Data.Models.Options;
using InstaConnect.Data.Models.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

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
            IOptions<AdminOptions> options)
        {
            _instaConnectContext = instaConnectContext;
            _roleManager = roleManager;
            _userManager = userManager;
            _adminOptions = options.Value;
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

            await _roleManager.CreateAsync(new Role(InstaConnectConstants.AdminRole));
            await _roleManager.CreateAsync(new Role(InstaConnectConstants.UserRole));
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
            await _userManager.AddToRoleAsync(adminUser, InstaConnectConstants.AdminRole);

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(adminUser);
            await _userManager.ConfirmEmailAsync(adminUser, token);
        }
    }
}
