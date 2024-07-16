using FluentAssertions;
using InstaConnect.Messages.Read.Business.Consumers.Messages;
using InstaConnect.Messages.Read.Data.Models.Entities;
using InstaConnect.Messages.Write.Business.IntegrationTests.Utilities;
using InstaConnect.Shared.Business.Contracts.Messages;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace InstaConnect.Messages.Read.Business.UnitTests.Tests.Consumers.Messages;

public class MessageCreatedEventConsumerIntegrationTests : BaseMessageIntegrationTest
{
    private readonly MessageCreatedEventConsumer _messageCreatedEventConsumer;
    private readonly ConsumeContext<MessageCreatedEvent> _messageCreatedEventConsumeContext;

    public MessageCreatedEventConsumerIntegrationTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {
        _messageCreatedEventConsumer = ServiceScope.ServiceProvider.GetRequiredService<MessageCreatedEventConsumer>();

        _messageCreatedEventConsumeContext = Substitute.For<ConsumeContext<MessageCreatedEvent>>();
    }

    [Fact]
    public async Task Consume_ShouldNotCreateMessage_WhenMessageCreatedEventIsInvalid()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var messageCreatedEvent = new MessageCreatedEvent()
        {
            Id = existingMessageId,
            SenderId = existingSenderId,
            ReceiverId = existingReceiverId,
            Content = MessageIntegrationTestConfigurations.EXISTING_MESSAGE_ADD_CONTENT,
        };

        _messageCreatedEventConsumeContext.Message.Returns(messageCreatedEvent);

        // Act
        await _messageCreatedEventConsumer.Consume(_messageCreatedEventConsumeContext);
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
    public async Task Consume_ShouldCreateMessage_WhenMessageCreatedEventIsValid()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var messageCreatedEvent = new MessageCreatedEvent()
        {
            Id = MessageIntegrationTestConfigurations.NON_EXISTING_MESSAGE_ID,
            SenderId = existingSenderId,
            ReceiverId = existingReceiverId,
            Content = MessageIntegrationTestConfigurations.EXISTING_MESSAGE_ADD_CONTENT,
        };

        _messageCreatedEventConsumeContext.Message.Returns(messageCreatedEvent);

        // Act
        await _messageCreatedEventConsumer.Consume(_messageCreatedEventConsumeContext);
        var existingMessage = await MessageRepository.GetByIdAsync(MessageIntegrationTestConfigurations.NON_EXISTING_MESSAGE_ID, CancellationToken);

        // Assert
        existingMessage
            .Should()
            .Match<Message>(m => m.Id == MessageIntegrationTestConfigurations.NON_EXISTING_MESSAGE_ID &&
                                 m.SenderId == existingSenderId &&
                                 m.ReceiverId == existingReceiverId &&
                                 m.Content == MessageIntegrationTestConfigurations.EXISTING_MESSAGE_ADD_CONTENT);
    }
}
