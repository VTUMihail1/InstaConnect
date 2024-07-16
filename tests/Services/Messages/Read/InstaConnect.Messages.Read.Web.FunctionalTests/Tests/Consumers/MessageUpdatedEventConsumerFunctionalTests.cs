using FluentAssertions;
using InstaConnect.Messages.Write.Web.FunctionalTests.Utilities;
using InstaConnect.Shared.Business.Contracts.Messages;
using MassTransit.Testing;

namespace InstaConnect.Messages.Write.Web.FunctionalTests.Tests.Consumers;

public class MessageUpdatedEventConsumerFunctionalTests : BaseMessageFunctionalTest
{
    public MessageUpdatedEventConsumerFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {
    }

    [Fact]
    public async Task Consume_ShouldReceiveEvent_WhenMessageUpdatedEventIsRaised()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var messageCreatedEvent = new MessageUpdatedEvent()
        {
            Id = existingMessageId,
            Content = MessageFunctionalTestConfigurations.EXISTING_MESSAGE_CONTENT
        };

        // Act
        await TestHarness.Start();
        await TestHarness.Bus.Publish(messageCreatedEvent, CancellationToken);
        await TestHarness.InactivityTask;
        await TestHarness.Stop();

        var result = await TestHarness.Consumed.Any<MessageUpdatedEvent>(m =>
                              m.Context.Message.Id == existingMessageId &&
                              m.Context.Message.Content == MessageFunctionalTestConfigurations.EXISTING_MESSAGE_CONTENT, CancellationToken);

        // Assert
        result.Should().BeTrue();
    }
}
