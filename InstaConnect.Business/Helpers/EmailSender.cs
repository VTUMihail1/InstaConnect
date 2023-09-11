using InstaConnect.Business.Abstraction.Helpers;
using InstaConnect.Business.Models.DTOs.Account;
using InstaConnect.Data.Models.Models.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace InstaConnect.Business.Helpers
{
    public class EmailSender : IEmailSender
    {
        private readonly ISendGridClient _sendGridClient;
        private readonly EmailSenderOptions _emailSenderOptions;

        public EmailSender(ISendGridClient sendGridClient, EmailSenderOptions emailSenderOptions)
        {
            _sendGridClient = sendGridClient;
            _emailSenderOptions = emailSenderOptions;
        }

        public async Task SendEmailAsync(AccountSendEmailDTO accountSendEmailDTO)
        {
            var sender = MailHelper.StringToEmailAddress(_emailSenderOptions.Sender);
            var receiver = MailHelper.StringToEmailAddress(accountSendEmailDTO.Email);
            var email = MailHelper.CreateSingleEmail(sender, receiver, accountSendEmailDTO.Subject, accountSendEmailDTO.PlainText, accountSendEmailDTO.Html);

            await _sendGridClient.SendEmailAsync(email);
        }
    }
}
