namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;

public interface IEmailConfirmationTokenEmailSender
{
	public Task SendAsync(EmailConfirmationToken emailConfirmationToken, CancellationToken cancellationToken);
}
