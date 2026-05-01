using InstaConnect.Chats.Presentation.Tests.Features.Chats.Abstractions;
using InstaConnect.Chats.Presentation.Tests.Features.Chats.Extensions;

namespace InstaConnect.Chats.Presentation.Tests.Functional.Features.Chats.Utilities;

public abstract class BaseChatPresentationQueryFunctionalTest : BaseChatWebTest
{
	protected IChatClient Client { get; }

	protected BaseChatPresentationQueryFunctionalTest(ChatsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Client = webApplicationFactory.CreateChatClient();
	}
}
