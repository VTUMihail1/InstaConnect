namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;

public interface IEmailConfirmationTokenEmailSender
{
    Task SendAsync(EmailConfirmationToken emailConfirmationToken, CancellationToken cancellationToken);
}