using InstaConnect.Chats.Infrastructure.Tests.Integration.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Tests.Features.ChatMessages.Assertions;
using InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Tests.Features.Chats.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.ChatMessages.Repositories;

public class UpdateChatMessageCommandRepositoryIntegrationTests : BaseChatMessageInfrastructureCommandIntegrationTest
{
	public UpdateChatMessageCommandRepositoryIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(ParticipantOne, CancellationToken);
		await ServiceScope.AddAsync(ParticipantTwo, CancellationToken);
		await ServiceScope.AddAsync(Chat, CancellationToken);
		await ServiceScope.AddAsync(ChatMessage, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldUpdateChatMessage_WhenCommandIsValid()
	{
		// Arrange
		var updatedChatMessage = ChatMessageBuilderFactory.Create(Chat).WithMessageId(ChatMessage.Id).Build();

		// Act
		await Repository.UpdateAsync(updatedChatMessage, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(ChatMessage.Id, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfy(updatedChatMessage);
	}
}
