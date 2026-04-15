namespace InstaConnect.Chats.Application.Tests.Integration.Features.ChatMessages.Utilities;

public abstract class BaseChatMessageApplicationCommandIntegrationTest : BaseChatMessageWebTest
{
    protected IApplicationSender Sender { get; }

    protected BaseChatMessageApplicationCommandIntegrationTest(ChatsWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        Sender = ServiceScope.GetSender();
    }
}
