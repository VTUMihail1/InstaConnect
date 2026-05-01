using System.Net;

using InstaConnect.Common.Presentation.Features.ExceptionHandling.Models;

namespace InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Abstractions;

public interface IEmailConfirmationTokenClient
{
	public Task AddAsync(AddEmailConfirmationTokenApiRequest request, CancellationToken cancellationToken);
	public Task<ApplicationProblemDetails> AddProblemDetailsAsync(AddEmailConfirmationTokenApiRequest request, CancellationToken cancellationToken);
	public Task<HttpStatusCode> AddStatusCodeAsync(AddEmailConfirmationTokenApiRequest request, CancellationToken cancellationToken);

	public Task VerifyAsync(VerifyEmailConfirmationTokenApiRequest request, CancellationToken cancellationToken);
	public Task<ApplicationProblemDetails> VerifyProblemDetailsAsync(VerifyEmailConfirmationTokenApiRequest request, CancellationToken cancellationToken);
	public Task<HttpStatusCode> VerifyStatusCodeAsync(VerifyEmailConfirmationTokenApiRequest request, CancellationToken cancellationToken);
}
