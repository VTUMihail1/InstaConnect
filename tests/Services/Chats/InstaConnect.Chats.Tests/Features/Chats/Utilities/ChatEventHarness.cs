using InstaConnect.Chats.Events.Features.Chats;

namespace InstaConnect.Chats.Tests.Features.Chats.Utilities;

public static class ChatEventHarness
{
	extension(IEventHarness eventHarness)
	{
		public async Task<ChatAddedEventRequest> PublishedAddedEventRequest(CancellationToken cancellationToken)
		{
			return await eventHarness.PublishedAsync<ChatAddedEventRequest>(cancellationToken);
		}
	}
}
