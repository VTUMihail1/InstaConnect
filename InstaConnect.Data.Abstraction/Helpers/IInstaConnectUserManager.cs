using InstaConnect.Data.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace InstaConnect.Data.Abstraction.Helpers
{
    /// <summary>
    /// Provides user management operations for InstaConnect users.
    /// </summary>
    public interface IInstaConnectUserManager
    {
        /// <summary>
        /// Adds a user to a specific role.
        /// </summary>
        /// <param name="user">The user to add to the role.</param>
        /// <param name="role">The name of the role to add the user to.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the identity result.</returns>
        Task<IdentityResult> AddToRoleAsync(User user, string role);

        Task<bool> CheckPasswordAsync(User user, string password);

        Task ConfirmEmailAsync(User user);

        Task ResetPasswordAsync(User user, string password);

        /// <summary>
        /// Creates a new user with the specified password.
        /// </summary>
        /// <param name="user">The user to create.</param>
        /// <param name="password">The user's password.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the identity result.</returns>
        Task<IdentityResult> CreateAsync(User user, string password);

        /// <summary>
        /// Deletes a user.
        /// </summary>
        /// <param name="user">The user to delete.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the identity result.</returns>
        Task<IdentityResult> DeleteAsync(User user);

        /// <summary>
        /// Finds a user by their email address.
        /// </summary>
        /// <param name="email">The email address of the user to find.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the found user.</returns>
        Task<User?> FindByEmailAsync(string email);

        /// <summary>
        /// Finds a user by their user ID.
        /// </summary>
        /// <param name="id">The user's ID.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the found user.</returns>
        Task<User?> FindByIdAsync(string userId);

        /// <summary>
        /// Finds a user by their username.
        /// </summary>
        /// <param name="username">The username of the user to find.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the found user.</returns>
        Task<User?> FindByNameAsync(string username);

        /// <summary>
        /// Generates an email confirmation token for a user.
        /// </summary>
        /// <param name="user">The user for whom to generate the email confirmation token.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the generated token.</returns>
        Task<string> GenerateEmailConfirmationTokenAsync(User user);

        /// <summary>
        /// Generates a password reset token for a user.
        /// </summary>
        /// <param name="user">The user for whom to generate the password reset token.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the generated token.</returns>
        Task<string> GeneratePasswordResetTokenAsync(User user);

        /// <summary>
        /// Checks if a user's email has been confirmed.
        /// </summary>
        /// <param name="user">The user to check.</param>
        /// <returns>A task representing the asynchronous operation. The task result indicates whether the email is confirmed.</returns>
        Task<bool> IsEmailConfirmedAsync(User user);

        /// <summary>
        /// Resets a user's password using a reset token and a new password.
        /// </summary>
        /// <param name="user">The user whose password needs to be reset.</param>
        /// <param name="token">The password reset token.</param>
        /// <param name="newPassword">The new password for the user.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the identity result.</returns>
        Task<IdentityResult> ResetPasswordAsync(User user, string token, string newPassword);

        /// <summary>
        /// Updates a user's information.
        /// </summary>
        /// <param name="user">The user to update.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the identity result.</returns>
        Task<IdentityResult> UpdateAsync(User user);
    }
}