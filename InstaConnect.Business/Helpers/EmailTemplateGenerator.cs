using InstaConnect.Business.Abstraction.Helpers;
using InstaConnect.Business.Models.Options;
using InstaConnect.Data.Models.Utilities;
using Microsoft.Extensions.Options;
using System.Text;

namespace InstaConnect.Business.Helpers
{
    public class EmailTemplateGenerator : IEmailTemplateGenerator
    {
        public string GenerateEmailConfirmationTemplate(string endpoint)
        {
            var html = File.ReadAllText(InstaConnectConstants.EmailTemplatePrefixPath + InstaConnectConstants.EmailConfirmationTemplatePath);
            var emailConfirmationTemplateHtml = html.Replace(InstaConnectConstants.TemplateLinkPlaceholder, endpoint);

            return emailConfirmationTemplateHtml;
        }

        public string GenerateForgotPasswordTemplate(string endpoint)
        {
            var html = File.ReadAllText(InstaConnectConstants.EmailTemplatePrefixPath + InstaConnectConstants.ForgotPasswordTemplatePath);
            var passwordResetTemplateHtml = html.Replace(InstaConnectConstants.TemplateLinkPlaceholder, endpoint);

            return passwordResetTemplateHtml;
        }
    }
}
