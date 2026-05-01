using InstaConnect.Chats.Presentation.Tests.Features.Chats.Abstractions;
using InstaConnect.Chats.Presentation.Tests.Features.Chats.Utilities;
using InstaConnect.Chats.Tests.Features.Common.Utilities;

namespace InstaConnect.Chats.Presentation.Tests.Features.Chats.Extensions;

public static class ChatsWebApplicationFactoryExtensions
{
	extension(ChatsWebApplicationFactory webApplicationFactory)
	{
		public IChatClient CreateChatClient()
		{
			return new ChatClient(webApplicationFactory.CreateClient(), webApplicationFactory.Services.GetBaseAccessTokenGenerator());
		}
	}
}
