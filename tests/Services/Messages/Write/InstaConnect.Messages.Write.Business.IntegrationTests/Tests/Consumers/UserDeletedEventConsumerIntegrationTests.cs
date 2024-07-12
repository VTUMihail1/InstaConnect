using FluentAssertions;
using InstaConnect.Messages.Write.Business.Commands.Messages.AddMessage;
using InstaConnect.Messages.Write.Business.Consumers;
using InstaConnect.Messages.Write.Business.IntegrationTests.Utilities;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Business.Exceptions.Base;
using MassTransit.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Messages.Write.Business.IntegrationTests.Tests.Consumers;

public class UserDeletedEventConsumerIntegrationTests : BaseMessageIntegrationTest
{

    private readonly UserDeletedEventConsumer _userDeletedEventConsumer;

    public UserDeletedEventConsumerIntegrationTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {
        _userDeletedEventConsumer = ServiceScope.ServiceProvider.GetRequiredService<UserDeletedEventConsumer>();
    }

    //[Fact]
    //public async Task Consume_ShouldReceiveEvent_WhenUserDeletedEventIsRaised()
    //{
    //    // Arrange
    //    await CreateMessageAsync(CancellationToken);
    //    var userDeletedEvent = new UserDeletedEvent()
    //    {
    //        Id = MessageIntegrationTestConfigurations.EXISTING_MESSAGE_SENDER_ID
    //    };

    //    // Act
    //    await EventPublisher.Publish(userDeletedEvent, CancellationToken);
    //    var result = await TestHarness.Consumed.Any<UserDeletedEvent>(m => m.Context.Message.Id == MessageIntegrationTestConfigurations.EXISTING_MESSAGE_SENDER_ID, CancellationToken);

    //    // Assert
    //    result.Should().BeTrue();
    //}

    //[Fact]
    //public async Task Consume_ShouldRemoveMessagesWithThatUserId_WhenUserDeletedEventIsRaised()
    //{
    //    // Arrange
    //    var existingMessageId = await CreateMessageAsync(CancellationToken);
    //    var userDeletedEvent = new UserDeletedEvent()
    //    {
    //        Id = MessageIntegrationTestConfigurations.EXISTING_MESSAGE_SENDER_ID
    //    };

    //    // Act
    //    await EventPublisher.Publish(userDeletedEvent, CancellationToken);
    //    var deletedMessage = await MessageRepository.GetByIdAsync(existingMessageId, CancellationToken);

    //    // Assert
    //    deletedMessage.Should().BeNull();
    //}
}
