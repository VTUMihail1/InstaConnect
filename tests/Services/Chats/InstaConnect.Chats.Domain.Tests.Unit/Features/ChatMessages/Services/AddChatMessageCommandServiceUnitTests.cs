using InstaConnect.Chats.Domain.Features.ChatMessages.Helpers;
using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Assertions;
using InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Builders;
using InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Domain.Tests.Unit.Features.ChatMessages.Utilities;

namespace InstaConnect.Chats.Domain.Tests.Unit.Features.ChatMessages.Services;

public class AddChatMessageCommandServiceUnitTests : BaseChatMessageDomainCommandUnitTest
{
	private readonly AddChatMessageCommandBuilderFactory _commandBuilderFactory;
	private readonly AddChatMessageCommandBuilder _commandBuilder;
	private readonly AddChatMessageCommand _command;

	private readonly ChatInclude _include;

	private readonly ChatMessageCommandService _service;

	public AddChatMessageCommandServiceUnitTests()
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(Chat);
		_command = _commandBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithParticipantOne().WithParticipantTwo().Build();

		_service = new(Mapper, Repository, DateTimeProvider, Factory, MessageRepository, IncludeBuilderFactory, NotificationService, MessageIncludeBuilderFactory);

		Repository.SetupGetById(_command, _include, Chat, CancellationToken);
		Factory.SetupCreate(_command, ChatMessage);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowChatNotFoundException_WhenIdIsInvalid()
	{
		// Arrange
		Repository.RemoveGetById(_command, _include, Chat, CancellationToken);

		// Assert
		await _service.ShouldThrowChatNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _service.AddAsync(_command, CancellationToken);

		// Assert
		response.ShouldSatisfy(_command, ChatMessage);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheRepositoryGetByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneGetByIdAsync(_command, _include, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheFactoryCreate_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		Factory.ShouldReceiveOneCreate(_command);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheMessageRepositoryAddAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await MessageRepository.ShouldReceiveOneAddAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheNotificationServiceAddedAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await NotificationService.ShouldReceiveOneAddedAsync(_command, ChatMessage, CancellationToken);
	}
}
