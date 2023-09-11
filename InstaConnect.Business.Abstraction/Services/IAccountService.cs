using InstaConnect.Business.Models.DTOs.Account;
using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Services
{
    /// <summary>
    /// Represents an interface for managing user accounts and authentication-related operations.
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// Confirms a user's email address asynchronously.
        /// </summary>
        /// <param name="userId">The user's unique identifier.</param>
        /// <param name="token">The email confirmation token.</param>
        /// <returns>An <see cref="IResult{T}"/> indicating the result of the email confirmation operation.</returns>
        Task<IResult<string>> ConfirmEmailAsync(string userId, string token);

        /// <summary>
        /// Sends an email containing an account confirmation token asynchronously.
        /// </summary>
        /// <param name="email">The recipient's email address.</param>
        /// <returns>An <see cref="IResult{T}"/> indicating the result of sending the account confirmation token.</returns>
        Task<IResult<string>> SendAccountConfirmEmailTokenAsync(string email);

        /// <summary>
        /// Sends an email containing a reset password token asynchronously.
        /// </summary>
        /// <param name="email">The recipient's email address.</param>
        /// <returns>An <see cref="IResult{T}"/> indicating the result of sending the reset password token.</returns>
        Task<IResult<string>> SendAccountResetPasswordTokenAsync(string email);

        /// <summary>
        /// Authenticates a user and logs them in asynchronously.
        /// </summary>
        /// <param name="accountLoginDTO">A data transfer object containing login credentials.</param>
        /// <returns>An <see cref="IResult{T}"/> indicating the result of the login operation.</returns>
        Task<IResult<string>> LoginAsync(AccountLoginDTO accountLoginDTO);

        /// <summary>
        /// Resets a user's password asynchronously.
        /// </summary>
        /// <param name="userId">The user's unique identifier.</param>
        /// <param name="token">The reset password token.</param>
        /// <param name="accountResetPasswordDTO">A data transfer object containing the new password.</param>
        /// <returns>An <see cref="IResult{T}"/> indicating the result of the password reset operation.</returns>
        Task<IResult<string>> ResetPasswordAsync(string userId, string token, AccountResetPasswordDTO accountResetPasswordDTO);

        /// <summary>
        /// Registers a new user account asynchronously.
        /// </summary>
        /// <param name="accountRegistrationDTO">A data transfer object containing registration information.</param>
        /// <returns>An <see cref="IResult{T}"/> indicating the result of the registration operation.</returns>
        Task<IResult<string>> SignUpAsync(AccountRegistrationDTO accountRegistrationDTO);
    }
}