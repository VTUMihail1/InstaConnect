using InstaConnect.Common.Domain.Features.Emails.Models;

namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;

public interface IForgotPasswordTokenSendEmailRequestFactory
{
    SendEmailRequest Get(ForgotPasswordToken forgotPasswordToken);
}
