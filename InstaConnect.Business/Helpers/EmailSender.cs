using InstaConnect.Business.Abstraction.Helpers;
using InstaConnect.Business.Models.DTOs.Account;
using InstaConnect.Business.Models.Options;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace InstaConnect.Business.Helpers
{
    public class EmailSender : IEmailSender
    {
        private readonly ISendGridClient _sendGridClient;
        private readonly EmailOptions _emailOptions;

        public EmailSender(ISendGridClient sendGridClient, IOptions<EmailOptions> options)
        {
            _sendGridClient = sendGridClient;
            _emailOptions = options.Value;
        }

        public async Task<Response> SendEmailAsync(AccountSendEmailDTO accountSendEmailDTO)
        {
            var sender = MailHelper.StringToEmailAddress(_emailOptions.Sender);
            var receiver = MailHelper.StringToEmailAddress(accountSendEmailDTO.Email);
            var email = MailHelper.CreateSingleEmail(sender, receiver, accountSendEmailDTO.Subject, accountSendEmailDTO.PlainText, accountSendEmailDTO.Html);

            var result = await _sendGridClient.SendEmailAsync(email);

            return result;
        }
    }
}
