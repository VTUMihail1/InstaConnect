using FluentAssertions;
using InstaConnect.Messages.Business.Features.Messages.Commands.UpdateMessage;
using InstaConnect.Messages.Business.Features.Messages.Models;
using InstaConnect.Messages.Business.UnitTests.Features.Messages.Utilities;
using InstaConnect.Messages.Data.Features.Messages.Models.Entities;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.Message;
using NSubstitute;

namespace InstaConnect.Messages.Business.UnitTests.Features.Messages.Commands.UpdateMessage;

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
        var command = new UpdateMessageCommand(
            InvalidId,
            ValidContent,
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
        var command = new UpdateMessageCommand(
            ValidId,
            ValidContent,
            ValidCurrentUserId
        );

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AccountForbiddenException>();
    }

    [Fact]
    public async Task Handle_ShouldReturnMessageViewModel_WhenMessageIdIsValid()
    {
        // Arrange
        var command = new UpdateMessageCommand(
            ValidId,
            ValidContent,
            ValidMessageCurrentUserId
        );

        // Act
        var response = await _commandHandler.Handle(command, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessageCommandViewModel>(m => m.Id == ValidId);
    }

    [Fact]
    public async Task Handle_ShouldGetMessageByIdFromRepository_WhenMessageIdIsValid()
    {
        // Arrange
        var command = new UpdateMessageCommand(
            ValidId,
            ValidContent,
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
    public async Task Handle_ShouldUpdateMessageInRepository_WhenMessageIdIsValid()
    {
        // Arrange
        var command = new UpdateMessageCommand(
            ValidId,
            ValidContent,
            ValidMessageCurrentUserId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        MessageWriteRepository
            .Received(1)
            .Update(Arg.Is<Message>(m => m.Id == ValidId &&
                                         m.SenderId == ValidMessageCurrentUserId &&
                                         m.ReceiverId == ValidMessageReceiverId &&
                                         m.Content == ValidContent));
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenMessageIdIsValid()
    {
        // Arrange
        var command = new UpdateMessageCommand(
            ValidId,
            ValidContent,
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
