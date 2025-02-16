using System.Net;

using InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Models.Requests;

namespace InstaConnect.Identity.Presentation.FunctionalTests.Features.EmailConfirmationTokens.Abstractions;
public interface IEmailConfirmationTokensClient
{
    Task AddAsync(AddEmailConfirmationTokenRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> AddStatusCodeAsync(AddEmailConfirmationTokenRequest request, CancellationToken cancellationToken);
    Task VerifyAsync(VerifyEmailConfirmationTokenRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> VerifyStatusCodeAsync(VerifyEmailConfirmationTokenRequest request, CancellationToken cancellationToken);
}