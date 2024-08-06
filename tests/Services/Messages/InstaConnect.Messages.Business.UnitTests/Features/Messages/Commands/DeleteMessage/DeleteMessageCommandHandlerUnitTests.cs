using FluentAssertions;
using InstaConnect.Messages.Business.Features.Messages.Commands.DeleteMessage;
using InstaConnect.Messages.Business.UnitTests.Features.Messages.Utilities;
using InstaConnect.Messages.Data.Features.Messages.Models.Entities;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.Message;
using NSubstitute;

namespace InstaConnect.Messages.Business.UnitTests.Features.Messages.Commands.DeleteMessage;

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
            InvalidId,
            ValidMessageCurrentUserId
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
            ValidId,
            ValidCurrentUserId
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
            ValidId,
            ValidMessageCurrentUserId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await MessageWriteRepository
            .Received(1)
            .GetByIdAsync(ValidId, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldDeleteMessageFromRepository_WhenMessageIdIsValid()
    {
        // Arrange
        var command = new DeleteMessageCommand(
            ValidId,
            ValidMessageCurrentUserId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        MessageWriteRepository
            .Received(1)
            .Delete(Arg.Is<Message>(m => m.Id == ValidId &&
                                         m.SenderId == ValidMessageCurrentUserId &&
                                         m.ReceiverId == ValidMessageReceiverId &&
                                         m.Content == ValidContent));
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenMessageIdIsValid()
    {
        // Arrange
        var command = new DeleteMessageCommand(
            ValidId,
            ValidMessageCurrentUserId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
