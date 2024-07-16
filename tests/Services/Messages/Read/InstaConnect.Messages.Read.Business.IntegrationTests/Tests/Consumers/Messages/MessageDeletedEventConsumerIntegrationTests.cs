using FluentAssertions;
using InstaConnect.Messages.Read.Business.Consumers.Messages;
using InstaConnect.Messages.Read.Data.Models.Entities;
using InstaConnect.Messages.Write.Business.IntegrationTests.Utilities;
using InstaConnect.Shared.Business.Contracts.Messages;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace InstaConnect.Messages.Read.Business.UnitTests.Tests.Consumers.Messages;

public class MessageDeletedEventConsumerIntegrationTests : BaseMessageIntegrationTest
{
    private readonly MessageDeletedEventConsumer _messageDeletedEventConsumer;
    private readonly ConsumeContext<MessageDeletedEvent> _messageDeletedEventConsumeContext;

    public MessageDeletedEventConsumerIntegrationTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {
        _messageDeletedEventConsumer = ServiceScope.ServiceProvider.GetRequiredService<MessageDeletedEventConsumer>();

        _messageDeletedEventConsumeContext = Substitute.For<ConsumeContext<MessageDeletedEvent>>();
    }

    [Fact]
    public async Task Consume_ShouldNotDeleteMessage_WhenMessageDeletedEventMessageIdIsInvalid()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var messageDeletedEvent = new MessageDeletedEvent()
        {
            Id = MessageIntegrationTestConfigurations.NON_EXISTING_MESSAGE_ID,
        };

        _messageDeletedEventConsumeContext.Message.Returns(messageDeletedEvent);

        // Act
        await _messageDeletedEventConsumer.Consume(_messageDeletedEventConsumeContext);
        var existingMessage = await MessageRepository.GetByIdAsync(existingMessageId, CancellationToken);

        // Assert
        existingMessage
            .Should()
            .Match<Message>(m => m.Id == existingMessageId &&
                                 m.SenderId == existingSenderId &&
                                 m.ReceiverId == existingReceiverId &&
                                 m.Content == MessageIntegrationTestConfigurations.EXISTING_MESSAGE_CONTENT);
    }

    [Fact]
    public async Task Consume_ShouldDeletedMessage_WhenMessageDeletedEventIsValid()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var messageDeletedEvent = new MessageDeletedEvent()
        {
            Id = existingMessageId,
        };

        _messageDeletedEventConsumeContext.Message.Returns(messageDeletedEvent);

        // Act
        await _messageDeletedEventConsumer.Consume(_messageDeletedEventConsumeContext);
        var existingMessage = await MessageRepository.GetByIdAsync(existingMessageId, CancellationToken);

        // Assert
        existingMessage
            .Should()
            .BeNull();
    }
}
