using InstaConnect.Business.Abstraction.Helpers;
using InstaConnect.Business.Extensions;
using InstaConnect.Business.Models.DTOs.Account;
using InstaConnect.Business.Models.Options;
using Microsoft.Extensions.Hosting;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace InstaConnect.Business.Helpers
{
    public class EmailSender : IEmailSender
    {
        private readonly ISendGridClient _sendGridClient;

        public EmailSender(ISendGridClient sendGridClient, EmailOptions emailOptions)
        {
            _sendGridClient = sendGridClient;
        }

        public async Task SendEmailAsync(AccountSendEmailDTO accountSendEmailDTO, string sender)
        {
            var emailSender = MailHelper.StringToEmailAddress(sender);
            var emailReceiver = MailHelper.StringToEmailAddress(accountSendEmailDTO.Email);
            var email = MailHelper.CreateSingleEmail(emailSender, emailReceiver, accountSendEmailDTO.Subject, accountSendEmailDTO.PlainText, accountSendEmailDTO.Html);

            var response = await _sendGridClient.SendEmailAsync(email);
        }
    }
}
