using FluentAssertions;
using InstaConnect.Messages.Read.Business.Consumers.Messages;
using InstaConnect.Messages.Read.Data.Models.Entities;
using InstaConnect.Messages.Write.Business.IntegrationTests.Utilities;
using InstaConnect.Shared.Business.Contracts.Messages;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace InstaConnect.Messages.Read.Business.UnitTests.Tests.Consumers.Messages;

public class MessageUpdatedEventConsumerIntegrationTests : BaseMessageIntegrationTest
{
    private readonly MessageUpdatedEventConsumer _messageUpdatedEventConsumer;
    private readonly ConsumeContext<MessageUpdatedEvent> _messageUpdatedEventConsumeContext;

    public MessageUpdatedEventConsumerIntegrationTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {
        _messageUpdatedEventConsumer = ServiceScope.ServiceProvider.GetRequiredService<MessageUpdatedEventConsumer>();

        _messageUpdatedEventConsumeContext = Substitute.For<ConsumeContext<MessageUpdatedEvent>>();
    }

    [Fact]
    public async Task Consume_ShouldNotUpdateMessage_WhenMessageUpdatedEventMessageIdIsInvalid()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var messageUpdatedEvent = new MessageUpdatedEvent()
        {
            Id = MessageIntegrationTestConfigurations.NON_EXISTING_MESSAGE_ID,
            Content = MessageIntegrationTestConfigurations.EXISTING_MESSAGE_UPDATE_CONTENT,
        };

        _messageUpdatedEventConsumeContext.Message.Returns(messageUpdatedEvent);

        // Act
        await _messageUpdatedEventConsumer.Consume(_messageUpdatedEventConsumeContext);
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
    public async Task Consume_ShouldUpdateMessage_WhenMessageUpdatedEventIsValid()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var messageUpdatedEvent = new MessageUpdatedEvent()
        {
            Id = existingMessageId,
            Content = MessageIntegrationTestConfigurations.EXISTING_MESSAGE_UPDATE_CONTENT,
        };

        _messageUpdatedEventConsumeContext.Message.Returns(messageUpdatedEvent);

        // Act
        await _messageUpdatedEventConsumer.Consume(_messageUpdatedEventConsumeContext);
        var existingMessage = await MessageRepository.GetByIdAsync(existingMessageId, CancellationToken);

        // Assert
        existingMessage
            .Should()
            .Match<Message>(m => m.Id == existingMessageId &&
                                 m.SenderId == existingSenderId &&
                                 m.ReceiverId == existingReceiverId &&
                                 m.Content == MessageIntegrationTestConfigurations.EXISTING_MESSAGE_UPDATE_CONTENT);
    }
}
