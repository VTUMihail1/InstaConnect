using InstaConnect.Business.Abstraction.Helpers;
using InstaConnect.Business.Models.Options;
using InstaConnect.Data.Models.Utilities;
using Microsoft.Extensions.Options;
using System.Text;

namespace InstaConnect.Business.Helpers
{
    public class EmailTemplateGenerator : IEmailTemplateGenerator
    {
        private readonly ITokenCryptographer _tokenCryptographer;
        private readonly EmailOptions _emailOptions;

        public EmailTemplateGenerator(
            ITokenCryptographer tokenCryptographer,
            IOptions<EmailOptions> options)
        {
            _tokenCryptographer = tokenCryptographer;
            _emailOptions = options.Value;
        }

        public string GenerateEmailConfirmationTemplate(string userId, string token)
        {
            var encodedToken = _tokenCryptographer.EncodeToken(token);
            var endpoint = $"{_emailOptions.ConfirmEmailEndpoint}/by-user/{userId}/by-token/{encodedToken}";

            var html = File.ReadAllText(InstaConnectConstants.EmailTemplatePrefixPath + InstaConnectConstants.EmailConfirmationTemplatePath);
            var emailConfirmationTemplateHtml = html.Replace(InstaConnectConstants.TemplateLinkPlaceholder, endpoint);

            return emailConfirmationTemplateHtml;
        }

        public string GenerateForgotPasswordTemplate(string userId, string token)
        {
            var encodedToken = _tokenCryptographer.EncodeToken(token);
            var endpoint = $"{_emailOptions.ResetPasswordEndpoint}/by-user/{userId}/by-token/{encodedToken}";

            var html = File.ReadAllText(InstaConnectConstants.EmailTemplatePrefixPath + InstaConnectConstants.ForgotPasswordTemplatePath);
            var passwordResetTemplateHtml = html.Replace(InstaConnectConstants.TemplateLinkPlaceholder, endpoint);

            return passwordResetTemplateHtml;
        }
    }
}
