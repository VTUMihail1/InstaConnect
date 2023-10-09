using InstaConnect.Data.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace InstaConnect.Data.Abstraction.Helpers
{
    /// <summary>
    /// Provides methods for signing in a user using InstaConnect.
    /// </summary>
    public interface IInstaConnectSignInManager
    {
        /// <summary>
        /// Attempts to sign in a user with the provided credentials.
        /// </summary>
        /// <param name="user">The user to sign in.</param>
        /// <param name="password">The user's password.</param>
        /// <param name="isPersistent">Indicates whether the sign-in session should be persistent.</param>
        /// <param name="lockoutOnFailure">Indicates whether to lockout the user after failed sign-in attempts.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the sign-in result.</returns>
        Task<SignInResult> PasswordSignInAsync(User user, string password, bool isPersistent, bool lockoutOnFailure);
    }
}