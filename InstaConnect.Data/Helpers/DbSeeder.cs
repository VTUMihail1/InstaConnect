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
        private readonly IAccountManager _accountManager;
        private readonly AdminOptions _adminOptions;

        public DbSeeder(
            InstaConnectContext instaConnectContext,
            RoleManager<Role> roleManager,
            IAccountManager accountManager,
            IOptions<AdminOptions> options)
        {
            _instaConnectContext = instaConnectContext;
            _roleManager = roleManager;
            _accountManager = accountManager;
            _adminOptions = options.Value;
        }

        public async Task SeedAsync()
        {
            await SeedRolesAsync();
            await SeedAdminAsync();
        }

        public async Task ApplyPendingMigrationsAsync()
        {
            var pendingMigrations = await _instaConnectContext.Database.GetPendingMigrationsAsync();

            if (pendingMigrations.Any())
            {
                await _instaConnectContext.Database.MigrateAsync();
            }
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

            await _accountManager.RegisterAdminAsync(adminUser, _adminOptions.Password);
            await _accountManager.ConfirmEmailAsync(adminUser);
        }
    }
}
