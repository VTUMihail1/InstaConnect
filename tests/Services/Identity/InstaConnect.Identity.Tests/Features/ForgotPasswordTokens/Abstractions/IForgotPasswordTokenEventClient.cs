using InstaConnect.Identity.Events.Features.ForgotPasswordTokens;

namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Abstractions;

public interface IForgotPasswordTokenEventClient
{
	public Task StartAsync(CancellationToken cancellationToken);

	public Task StopAsync(CancellationToken cancellationToken);

	public Task<ICollection<ForgotPasswordTokenAddedEventRequest>> PublishedAddedRangeAsync(CancellationToken cancellationToken);

	public Task<ICollection<ForgotPasswordTokenDeletedEventRequest>> PublishedDeletedRangeAsync(CancellationToken cancellationToken);
}
