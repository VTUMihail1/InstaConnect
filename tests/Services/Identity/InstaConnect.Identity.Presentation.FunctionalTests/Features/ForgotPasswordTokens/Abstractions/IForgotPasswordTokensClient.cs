using System.Net;
using InstaConnect.Identity.Presentation.Features.Users.Models.Requests;

namespace InstaConnect.Identity.Presentation.FunctionalTests.Features.ForgotPasswordTokens.Abstractions;
public interface IForgotPasswordTokensClient
{
    Task AddAsync(AddForgotPasswordTokenRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> AddStatusCodeAsync(AddForgotPasswordTokenRequest request, CancellationToken cancellationToken);
    Task VerifyAsync(VerifyForgotPasswordTokenRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> VerifyStatusCodeAsync(VerifyForgotPasswordTokenRequest request, CancellationToken cancellationToken);
}
