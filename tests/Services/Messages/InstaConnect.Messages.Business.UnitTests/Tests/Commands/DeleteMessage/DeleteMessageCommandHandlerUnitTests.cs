using FluentAssertions;
using InstaConnect.Messages.Business.Commands.Messages.DeleteMessage;
using InstaConnect.Messages.Business.UnitTests.Utilities;
using InstaConnect.Messages.Data.Models.Entities;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.Message;
using NSubstitute;

namespace InstaConnect.Messages.Business.UnitTests.Tests.Commands.DeleteMessage;

public class DeleteMessageCommandHandlerUnitTests : BaseMessageUnitTest
{
    private readonly DeleteMessageCommandHandler _commandHandler;

    public DeleteMessageCommandHandlerUnitTests()
    {
        _commandHandler = new(
            UnitOfWork,
            MessageWriteRepository);
    }

    [Fact]
    public async Task Handle_ShouldThrowMessageNotFoundException_WhenMessageIdIsInvalid()
    {
        // Arrange
        var command = new DeleteMessageCommand(
            MessageUnitTestConfigurations.NON_EXISTING_MESSAGE_ID,
            MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID
        );

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<MessageNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowAccountForbiddenException_WhenSenderIdIsInvalid()
    {
        // Arrange
        var command = new DeleteMessageCommand(
            MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
            MessageUnitTestConfigurations.EXISTING_SENDER_ID
        );

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AccountForbiddenException>();
    }

    [Fact]
    public async Task Handle_ShouldGetMessageByIdFromRepository_WhenMessageIdIsValid()
    {
        // Arrange
        var command = new DeleteMessageCommand(
            MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
            MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await MessageWriteRepository
            .Received(1)
            .GetByIdAsync(MessageUnitTestConfigurations.EXISTING_MESSAGE_ID, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldDeleteMessageFromRepository_WhenMessageIdIsValid()
    {
        // Arrange
        var command = new DeleteMessageCommand(
            MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
            MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        MessageWriteRepository
            .Received(1)
            .Delete(Arg.Is<Message>(m => m.Id == MessageUnitTestConfigurations.EXISTING_MESSAGE_ID &&
                                         m.SenderId == MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID &&
                                         m.ReceiverId == MessageUnitTestConfigurations.EXISTING_MESSAGE_RECEIVER_ID &&
                                         m.Content == ValidContent));
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenMessageIdIsValid()
    {
        // Arrange
        var command = new DeleteMessageCommand(
            MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
            MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
