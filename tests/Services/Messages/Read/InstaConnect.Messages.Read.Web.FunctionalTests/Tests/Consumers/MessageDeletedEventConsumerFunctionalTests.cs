using FluentAssertions;
using InstaConnect.Messages.Write.Web.FunctionalTests.Utilities;
using InstaConnect.Shared.Business.Contracts.Messages;
using MassTransit.Testing;

namespace InstaConnect.Messages.Write.Web.FunctionalTests.Tests.Consumers;

public class MessageDeletedEventConsumerFunctionalTests : BaseMessageFunctionalTest
{
    public MessageDeletedEventConsumerFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {
    }

    [Fact]
    public async Task Consume_ShouldReceiveEvent_WhenMessageDeletedEventIsRaised()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var messageDeletedEvent = new MessageDeletedEvent()
        {
            Id = existingMessageId
        };

        // Act
        await TestHarness.Start();
        await TestHarness.Bus.Publish(messageDeletedEvent, CancellationToken);
        await TestHarness.InactivityTask;
        await TestHarness.Stop();

        var result = await TestHarness.Consumed.Any<MessageDeletedEvent>(m =>
                              m.Context.Message.Id == existingMessageId, CancellationToken);

        // Assert
        result.Should().BeTrue();
    }
}
