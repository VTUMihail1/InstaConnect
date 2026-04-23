using InstaConnect.Chats.Tests.Features.Common.Utilities;

namespace InstaConnect.Chats.Presentation.Tests.Functional.Features.ChatMessages.Utilities;

public abstract class BaseChatMessagePresentationQueryFunctionalTest : BaseChatMessageWebTest
{
    protected HttpClient HttpClient { get; }

    protected BaseChatMessagePresentationQueryFunctionalTest(ChatsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        HttpClient = webApplicationFactory.CreateClient();
    }
}
