using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Models.DTOs.Account;
using InstaConnect.Business.Models.Options;
using InstaConnect.Data.Models.Utilities;
using Microsoft.Extensions.Options;
using SendGrid.Helpers.Mail;

namespace InstaConnect.Business.Factories
{
    public class EmailFactory : IEmailFactory
    {
        private readonly EmailOptions _emailOptions;

        public EmailFactory(IOptions<EmailOptions> options)
        {
            _emailOptions = options.Value;
        }

        public SendGridMessage GetEmail(string receiver, string subject, string plaintText, string template)
        {
            var emailSender = MailHelper.StringToEmailAddress(_emailOptions.Sender);
            var emailReceiver = MailHelper.StringToEmailAddress(receiver);
            var email = MailHelper.CreateSingleEmail(emailSender, emailReceiver, subject, plaintText, template);

            return email;
        }
    }
}
