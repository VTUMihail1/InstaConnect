using InstaConnect.Chats.Infrastructure.Tests.Integration.Features.Chats.Utilities;
using InstaConnect.Chats.Tests.Features.Chats.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.Chats.Repositories;

public class DeleteChatCommandRepositoryIntegrationTests : BaseChatInfrastructureCommandIntegrationTest
{
	public DeleteChatCommandRepositoryIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await base.InitializeAsync();
		await ServiceScope.AddAsync(Chat, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteChat_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(Chat, CancellationToken);
		var chat = await ServiceScope.GetByIdAsync(Chat.Id, CancellationToken);

		// Assert
		chat.ShouldBeNull();
	}
}
