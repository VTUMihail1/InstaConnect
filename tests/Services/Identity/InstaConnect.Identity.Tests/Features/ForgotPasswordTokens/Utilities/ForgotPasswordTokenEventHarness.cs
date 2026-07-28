using InstaConnect.Common.Tests.Features.Abstractions;
using InstaConnect.Identity.Events.Features.ForgotPasswordTokens;

namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenEventHarness
{
	extension(IEventHarness eventHarness)
	{
		public async Task<ICollection<ForgotPasswordTokenAddedEventRequest>> PublishedForgotPasswordTokenAddedEventRequestRange(CancellationToken cancellationToken)
		{
			return await eventHarness.PublishedRangeAsync<ForgotPasswordTokenAddedEventRequest>(cancellationToken);
		}

		public async Task<ICollection<ForgotPasswordTokenDeletedEventRequest>> PublishedForgotPasswordTokenDeletedEventRequestRange(CancellationToken cancellationToken)
		{
			return await eventHarness.PublishedRangeAsync<ForgotPasswordTokenDeletedEventRequest>(cancellationToken);
		}
	}
}
