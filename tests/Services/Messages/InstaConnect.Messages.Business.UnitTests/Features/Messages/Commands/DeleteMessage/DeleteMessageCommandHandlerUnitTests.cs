using FluentAssertions;
using InstaConnect.Messages.Business.Features.Messages.Commands.DeleteMessage;
using InstaConnect.Messages.Business.UnitTests.Features.Messages.Utilities;
using InstaConnect.Messages.Common.Features.Messages.Utilities;
using InstaConnect.Messages.Data.Features.Messages.Models.Entities;
using InstaConnect.Shared.Common.Exceptions.Message;
using InstaConnect.Shared.Common.Exceptions.User;
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
            MessageTestUtilities.InvalidId,
            MessageTestUtilities.ValidMessageCurrentUserId
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
            MessageTestUtilities.ValidId,
            MessageTestUtilities.ValidCurrentUserId
        );

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserForbiddenException>();
    }

    [Fact]
    public async Task Handle_ShouldGetMessageByIdFromRepository_WhenMessageIdIsValid()
    {
        // Arrange
        var command = new DeleteMessageCommand(
            MessageTestUtilities.ValidId,
            MessageTestUtilities.ValidMessageCurrentUserId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await MessageWriteRepository
            .Received(1)
            .GetByIdAsync(MessageTestUtilities.ValidId, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldDeleteMessageFromRepository_WhenMessageIdIsValid()
    {
        // Arrange
        var command = new DeleteMessageCommand(
            MessageTestUtilities.ValidId,
            MessageTestUtilities.ValidMessageCurrentUserId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        MessageWriteRepository
            .Received(1)
            .Delete(Arg.Is<Message>(m => m.Id == MessageTestUtilities.ValidId &&
                                         m.SenderId == MessageTestUtilities.ValidMessageCurrentUserId &&
                                         m.ReceiverId == MessageTestUtilities.ValidMessageReceiverId &&
                                         m.Content == MessageTestUtilities.ValidContent));
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenMessageIdIsValid()
    {
        // Arrange
        var command = new DeleteMessageCommand(
            MessageTestUtilities.ValidId,
            MessageTestUtilities.ValidMessageCurrentUserId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
