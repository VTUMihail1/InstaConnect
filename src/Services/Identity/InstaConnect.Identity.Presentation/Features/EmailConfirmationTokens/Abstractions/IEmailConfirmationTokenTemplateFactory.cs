namespace InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Abstractions;

public interface IEmailConfirmationTokenTemplateFactory
{
    Task<string> GetAddedAsync(EmailConfirmationTokenAddedViewRequest request, CancellationToken cancellationToken);
}
