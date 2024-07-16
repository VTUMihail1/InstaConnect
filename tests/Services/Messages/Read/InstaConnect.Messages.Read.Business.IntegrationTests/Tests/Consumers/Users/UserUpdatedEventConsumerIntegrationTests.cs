using FluentAssertions;
using InstaConnect.Messages.Read.Business.Consumers.Users;
using InstaConnect.Messages.Read.Data.Models.Entities;
using InstaConnect.Messages.Write.Business.IntegrationTests.Utilities;
using InstaConnect.Shared.Business.Contracts.Users;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace InstaConnect.Messages.Read.Business.IntegrationTests.Tests.Consumers.Users;

public class UserUpdatedEventConsumerIntegrationTests : BaseMessageIntegrationTest
{
    private readonly UserUpdatedEventConsumer _userUpdatedEventConsumer;
    private readonly ConsumeContext<UserUpdatedEvent> _userUpdatedEventConsumeContext;

    public UserUpdatedEventConsumerIntegrationTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {
        _userUpdatedEventConsumer = ServiceScope.ServiceProvider.GetRequiredService<UserUpdatedEventConsumer>();

        _userUpdatedEventConsumeContext = Substitute.For<ConsumeContext<UserUpdatedEvent>>();
    }

    [Fact]
    public async Task Consume_ShouldNotCreateUser_WhenUserUpdatedEventIsInvalid()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var userUpdatedEvent = new UserUpdatedEvent()
        {
            Id = MessageIntegrationTestConfigurations.NON_EXISTING_MESSAGE_ID,
            FirstName = MessageIntegrationTestConfigurations.EXISTING_SENDER_FIRST_NAME,
            LastName = MessageIntegrationTestConfigurations.EXISTING_SENDER_LAST_NAME,
            UserName = MessageIntegrationTestConfigurations.EXISTING_MESSAGE_UPDATE_NAME,
            Email = MessageIntegrationTestConfigurations.EXISTING_SENDER_EMAIL,
            ProfileImage = MessageIntegrationTestConfigurations.EXISTING_SENDER_PROFILE_IMAGE,
        };

        _userUpdatedEventConsumeContext.Message.Returns(userUpdatedEvent);

        // Act
        await _userUpdatedEventConsumer.Consume(_userUpdatedEventConsumeContext);
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
    public async Task Consume_ShouldCreateUser_WhenUserUpdatedEventIsValid()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var userUpdatedEvent = new UserUpdatedEvent()
        {
            Id = existingSenderId,
            FirstName = MessageIntegrationTestConfigurations.EXISTING_SENDER_FIRST_NAME,
            LastName = MessageIntegrationTestConfigurations.EXISTING_SENDER_LAST_NAME,
            UserName = MessageIntegrationTestConfigurations.EXISTING_MESSAGE_UPDATE_NAME,
            Email = MessageIntegrationTestConfigurations.EXISTING_SENDER_EMAIL,
            ProfileImage = MessageIntegrationTestConfigurations.EXISTING_SENDER_PROFILE_IMAGE,
        };

        _userUpdatedEventConsumeContext.Message.Returns(userUpdatedEvent);

        // Act
        await _userUpdatedEventConsumer.Consume(_userUpdatedEventConsumeContext);
        var existingUser = await UserRepository.GetByIdAsync(existingSenderId, CancellationToken);

        // Assert
        existingUser
            .Should()
            .Match<User>(m => m.Id == existingSenderId &&
                              m.FirstName == MessageIntegrationTestConfigurations.EXISTING_SENDER_FIRST_NAME &&
                              m.LastName == MessageIntegrationTestConfigurations.EXISTING_SENDER_LAST_NAME &&
                              m.UserName == MessageIntegrationTestConfigurations.EXISTING_MESSAGE_UPDATE_NAME &&
                              m.Email == MessageIntegrationTestConfigurations.EXISTING_SENDER_EMAIL &&
                              m.ProfileImage == MessageIntegrationTestConfigurations.EXISTING_SENDER_PROFILE_IMAGE);
    }
}
