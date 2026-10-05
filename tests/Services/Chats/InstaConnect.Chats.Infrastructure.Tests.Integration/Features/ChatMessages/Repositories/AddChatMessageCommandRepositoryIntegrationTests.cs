using InstaConnect.Chats.Infrastructure.Tests.Integration.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Tests.Features.ChatMessages.Assertions;
using InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Tests.Features.Chats.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.ChatMessages.Repositories;

public class AddChatMessageCommandRepositoryIntegrationTests : BaseChatMessageInfrastructureCommandIntegrationTest
{
	public AddChatMessageCommandRepositoryIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(ParticipantOne, CancellationToken);
		await ServiceScope.AddAsync(ParticipantTwo, CancellationToken);
		await ServiceScope.AddAsync(Chat, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldAddChatMessage_WhenCommandIsValid()
	{
		// Act
		await Repository.AddAsync(ChatMessage, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(ChatMessage.Id, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfy(ChatMessage);
	}
}
