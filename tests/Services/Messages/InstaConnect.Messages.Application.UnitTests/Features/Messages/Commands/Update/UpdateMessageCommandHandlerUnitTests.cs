using FluentAssertions;
using InstaConnect.Messages.Application.Features.Messages.Commands.Update;
using InstaConnect.Messages.Application.Features.Messages.Models;
using InstaConnect.Messages.Application.UnitTests.Features.Messages.Utilities;
using InstaConnect.Messages.Common.Features.Messages.Utilities;
using InstaConnect.Messages.Domain.Features.Messages.Models.Entities;
using InstaConnect.Shared.Common.Exceptions.Message;
using InstaConnect.Shared.Common.Exceptions.User;
using NSubstitute;

namespace InstaConnect.Messages.Application.UnitTests.Features.Messages.Commands.Update;

public class UpdateMessageCommandHandlerUnitTests : BaseMessageUnitTest
{
    private readonly UpdateMessageCommandHandler _commandHandler;

    public UpdateMessageCommandHandlerUnitTests()
    {
        _commandHandler = new(
            UnitOfWork,
            InstaConnectMapper,
            MessageWriteRepository);
    }

    [Fact]
    public async Task Handle_ShouldThrowMessageNotFoundException_WhenMessageIdIsInvalid()
    {
        // Arrange
        var existingMessage = CreateMessage();
        var command = new UpdateMessageCommand(
            MessageTestUtilities.InvalidId,
            MessageTestUtilities.ValidUpdateContent,
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
        var command = new UpdateMessageCommand(
            existingMessage.Id,
            MessageTestUtilities.ValidUpdateContent,
            existingUser.Id
        );

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserForbiddenException>();
    }

    [Fact]
    public async Task Handle_ShouldReturnMessageViewModel_WhenMessageIdIsValid()
    {
        // Arrange
        var existingMessage = CreateMessage();
        var command = new UpdateMessageCommand(
            existingMessage.Id,
            MessageTestUtilities.ValidUpdateContent,
            existingMessage.SenderId
        );

        // Act
        var response = await _commandHandler.Handle(command, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessageCommandViewModel>(m => m.Id == existingMessage.Id);
    }

    [Fact]
    public async Task Handle_ShouldGetMessageByIdFromRepository_WhenMessageIdIsValid()
    {
        // Arrange
        var existingMessage = CreateMessage();
        var command = new UpdateMessageCommand(
            existingMessage.Id,
            MessageTestUtilities.ValidUpdateContent,
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
    public async Task Handle_ShouldUpdateMessageInRepository_WhenMessageIdIsValid()
    {
        // Arrange
        var existingMessage = CreateMessage();
        var command = new UpdateMessageCommand(
            existingMessage.Id,
            MessageTestUtilities.ValidUpdateContent,
            existingMessage.SenderId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        MessageWriteRepository
            .Received(1)
            .Update(Arg.Is<Message>(m => m.Id == existingMessage.Id &&
                                         m.SenderId == existingMessage.SenderId &&
                                         m.ReceiverId == existingMessage.ReceiverId &&
                                         m.Content == MessageTestUtilities.ValidUpdateContent));
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenMessageIdIsValid()
    {
        // Arrange
        var existingMessage = CreateMessage();
        var command = new UpdateMessageCommand(
            existingMessage.Id,
            MessageTestUtilities.ValidUpdateContent,
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
