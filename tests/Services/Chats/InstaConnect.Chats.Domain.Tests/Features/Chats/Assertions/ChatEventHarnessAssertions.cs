using InstaConnect.Chats.Domain.Tests.Features.Chats.Utilities;
using InstaConnect.Chats.Events.Features.Chats;

namespace InstaConnect.Chats.Domain.Tests.Features.Chats.Assertions;

public static class ChatEventHarnessAssertions
{
	extension(IEventHarness eventHarness)
	{
		public async Task ShouldHavePublishedChatAddedAsync(
			AddChatCommand command,
			Chat chat,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<ChatAddedEventRequest>(
				p => p.Matches(command, chat),
				cancellationToken);
		}
	}
}
