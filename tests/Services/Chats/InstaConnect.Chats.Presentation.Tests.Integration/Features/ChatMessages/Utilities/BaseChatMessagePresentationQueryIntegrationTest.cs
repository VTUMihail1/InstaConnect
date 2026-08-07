namespace InstaConnect.Chats.Presentation.Tests.Integration.Features.ChatMessages.Utilities;

public abstract class BaseChatMessagePresentationQueryIntegrationTest : BaseChatMessageWebTest
{
	protected ChatMessageController Controller { get; }

	protected BaseChatMessagePresentationQueryIntegrationTest(ChatsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Controller = ServiceScope.GetChatMessageController();
	}
}
