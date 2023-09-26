using InstaConnect.Data.Models.Entities;
using InstaConnect.Data.Models.Utilities;
using Microsoft.AspNetCore.Identity;

namespace InstaConnect.Business.Extensions
{
    public static class UserManagerExtensions
    {
        public async static Task<bool> HasPermissionAsync(this UserManager<User> userManager, string currentUserId, string userId)
        {
            var existingUser = await userManager.FindByIdAsync(currentUserId);
            var hasPermission = await userManager.IsInRoleAsync(existingUser, InstaConnectConstants.AdminRole) || currentUserId == userId;

            return hasPermission;
        }
    }
}
