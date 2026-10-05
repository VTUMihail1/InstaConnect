using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.Chats.Domain.Features.ChatMessages.Models.ValueObjects;
using InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessages.Assertions;
using InstaConnect.Chats.Infrastructure.Tests.Integration.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Tests.Features.ChatMessages.Builders;
using InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.Id;
using InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Tests.Features.Chats.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.ChatMessages.Repositories;

public class GetChatMessageByIdCommandRepositoryIntegrationTests : BaseChatMessageInfrastructureCommandIntegrationTest
{
	private readonly ChatMessageIdBuilderFactory _idBuilderFactory;
	private readonly ChatMessageIdBuilder _idBuilder;
	private readonly ChatMessageId _id;

	private readonly ChatMessageInclude _include;

	public GetChatMessageByIdCommandRepositoryIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_idBuilderFactory = new();
		_idBuilder = _idBuilderFactory.Create(ChatMessage.Id);
		_id = _idBuilder.Build();

		_include = MessageIncludeBuilderFactory.Create().WithSender().WithChat().Build();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(ParticipantOne, CancellationToken);
		await ServiceScope.AddAsync(ParticipantTwo, CancellationToken);
		await ServiceScope.AddAsync(Chat, CancellationToken);
		await ServiceScope.AddAsync(ChatMessage, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnNull_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(ChatMessage, CancellationToken);

		// Act
		var response = await Repository.GetByIdAsync(_id, _include, CancellationToken);

		// Assert
		response.ShouldBeNull();
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Repository.GetByIdAsync(_id, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(_id, ChatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = _idBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, ChatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = _idBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, ChatMessage);
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenCommandAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = _idBuilder.WithMessageId(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, ChatMessage);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenInvertedCommandIsValid()
	{
		// Arrange
		var id = _idBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, ChatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenInvertedCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = _idBuilder.WithParticipantOneId(ParticipantTwo.Id, transformer).WithParticipantTwoId(ParticipantOne.Id).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, ChatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenInvertedCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = _idBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id, transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, ChatMessage);
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenInvertedCommandAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = _idBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id).WithMessageId(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, ChatMessage);
	}
}
