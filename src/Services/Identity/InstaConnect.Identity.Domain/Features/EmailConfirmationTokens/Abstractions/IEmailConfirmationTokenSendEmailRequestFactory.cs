using InstaConnect.Common.Domain.Features.Emails.Models;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;

public interface IEmailConfirmationTokenSendEmailRequestFactory
{
    SendEmailRequest Get(EmailConfirmationToken emailConfirmationToken);
}
