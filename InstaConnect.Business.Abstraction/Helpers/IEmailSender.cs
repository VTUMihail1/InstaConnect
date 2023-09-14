using InstaConnect.Business.Models.DTOs.Account;
using SendGrid;

namespace InstaConnect.Business.Abstraction.Helpers
{
    /// <summary>
    /// Represents an interface for sending email messages asynchronously.
    /// </summary>
    public interface IEmailSender
    {
        /// <summary>
        /// Sends an email message asynchronously using the provided <paramref name="accountSendEmailDTO"/>.
        /// </summary>
        /// <param name="accountSendEmailDTO">An instance of <see cref="AccountSendEmailDTO"/> containing email message details.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Response> SendEmailAsync(AccountSendEmailDTO accountSendEmailDTO);
    }
}