using InstaConnect.Business.Models.DTOs.Account;
using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Services
{
    /// <summary>
    /// Represents a service for managing user accounts.
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// Attempts to log in a user asynchronously.
        /// </summary>
        /// <param name="accountLoginDTO">The user's login information.</param>
        /// <returns>An asynchronous task that returns the result of the login operation.</returns>
        Task<IResult<AccountResultDTO>> LoginAsync(AccountLoginDTO accountLoginDTO);

        /// <summary>
        /// Registers a new user asynchronously.
        /// </summary>
        /// <param name="accountRegistrationDTO">The user's registration information.</param>
        /// <returns>An asynchronous task that returns the result of the registration operation.</returns>
        Task<IResult<AccountResultDTO>> SignUpAsync(AccountRegistrationDTO accountRegistrationDTO);

        /// <summary>
        /// Resends an email confirmation token to the specified email address.
        /// </summary>
        /// <param name="email">The email address to resend the token to.</param>
        /// <returns>An asynchronous task that returns the result of the resend operation.</returns>
        Task<IResult<AccountResultDTO>> ResendEmailConfirmationTokenAsync(string email);

        /// <summary>
        /// Confirms a user's email address using a token.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="encodedToken">The encoded email confirmation token.</param>
        /// <returns>An asynchronous task that returns the result of the email confirmation.</returns>
        Task<IResult<AccountResultDTO>> ConfirmEmailWithTokenAsync(string userId, string encodedToken);

        /// <summary>
        /// Sends a password reset token to the specified email address.
        /// </summary>
        /// <param name="email">The email address to send the reset token to.</param>
        /// <returns>An asynchronous task that returns the result of the send operation.</returns>
        Task<IResult<AccountResultDTO>> SendPasswordResetTokenByEmailAsync(string email);

        /// <summary>
        /// Resets a user's password using a token.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="encodedToken">The encoded password reset token.</param>
        /// <param name="accountResetPasswordDTO">The new password and confirmation.</param>
        /// <returns>An asynchronous task that returns the result of the password reset.</returns>
        Task<IResult<AccountResultDTO>> ResetPasswordWithTokenAsync(string userId, string encodedToken, AccountResetPasswordDTO accountResetPasswordDTO);

        /// <summary>
        /// Logs out the user with the specified value.
        /// </summary>
        /// <param name="value">The value associated with the user's session.</param>
        /// <returns>An asynchronous task that returns the result of the logout operation.</returns>
        Task<IResult<AccountResultDTO>> LogoutAsync(string value);

        /// <summary>
        /// Edits a user's account information asynchronously.
        /// </summary>
        /// <param name="id">The ID of the user to edit.</param>
        /// <param name="accountEditDTO">The updated account information.</param>
        /// <returns>An asynchronous task that returns the result of the edit operation.</returns>
        Task<IResult<AccountResultDTO>> EditAsync(string id, AccountEditDTO accountEditDTO);

        /// <summary>
        /// Deletes a user's account asynchronously.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>An asynchronous task that returns the result of the delete operation.</returns>
        Task<IResult<AccountResultDTO>> DeleteAsync(string id);
    }
}