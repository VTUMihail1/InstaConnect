﻿using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Models.DTOs.Account;
using InstaConnect.Business.Models.Options;
using InstaConnect.Business.Models.Utilities;

namespace InstaConnect.Business.Factories
{
    public class EmailFactory : IEmailFactory
    {
        public AccountSendEmailDTO GetEmailVerificationDTO(string email, string template)
        {
            return new AccountSendEmailDTO()
            {
                Email = email,
                Subject = InstaConnectConstants.AccountEmailConfirmationTitle,
                PlainText = string.Empty,
                Html = template
            };
        }

        public AccountSendEmailDTO GetPasswordResetDTO(string email, string template)
        {
            return new AccountSendEmailDTO()
            {
                Email = email,
                Subject = InstaConnectConstants.AccountForgotPasswordTitle,
                PlainText = string.Empty,
                Html = template
            };
        }
    }
}
