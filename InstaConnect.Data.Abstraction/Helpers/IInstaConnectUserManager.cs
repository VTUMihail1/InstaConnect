using InstaConnect.Data.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace InstaConnect.Data.Abstraction.Helpers
{
    /// <summary>
    /// Provides methods for managing user-related operations and interactions.
    /// </summary>
    public interface IInstaConnectUserManager
    {
        /// <summary>
        /// Asynchronously adds a user to a specific role.
        /// </summary>
        /// <param name="user">The user to add to the role.</param>
        /// <param name="role">The role to add the user to.</param>
        /// <returns>A task that represents the asynchronous operation. The task result is an IdentityResult indicating the result of the operation.</returns>
        Task<IdentityResult> AddToRoleAsync(User user, string role);

        /// <summary>
        /// Asynchronously checks if the provided password is correct for the user.
        /// </summary>
        /// <param name="user">The user for which to check the password.</param>
        /// <param name="password">The password to check.</param>
        /// <returns>A task that represents the asynchronous operation. The task result is a boolean value indicating whether the password is correct (true) or not (false).</returns>
        Task<bool> CheckPasswordAsync(User user, string password);

        /// <summary>
        /// Asynchronously confirms the email of a user.
        /// </summary>
        /// <param name="user">The user to confirm the email for.</param>
        /// <returns>A task that represents the asynchronous confirmation operation.</returns>
        Task ConfirmEmailAsync(User user);

        /// <summary>
        /// Asynchronously resets a user's password.
        /// </summary>
        /// <param name="user">The user for which to reset the password.</param>
        /// <param name="password">The new password for the user.</param>
        /// <returns>A task that represents the asynchronous password reset operation.</returns>
        Task ResetPasswordAsync(User user, string password);

        /// <summary>
        /// Asynchronously creates a new user with the provided password.
        /// </summary>
        /// <param name="user">The user to create.</param>
        /// <param name="password">The password for the new user.</param>
        /// <returns>A task that represents the asynchronous user creation operation. The task result is an IdentityResult indicating the result of the operation.</returns>
        Task<IdentityResult> CreateAsync(User user, string password);

        /// <summary>
        /// Asynchronously deletes a user.
        /// </summary>
        /// <param name="user">The user to delete.</param>
        /// <returns>A task that represents the asynchronous user deletion operation. The task result is an IdentityResult indicating the result of the operation.</returns>
        Task<IdentityResult> DeleteAsync(User user);

        /// <summary>
        /// Asynchronously finds a user by their email address.
        /// </summary>
        /// <param name="email">The email address to search for.</param>
        /// <returns>A task that represents the asynchronous user retrieval operation. The task result is a User or null if the user is not found.</returns>
        Task<User?> FindByEmailAsync(string email);

        /// <summary>
        /// Asynchronously finds a user by their unique identifier (ID).
        /// </summary>
        /// <param name="userId">The unique identifier of the user to search for.</param>
        /// <returns>A task that represents the asynchronous user retrieval operation. The task result is a User or null if the user is not found.</returns>
        Task<User?> FindByIdAsync(string userId);

        /// <summary>
        /// Asynchronously finds a user by their username.
        /// </summary>
        /// <param name="username">The username to search for.</param>
        /// <returns>A task that represents the asynchronous user retrieval operation. The task result is a User or null if the user is not found.</returns>
        Task<User?> FindByNameAsync(string username);

        /// <summary>
        /// Asynchronously generates an email confirmation token for a user.
        /// </summary>
        /// <param name="user">The user for which to generate the email confirmation token.</param>
        /// <returns>A task that represents the asynchronous token generation operation. The task result is a string containing the generated token.</returns>
        Task<string> GenerateEmailConfirmationTokenAsync(User user);

        /// <summary>
        /// Asynchronously generates a password reset token for a user.
        /// </summary>
        /// <param name="user">The user for which to generate the password reset token.</param>
        /// <returns>A task that represents the asynchronous token generation operation. The task result is a string containing the generated token.</returns>
        Task<string> GeneratePasswordResetTokenAsync(User user);

        /// <summary>
        /// Asynchronously checks if a user's email is confirmed.
        /// </summary>
        /// <param name="user">The user to check for email confirmation status.</param>
        /// <returns>A task that represents the asynchronous operation. The task result is a boolean value indicating whether the email is confirmed (true) or not (false).</returns>
        Task<bool> IsEmailConfirmedAsync(User user);

        /// <summary>
        /// Asynchronously resets a user's password using a token and a new password.
        /// </summary>
        /// <param name="user">The user for which to reset the password.</param>
        /// <param name="token">The reset token.</param>
        /// <param name="newPassword">The new password for the user.</param>
        /// <returns>A task that represents the asynchronous password reset operation. The task result is an IdentityResult indicating the result of the operation.</returns>
        Task<IdentityResult> ResetPasswordAsync(User user, string token, string newPassword);

        /// <summary>
        /// Asynchronously updates user information.
        /// </summary>
        /// <param name="user">The user to update.</param>
        /// <returns>A task that represents the asynchronous user information update operation. The task result is an IdentityResult indicating the result of the operation.</returns>
        Task<IdentityResult> UpdateAsync(User user);
    }
}