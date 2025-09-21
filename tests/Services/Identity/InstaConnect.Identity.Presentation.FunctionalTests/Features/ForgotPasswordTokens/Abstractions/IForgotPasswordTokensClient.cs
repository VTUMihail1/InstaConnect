namespace InstaConnect.Identity.Presentation.FunctionalTests.Features.ForgotPasswordTokens.Abstractions;
public interface IForgotPasswordTokensClient
{
    Task AddAsync(AddForgotPasswordTokenApiRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> AddStatusCodeAsync(AddForgotPasswordTokenApiRequest request, CancellationToken cancellationToken);
    Task VerifyAsync(VerifyForgotPasswordTokenApiRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> VerifyStatusCodeAsync(VerifyForgotPasswordTokenApiRequest request, CancellationToken cancellationToken);
}
