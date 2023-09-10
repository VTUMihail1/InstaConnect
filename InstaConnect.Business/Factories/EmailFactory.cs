using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Extensions;
using InstaConnect.Business.Models.DTOs.Account;
using InstaConnect.Business.Models.Options;
using InstaConnect.Business.Models.Utilities;

namespace InstaConnect.Business.Factories
{
    public class EmailFactory : IEmailFactory
    {
        public AccountSendEmailDTO GetEmailVerificationDTO(string email, string domain, string userId, string token)
        {
            return new AccountSendEmailDTO()
            {
                Email = email,
                Subject = InstaConnectConstants.AccountEmailConfirmationTitle,
                PlainText = string.Empty,
                Html = this.GenerateEmailConfirmationTemplate(domain, userId, token)
            };
        }

        public AccountSendEmailDTO GetPasswordResetDTO(string email, string domain, string userId, string token)
        {
            return new AccountSendEmailDTO()
            {
                Email = email,
                Subject = InstaConnectConstants.AccountForgotPasswordTitle,
                PlainText = string.Empty,
                Html = this.GenerateForgotPasswordTemplate(domain, userId, token)
            };
        }
    }
}
