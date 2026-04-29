using InstaConnect.Chats.Events.Features.Chats;
using InstaConnect.Chats.Tests.Features.Chats.Utilities;

namespace InstaConnect.Chats.Tests.Features.Chats.Assertions;

public static class ChatEventHarnessAssertions
{
	extension(IEventHarness eventHarness)
	{
		public async Task ShouldHavePublishedChatAddedAsync(
			Chat chat,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<ChatAddedEventRequest>(
				p => p.Matches(chat),
				cancellationToken);
		}
	}
}
