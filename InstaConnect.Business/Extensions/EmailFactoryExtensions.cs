using InstaConnect.Business.Abstraction.Factories;
using System.Text;

namespace InstaConnect.Business.Extensions
{
    public static class EmailFactoryExtensions
    {
        public static string GenerateEmailConfirmationTemplate(this IEmailFactory emailFactory, string domain, string userId, string token)
        {
            var encodedToken = Convert.ToBase64String(Encoding.UTF8.GetBytes(token));
            var endpoint = $"{domain}/{userId}/{encodedToken}";

            var html = File.ReadAllText(@"C:\Users\Misho\Desktop\InstaConnect\InstaConnect\InstaConnect.Business\Helpers\Templates\InstaConnectConfirmEmailTemplate.html");
            var emailConfirmationHtml = html.Replace("InsertYourRouteValuesHere", endpoint);

            return emailConfirmationHtml;
        }

        public static string GenerateForgotPasswordTemplate(this IEmailFactory emailFactory, string domain, string userId, string token)
        {
            var encodedToken = Convert.ToBase64String(Encoding.UTF8.GetBytes(token));
            var endpoint = $"{domain}/{userId}/{encodedToken}";

            var html = File.ReadAllText(@"C:\Users\Misho\Desktop\InstaConnect\InstaConnect\InstaConnect.Business\Helpers\Templates\InstaConnectResetPasswordTemplate.html");
            var emailConfirmationHtml = html.Replace("InsertYourRouteValuesHere", endpoint);

            return emailConfirmationHtml;
        }
    }
}
