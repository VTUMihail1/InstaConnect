using InstaConnect.Chats.Application.Tests.Features.Chats.Utilities;
using InstaConnect.Chats.Events.Features.Chats;

namespace InstaConnect.Chats.Application.Tests.Features.Chats.Assertions;

public static class ChatEventHarnessAssertions
{
	extension(IEventHarness eventHarness)
	{
		public async Task ShouldHavePublishedChatAddedAsync(
			AddChatCommandRequest request,
			Chat chat,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<ChatAddedEventRequest>(
				p => p.Matches(request, chat),
				cancellationToken);
		}
	}
}
