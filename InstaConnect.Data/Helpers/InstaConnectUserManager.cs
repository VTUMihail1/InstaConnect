using InstaConnect.Data.Abstraction.Helpers;
using InstaConnect.Data.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace InstaConnect.Data.Helpers
{
    public class InstaConnectUserManager : IInstaConnectUserManager
    {
        private readonly UserManager<User> _userManager;

        public InstaConnectUserManager(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<User> FindByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            return user;
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            return user;
        }

        public async Task<User> FindByNameAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            return user;
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(User user)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            return token;
        }

        public async Task<IdentityResult> ConfirmEmailAsync(User user, string token)
        {
            var identityResult = await _userManager.ConfirmEmailAsync(user, token);

            return identityResult;
        }

        public async Task<string> GeneratePasswordResetTokenAsync(User user)
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            return token;
        }

        public async Task<IdentityResult> ResetPasswordAsync(User user, string token, string newPassword)
        {
            var identityResult = await _userManager.ResetPasswordAsync(user, token, newPassword);

            return identityResult;
        }

        public async Task<bool> IsEmailConfirmedAsync(User user)
        {
            var result = await _userManager.IsEmailConfirmedAsync(user);

            return result;
        }

        public async Task<IdentityResult> CreateAsync(User user, string password)
        {
            var identityResult = await _userManager.CreateAsync(user, password);

            return identityResult;
        }

        public async Task<IdentityResult> AddToRoleAsync(User user, string role)
        {
            var identityResult = await _userManager.AddToRoleAsync(user, role);

            return identityResult;
        }

        public async Task<IdentityResult> UpdateAsync(User user)
        {
            var identityResult = await _userManager.UpdateAsync(user);

            return identityResult;
        }

        public async Task<IdentityResult> DeleteAsync(User user)
        {
            var identityResult = await _userManager.DeleteAsync(user);

            return identityResult;
        }
    }
}
