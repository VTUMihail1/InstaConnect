using InstaConnect.Messages.Read.Business.Consumers.Messages;
using InstaConnect.Messages.Read.Data.Models.Entities;
using InstaConnect.Messages.Write.Business.UnitTests.Utilities;
using InstaConnect.Shared.Business.Contracts.Messages;
using MassTransit;
using NSubstitute;

namespace InstaConnect.Messages.Read.Business.UnitTests.Tests.Consumers.Messages;

public class MessageCreatedEventConsumerUnitTests : BaseMessageUnitTest
{
    private readonly MessageCreatedEventConsumer _messageCreatedEventConsumer;
    private readonly ConsumeContext<MessageCreatedEvent> _messageCreatedEventConsumeContext;

    public MessageCreatedEventConsumerUnitTests()
    {
        _messageCreatedEventConsumer = new(
            UnitOfWork,
            MessageRepository,
            InstaConnectMapper);

        _messageCreatedEventConsumeContext = Substitute.For<ConsumeContext<MessageCreatedEvent>>();
    }

    [Fact]
    public async Task Consume_ShouldCallGetByIdAsyncMethod_WhenMessageIdIsInvalid()
    {
        // Arrange
        var messageCreatedEvent = new MessageCreatedEvent()
        {
            Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
            SenderId = MessageUnitTestConfigurations.EXISTING_SENDER_ID,
            ReceiverId = MessageUnitTestConfigurations.EXISTING_RECEIVER_ID,
            Content = MessageUnitTestConfigurations.EXISTING_MESSAGE_CONTENT,
        };

        _messageCreatedEventConsumeContext.Message.Returns(messageCreatedEvent);

        // Act
        await _messageCreatedEventConsumer.Consume(_messageCreatedEventConsumeContext);

        // Assert
        await MessageRepository
            .Received(1)
            .GetByIdAsync(MessageUnitTestConfigurations.EXISTING_MESSAGE_ID, CancellationToken);
    }

    [Fact]
    public async Task Consume_ShouldNotAddMethod_WhenMessageIdIsInvalid()
    {
        // Arrange
        var messageCreatedEvent = new MessageCreatedEvent()
        {
            Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
            SenderId = MessageUnitTestConfigurations.EXISTING_SENDER_ID,
            ReceiverId = MessageUnitTestConfigurations.EXISTING_RECEIVER_ID,
            Content = MessageUnitTestConfigurations.EXISTING_MESSAGE_CONTENT,
        };

        _messageCreatedEventConsumeContext.Message.Returns(messageCreatedEvent);

        // Act
        await _messageCreatedEventConsumer.Consume(_messageCreatedEventConsumeContext);

        // Assert
        MessageRepository
            .Received(0)
            .Add(Arg.Any<Message>());
    }

    [Fact]
    public async Task Consume_ShouldNotCallSaveChangesAsync_WhenMessageIdIsInvalid()
    {
        // Arrange
        var messageCreatedEvent = new MessageCreatedEvent()
        {
            Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
            SenderId = MessageUnitTestConfigurations.EXISTING_SENDER_ID,
            ReceiverId = MessageUnitTestConfigurations.EXISTING_RECEIVER_ID,
            Content = MessageUnitTestConfigurations.EXISTING_MESSAGE_CONTENT,
        };

        _messageCreatedEventConsumeContext.Message.Returns(messageCreatedEvent);

        // Act
        await _messageCreatedEventConsumer.Consume(_messageCreatedEventConsumeContext);

        // Assert
        await UnitOfWork
            .Received(0)
            .SaveChangesAsync(CancellationToken);
    }

    [Fact]
    public async Task Consume_ShouldGetUserById_WhenMessageCreatedEventIsValid()
    {
        // Arrange
        var messageCreatedEvent = new MessageCreatedEvent()
        {
            Id = MessageUnitTestConfigurations.NON_EXISTING_MESSAGE_ID,
            SenderId = MessageUnitTestConfigurations.EXISTING_SENDER_ID,
            ReceiverId = MessageUnitTestConfigurations.EXISTING_RECEIVER_ID,
            Content = MessageUnitTestConfigurations.EXISTING_MESSAGE_CONTENT,
        };

        _messageCreatedEventConsumeContext.Message.Returns(messageCreatedEvent);

        // Act
        await _messageCreatedEventConsumer.Consume(_messageCreatedEventConsumeContext);

        // Assert
        await MessageRepository
            .Received(1)
            .GetByIdAsync(MessageUnitTestConfigurations.NON_EXISTING_MESSAGE_ID, CancellationToken);
    }

    [Fact]
    public async Task Consume_ShouldAddUserToRepository_WhenMessageCreatedEventIsValid()
    {
        // Arrange
        var messageCreatedEvent = new MessageCreatedEvent()
        {
            Id = MessageUnitTestConfigurations.NON_EXISTING_MESSAGE_ID,
            SenderId = MessageUnitTestConfigurations.EXISTING_SENDER_ID,
            ReceiverId = MessageUnitTestConfigurations.EXISTING_RECEIVER_ID,
            Content = MessageUnitTestConfigurations.EXISTING_MESSAGE_CONTENT,
        };

        _messageCreatedEventConsumeContext.Message.Returns(messageCreatedEvent);

        // Act
        await _messageCreatedEventConsumer.Consume(_messageCreatedEventConsumeContext);

        // Assert
        MessageRepository
            .Received(1)
            .Add(Arg.Is<Message>(m => m.Id == MessageUnitTestConfigurations.NON_EXISTING_MESSAGE_ID &&
                                      m.SenderId == MessageUnitTestConfigurations.EXISTING_SENDER_ID &&
                                      m.ReceiverId == MessageUnitTestConfigurations.EXISTING_RECEIVER_ID &&
                                      m.Content == MessageUnitTestConfigurations.EXISTING_MESSAGE_CONTENT));
    }

    [Fact]
    public async Task Consume_ShouldCallSaveChangesAsync_WhenMessageCreatedEventIsValid()
    {
        // Arrange
        var messageCreatedEvent = new MessageCreatedEvent()
        {
            Id = MessageUnitTestConfigurations.NON_EXISTING_MESSAGE_ID,
            SenderId = MessageUnitTestConfigurations.EXISTING_SENDER_ID,
            ReceiverId = MessageUnitTestConfigurations.EXISTING_RECEIVER_ID,
            Content = MessageUnitTestConfigurations.EXISTING_MESSAGE_CONTENT,
        };

        _messageCreatedEventConsumeContext.Message.Returns(messageCreatedEvent);

        // Act
        await _messageCreatedEventConsumer.Consume(_messageCreatedEventConsumeContext);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
