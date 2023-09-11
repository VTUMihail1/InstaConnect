using InstaConnect.Business.Models.Options;
using InstaConnect.Business.Models.Utilities;
using System.Text;

namespace InstaConnect.Business.Helpers
{
    public class EmailTemplateGenerator : IEmailTemplateGenerator
    {
        private readonly EmailTemplateOptions _emailTemplateOptions;

        public EmailTemplateGenerator(EmailTemplateOptions emailTemplateOptions)
        {
            _emailTemplateOptions = emailTemplateOptions;
        }

        public string GenerateEmailConfirmationTemplate(string userId, string token)
        {
            var encodedToken = Convert.ToBase64String(Encoding.UTF8.GetBytes(token));
            var endpoint = $"{_emailTemplateOptions.ConfirmEmailEndpoint}/{userId}/{encodedToken}";

            var html = File.ReadAllText(InstaConnectConstants.EmailConfirmationTemplatePath);
            var emailConfirmationTemplateHtml = html.Replace(InstaConnectConstants.TemplateLinkPlaceholder, endpoint);

            return emailConfirmationTemplateHtml;
        }

        public string GenerateForgotPasswordTemplate(string userId, string token)
        {
            var encodedToken = Convert.ToBase64String(Encoding.UTF8.GetBytes(token));
            var endpoint = $"{_emailTemplateOptions.ResetPasswordEndpoint}/{userId}/{encodedToken}";

            var html = File.ReadAllText(InstaConnectConstants.ForgotPasswordTemplatePath);
            var passwordResetTemplateHtml = html.Replace(InstaConnectConstants.TemplateLinkPlaceholder, endpoint);

            return passwordResetTemplateHtml;
        }
    }
}
