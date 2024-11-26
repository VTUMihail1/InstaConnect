using FluentAssertions;
using InstaConnect.Messages.Application.Features.Messages.Commands.AddMessage;
using InstaConnect.Messages.Application.Features.Messages.Models;
using InstaConnect.Messages.Application.UnitTests.Features.Messages.Utilities;
using InstaConnect.Messages.Common.Features.Messages.Utilities;
using InstaConnect.Messages.Domain.Features.Messages.Models;
using InstaConnect.Messages.Domain.Features.Messages.Models.Entities;
using InstaConnect.Shared.Common.Exceptions.User;
using NSubstitute;

namespace InstaConnect.Messages.Application.UnitTests.Features.Messages.Commands.AddMessage;

public class AddMessageCommandHandlerUnitTests : BaseMessageUnitTest
{
    private readonly AddMessageCommandHandler _commandHandler;

    public AddMessageCommandHandlerUnitTests()
    {
        _commandHandler = new(
            UnitOfWork,
            MessageSender,
            InstaConnectMapper,
            UserWriteRepository,
            MessageWriteRepository);
    }

    [Fact]
    public async Task Handle_ShouldThrowUserNotFoundException_WhenSenderIdIsInvalid()
    {
        // Arrange
        var command = new AddMessageCommand(
            MessageTestUtilities.InvalidUserId,
            MessageTestUtilities.ValidCurrentUserId,
            MessageTestUtilities.ValidContent
        );

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowUserNotFoundException_WhenReceiverIdIsInvalid()
    {
        // Arrange
        var command = new AddMessageCommand(
            MessageTestUtilities.ValidCurrentUserId,
            MessageTestUtilities.InvalidUserId,
            MessageTestUtilities.ValidContent
        );

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldReturnMessageViewModel_WhenMessageIsValid()
    {
        // Arrange
        var command = new AddMessageCommand(
            MessageTestUtilities.ValidCurrentUserId,
            MessageTestUtilities.ValidReceiverId,
            MessageTestUtilities.ValidContent
        );

        // Act
        var response = await _commandHandler.Handle(command, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessageCommandViewModel>(m => !string.IsNullOrEmpty(m.Id));
    }

    [Fact]
    public async Task Handle_ShouldAddMessageToRepository_WhenMessageIsValid()
    {
        // Arrange
        var command = new AddMessageCommand(
            MessageTestUtilities.ValidCurrentUserId,
            MessageTestUtilities.ValidReceiverId,
            MessageTestUtilities.ValidContent
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        MessageWriteRepository
            .Received(1)
            .Add(Arg.Is<Message>(m =>
                !string.IsNullOrEmpty(m.Id) &&
                m.SenderId == MessageTestUtilities.ValidCurrentUserId &&
                m.ReceiverId == MessageTestUtilities.ValidReceiverId &&
                m.Content == MessageTestUtilities.ValidContent));
    }

    [Fact]
    public async Task Handle_ShouldSendMessageFromSender_WhenMessageIsValid()
    {
        // Arrange
        var command = new AddMessageCommand(
            MessageTestUtilities.ValidCurrentUserId,
            MessageTestUtilities.ValidReceiverId,
            MessageTestUtilities.ValidContent
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await MessageSender
            .Received(1)
            .SendMessageToUserAsync(Arg.Is<MessageSendModel>(m =>
                m.Content == MessageTestUtilities.ValidContent &&
                m.ReceiverId == MessageTestUtilities.ValidReceiverId),
                CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenMessageIsValid()
    {
        // Arrange
        var command = new AddMessageCommand(
            MessageTestUtilities.ValidCurrentUserId,
            MessageTestUtilities.ValidReceiverId,
            MessageTestUtilities.ValidContent
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
