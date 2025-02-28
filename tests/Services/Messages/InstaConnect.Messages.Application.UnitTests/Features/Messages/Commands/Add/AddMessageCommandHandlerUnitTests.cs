using InstaConnect.Messages.Application.Features.Messages.Commands.Add;
using InstaConnect.Messages.Domain.Features.Messages.Models;

namespace InstaConnect.Messages.Application.UnitTests.Features.Messages.Commands.Add;

public class AddMessageCommandHandlerUnitTests : BaseMessageUnitTest
{
    private readonly AddMessageCommandHandler _commandHandler;

    public AddMessageCommandHandlerUnitTests()
    {
        _commandHandler = new(
            UnitOfWork,
            MessageSender,
            MessageFactory,
            InstaConnectMapper,
            UserWriteRepository,
            MessageWriteRepository);
    }

    [Fact]
    public async Task Handle_ShouldThrowUserNotFoundException_WhenSenderIdIsInvalid()
    {
        // Arrange
        var existingReceiver = CreateUser();
        var command = new AddMessageCommand(
            UserTestUtilities.InvalidId,
            existingReceiver.Id,
            MessageTestUtilities.ValidAddContent
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
        var existingSender = CreateUser();
        var command = new AddMessageCommand(
            existingSender.Id,
            UserTestUtilities.InvalidId,
            MessageTestUtilities.ValidAddContent
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
        var existingMessage = CreateMessageFactory();
        var command = new AddMessageCommand(
            existingMessage.SenderId,
            existingMessage.ReceiverId,
            MessageTestUtilities.ValidAddContent);

        // Act
        var response = await _commandHandler.Handle(command, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessageCommandViewModel>(m => m.Id == existingMessage.SenderId);
    }

    [Fact]
    public async Task Handle_ShouldGetMessageFromFactory_WhenMessageIsValid()
    {
        // Arrange
        var existingMessage = CreateMessageFactory();
        var command = new AddMessageCommand(
            existingMessage.SenderId,
            existingMessage.ReceiverId,
            MessageTestUtilities.ValidAddContent);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        MessageFactory
            .Received(1)
            .Get(existingMessage.SenderId, existingMessage.ReceiverId, MessageTestUtilities.ValidAddContent);
    }

    [Fact]
    public async Task Handle_ShouldAddMessageToRepository_WhenMessageIsValid()
    {
        // Arrange
        var existingMessage = CreateMessageFactory();
        var command = new AddMessageCommand(
            existingMessage.SenderId,
            existingMessage.ReceiverId,
            MessageTestUtilities.ValidAddContent);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        MessageWriteRepository
            .Received(1)
            .Add(Arg.Is<Message>(m =>
                !string.IsNullOrEmpty(m.Id) &&
                m.SenderId == existingMessage.SenderId &&
                m.ReceiverId == existingMessage.ReceiverId &&
                m.Content == MessageTestUtilities.ValidAddContent));
    }

    [Fact]
    public async Task Handle_ShouldSendMessageFromSender_WhenMessageIsValid()
    {
        // Arrange
        var existingMessage = CreateMessageFactory();
        var command = new AddMessageCommand(
            existingMessage.SenderId,
            existingMessage.ReceiverId,
            MessageTestUtilities.ValidAddContent);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await MessageSender
            .Received(1)
            .SendMessageToUserAsync(Arg.Is<MessageSendModel>(m =>
                m.Content == MessageTestUtilities.ValidAddContent &&
                m.ReceiverId == existingMessage.ReceiverId),
                CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenMessageIsValid()
    {
        // Arrange
        var existingMessage = CreateMessageFactory();
        var command = new AddMessageCommand(
            existingMessage.SenderId,
            existingMessage.ReceiverId,
            MessageTestUtilities.ValidAddContent);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
