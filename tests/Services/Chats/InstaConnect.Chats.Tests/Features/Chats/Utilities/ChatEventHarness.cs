using InstaConnect.Chats.Events.Features.Chats;
using InstaConnect.Common.Tests.Features.Abstractions;

namespace InstaConnect.Chats.Tests.Features.Chats.Utilities;

public static class ChatEventHarness
{
	extension(IEventHarness eventHarness)
	{
		public async Task<ChatAddedEventRequest> PublishedAddedEventRequestAsync(CancellationToken cancellationToken)
		{
			return await eventHarness.PublishedAsync<ChatAddedEventRequest>(cancellationToken);
		}
	}
}
