using InstaConnect.Messages.Application.Features.Messages.Commands.Delete;
using InstaConnect.Messages.Common.Tests.Features.Messages.Utilities;

namespace InstaConnect.Messages.Application.UnitTests.Features.Messages.Commands.Delete;

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
        var existingMessage = CreateMessage();
        var command = new DeleteMessageCommand(
            MessageTestUtilities.InvalidId,
            existingMessage.SenderId
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
        var existingUser = CreateUser();
        var existingMessage = CreateMessage();
        var command = new DeleteMessageCommand(
            existingMessage.Id,
            existingUser.Id
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
        var existingMessage = CreateMessage();
        var command = new DeleteMessageCommand(
            existingMessage.Id,
            existingMessage.SenderId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await MessageWriteRepository
            .Received(1)
            .GetByIdAsync(existingMessage.Id, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldDeleteMessageFromRepository_WhenMessageIdIsValid()
    {
        // Arrange
        var existingMessage = CreateMessage();
        var command = new DeleteMessageCommand(
            existingMessage.Id,
            existingMessage.SenderId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        MessageWriteRepository
            .Received(1)
            .Delete(Arg.Is<Message>(m => m.Id == existingMessage.Id &&
                                         m.SenderId == existingMessage.SenderId &&
                                         m.ReceiverId == existingMessage.ReceiverId &&
                                         m.Content == existingMessage.Content));
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenMessageIdIsValid()
    {
        // Arrange
        var existingMessage = CreateMessage();
        var command = new DeleteMessageCommand(
            existingMessage.Id,
            existingMessage.SenderId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
