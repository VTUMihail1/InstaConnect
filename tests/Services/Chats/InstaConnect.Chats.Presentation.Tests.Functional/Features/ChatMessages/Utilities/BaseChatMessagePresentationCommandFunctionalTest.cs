using InstaConnect.Chats.Tests.Features.Common.Utilities;

namespace InstaConnect.Chats.Presentation.Tests.Functional.Features.ChatMessages.Utilities;

public abstract class BaseChatMessagePresentationCommandFunctionalTest : BaseChatMessageWebTest
{
    protected HttpClient HttpClient { get; }

    protected BaseChatMessagePresentationCommandFunctionalTest(ChatsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        HttpClient = webApplicationFactory.CreateClient();
    }
}
