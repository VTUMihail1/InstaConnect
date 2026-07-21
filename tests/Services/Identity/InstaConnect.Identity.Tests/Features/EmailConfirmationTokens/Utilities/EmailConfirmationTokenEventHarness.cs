using InstaConnect.Identity.Events.Features.EmailConfirmationTokens;

namespace InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenEventHarness
{
	extension(IEventHarness eventHarness)
	{
		public async Task<EmailConfirmationTokenAddedEventRequest> PublishedEmailConfirmationTokenAddedEventRequest(CancellationToken cancellationToken)
		{
			return await eventHarness.PublishedAsync<EmailConfirmationTokenAddedEventRequest>(cancellationToken);
		}

		public async Task<ICollection<EmailConfirmationTokenAddedEventRequest>> PublishedEmailConfirmationTokenAddedEventRequestRange(CancellationToken cancellationToken)
		{
			return await eventHarness.PublishedRangeAsync<EmailConfirmationTokenAddedEventRequest>(cancellationToken);
		}

		public async Task<ICollection<EmailConfirmationTokenDeletedEventRequest>> PublishedEmailConfirmationTokenDeletedEventRequestRange(CancellationToken cancellationToken)
		{
			return await eventHarness.PublishedRangeAsync<EmailConfirmationTokenDeletedEventRequest>(cancellationToken);
		}
	}
}
