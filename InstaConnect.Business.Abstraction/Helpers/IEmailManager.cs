namespace InstaConnect.Business.Abstraction.Helpers
{
    /// <summary>
    /// Represents an interface for handling email-related operations such as sending email confirmations and password reset emails.
    /// </summary>
    public interface IEmailManager
    {
        /// <summary>
        /// Sends an email confirmation email asynchronously.
        /// </summary>
        /// <param name="email">The recipient's email address.</param>
        /// <param name="userId">The user's unique identifier.</param>
        /// <param name="token">The email confirmation token.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<bool> SendEmailConfirmationAsync(string email, string userId, string token);

        /// <summary>
        /// Sends a password reset email asynchronously.
        /// </summary>
        /// <param name="email">The recipient's email address.</param>
        /// <param name="userId">The user's unique identifier.</param>
        /// <param name="token">The password reset token.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<bool> SendPasswordResetAsync(string email, string userId, string token);
    }
}