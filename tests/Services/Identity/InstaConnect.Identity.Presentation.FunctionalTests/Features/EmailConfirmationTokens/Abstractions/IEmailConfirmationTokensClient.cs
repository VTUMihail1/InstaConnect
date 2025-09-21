namespace InstaConnect.Identity.Presentation.FunctionalTests.Features.EmailConfirmationTokens.Abstractions;
public interface IEmailConfirmationTokensClient
{
    Task AddAsync(AddEmailConfirmationTokenApiRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> AddStatusCodeAsync(AddEmailConfirmationTokenApiRequest request, CancellationToken cancellationToken);
    Task VerifyAsync(VerifyEmailConfirmationTokenApiRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> VerifyStatusCodeAsync(VerifyEmailConfirmationTokenApiRequest request, CancellationToken cancellationToken);
}