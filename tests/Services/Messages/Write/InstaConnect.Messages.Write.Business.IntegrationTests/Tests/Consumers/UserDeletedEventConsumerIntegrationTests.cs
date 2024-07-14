using FluentAssertions;
using InstaConnect.Messages.Write.Business.Commands.Messages.AddMessage;
using InstaConnect.Messages.Write.Business.Consumers;
using InstaConnect.Messages.Write.Business.IntegrationTests.Utilities;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Business.Exceptions.Base;
using MassTransit.Testing;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace InstaConnect.Messages.Write.Business.IntegrationTests.Tests.Consumers;

public class UserDeletedEventConsumerIntegrationTests : BaseMessageIntegrationTest
{
    private readonly UserDeletedEventConsumer _userDeletedEventConsumer;

    public UserDeletedEventConsumerIntegrationTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {
        _userDeletedEventConsumer = ServiceScope.ServiceProvider.GetRequiredService<UserDeletedEventConsumer>();
    }

    [Fact]
    public async Task Consume_ShouldRemoveMessagesWithThatUserId_WhenUserDeletedEventIsRaised()
    {
        // Arrange
        var existingMessageId = await CreateMessageAsync(CancellationToken);
        var userDeletedEvent = new UserDeletedEvent()
        {
            Id = MessageIntegrationTestConfigurations.EXISTING_MESSAGE_SENDER_ID
        };
        UserDeletedEventConsumeContext.Message.Returns(userDeletedEvent);

        // Act
        await _userDeletedEventConsumer.Consume(UserDeletedEventConsumeContext);
        var deletedMessage = await MessageRepository.GetByIdAsync(existingMessageId, CancellationToken);

        // Assert
        deletedMessage.Should().BeNull();
    }
}
