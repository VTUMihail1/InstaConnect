using InstaConnect.Chats.Domain.Features.Chats.Abstractions;
using InstaConnect.Chats.Tests.Features.Chats.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.Chats.Utilities;

public abstract class BaseChatInfrastructureCommandIntegrationTest : BaseChatWebTest
{
	protected IChatCommandRepository Repository { get; }

	protected IChatIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BaseChatInfrastructureCommandIntegrationTest(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetCommandRepository();
		IncludeBuilderFactory = ServiceScope.GetIncludeBuilderFactory();
	}

	public override async Task InitializeAsync()
	{
		await base.InitializeAsync();
		await ServiceScope.AddAsync(ParticipantOne, CancellationToken);
		await ServiceScope.AddAsync(ParticipantTwo, CancellationToken);
	}
}
