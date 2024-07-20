using FluentAssertions;
using InstaConnect.Messages.Business.IntegrationTests.Utilities;
using InstaConnect.Messages.Business.Consumers.Users;
using InstaConnect.Messages.Data.Models.Entities;
using InstaConnect.Shared.Business.Contracts.Users;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace InstaConnect.Messages.Business.IntegrationTests.Tests.Consumers.Users;

public class UserDeletedEventConsumerIntegrationTests : BaseMessageIntegrationTest
{
    private readonly UserDeletedEventConsumer _userDeletedEventConsumer;
    private readonly ConsumeContext<UserDeletedEvent> _userDeletedEventConsumerContext;

    public UserDeletedEventConsumerIntegrationTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {
        _userDeletedEventConsumer = ServiceScope.ServiceProvider.GetRequiredService<UserDeletedEventConsumer>();

        _userDeletedEventConsumerContext = Substitute.For<ConsumeContext<UserDeletedEvent>>();
    }

    [Fact]
    public async Task Consume_ShouldNotCreateUser_WhenUserDeletedEventIsInvalid()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var userDeletedEvent = new UserDeletedEvent()
        {
            Id = MessageIntegrationTestConfigurations.NON_EXISTING_MESSAGE_ID
        };

        _userDeletedEventConsumerContext.Message.Returns(userDeletedEvent);

        // Act
        await _userDeletedEventConsumer.Consume(_userDeletedEventConsumerContext);
        var existingUser = await UserReadRepository.GetByIdAsync(existingSenderId, CancellationToken);

        // Assert
        existingUser
            .Should()
            .Match<User>(m => m.Id == existingSenderId &&
                              m.FirstName == MessageIntegrationTestConfigurations.EXISTING_SENDER_FIRST_NAME &&
                              m.LastName == MessageIntegrationTestConfigurations.EXISTING_SENDER_LAST_NAME &&
                              m.UserName == MessageIntegrationTestConfigurations.EXISTING_SENDER_NAME &&
                              m.Email == MessageIntegrationTestConfigurations.EXISTING_SENDER_EMAIL &&
                              m.ProfileImage == MessageIntegrationTestConfigurations.EXISTING_SENDER_PROFILE_IMAGE);
    }

    [Fact]
    public async Task Consume_ShouldCreateUser_WhenUserDeletedEventIsValid()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var userDeletedEvent = new UserDeletedEvent()
        {
            Id = existingSenderId,
        };

        _userDeletedEventConsumerContext.Message.Returns(userDeletedEvent);

        // Act
        await _userDeletedEventConsumer.Consume(_userDeletedEventConsumerContext);
        var existingUser = await UserReadRepository.GetByIdAsync(existingSenderId, CancellationToken);

        // Assert
        existingUser
            .Should()
            .BeNull();
    }
}
