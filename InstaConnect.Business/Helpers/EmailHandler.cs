using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Helpers;
using InstaConnect.Business.Models.Options;

namespace InstaConnect.Business.Helpers
{
    public class EmailHandler : IEmailHandler
    {
        private readonly IEmailSender _emailSender;
        private readonly IEmailFactory _emailFactory;
        private readonly EmailOptions _emailOptions;

        public EmailHandler(
            IEmailSender emailSender,
            IEmailFactory emailFactory,
            EmailOptions emailOptions)
        {
            _emailSender = emailSender;
            _emailFactory = emailFactory;
            _emailOptions = emailOptions;
        }

        public async Task SendEmailVerification(string email, string userId, string token)
        {
            var accountSendEmailDTO = _emailFactory.GetEmailVerificationDTO(email, _emailOptions.ConfirmEmailEndpoint, userId, token);

            await _emailSender.SendEmailAsync(accountSendEmailDTO, _emailOptions.Sender);
        }

        public async Task SendPasswordResetAsync(string email, string userId, string token)
        {
            var accountSendEmailDTO = _emailFactory.GetPasswordResetDTO(email, _emailOptions.ResetPasswordEndpoint, userId, token);

            await _emailSender.SendEmailAsync(accountSendEmailDTO, _emailOptions.Sender);
        }
    }
}
