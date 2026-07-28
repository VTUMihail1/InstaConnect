using InstaConnect.Chats.Domain.Features.ChatMessages.Helpers;
using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Assertions;
using InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Builders;
using InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Domain.Tests.Unit.Features.ChatMessages.Utilities;

namespace InstaConnect.Chats.Domain.Tests.Unit.Features.ChatMessages.Services;

public class GetChatMessageByIdQueryServiceUnitTests : BaseChatMessageDomainQueryUnitTest
{
	private readonly GetChatMessageByIdQueryBuilderFactory _queryBuilderFactory;
	private readonly GetChatMessageByIdQueryBuilder _queryBuilder;
	private readonly GetChatMessageByIdQuery _query;

	private readonly ChatMessageQueryService _service;

	public GetChatMessageByIdQueryServiceUnitTests()
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(ChatMessage);
		_query = _queryBuilder.Build();

		_service = new(Repository, MessageRepository, CollectionResponseFactory);

		Repository.SetupExistsById(_query, CancellationToken);
		MessageRepository.SetupGetById(_query, ChatMessage, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldThrowChatNotFoundException_WhenIdIsInvalid()
	{
		// Arrange
		Repository.RemoveExistsById(_query, CancellationToken);

		// Assert
		await _service.ShouldThrowChatNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldThrowChatMessageNotFoundException_WhenChatMessageDoesNotExist()
	{
		// Arrange
		MessageRepository.RemoveGetById(_query, ChatMessage, CancellationToken);

		// Assert
		await _service.ShouldThrowChatMessageNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await _service.GetByIdAsync(_query, CancellationToken);

		// Assert
		response.ShouldSatisfy(_query, ChatMessage);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheRepositoryExistsByIdAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetByIdAsync(_query, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneExistsByIdAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheMessageRepositoryGetByIdAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetByIdAsync(_query, CancellationToken);

		// Assert
		await MessageRepository.ShouldReceiveOneGetByIdAsync(_query, CancellationToken);
	}
}
