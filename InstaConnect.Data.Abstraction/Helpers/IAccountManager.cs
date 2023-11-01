using InstaConnect.Data.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace InstaConnect.Data.Abstraction.Helpers
{
    /// <summary>
    /// Provides methods for managing user accounts.
    /// </summary>
    public interface IAccountManager
    {
        /// <summary>
        /// Asynchronously checks the provided password for a user.
        /// </summary>
        /// <param name="user">The user to check the password for.</param>
        /// <param name="password">The password to be checked.</param>
        /// <returns>True if the password is correct; otherwise, false.</returns>
        Task<bool> CheckPasswordAsync(User user, string password);

        /// <summary>
        /// Asynchronously confirms the email address of a user.
        /// </summary>
        /// <param name="user">The user to confirm the email for.</param>
        Task ConfirmEmailAsync(User user);

        /// <summary>
        /// Asynchronously resets the password for a user.
        /// </summary>
        /// <param name="user">The user for whom the password will be reset.</param>
        /// <param name="password">The new password to set for the user.</param>
        Task ResetPasswordAsync(User user, string password);

        /// <summary>
        /// Asynchronously registers a new user.
        /// </summary>
        /// <param name="user">The user to register.</param>
        /// <param name="password">The password for the new user.</param>
        Task RegisterUserAsync(User user, string password);

        /// <summary>
        /// Asynchronously registers a new administrator user.
        /// </summary>
        /// <param name="user">The administrator user to register.</param>
        /// <param name="password">The password for the new administrator user.</param>
        Task RegisterAdminAsync(User user, string password);

        /// <summary>
        /// Asynchronously checks if the email address of a user is confirmed.
        /// </summary>
        /// <param name="user">The user to check the email confirmation status for.</param>
        /// <returns>True if the email is confirmed; otherwise, false.</returns>
        Task<bool> IsEmailConfirmedAsync(User user);
    }
}