using SendGrid.Helpers.Mail;

namespace InstaConnect.Business.Abstraction.Factories
{
    /// <summary>
    /// Provides a method for creating email messages using SendGridMessage.
    /// </summary>
    public interface IEmailFactory
    {
        /// <summary>
        /// Creates an email message using the provided parameters.
        /// </summary>
        /// <param name="receiver">The email address of the message recipient.</param>
        /// <param name="subject">The subject of the email message.</param>
        /// <param name="plainText">The plain text content of the email message.</param>
        /// <param name="template">The template for formatting the email message.</param>
        /// <returns>A SendGridMessage representing the created email message.</returns>
        SendGridMessage GetEmail(string receiver, string subject, string plainText, string template);
    }
}