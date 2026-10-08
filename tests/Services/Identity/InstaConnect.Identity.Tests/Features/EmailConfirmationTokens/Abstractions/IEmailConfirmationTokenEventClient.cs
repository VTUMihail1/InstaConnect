using InstaConnect.Identity.Events.Features.EmailConfirmationTokens;

namespace InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Abstractions;

public interface IEmailConfirmationTokenEventClient
{
	public Task StartAsync(CancellationToken cancellationToken);

	public Task StopAsync(CancellationToken cancellationToken);

	public Task<EmailConfirmationTokenAddedEventRequest> PublishedAddedAsync(CancellationToken cancellationToken);

	public Task<ICollection<EmailConfirmationTokenAddedEventRequest>> PublishedAddedRangeAsync(CancellationToken cancellationToken);

	public Task<ICollection<EmailConfirmationTokenDeletedEventRequest>> PublishedDeletedRangeAsync(CancellationToken cancellationToken);
}
