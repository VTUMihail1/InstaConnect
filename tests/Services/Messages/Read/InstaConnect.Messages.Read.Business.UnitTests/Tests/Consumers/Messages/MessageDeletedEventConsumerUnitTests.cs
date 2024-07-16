using InstaConnect.Messages.Read.Business.Consumers.Messages;
using InstaConnect.Messages.Read.Data.Models.Entities;
using InstaConnect.Messages.Write.Business.UnitTests.Utilities;
using InstaConnect.Shared.Business.Contracts.Messages;
using MassTransit;
using NSubstitute;

namespace InstaConnect.Messages.Read.Business.UnitTests.Tests.Consumers.Messages;

public class MessageDeletedEventConsumerUnitTests : BaseMessageUnitTest
{
    private readonly MessageDeletedEventConsumer _messageDeletedEventConsumer;
    private readonly ConsumeContext<MessageDeletedEvent> _messageDeletedEventConsumeContext;

    public MessageDeletedEventConsumerUnitTests()
    {
        _messageDeletedEventConsumer = new(
            UnitOfWork,
            MessageRepository);

        _messageDeletedEventConsumeContext = Substitute.For<ConsumeContext<MessageDeletedEvent>>();
    }

    [Fact]
    public async Task Consume_ShouldCallGetByIdAsyncMethod_WhenMessageIdIsInvalid()
    {
        // Arrange
        var messageDeletedEvent = new MessageDeletedEvent()
        {
            Id = MessageUnitTestConfigurations.NON_EXISTING_MESSAGE_ID,
        };

        _messageDeletedEventConsumeContext.Message.Returns(messageDeletedEvent);

        // Act
        await _messageDeletedEventConsumer.Consume(_messageDeletedEventConsumeContext);

        // Assert
        await MessageRepository
            .Received(1)
            .GetByIdAsync(MessageUnitTestConfigurations.NON_EXISTING_MESSAGE_ID, CancellationToken);
    }

    [Fact]
    public async Task Consume_ShouldNotAddMethod_WhenMessageIdIsInvalid()
    {
        // Arrange
        var messageDeletedEvent = new MessageDeletedEvent()
        {
            Id = MessageUnitTestConfigurations.NON_EXISTING_MESSAGE_ID,
        };

        _messageDeletedEventConsumeContext.Message.Returns(messageDeletedEvent);

        // Act
        await _messageDeletedEventConsumer.Consume(_messageDeletedEventConsumeContext);

        // Assert
        MessageRepository
            .Received(0)
            .Delete(Arg.Any<Message>());
    }

    [Fact]
    public async Task Consume_ShouldNotCallSaveChangesAsync_WhenMessageIdIsInvalid()
    {
        // Arrange
        var messageDeletedEvent = new MessageDeletedEvent()
        {
            Id = MessageUnitTestConfigurations.NON_EXISTING_MESSAGE_ID,
        };

        _messageDeletedEventConsumeContext.Message.Returns(messageDeletedEvent);

        // Act
        await _messageDeletedEventConsumer.Consume(_messageDeletedEventConsumeContext);

        // Assert
        await UnitOfWork
            .Received(0)
            .SaveChangesAsync(CancellationToken);
    }

    [Fact]
    public async Task Consume_ShouldGetUserById_WhenMessageDeletedEventIsValid()
    {
        // Arrange
        var messageDeletedEvent = new MessageDeletedEvent()
        {
            Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
        };

        _messageDeletedEventConsumeContext.Message.Returns(messageDeletedEvent);

        // Act
        await _messageDeletedEventConsumer.Consume(_messageDeletedEventConsumeContext);

        // Assert
        await MessageRepository
            .Received(1)
            .GetByIdAsync(MessageUnitTestConfigurations.EXISTING_MESSAGE_ID, CancellationToken);
    }

    [Fact]
    public async Task Consume_ShouldAddUserToRepository_WhenMessageDeletedEventIsValid()
    {
        // Arrange
        var messageDeletedEvent = new MessageDeletedEvent()
        {
            Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
        };

        _messageDeletedEventConsumeContext.Message.Returns(messageDeletedEvent);

        // Act
        await _messageDeletedEventConsumer.Consume(_messageDeletedEventConsumeContext);

        // Assert
        MessageRepository
            .Received(1)
            .Delete(Arg.Is<Message>(m => m.Id == MessageUnitTestConfigurations.EXISTING_MESSAGE_ID &&
                                      m.SenderId == MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID &&
                                      m.ReceiverId == MessageUnitTestConfigurations.EXISTING_MESSAGE_RECEIVER_ID &&
                                      m.Content == MessageUnitTestConfigurations.EXISTING_MESSAGE_CONTENT));
    }

    [Fact]
    public async Task Consume_ShouldCallSaveChangesAsync_WhenMessageDeletedEventIsValid()
    {
        // Arrange
        var messageDeletedEvent = new MessageDeletedEvent()
        {
            Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
        };

        _messageDeletedEventConsumeContext.Message.Returns(messageDeletedEvent);

        // Act
        await _messageDeletedEventConsumer.Consume(_messageDeletedEventConsumeContext);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
