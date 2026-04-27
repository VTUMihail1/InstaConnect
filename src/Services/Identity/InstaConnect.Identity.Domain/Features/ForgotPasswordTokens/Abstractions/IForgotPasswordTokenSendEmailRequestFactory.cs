using InstaConnect.Common.Domain.Features.Emails.Models;

namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;

public interface IForgotPasswordTokenSendEmailRequestFactory
{
    Task<SendEmailRequest> GetAsync(ForgotPasswordToken forgotPasswordToken, CancellationToken cancellationToken);
}
