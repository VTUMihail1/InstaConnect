using FluentAssertions;
using InstaConnect.Messages.Write.Business.Commands.Messages.UpdateMessage;
using InstaConnect.Messages.Write.Business.Models;
using InstaConnect.Messages.Write.Business.UnitTests.Utilities;
using InstaConnect.Messages.Write.Data.Models.Entities;
using InstaConnect.Shared.Business.Contracts.Messages;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.Message;
using NSubstitute;

namespace InstaConnect.Messages.Write.Business.UnitTests.Commands.UpdateMessage;

public class UpdateMessageCommandHandlerUnitTests : BaseMessageUnitTest
{
    private readonly UpdateMessageCommandHandler _commandHandler;

    public UpdateMessageCommandHandlerUnitTests()
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
        var command = new UpdateMessageCommand()
        {
            Id = MessageUnitTestConfigurations.NON_EXISTING_MESSAGE_ID,
            CurrentUserId = MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID,
            Content = ValidContent
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
        var command = new UpdateMessageCommand()
        {
            Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
            CurrentUserId = MessageUnitTestConfigurations.EXISTING_SENDER_ID,
            Content = ValidContent
        };

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AccountForbiddenException>();
    }

    [Fact]
    public async Task Handle_ShouldReturnMessageViewModel_WhenMessageIdIsValid()
    {
        // Arrange
        var command = new UpdateMessageCommand()
        {
            Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
            CurrentUserId = MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID,
            Content = ValidContent
        };

        // Act
        var response = await _commandHandler.Handle(command, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessageViewModel>(m => m.Id == MessageUnitTestConfigurations.EXISTING_MESSAGE_ID);
    }

    [Fact]
    public async Task Handle_ShouldGetMessageByIdFromRepository_WhenMessageIdIsValid()
    {
        // Arrange
        var command = new UpdateMessageCommand()
        {
            Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
            CurrentUserId = MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID,
            Content = ValidContent
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
        var command = new UpdateMessageCommand()
        {
            Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
            CurrentUserId = MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID,
            Content = ValidContent
        };

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        MessageRepository
            .Received(1)
            .Update(Arg.Is<Message>(m => m.Id == MessageUnitTestConfigurations.EXISTING_MESSAGE_ID &&
                                         m.SenderId == MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID &&
                                         m.ReceiverId == MessageUnitTestConfigurations.EXISTING_MESSAGE_RECEIVER_ID &&
                                         m.Content == ValidContent));
    }

    [Fact]
    public async Task Handle_ShouldSendMessageDeletedEvent_WhenMessageIdIsValid()
    {
        // Arrange
        var command = new UpdateMessageCommand()
        {
            Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
            CurrentUserId = MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID,
            Content = ValidContent
        };

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await EventPublisher
            .Received(1)
            .Publish(Arg.Is<MessageUpdatedEvent>(m => m.Id == MessageUnitTestConfigurations.EXISTING_MESSAGE_ID &&
                                                      m.Content == ValidContent),
                     CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenMessageIdIsValid()
    {
        // Arrange
        var command = new UpdateMessageCommand()
        {
            Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
            CurrentUserId = MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID,
            Content = ValidContent
        };

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
