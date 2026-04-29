using InstaConnect.Common.Domain.Features.Emails.Models;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;

public interface IEmailConfirmationTokenSendEmailRequestFactory
{
	public Task<SendEmailRequest> GetAsync(EmailConfirmationToken emailConfirmationToken, CancellationToken cancellationToken);
}
