using InstaConnect.Chats.Domain.Features.ChatMessages.Helpers;
using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Assertions;
using InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Builders;
using InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Domain.Tests.Unit.Features.ChatMessages.Utilities;

namespace InstaConnect.Chats.Domain.Tests.Unit.Features.ChatMessages.Services;

public class DeleteChatMessageServiceUnitTests : BaseChatMessageDomainCommandUnitTest
{
	private readonly DeleteChatMessageCommandBuilderFactory _commandBuilderFactory;
	private readonly DeleteChatMessageCommandBuilder _commandBuilder;
	private readonly DeleteChatMessageCommand _command;

	private readonly ChatInclude _include;
	private readonly ChatMessageInclude _messageInclude;

	private readonly ChatMessageCommandService _service;

	public DeleteChatMessageServiceUnitTests()
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(ChatMessage);
		_command = _commandBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithParticipantOne().WithParticipantTwo().Build();
		_messageInclude = MessageIncludeBuilderFactory.Create().WithSender().WithChat(_include).Build();

		_service = new(Mapper, Repository, DateTimeProvider, Factory, MessageRepository, IncludeBuilderFactory, NotificationService, MessageIncludeBuilderFactory);

		Repository.SetupExistsById(_command, CancellationToken);
		MessageRepository.SetupGetById(_command, _messageInclude, ChatMessage, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldThrowChatNotFoundException_WhenIdIsInvalid()
	{
		// Arrange
		Repository.RemoveExistsById(_command, CancellationToken);

		// Assert
		await _service.ShouldThrowChatNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldThrowChatMessageNotFoundException_WhenChatMessageDoesNotExist()
	{
		// Arrange
		MessageRepository.RemoveGetById(_command, _messageInclude, ChatMessage, CancellationToken);

		// Assert
		await _service.ShouldThrowChatMessageNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldThrowChatMessageForbiddenException_WhenParticipantOneIdIsInvalid()
	{
		// Arrange
		var command = _commandBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id).Build();
		Repository.SetupExistsById(command, CancellationToken);
		MessageRepository.SetupGetById(command, _messageInclude, ChatMessage, CancellationToken);

		// Assert
		await _service.ShouldThrowChatMessageForbiddenExceptionAsync(command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheRepositoryExistsByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.DeleteAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneExistsByIdAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheMessageRepositoryGetByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.DeleteAsync(_command, CancellationToken);

		// Assert
		await MessageRepository.ShouldReceiveOneGetByIdAsync(_command, _messageInclude, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheMessageRepositoryDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _service.DeleteAsync(_command, CancellationToken);

		// Assert
		await MessageRepository.ShouldReceiveOneDeleteAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheNotificationServiceDeletedAsync_WhenCommandIsValid()
	{
		// Act
		await _service.DeleteAsync(_command, CancellationToken);

		// Assert
		await NotificationService.ShouldReceiveOneDeletedAsync(_command, ChatMessage, CancellationToken);
	}
}
