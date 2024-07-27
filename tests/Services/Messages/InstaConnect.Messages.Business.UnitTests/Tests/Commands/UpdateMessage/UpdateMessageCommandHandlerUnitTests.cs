using FluentAssertions;
using InstaConnect.Messages.Business.Commands.Messages.UpdateMessage;
using InstaConnect.Messages.Business.Models;
using InstaConnect.Messages.Business.UnitTests.Utilities;
using InstaConnect.Messages.Data.Models.Entities;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.Message;
using NSubstitute;

namespace InstaConnect.Messages.Business.UnitTests.Tests.Commands.UpdateMessage;

public class UpdateMessageCommandHandlerUnitTests : BaseMessageUnitTest
{
    private readonly UpdateMessageCommandHandler _commandHandler;

    public UpdateMessageCommandHandlerUnitTests()
    {
        _commandHandler = new(
            UnitOfWork,
            MessageWriteRepository,
            InstaConnectMapper);
    }

    [Fact]
public async Task Handle_ShouldThrowMessageNotFoundException_WhenMessageIdIsInvalid()
{
    // Arrange
    var command = new UpdateMessageCommand(
        MessageUnitTestConfigurations.NON_EXISTING_MESSAGE_ID,
        ValidContent,
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
    var command = new UpdateMessageCommand(
        MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
        ValidContent,
        MessageUnitTestConfigurations.EXISTING_SENDER_ID
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
        MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
        ValidContent,
        MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID
    );

    // Act
    var response = await _commandHandler.Handle(command, CancellationToken);

    // Assert
    response
        .Should()
        .Match<MessageCommandViewModel>(m => m.Id == MessageUnitTestConfigurations.EXISTING_MESSAGE_ID);
}

[Fact]
public async Task Handle_ShouldGetMessageByIdFromRepository_WhenMessageIdIsValid()
{
    // Arrange
    var command = new UpdateMessageCommand(
        MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
        ValidContent,
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
public async Task Handle_ShouldUpdateMessageInRepository_WhenMessageIdIsValid()
{
    // Arrange
    var command = new UpdateMessageCommand(
        MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
        ValidContent,
        MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID
    );

    // Act
    await _commandHandler.Handle(command, CancellationToken);

    // Assert
    MessageWriteRepository
        .Received(1)
        .Update(Arg.Is<Message>(m => m.Id == MessageUnitTestConfigurations.EXISTING_MESSAGE_ID &&
                                     m.SenderId == MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID &&
                                     m.ReceiverId == MessageUnitTestConfigurations.EXISTING_MESSAGE_RECEIVER_ID &&
                                     m.Content == ValidContent));
}

[Fact]
public async Task Handle_ShouldCallSaveChangesAsync_WhenMessageIdIsValid()
{
    // Arrange
    var command = new UpdateMessageCommand(
        MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
        ValidContent,
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
