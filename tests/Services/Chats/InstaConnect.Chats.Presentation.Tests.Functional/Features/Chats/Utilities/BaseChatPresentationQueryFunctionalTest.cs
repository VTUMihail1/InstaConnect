namespace InstaConnect.Chats.Presentation.Tests.Functional.Features.Chats.Utilities;

public abstract class BaseChatPresentationQueryFunctionalTest : BaseChatWebTest
{
	protected HttpClient HttpClient { get; }

	protected BaseChatPresentationQueryFunctionalTest(ChatsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		HttpClient = webApplicationFactory.CreateClient();
	}
}
