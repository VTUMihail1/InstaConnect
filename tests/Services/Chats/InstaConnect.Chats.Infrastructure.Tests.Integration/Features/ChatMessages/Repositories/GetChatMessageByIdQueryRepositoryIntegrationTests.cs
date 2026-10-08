using InstaConnect.Chats.Domain.Features.ChatMessages.Models.ValueObjects;
using InstaConnect.Chats.Domain.Features.Users.Models.Requests;
using InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessages.Assertions;
using InstaConnect.Chats.Infrastructure.Tests.Features.Common.Builders;
using InstaConnect.Chats.Infrastructure.Tests.Integration.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Tests.Features.ChatMessages.Builders;
using InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.Id;
using InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Tests.Features.Chats.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.ChatMessages.Repositories;

public class GetChatMessageByIdQueryRepositoryIntegrationTests : BaseChatMessageInfrastructureQueryIntegrationTest
{
	private readonly ChatMessageIdBuilderFactory _idBuilderFactory;
	private readonly ChatMessageIdBuilder _idBuilder;
	private readonly ChatMessageId _id;

	private readonly CurrentUserQueryBuilderFactory _currentUserQueryBuilderFactory;
	private readonly CurrentUserQueryBuilder _currentUserQueryBuilder;
	private readonly CurrentUserQuery _currentUserQuery;

	public GetChatMessageByIdQueryRepositoryIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_idBuilderFactory = new();
		_idBuilder = _idBuilderFactory.Create(ChatMessage.Id);
		_id = _idBuilder.Build();

		_currentUserQueryBuilderFactory = new();
		_currentUserQueryBuilder = _currentUserQueryBuilderFactory.Create(ParticipantOne);
		_currentUserQuery = _currentUserQueryBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(ChatMessage, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnNull_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(ChatMessage, CancellationToken);

		// Act
		var response = await Repository.GetByIdAsync(_id, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldBeNull();
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Repository.GetByIdAsync(_id, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_id, _currentUserQuery, ChatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = _idBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, _currentUserQuery, ChatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = _idBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, _currentUserQuery, ChatMessage);
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = _idBuilder.WithMessageId(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, _currentUserQuery, ChatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var currentUserQuery = _currentUserQueryBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(_id, currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_id, currentUserQuery, ChatMessage);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnInvertedResponse_WhenQueryIsValid()
	{
		// Arrange
		var id = _idBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id).Build();
		var currentUserQuery = _currentUserQueryBuilder.WithCurrentUserId(ParticipantTwo.Id).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(id, currentUserQuery, ChatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnInvertedResponse_WhenQueryAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = _idBuilder.WithParticipantOneId(ParticipantTwo.Id, transformer).WithParticipantTwoId(ParticipantOne.Id).Build();
		var currentUserQuery = _currentUserQueryBuilder.WithCurrentUserId(ParticipantTwo.Id).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(id, currentUserQuery, ChatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnInvertedResponse_WhenQueryAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = _idBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id, transformer).Build();
		var currentUserQuery = _currentUserQueryBuilder.WithCurrentUserId(ParticipantTwo.Id).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(id, currentUserQuery, ChatMessage);
	}

	[Theory]
	[ChatMessageIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnInvertedResponse_WhenQueryAndMessageIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = _idBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id).WithMessageId(transformer).Build();
		var currentUserQuery = _currentUserQueryBuilder.WithCurrentUserId(ParticipantTwo.Id).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(id, currentUserQuery, ChatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnInvertedResponse_WhenQueryAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = _idBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id).Build();
		var currentUserQuery = _currentUserQueryBuilder.WithCurrentUserId(ParticipantTwo.Id, transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfyInverted(id, currentUserQuery, ChatMessage);
	}
}
