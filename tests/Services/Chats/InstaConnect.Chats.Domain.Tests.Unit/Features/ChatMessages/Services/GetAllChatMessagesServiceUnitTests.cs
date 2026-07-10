using InstaConnect.Chats.Domain.Features.ChatMessages.Helpers;
using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Assertions;
using InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Builders;
using InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Domain.Tests.Unit.Features.ChatMessages.Utilities;

namespace InstaConnect.Chats.Domain.Tests.Unit.Features.ChatMessages.Services;

public class GetAllChatMessagesServiceUnitTests : BaseChatMessageDomainQueryUnitTest
{
	private readonly GetAllChatMessagesQueryBuilderFactory _queryBuilderFactory;
	private readonly GetAllChatMessagesQueryBuilder _queryBuilder;
	private readonly GetAllChatMessagesQuery _query;

	private readonly ChatMessageQueryService _service;

	public GetAllChatMessagesServiceUnitTests()
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(ChatMessage);
		_query = _queryBuilder.Build();

		_service = new(Repository, MessageRepository, CollectionResponseFactory);

		Repository.SetupGetById(_query, Chat, CancellationToken);
		MessageRepository.SetupGetAllQuery(_query, ChatMessages, CancellationToken);
		MessageRepository.SetupGetTotalCount(_query, ChatMessages, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldThrowChatNotFoundException_WhenIdIsInvalid()
	{
		// Arrange
		Repository.RemoveGetById(_query, Chat, CancellationToken);

		// Assert
		await _service.ShouldThrowChatNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await _service.GetAllAsync(_query, CancellationToken);

		// Assert
		response.ShouldSatisfy(Chat, ChatMessages, _query);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheRepositoryGetByIdAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllAsync(_query, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneGetByIdAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheMessageRepositoryGetAllAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllAsync(_query, CancellationToken);

		// Assert
		await MessageRepository.ShouldReceiveOneGetAllAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheMessageRepositoryGetTotalCountAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllAsync(_query, CancellationToken);

		// Assert
		await MessageRepository.ShouldReceiveOneGetTotalCountAsync(_query, CancellationToken);
	}
}
