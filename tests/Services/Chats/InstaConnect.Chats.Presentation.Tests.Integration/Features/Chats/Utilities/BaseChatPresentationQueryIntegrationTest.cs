namespace InstaConnect.Chats.Presentation.Tests.Integration.Features.Chats.Utilities;

public abstract class BaseChatPresentationQueryIntegrationTest : BaseChatWebTest
{
	protected ChatController Controller { get; }

	protected BaseChatPresentationQueryIntegrationTest(ChatsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Controller = ServiceScope.GetChatController();
	}
}
