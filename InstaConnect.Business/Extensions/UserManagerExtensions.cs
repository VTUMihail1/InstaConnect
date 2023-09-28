using InstaConnect.Data.Models.Entities;
using InstaConnect.Data.Models.Utilities;
using Microsoft.AspNetCore.Identity;

namespace InstaConnect.Business.Extensions
{
    public static class UserManagerExtensions
    {
        public async static Task<bool> HasPermissionAsync(this UserManager<User> userManager, User currentUser, string userId)
        {
            var hasPermission = await userManager.IsInRoleAsync(currentUser, InstaConnectConstants.AdminRole) || currentUser.Id == userId;

            return hasPermission;
        }
    }
}
