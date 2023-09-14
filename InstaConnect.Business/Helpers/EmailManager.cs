using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Helpers;

namespace InstaConnect.Business.Helpers
{
    public class EmailManager : IEmailManager
    {
        private readonly IEmailSender _emailSender;
        private readonly IEmailFactory _emailFactory;
        private readonly IEmailTemplateGenerator _emailTemplateGenerator;

        public EmailManager(
            IEmailSender emailSender,
            IEmailFactory emailFactory,
            IEmailTemplateGenerator emailTemplateGenerator)
        {
            _emailSender = emailSender;
            _emailFactory = emailFactory;
            _emailTemplateGenerator = emailTemplateGenerator;
        }

        public async Task<bool> SendEmailConfirmationAsync(string email, string userId, string token)
        {
            var emailConfirmationTemplate = _emailTemplateGenerator.GenerateEmailConfirmationTemplate(userId, token);
            var accountSendEmailDTO = _emailFactory.GetEmailVerificationDTO(email, emailConfirmationTemplate);

            var result = await _emailSender.SendEmailAsync(accountSendEmailDTO);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> SendPasswordResetAsync(string email, string userId, string token)
        {
            var forgotPasswordTemplate = _emailTemplateGenerator.GenerateForgotPasswordTemplate(userId, token);
            var accountSendEmailDTO = _emailFactory.GetPasswordResetDTO(email, forgotPasswordTemplate);

            var result = await _emailSender.SendEmailAsync(accountSendEmailDTO);

            return result.IsSuccessStatusCode;
        }
    }
}
