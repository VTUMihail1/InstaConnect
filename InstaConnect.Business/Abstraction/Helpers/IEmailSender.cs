using SendGrid;
using SendGrid.Helpers.Mail;

namespace InstaConnect.Business.Abstraction.Helpers
{
    /// <summary>
    /// Provides a method for sending email messages asynchronously.
    /// </summary>
    public interface IEmailSender
    {
        /// <summary>
        /// Sends an email message using the provided SendGridMessage.
        /// </summary>
        /// <param name="sendGridMessage">The SendGridMessage containing the email content and recipient information.</param>
        /// <returns>A task that represents the asynchronous operation. The task result is a Response indicating the result of the email sending process.</returns>
        Task<Response> SendEmailAsync(SendGridMessage sendGridMessage);
    }
}