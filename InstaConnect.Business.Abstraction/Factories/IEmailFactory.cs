using InstaConnect.Business.Models.DTOs.Account;

namespace InstaConnect.Business.Abstraction.Factories
{
    /// <summary>
    /// Represents an interface for creating email-related data transfer objects (DTOs) for various email purposes.
    /// </summary>
    public interface IEmailFactory
    {
        /// <summary>
        /// Creates an email data transfer object (DTO) for email verification.
        /// </summary>
        /// <param name="email">The recipient's email address.</param>
        /// <param name="template">The email template to use for verification.</param>
        /// <returns>An instance of <see cref="AccountSendEmailDTO"/> containing email verification information.</returns>
        AccountSendEmailDTO GetEmailVerificationDTO(string email, string template);

        /// <summary>
        /// Creates an email data transfer object (DTO) for password reset.
        /// </summary>
        /// <param name="email">The recipient's email address.</param>
        /// <param name="template">The email template to use for password reset.</param>
        /// <returns>An instance of <see cref="AccountSendEmailDTO"/> containing password reset information.</returns>
        AccountSendEmailDTO GetPasswordResetDTO(string email, string template);
    }
}