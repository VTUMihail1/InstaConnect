using InstaConnect.Chats.Infrastructure.Tests.Integration.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Tests.Features.Chats.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.ChatMessages.Repositories;

public class DeleteChatMessageCommandRepositoryIntegrationTests : BaseChatMessageInfrastructureCommandIntegrationTest
{
	public DeleteChatMessageCommandRepositoryIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
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
	public async Task DeleteAsync_ShouldDeleteChatMessage_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(ChatMessage, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(ChatMessage.Id, CancellationToken);

		// Assert
		chatMessage.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteChatMessage_WhenInvertedCommandIsValid()
	{
		// Arrange
		var invertedChatMessage = ChatMessageBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id).Build();

		// Act
		await Repository.DeleteAsync(invertedChatMessage, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(ChatMessage.Id, CancellationToken);

		// Assert
		chatMessage.ShouldBeNull();
	}
}
