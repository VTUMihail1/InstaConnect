using InstaConnect.Chats.Tests.Features.Common.Utilities;

namespace InstaConnect.Chats.Presentation.Tests.Functional.Features.Chats.Utilities;

public abstract class BaseChatPresentationCommandFunctionalTest : BaseChatWebTest
{
    protected HttpClient HttpClient { get; }

    protected BaseChatPresentationCommandFunctionalTest(ChatsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        HttpClient = webApplicationFactory.CreateClient();
    }
}

