using FluentAssertions;
using InstaConnect.Messages.Business.IntegrationTests.Utilities;
using InstaConnect.Messages.Business.Consumers.Users;
using InstaConnect.Messages.Data.Models.Entities;
using InstaConnect.Shared.Business.Contracts.Users;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace InstaConnect.Messages.Business.IntegrationTests.Tests.Consumers.Users;

public class UserCreatedEventConsumerIntegrationTests : BaseMessageIntegrationTest
{
    private readonly UserCreatedEventConsumer _userCreatedEventConsumer;
    private readonly ConsumeContext<UserCreatedEvent> _userCreatedEventConsumeContext;

    public UserCreatedEventConsumerIntegrationTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {
        _userCreatedEventConsumer = ServiceScope.ServiceProvider.GetRequiredService<UserCreatedEventConsumer>();

        _userCreatedEventConsumeContext = Substitute.For<ConsumeContext<UserCreatedEvent>>();
    }

    [Fact]
    public async Task Consume_ShouldNotCreateUser_WhenUserCreatedEventIsInvalid()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var userCreatedEvent = new UserCreatedEvent()
        {
            Id = existingSenderId,
            FirstName = MessageIntegrationTestConfigurations.EXISTING_SENDER_FIRST_NAME,
            LastName = MessageIntegrationTestConfigurations.EXISTING_SENDER_LAST_NAME,
            UserName = MessageIntegrationTestConfigurations.EXISTING_MESSAGE_ADD_NAME,
            Email = MessageIntegrationTestConfigurations.EXISTING_SENDER_EMAIL,
            ProfileImage = MessageIntegrationTestConfigurations.EXISTING_SENDER_PROFILE_IMAGE,
        };

        _userCreatedEventConsumeContext.Message.Returns(userCreatedEvent);

        // Act
        await _userCreatedEventConsumer.Consume(_userCreatedEventConsumeContext);
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
    public async Task Consume_ShouldCreateUser_WhenUserCreatedEventIsValid()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var userCreatedEvent = new UserCreatedEvent()
        {
            Id = MessageIntegrationTestConfigurations.NON_EXISTING_USER_ID,
            FirstName = MessageIntegrationTestConfigurations.EXISTING_SENDER_FIRST_NAME,
            LastName = MessageIntegrationTestConfigurations.EXISTING_SENDER_LAST_NAME,
            UserName = MessageIntegrationTestConfigurations.EXISTING_MESSAGE_ADD_NAME,
            Email = MessageIntegrationTestConfigurations.EXISTING_SENDER_EMAIL,
            ProfileImage = MessageIntegrationTestConfigurations.EXISTING_SENDER_PROFILE_IMAGE,
        };

        _userCreatedEventConsumeContext.Message.Returns(userCreatedEvent);

        // Act
        await _userCreatedEventConsumer.Consume(_userCreatedEventConsumeContext);
        var existingUser = await UserReadRepository.GetByIdAsync(MessageIntegrationTestConfigurations.NON_EXISTING_USER_ID, CancellationToken);

        // Assert
        existingUser
            .Should()
            .Match<User>(m => m.Id == MessageIntegrationTestConfigurations.NON_EXISTING_USER_ID &&
                              m.FirstName == MessageIntegrationTestConfigurations.EXISTING_SENDER_FIRST_NAME &&
                              m.LastName == MessageIntegrationTestConfigurations.EXISTING_SENDER_LAST_NAME &&
                              m.UserName == MessageIntegrationTestConfigurations.EXISTING_MESSAGE_ADD_NAME &&
                              m.Email == MessageIntegrationTestConfigurations.EXISTING_SENDER_EMAIL &&
                              m.ProfileImage == MessageIntegrationTestConfigurations.EXISTING_SENDER_PROFILE_IMAGE);
    }
}
