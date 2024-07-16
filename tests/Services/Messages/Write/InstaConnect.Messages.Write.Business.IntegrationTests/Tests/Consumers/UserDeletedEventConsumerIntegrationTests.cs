using FluentAssertions;
using InstaConnect.Messages.Write.Business.Commands.Messages.AddMessage;
using InstaConnect.Messages.Write.Business.Consumers;
using InstaConnect.Messages.Write.Business.IntegrationTests.Utilities;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Business.Exceptions.Base;
using MassTransit;
using MassTransit.Testing;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace InstaConnect.Messages.Write.Business.IntegrationTests.Tests.Consumers;

public class UserDeletedEventConsumerIntegrationTests : BaseMessageIntegrationTest
{
    private readonly UserDeletedEventConsumer _userDeletedEventConsumer;
    private readonly ConsumeContext<UserDeletedEvent> _userDeletedEventConsumeContext;

    public UserDeletedEventConsumerIntegrationTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {
        _userDeletedEventConsumer = ServiceScope.ServiceProvider.GetRequiredService<UserDeletedEventConsumer>();
        _userDeletedEventConsumeContext = Substitute.For<ConsumeContext<UserDeletedEvent>>();
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

        _userDeletedEventConsumeContext.Message.Returns(userDeletedEvent);

        // Act
        await _userDeletedEventConsumer.Consume(_userDeletedEventConsumeContext);
        var deletedMessage = await MessageRepository.GetByIdAsync(existingMessageId, CancellationToken);

        // Assert
        deletedMessage.Should().BeNull();
    }
}
