using FluentAssertions;
using InstaConnect.Messages.Write.Web.FunctionalTests.Utilities;
using InstaConnect.Shared.Business.Contracts.Users;
using MassTransit.Testing;

namespace InstaConnect.Messages.Write.Web.FunctionalTests.Tests.Consumers;

public class UserDeletedEventConsumerFunctionalTests : BaseMessageFunctionalTest
{
    public UserDeletedEventConsumerFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {
    }

    [Fact]
    public async Task Consume_ShouldReceiveEvent_WhenUserDeletedEventIsRaised()
    {
        // Arrange
        await CreateMessageAsync(CancellationToken);
        var userDeletedEvent = new UserDeletedEvent()
        {
            Id = MessageFunctionalTestConfigurations.EXISTING_MESSAGE_SENDER_ID
        };

        // Act
        await TestHarness.Start();
        await TestHarness.Bus.Publish(userDeletedEvent, CancellationToken);
        await TestHarness.InactivityTask;
        await TestHarness.Stop();

        var result = await TestHarness.Consumed.Any<UserDeletedEvent>(m => m.Context.Message.Id == MessageFunctionalTestConfigurations.EXISTING_MESSAGE_SENDER_ID, CancellationToken);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task Consume_ShouldRemoveMessagesWithThatUserId_WhenUserDeletedEventIsRaised()
    {
        // Arrange
        var existingMessageId = await CreateMessageAsync(CancellationToken);
        var userDeletedEvent = new UserDeletedEvent()
        {
            Id = MessageFunctionalTestConfigurations.EXISTING_MESSAGE_SENDER_ID
        };

        // Act
        await TestHarness.Start();
        await TestHarness.Bus.Publish(userDeletedEvent, CancellationToken);
        await TestHarness.InactivityTask;
        await TestHarness.Stop();

        var deletedMessage = await MessageRepository.GetByIdAsync(existingMessageId, CancellationToken);

        // Assert
        deletedMessage.Should().BeNull();
    }
}
