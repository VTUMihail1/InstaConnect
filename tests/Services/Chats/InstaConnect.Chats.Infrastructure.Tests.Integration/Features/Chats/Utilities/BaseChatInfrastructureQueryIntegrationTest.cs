using InstaConnect.Chats.Domain.Features.Chats.Abstractions;
using InstaConnect.Chats.Tests.Features.Chats.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.Chats.Utilities;

public abstract class BaseChatInfrastructureQueryIntegrationTest : BaseChatWebTest
{
	protected IChatQueryRepository Repository { get; }

	protected BaseChatInfrastructureQueryIntegrationTest(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetQueryRepository();
	}
}
