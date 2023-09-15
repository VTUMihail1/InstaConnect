using InstaConnect.Business.Abstraction.Helpers;
using InstaConnect.Business.Models.Options;
using InstaConnect.Data.Models.Utilities;
using Microsoft.Extensions.Options;
using System.Text;

namespace InstaConnect.Business.Helpers
{
    public class EmailTemplateGenerator : IEmailTemplateGenerator
    {
        private readonly EmailOptions _emailOptions;

        public EmailTemplateGenerator(IOptions<EmailOptions> options)
        {
            _emailOptions = options.Value;
        }

        public string GenerateEmailConfirmationTemplate(string userId, string token)
        {
            var encodedToken = Convert.ToBase64String(Encoding.UTF8.GetBytes(token));
            var endpoint = $"{_emailOptions.ConfirmEmailEndpoint}/{userId}/{encodedToken}";

            var html = File.ReadAllText(InstaConnectConstants.EmailConfirmationTemplatePath);
            var emailConfirmationTemplateHtml = html.Replace(InstaConnectConstants.TemplateLinkPlaceholder, endpoint);

            return emailConfirmationTemplateHtml;
        }

        public string GenerateForgotPasswordTemplate(string userId, string token)
        {
            var encodedToken = Convert.ToBase64String(Encoding.UTF8.GetBytes(token));
            var endpoint = $"{_emailOptions.ResetPasswordEndpoint}/{userId}/{encodedToken}";

            var html = File.ReadAllText(InstaConnectConstants.ForgotPasswordTemplatePath);
            var passwordResetTemplateHtml = html.Replace(InstaConnectConstants.TemplateLinkPlaceholder, endpoint);

            return passwordResetTemplateHtml;
        }
    }
}
