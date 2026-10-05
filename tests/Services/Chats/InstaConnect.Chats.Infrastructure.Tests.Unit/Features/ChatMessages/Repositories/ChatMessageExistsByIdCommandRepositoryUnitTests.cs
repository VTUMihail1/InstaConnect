using InstaConnect.Chats.Domain.Features.ChatMessages.Models.ValueObjects;
using InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.Repositories;
using InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessages.Assertions;
using InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Infrastructure.Tests.Unit.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Tests.Features.ChatMessages.Builders;

namespace InstaConnect.Chats.Infrastructure.Tests.Unit.Features.ChatMessages.Repositories;

public class ChatMessageExistsByIdCommandRepositoryUnitTests : BaseChatMessageInfrastructureCommandUnitTest
{
	private readonly ChatMessageIdBuilderFactory _idBuilderFactory;
	private readonly ChatMessageIdBuilder _idBuilder;
	private readonly ChatMessageId _id;

	private readonly ChatMessageCommandRepository _repository;

	public ChatMessageExistsByIdCommandRepositoryUnitTests()
	{
		_idBuilderFactory = new();
		_idBuilder = _idBuilderFactory.Create(ChatMessage.Id);
		_id = _idBuilder.Build();

		_repository = new(Collection, MessageIncludeBuilderFactory);

		Collection.SetupAggregateFluent(_id, Fluent);
		Fluent.SetupMatch(_id);
		Fluent.SetupAnyAsync(_id, ChatMessage, CancellationToken);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _repository.ExistsByIdAsync(_id, CancellationToken);

		// Assert
		response.ShouldSatisfy(_id, ChatMessage);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenRequestIsValid()
	{
		// Act
		await _repository.ExistsByIdAsync(_id, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(_id);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldCallTheFluentMatch_WhenRequestIsValid()
	{
		// Act
		await _repository.ExistsByIdAsync(_id, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(_id);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldCallTheFluentAnyAsync_WhenRequestIsValid()
	{
		// Act
		await _repository.ExistsByIdAsync(_id, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneAnyAsync(_id, CancellationToken);
	}
}
