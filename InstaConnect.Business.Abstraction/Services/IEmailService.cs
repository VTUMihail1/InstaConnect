using InstaConnect.Business.Models.DTOs.Email;
using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Services
{
    /// <summary>
    /// Represents an interface for sending email notifications and tokens for account-related operations.
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// Asynchronously sends an email confirmation message with a confirmation token.
        /// </summary>
        /// <param name="email">The recipient's email address.</param>
        /// <param name="userId">The user's ID for whom the confirmation is intended.</param>
        /// <param name="token">The email confirmation token to include in the message.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="EmailResultDTO"/> with the email sending result.</returns>
        Task<IResult<EmailResultDTO>> SendEmailConfirmationAsync(string email, string userId, string token);

        /// <summary>
        /// Asynchronously sends a password reset email with a reset token.
        /// </summary>
        /// <param name="email">The recipient's email address.</param>
        /// <param name="userId">The user's ID for whom the password reset is intended.</param>
        /// <param name="token">The password reset token to include in the message.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="EmailResultDTO"/> with the email sending result.</returns>
        Task<IResult<EmailResultDTO>> SendPasswordResetAsync(string email, string userId, string token);
    }
}