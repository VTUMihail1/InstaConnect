using InstaConnect.Business.Models.DTOs.Account;
using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Services
{
    /// <summary>
    /// Represents an interface for account-related operations.
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// Asynchronously performs a user login operation.
        /// </summary>
        /// <param name="accountLoginDTO">The login information for the user.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="AccountResultDTO"/> with the login result.</returns>
        Task<IResult<AccountResultDTO>> LoginAsync(AccountLoginDTO accountLoginDTO);

        /// <summary>
        /// Asynchronously signs up a new user.
        /// </summary>
        /// <param name="accountRegistrationDTO">The registration information for the new user.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="AccountResultDTO"/> with the signup result.</returns>
        Task<IResult<AccountResultDTO>> SignUpAsync(AccountRegisterDTO accountRegistrationDTO);

        /// <summary>
        /// Asynchronously resends an email confirmation token to the specified email address.
        /// </summary>
        /// <param name="email">The email address for which to resend the confirmation token.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="AccountResultDTO"/> with the resend token result.</returns>
        Task<IResult<AccountResultDTO>> ResendEmailConfirmationTokenAsync(string email);

        /// <summary>
        /// Asynchronously confirms a user's email with a token.
        /// </summary>
        /// <param name="userId">The user's ID.</param>
        /// <param name="token">The confirmation token.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="AccountResultDTO"/> with the confirmation result.</returns>
        Task<IResult<AccountResultDTO>> ConfirmEmailWithTokenAsync(string userId, string token);

        /// <summary>
        /// Asynchronously sends a password reset token to the specified email address.
        /// </summary>
        /// <param name="email">The email address for which to send the reset token.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="AccountResultDTO"/> with the reset token result.</returns>
        Task<IResult<AccountResultDTO>> SendPasswordResetTokenByEmailAsync(string email);

        /// <summary>
        /// Asynchronously resets a user's password with a token and new password information.
        /// </summary>
        /// <param name="userId">The user's ID.</param>
        /// <param name="token">The reset token.</param>
        /// <param name="accountResetPasswordDTO">The new password information for the user.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="AccountResultDTO"/> with the password reset result.</returns>
        Task<IResult<AccountResultDTO>> ResetPasswordWithTokenAsync(string userId, string token, AccountResetPasswordDTO accountResetPasswordDTO);

        /// <summary>
        /// Asynchronously logs a user out of the system.
        /// </summary>
        /// <param name="value">A value related to the logout operation (e.g., session ID).</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="AccountResultDTO"/> with the logout result.</returns>
        Task<IResult<AccountResultDTO>> LogoutAsync(string value);

        /// <summary>
        /// Asynchronously updates the user's account information.
        /// </summary>
        /// <param name="id">The user's ID.</param>
        /// <param name="accountEditDTO">The updated account information.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="AccountResultDTO"/> with the edit result.</returns>
        Task<IResult<AccountResultDTO>> EditAsync(string id, AccountEditDTO accountEditDTO);

        /// <summary>
        /// Asynchronously deletes a user's account.
        /// </summary>
        /// <param name="id">The user's ID to be deleted.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="AccountResultDTO"/> with the delete result.</returns>
        Task<IResult<AccountResultDTO>> DeleteAsync(string id);
    }
}