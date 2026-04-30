using InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Extensions;

namespace InstaConnect.Chats.Presentation.Tests.Functional.Features.ChatMessages.Utilities;

public abstract class BaseChatMessagePresentationCommandFunctionalTest : BaseChatMessageWebTest
{
	protected IChatMessageClient HttpClient { get; }

	protected BaseChatMessagePresentationCommandFunctionalTest(ChatsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		HttpClient = webApplicationFactory.CreateChatMessageClient();
	}
}
