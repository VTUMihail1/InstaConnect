using InstaConnect.Business.Abstraction.Helpers;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace InstaConnect.Business.Helpers
{
    public class EmailSender : IEmailSender
    {
        private readonly ISendGridClient _sendGridClient;

        public EmailSender(ISendGridClient sendGridClient)
        {
            _sendGridClient = sendGridClient;
        }

        public async Task<Response> SendEmailAsync(SendGridMessage sendGridMessage)
        {
            var result = await _sendGridClient.SendEmailAsync(sendGridMessage);

            return result;
        }
    }
}
