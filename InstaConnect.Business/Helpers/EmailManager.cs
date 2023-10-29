using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Helpers;
using InstaConnect.Data.Models.Utilities;

namespace InstaConnect.Business.Helpers
{
    public class EmailManager : IEmailManager
    {
        private readonly IEmailSender _emailSender;
        private readonly IEmailFactory _emailFactory;
        private readonly IEndpointHandler _endpointHandler;
        private readonly IEmailTemplateGenerator _emailTemplateGenerator;

        public EmailManager(
            IEmailSender emailSender,
            IEmailFactory emailFactory,
            IEndpointHandler endpointHandler,
            IEmailTemplateGenerator emailTemplateGenerator)
        {
            _emailSender = emailSender;
            _emailFactory = emailFactory;
            _endpointHandler = endpointHandler;
            _emailTemplateGenerator = emailTemplateGenerator;
        }

        public async Task<bool> SendEmailConfirmationAsync(string email, string userId, string token)
        {
            var emailConfirmationEndpoint = _endpointHandler.ConfigureEmailConfirmationEndpoint(userId, token);
            var emailConfirmationTemplate = _emailTemplateGenerator.GenerateEmailConfirmationTemplate(emailConfirmationEndpoint);
            var emailConfirmationEmail = _emailFactory.GetEmail(email, InstaConnectConstants.AccountEmailConfirmationTitle, string.Empty, emailConfirmationTemplate);

            var result = await _emailSender.SendEmailAsync(emailConfirmationEmail);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> SendPasswordResetAsync(string email, string userId, string token)
        {
            var passwordResetEndpoint = _endpointHandler.ConfigurePasswordResetEndpoint(userId, token);
            var passwordResetTemplate = _emailTemplateGenerator.GenerateForgotPasswordTemplate(passwordResetEndpoint);
            var passwordResetEmail = _emailFactory.GetEmail(email, InstaConnectConstants.AccountForgotPasswordTitle, string.Empty, passwordResetTemplate);

            var result = await _emailSender.SendEmailAsync(passwordResetEmail);

            return result.IsSuccessStatusCode;
        }
    }
}
