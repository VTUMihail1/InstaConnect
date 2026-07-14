using InstaConnect.Chats.Events.Features.Chats;
using InstaConnect.Chats.Presentation.Tests.Features.Chats.Utilities;

namespace InstaConnect.Chats.Presentation.Tests.Features.Chats.Assertions;

public static class ChatEventHarnessAssertions
{
	extension(IEventHarness eventHarness)
	{
		public async Task ShouldHavePublishedChatAddedAsync(
			AddChatApiRequest request,
			Chat chat,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<ChatAddedEventRequest>(
				p => p.Matches(request, chat),
				cancellationToken);
		}
	}
}
