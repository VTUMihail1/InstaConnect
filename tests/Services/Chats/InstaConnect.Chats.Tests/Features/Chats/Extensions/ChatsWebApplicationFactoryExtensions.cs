using InstaConnect.Chats.Tests.Features.Chats.Abstractions;
using InstaConnect.Chats.Tests.Features.Chats.Helpers;
using InstaConnect.Chats.Tests.Features.Common.Utilities;

namespace InstaConnect.Chats.Tests.Features.Chats.Extensions;

public static class ChatsWebApplicationFactoryExtensions
{
	extension(ChatsWebApplicationFactory webApplicationFactory)
	{
		public IChatEventClient CreateEventClient()
		{
			var eventHarness = webApplicationFactory.Services.GetEventHarness();

			return new ChatEventClient(eventHarness);
		}
	}
}
