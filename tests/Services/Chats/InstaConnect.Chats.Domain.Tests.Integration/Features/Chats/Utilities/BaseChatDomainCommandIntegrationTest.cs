using InstaConnect.Chats.Domain.Features.Chats.Abstractions;
using InstaConnect.Chats.Domain.Tests.Features.Chats.Utilities;
using InstaConnect.Chats.Tests.Features.Chats.Utilities;

namespace InstaConnect.Chats.Domain.Tests.Integration.Features.Chats.Utilities;

public abstract class BaseChatDomainCommandIntegrationTest : BaseChatWebTest
{
	protected IChatCommandService Service { get; }

	protected BaseChatDomainCommandIntegrationTest(ChatsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Service = ServiceScope.GetChatCommandService();
	}
}
