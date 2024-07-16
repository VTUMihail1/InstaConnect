using InstaConnect.Messages.Read.Business.Consumers.Messages;
using InstaConnect.Messages.Read.Data.Models.Entities;
using InstaConnect.Messages.Write.Business.UnitTests.Utilities;
using InstaConnect.Shared.Business.Contracts.Messages;
using MassTransit;
using NSubstitute;

namespace InstaConnect.Messages.Read.Business.UnitTests.Tests.Consumers.Messages;

public class MessageUpdatedEventConsumerUnitTests : BaseMessageUnitTest
{
    private readonly MessageUpdatedEventConsumer _messageUpdatedEventConsumer;
    private readonly ConsumeContext<MessageUpdatedEvent> _messageUpdatedEventConsumeContext;

    public MessageUpdatedEventConsumerUnitTests()
    {
        _messageUpdatedEventConsumer = new(
            UnitOfWork,
            MessageRepository,
            InstaConnectMapper);

        _messageUpdatedEventConsumeContext = Substitute.For<ConsumeContext<MessageUpdatedEvent>>();
    }

    [Fact]
    public async Task Consume_ShouldCallGetByIdAsyncMethod_WhenMessageIdIsInvalid()
    {
        // Arrange
        var messageUpdatedEvent = new MessageUpdatedEvent()
        {
            Id = MessageUnitTestConfigurations.NON_EXISTING_MESSAGE_ID,
            Content = MessageUnitTestConfigurations.EXISTING_MESSAGE_CONTENT,
        };

        _messageUpdatedEventConsumeContext.Message.Returns(messageUpdatedEvent);

        // Act
        await _messageUpdatedEventConsumer.Consume(_messageUpdatedEventConsumeContext);

        // Assert
        await MessageRepository
            .Received(1)
            .GetByIdAsync(MessageUnitTestConfigurations.NON_EXISTING_MESSAGE_ID, CancellationToken);
    }

    [Fact]
    public async Task Consume_ShouldNotAddMethod_WhenMessageIdIsInvalid()
    {
        // Arrange
        var messageUpdatedEvent = new MessageUpdatedEvent()
        {
            Id = MessageUnitTestConfigurations.NON_EXISTING_MESSAGE_ID,
            Content = MessageUnitTestConfigurations.EXISTING_MESSAGE_CONTENT,
        };

        _messageUpdatedEventConsumeContext.Message.Returns(messageUpdatedEvent);

        // Act
        await _messageUpdatedEventConsumer.Consume(_messageUpdatedEventConsumeContext);

        // Assert
        MessageRepository
            .Received(0)
            .Update(Arg.Any<Message>());
    }

    [Fact]
    public async Task Consume_ShouldNotCallSaveChangesAsync_WhenMessageIdIsInvalid()
    {
        // Arrange
        var messageUpdatedEvent = new MessageUpdatedEvent()
        {
            Id = MessageUnitTestConfigurations.NON_EXISTING_MESSAGE_ID,
            Content = MessageUnitTestConfigurations.EXISTING_MESSAGE_CONTENT,
        };

        _messageUpdatedEventConsumeContext.Message.Returns(messageUpdatedEvent);

        // Act
        await _messageUpdatedEventConsumer.Consume(_messageUpdatedEventConsumeContext);

        // Assert
        await UnitOfWork
            .Received(0)
            .SaveChangesAsync(CancellationToken);
    }

    [Fact]
    public async Task Consume_ShouldGetUserById_WhenMessageUpdatedEventIsValid()
    {
        // Arrange
        var messageUpdatedEvent = new MessageUpdatedEvent()
        {
            Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
            Content = MessageUnitTestConfigurations.EXISTING_MESSAGE_CONTENT,
        };

        _messageUpdatedEventConsumeContext.Message.Returns(messageUpdatedEvent);

        // Act
        await _messageUpdatedEventConsumer.Consume(_messageUpdatedEventConsumeContext);

        // Assert
        await MessageRepository
            .Received(1)
            .GetByIdAsync(MessageUnitTestConfigurations.EXISTING_MESSAGE_ID, CancellationToken);
    }

    [Fact]
    public async Task Consume_ShouldAddUserToRepository_WhenMessageUpdatedEventIsValid()
    {
        // Arrange
        var messageUpdatedEvent = new MessageUpdatedEvent()
        {
            Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
            Content = MessageUnitTestConfigurations.EXISTING_MESSAGE_CONTENT,
        };

        _messageUpdatedEventConsumeContext.Message.Returns(messageUpdatedEvent);

        // Act
        await _messageUpdatedEventConsumer.Consume(_messageUpdatedEventConsumeContext);

        // Assert
        MessageRepository
            .Received(1)
            .Update(Arg.Is<Message>(m => m.Id == MessageUnitTestConfigurations.EXISTING_MESSAGE_ID &&
                                      m.SenderId == MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID &&
                                      m.ReceiverId == MessageUnitTestConfigurations.EXISTING_MESSAGE_RECEIVER_ID &&
                                      m.Content == MessageUnitTestConfigurations.EXISTING_MESSAGE_CONTENT));
    }

    [Fact]
    public async Task Consume_ShouldCallSaveChangesAsync_WhenMessageUpdatedEventIsValid()
    {
        // Arrange
        var messageUpdatedEvent = new MessageUpdatedEvent()
        {
            Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
            Content = MessageUnitTestConfigurations.EXISTING_MESSAGE_CONTENT,
        };

        _messageUpdatedEventConsumeContext.Message.Returns(messageUpdatedEvent);

        // Act
        await _messageUpdatedEventConsumer.Consume(_messageUpdatedEventConsumeContext);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
