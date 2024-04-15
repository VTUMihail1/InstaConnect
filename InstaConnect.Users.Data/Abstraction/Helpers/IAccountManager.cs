using InstaConnect.Data.Models.Entities;

namespace InstaConnect.Users.Data.Abstraction.Helpers
{
    /// <summary>
    /// Represents an interface for managing user accounts.
    /// </summary>
    public interface IAccountManager
    {
        /// <summary>
        /// Asynchronously checks the password for a user.
        /// </summary>
        /// <param name="user">The user to check the password for.</param>
        /// <param name="password">The password to check.</param>
        /// <returns>A task that represents the asynchronous operation. The task result is true if the password is correct, otherwise false.</returns>
        Task<bool> CheckPasswordAsync(User user, string password);

        /// <summary>
        /// Asynchronously confirms the email for a user.
        /// </summary>
        /// <param name="user">The user whose email is to be confirmed.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task ConfirmEmailAsync(User user);

        /// <summary>
        /// Asynchronously resets the password for a user.
        /// </summary>
        /// <param name="user">The user for whom the password is to be reset.</param>
        /// <param name="password">The new password to set for the user.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task ResetPasswordAsync(User user, string password);

        /// <summary>
        /// Asynchronously registers a user with a given password.
        /// </summary>
        /// <param name="user">The user to register.</param>
        /// <param name="password">The password for the user.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task RegisterUserAsync(User user, string password);

        /// <summary>
        /// Asynchronously registers an admin user with a given password.
        /// </summary>
        /// <param name="user">The admin user to register.</param>
        /// <param name="password">The password for the admin user.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task RegisterAdminAsync(User user, string password);

        /// <summary>
        /// Asynchronously checks if a user's email is confirmed.
        /// </summary>
        /// <param name="user">The user to check for email confirmation.</param>
        /// <returns>A task that represents the asynchronous operation. The task result is true if the email is confirmed, otherwise false.</returns>
        Task<bool> IsEmailConfirmedAsync(User user);

        /// <summary>
        /// Validates a user by comparing their current user ID with another user ID.
        /// </summary>
        /// <param name="currentUserId">The current user's ID.</param>
        /// <param name="userId">The user ID to validate against.</param>
        /// <returns>True if the user is valid, otherwise false.</returns>
        bool ValidateUser(string currentUserId, string userId);
    }
}