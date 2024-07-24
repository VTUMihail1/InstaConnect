using FluentAssertions;
using InstaConnect.Messages.Business.Commands.Messages.AddMessage;
using InstaConnect.Messages.Business.Models;
using InstaConnect.Messages.Business.UnitTests.Utilities;
using InstaConnect.Messages.Data.Models.Entities;
using InstaConnect.Shared.Business.Exceptions.User;
using NSubstitute;

namespace InstaConnect.Messages.Business.UnitTests.Tests.Commands.AddMessage;

public class AddMessageCommandHandlerUnitTests : BaseMessageUnitTest
{
    private readonly AddMessageCommandHandler _commandHandler;

    public AddMessageCommandHandlerUnitTests()
    {
        _commandHandler = new(
            UnitOfWork,
            MessageSender,
            MessageWriteRepository,
            InstaConnectMapper,
            UserWriteRepository);
    }

    [Fact]
    public async Task Handle_ShouldThrowUserNotFoundException_WhenSenderIdIsInvalid()
    {
        // Arrange
        var command = new AddMessageCommand(
            MessageUnitTestConfigurations.NON_EXISTING_USER_ID,
            MessageUnitTestConfigurations.EXISTING_SENDER_ID,
            ValidContent
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
            MessageUnitTestConfigurations.EXISTING_SENDER_ID,
            MessageUnitTestConfigurations.NON_EXISTING_USER_ID,
            ValidContent
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
            MessageUnitTestConfigurations.EXISTING_SENDER_ID,
            MessageUnitTestConfigurations.EXISTING_RECEIVER_ID,
            ValidContent
        );

        // Act
        var response = await _commandHandler.Handle(command, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessageWriteViewModel>(m => m.Id == MessageUnitTestConfigurations.EXISTING_MESSAGE_ID);
    }

    [Fact]
    public async Task Handle_ShouldAddMessageToRepository_WhenMessageIsValid()
    {
        // Arrange
        var command = new AddMessageCommand(
            MessageUnitTestConfigurations.EXISTING_SENDER_ID,
            MessageUnitTestConfigurations.EXISTING_RECEIVER_ID,
            ValidContent
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        MessageWriteRepository
            .Received(1)
            .Add(Arg.Is<Message>(m =>
                // m.Id == string.Empty &&
                m.SenderId == MessageUnitTestConfigurations.EXISTING_SENDER_ID &&
                m.ReceiverId == MessageUnitTestConfigurations.EXISTING_RECEIVER_ID &&
                m.Content == ValidContent));
    }

    [Fact]
    public async Task Handle_ShouldSendMessageFromSender_WhenMessageIsValid()
    {
        // Arrange
        var command = new AddMessageCommand(
            MessageUnitTestConfigurations.EXISTING_SENDER_ID,
            MessageUnitTestConfigurations.EXISTING_RECEIVER_ID,
            ValidContent
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await MessageSender
            .Received(1)
            .SendMessageToUserAsync(Arg.Is<MessageSendModel>(m =>
                m.Content == ValidContent &&
                m.ReceiverId == MessageUnitTestConfigurations.EXISTING_RECEIVER_ID),
                CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenMessageIsValid()
    {
        // Arrange
        var command = new AddMessageCommand(
            MessageUnitTestConfigurations.EXISTING_SENDER_ID,
            MessageUnitTestConfigurations.EXISTING_RECEIVER_ID,
            ValidContent
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
