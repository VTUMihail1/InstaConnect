using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Helpers;
using InstaConnect.Business.Models.Options;

namespace InstaConnect.Business.Helpers
{
    public class EmailHandler : IEmailHandler
    {
        private readonly IEmailSender _emailSender;
        private readonly IEmailFactory _emailFactory;
        private readonly IEmailTemplateGenerator _emailTemplateGenerator;

        public EmailHandler(
            IEmailSender emailSender,
            IEmailFactory emailFactory,
            IEmailTemplateGenerator emailTemplateGenerator)
        {
            _emailSender = emailSender;
            _emailFactory = emailFactory;
            _emailTemplateGenerator = emailTemplateGenerator;
        }

        public async Task SendEmailConfirmationAsync(string email, string userId, string token)
        {
            var emailConfirmationTemplate = _emailTemplateGenerator.GenerateEmailConfirmationTemplate(userId, token);
            var accountSendEmailDTO = _emailFactory.GetEmailVerificationDTO(email, emailConfirmationTemplate);

            await _emailSender.SendEmailAsync(accountSendEmailDTO);
        }

        public async Task SendPasswordResetAsync(string email, string userId, string token)
        {
            var forgotPasswordTemplate = _emailTemplateGenerator.GenerateForgotPasswordTemplate(userId, token);
            var accountSendEmailDTO = _emailFactory.GetPasswordResetDTO(email, forgotPasswordTemplate);

            await _emailSender.SendEmailAsync(accountSendEmailDTO);
        }
    }
}
