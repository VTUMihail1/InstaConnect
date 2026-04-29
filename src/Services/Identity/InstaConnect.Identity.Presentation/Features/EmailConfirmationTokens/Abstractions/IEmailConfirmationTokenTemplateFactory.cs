namespace InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Abstractions;

public interface IEmailConfirmationTokenTemplateFactory
{
	public Task<string> GetAddedAsync(EmailConfirmationTokenAddedViewRequest request, CancellationToken cancellationToken);
}
