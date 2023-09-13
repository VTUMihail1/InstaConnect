using InstaConnect.Business.Models.DTOs.Account;
using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Services
{
    /// <summary>
    /// Represents the account service for user authentication and account management.
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// Logs in a user with the provided credentials.
        /// </summary>
        /// <param name="accountLoginDTO">The DTO containing login information.</param>
        /// <returns>An <see cref="IResult{T}"/> containing the result of the login operation.</returns>
        Task<IResult<string>> LoginAsync(AccountLoginDTO accountLoginDTO);

        /// <summary>
        /// Registers a new user account.
        /// </summary>
        /// <param name="accountRegistrationDTO">The DTO containing registration information.</param>
        /// <returns>An <see cref="IResult{T}"/> containing the result of the registration operation.</returns>
        Task<IResult<string>> SignUpAsync(AccountRegistrationDTO accountRegistrationDTO);

        /// <summary>
        /// Sends an email confirmation token to the user with the specified email.
        /// </summary>
        /// <param name="email">The email address of the user.</param>
        /// <returns>An <see cref="IResult{T}"/> containing the result of sending the email confirmation token.</returns>
        Task<IResult<string>> SendEmailConfirmationTokenAsync(string email);

        /// <summary>
        /// Confirms a user's email using the provided token.
        /// </summary>
        /// <param name="userId">The user's ID.</param>
        /// <param name="encodedToken">The encoded email confirmation token.</param>
        /// <returns>An <see cref="IResult{T}"/> containing the result of confirming the email.</returns>
        Task<IResult<string>> ConfirmEmailWithTokenAsync(string userId, string encodedToken);

        /// <summary>
        /// Sends a password reset token to the user with the specified email.
        /// </summary>
        /// <param name="email">The email address of the user.</param>
        /// <returns>An <see cref="IResult{T}"/> containing the result of sending the password reset token.</returns>
        Task<IResult<string>> SendPasswordResetTokenByEmailAsync(string email);

        /// <summary>
        /// Resets a user's password using the provided token and new password.
        /// </summary>
        /// <param name="userId">The user's ID.</param>
        /// <param name="encodedToken">The encoded password reset token.</param>
        /// <param name="accountResetPasswordDTO">The DTO containing the new password.</param>
        /// <returns>An <see cref="IResult{T}"/> containing the result of resetting the password.</returns>
        Task<IResult<string>> ResetPasswordWithTokenAsync(string userId, string encodedToken, AccountResetPasswordDTO accountResetPasswordDTO);
    }
}