using InstaConnect.Chats.Domain.Features.ChatMessages.Models.ValueObjects;
using InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessages.Assertions;
using InstaConnect.Chats.Infrastructure.Tests.Integration.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Tests.Features.ChatMessages.Builders;
using InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.Id;
using InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Tests.Features.Chats.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.ChatMessages.Repositories;

public class ChatMessageExistsByIdQueryRepositoryIntegrationTests : BaseChatMessageInfrastructureQueryIntegrationTest
{
	private readonly ChatMessageIdBuilderFactory _idBuilderFactory;
	private readonly ChatMessageIdBuilder _idBuilder;
	private readonly ChatMessageId _id;

	public ChatMessageExistsByIdQueryRepositoryIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_idBuilderFactory = new();
		_idBuilder = _idBuilderFactory.Create(ChatMessage.Id);
		_id = _idBuilder.Build();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(ParticipantOne, CancellationToken);
		await ServiceScope.AddAsync(ParticipantTwo, CancellationToken);
		await ServiceScope.AddAsync(Chat, CancellationToken);
		await ServiceScope.AddAsync(ChatMessage, CancellationToken);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldReturnNull_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(ChatMessage, CancellationToken);

		// Act
		var response = await Repository.ExistsByIdAsync(_id, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(_id, CancellationToken);

		// Assert
		response.ShouldSatisfy(_id, chatMessage);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Repository.ExistsByIdAsync(_id, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(_id, CancellationToken);

		// Assert
		response.ShouldSatisfy(_id, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenQueryAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = _idBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Repository.ExistsByIdAsync(id, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(_id, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenQueryAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = _idBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Repository.ExistsByIdAsync(id, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(_id, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, chatMessage);
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenQueryAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = _idBuilder.WithMessageId(transformer).Build();

		// Act
		var response = await Repository.ExistsByIdAsync(id, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(_id, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, chatMessage);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenInvertedQueryIsValid()
	{
		// Arrange
		var id = _idBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id).Build();

		// Act
		var response = await Repository.ExistsByIdAsync(id, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(_id, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenInvertedQueryAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = _idBuilder.WithParticipantOneId(ParticipantTwo.Id, transformer).WithParticipantTwoId(ParticipantOne.Id).Build();

		// Act
		var response = await Repository.ExistsByIdAsync(id, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(_id, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenInvertedQueryAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = _idBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id, transformer).Build();

		// Act
		var response = await Repository.ExistsByIdAsync(id, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(_id, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, chatMessage);
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenInvertedQueryAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = _idBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id).WithMessageId(transformer).Build();

		// Act
		var response = await Repository.ExistsByIdAsync(id, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(_id, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, chatMessage);
	}
}
