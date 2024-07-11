using FluentAssertions;
using InstaConnect.Messages.Write.Business.Commands.Messages.DeleteMessage;
using InstaConnect.Messages.Write.Business.UnitTests.Utilities;
using InstaConnect.Messages.Write.Data.Models.Entities;
using InstaConnect.Shared.Business.Contracts.Messages;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.Message;
using NSubstitute;

namespace InstaConnect.Messages.Write.Business.UnitTests.Commands.DeleteMessage;

public class DeleteMessageCommandHandlerUnitTests : BaseMessageUnitTest
{
    private readonly DeleteMessageCommandHandler _commandHandler;

    public DeleteMessageCommandHandlerUnitTests()
    {
        _commandHandler = new(
            UnitOfWork,
            EventPublisher,
            MessageRepository,
            InstaConnectMapper);
    }

    [Fact]
    public async Task Handle_ShouldThrowMessageNotFoundException_WhenMessageIdIsInvalid()
    {
        // Arrange
        var command = new DeleteMessageCommand()
        {
            Id = MessageUnitTestConfigurations.NON_EXISTING_MESSAGE_ID,
            CurrentUserId = MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID
        };

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<MessageNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowAccountForbiddenException_WhenSenderIdIsInvalid()
    {
        // Arrange
        var command = new DeleteMessageCommand()
        {
            Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
            CurrentUserId = MessageUnitTestConfigurations.EXISTING_SENDER_ID
        };

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AccountForbiddenException>();
    }

    [Fact]
    public async Task Handle_ShouldGetMessageByIdFromRepository_WhenMessageIdIsValid()
    {
        // Arrange
        var command = new DeleteMessageCommand()
        {
            Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
            CurrentUserId = MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID
        };

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await MessageRepository
            .Received(1)
            .GetByIdAsync(MessageUnitTestConfigurations.EXISTING_MESSAGE_ID, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldDeleteMessageFromRepository_WhenMessageIdIsValid()
    {
        // Arrange
        var command = new DeleteMessageCommand()
        {
            Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
            CurrentUserId = MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID
        };

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        MessageRepository
            .Received(1)
            .Delete(Arg.Is<Message>(m => m.Id == MessageUnitTestConfigurations.EXISTING_MESSAGE_ID &&
                                         m.SenderId == MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID &&
                                         m.ReceiverId == MessageUnitTestConfigurations.EXISTING_MESSAGE_RECEIVER_ID &&
                                         m.Content == MessageUnitTestConfigurations.EXISTING_MESSAGE_CONTENT));
    }

    [Fact]
    public async Task Handle_ShouldSendMessageDeletedEvent_WhenMessageIdIsValid()
    {
        // Arrange
        var command = new DeleteMessageCommand()
        {
            Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
            CurrentUserId = MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID
        };

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await EventPublisher
            .Received(1)
            .Publish(Arg.Is<MessageDeletedEvent>(m => m.Id == MessageUnitTestConfigurations.EXISTING_MESSAGE_ID),
                     CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenMessageIdIsValid()
    {
        // Arrange
        var command = new DeleteMessageCommand()
        {
            Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
            CurrentUserId = MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID
        };

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
