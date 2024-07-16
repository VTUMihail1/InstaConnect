using FluentAssertions;
using InstaConnect.Messages.Write.Web.FunctionalTests.Utilities;
using InstaConnect.Shared.Business.Contracts.Messages;
using MassTransit.Testing;

namespace InstaConnect.Messages.Write.Web.FunctionalTests.Tests.Consumers;

public class MessageCreatedEventConsumerFunctionalTests : BaseMessageFunctionalTest
{
    public MessageCreatedEventConsumerFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {
    }

    [Fact]
    public async Task Consume_ShouldReceiveEvent_WhenMessageCreatedEventIsRaised()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var messageCreatedEvent = new MessageCreatedEvent()
        {
            Id = MessageFunctionalTestConfigurations.NON_EXISTING_MESSAGE_ID,
            SenderId = existingSenderId,
            ReceiverId = existingReceiverId,
            Content = MessageFunctionalTestConfigurations.EXISTING_MESSAGE_CONTENT
        };

        // Act
        await TestHarness.Start();
        await TestHarness.Bus.Publish(messageCreatedEvent, CancellationToken);
        await TestHarness.InactivityTask;
        await TestHarness.Stop();

        var result = await TestHarness.Consumed.Any<MessageCreatedEvent>(m =>
                              m.Context.Message.Id == MessageFunctionalTestConfigurations.NON_EXISTING_MESSAGE_ID &&
                              m.Context.Message.SenderId == existingSenderId &&
                              m.Context.Message.ReceiverId == existingReceiverId &&
                              m.Context.Message.Content == MessageFunctionalTestConfigurations.EXISTING_MESSAGE_CONTENT, CancellationToken);

        // Assert
        result.Should().BeTrue();
    }
}
