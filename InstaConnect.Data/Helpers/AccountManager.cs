using InstaConnect.Data.Abstraction.Helpers;
using InstaConnect.Data.Models.Entities;
using InstaConnect.Data.Models.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Data.Helpers
{
    public class AccountManager : IAccountManager
    {
        private readonly UserManager<User> _userManager;

        public AccountManager(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> CheckPasswordAsync(User user, string password)
        {
            var result = await _userManager.CheckPasswordAsync(user, password);

            return result;
        }

        public async Task RegisterUserAsync(User user, string password)
        {
            await _userManager.CreateAsync(user, password);
            await _userManager.AddToRoleAsync(user, InstaConnectConstants.UserRole);
        }

        public async Task RegisterAdminAsync(User user, string password)
        {
            await _userManager.CreateAsync(user, password);
            await _userManager.AddToRoleAsync(user, InstaConnectConstants.AdminRole);
        }

        public async Task<bool> IsEmailConfirmedAsync(User user)
        {
            var result = await _userManager.IsEmailConfirmedAsync(user);

            return result;
        }

        public async Task ConfirmEmailAsync(User user)
        {
            await _userManager.Users
                   .Where(u => u.Id == user.Id)
                   .ExecuteUpdateAsync(u => u.SetProperty(u => u.EmailConfirmed, true));
        }

        public async Task ResetPasswordAsync(User user, string password)
        {
            var passwordHash = _userManager.PasswordHasher.HashPassword(user, password);

            await _userManager.Users
                 .Where(u => u.Id == user.Id)
                 .ExecuteUpdateAsync(u => u.SetProperty(u => u.PasswordHash, passwordHash));
        }

        public bool ValidateUser(string currentUserId, string userId)
        {
            var result = currentUserId == userId;

            return result;
        }
    }
}
