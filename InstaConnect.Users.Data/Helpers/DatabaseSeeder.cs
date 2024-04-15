using InstaConnect.Shared.Utilities;
using InstaConnect.Users.Data.Abstraction.Helpers;
using InstaConnect.Users.Data.Models.Entities;
using InstaConnect.Users.Data.Models.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace InstaConnect.Users.Data.Helpers
{
    public class DatabaseSeeder : IDatabaseSeeder
    {
        private readonly UsersContext _usersContext;
        private readonly RoleManager<Role> _roleManager;
        private readonly IAccountManager _accountManager;
        private readonly AdminOptions _adminOptions;

        public DatabaseSeeder(
            UsersContext usersContext,
            RoleManager<Role> roleManager,
            IAccountManager accountManager,
            IOptions<AdminOptions> options)
        {
            _usersContext = usersContext;
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
            var pendingMigrations = await _usersContext.Database.GetPendingMigrationsAsync();

            if (pendingMigrations.Any())
            {
                await _usersContext.Database.MigrateAsync();
            }
        }

        private async Task SeedRolesAsync()
        {
            if (await _usersContext.Roles.AnyAsync())
            {
                return;
            }

            await _roleManager.CreateAsync(new Role(Roles.User));
            await _roleManager.CreateAsync(new Role(Roles.Admin));
        }

        private async Task SeedAdminAsync()
        {
            if (await _usersContext.Users.AnyAsync())
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
