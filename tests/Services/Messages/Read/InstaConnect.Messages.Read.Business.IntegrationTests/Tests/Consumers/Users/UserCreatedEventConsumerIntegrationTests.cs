using FluentAssertions;
using InstaConnect.Messages.Read.Business.Consumers.Users;
using InstaConnect.Messages.Read.Data.Models.Entities;
using InstaConnect.Messages.Write.Business.IntegrationTests.Utilities;
using InstaConnect.Shared.Business.Contracts.Users;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace InstaConnect.Messages.Read.Business.IntegrationTests.Tests.Consumers.Users;

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
            FirstName = MessageIntegrationTestConfigurations.EXISTING_MESSAGE_RECEIVER_ID,
            LastName = MessageIntegrationTestConfigurations.EXISTING_SENDER_LAST_NAME,
            UserName = MessageIntegrationTestConfigurations.EXISTING_MESSAGE_ADD_NAME,
            Email = MessageIntegrationTestConfigurations.EXISTING_SENDER_EMAIL,
            ProfileImage = MessageIntegrationTestConfigurations.EXISTING_SENDER_PROFILE_IMAGE,
        };

        _userCreatedEventConsumeContext.Message.Returns(userCreatedEvent);

        // Act
        await _userCreatedEventConsumer.Consume(_userCreatedEventConsumeContext);
        var existingUser = await UserRepository.GetByIdAsync(existingSenderId, CancellationToken);

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
        var existingUser = await UserRepository.GetByIdAsync(MessageIntegrationTestConfigurations.NON_EXISTING_USER_ID, CancellationToken);

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
