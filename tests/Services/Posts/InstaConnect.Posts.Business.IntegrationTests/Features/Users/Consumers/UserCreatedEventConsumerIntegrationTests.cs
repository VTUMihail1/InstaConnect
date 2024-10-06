using FluentAssertions;
using InstaConnect.Posts.Business.Features.Users.Consumers;
using InstaConnect.Posts.Business.IntegrationTests.Features.Users.Utilities;
using InstaConnect.Posts.Business.IntegrationTests.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;
using InstaConnect.Posts.Data.Features.Users.Models.Entitites;
using InstaConnect.Shared.Business.Contracts.Users;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace InstaConnect.Posts.Business.IntegrationTests.Features.Users.Consumers;

public class UserCreatedEventConsumerIntegrationTests : BaseUserIntegrationTest
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
        var existingUserId = await CreateUserAsync(CancellationToken);
        var userCreatedEvent = new UserCreatedEvent(
            existingUserId,
            UserTestUtilities.ValidAddUserName,
            UserTestUtilities.ValidUserEmail,
            UserTestUtilities.ValidUserFirstName,
            UserTestUtilities.ValidUserLastName,
            UserTestUtilities.ValidUserProfileImage);

        _userCreatedEventConsumeContext.Message.Returns(userCreatedEvent);

        // Act
        await _userCreatedEventConsumer.Consume(_userCreatedEventConsumeContext);
        var existingUser = await UserWriteRepository.GetByIdAsync(existingUserId, CancellationToken);

        // Assert
        existingUser
            .Should()
            .Match<User>(m => m.Id == existingUserId &&
                              m.FirstName == UserTestUtilities.ValidUserFirstName &&
                              m.LastName == UserTestUtilities.ValidUserLastName &&
                              m.UserName == UserTestUtilities.ValidUserName &&
                              m.Email == UserTestUtilities.ValidUserEmail &&
                              m.ProfileImage == UserTestUtilities.ValidUserProfileImage);
    }

    [Fact]
    public async Task Consume_ShouldCreateUser_WhenUserCreatedEventIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var userCreatedEvent = new UserCreatedEvent(
            UserTestUtilities.InvalidUserId,
            UserTestUtilities.ValidAddUserName,
            UserTestUtilities.ValidUserEmail,
            UserTestUtilities.ValidUserFirstName,
            UserTestUtilities.ValidUserLastName,
            UserTestUtilities.ValidUserProfileImage);

        _userCreatedEventConsumeContext.Message.Returns(userCreatedEvent);

        // Act
        await _userCreatedEventConsumer.Consume(_userCreatedEventConsumeContext);
        var existingUser = await UserWriteRepository.GetByIdAsync(UserTestUtilities.InvalidUserId, CancellationToken);

        // Assert
        existingUser
            .Should()
            .Match<User>(m => m.Id == UserTestUtilities.InvalidUserId &&
                              m.FirstName == UserTestUtilities.ValidUserFirstName &&
                              m.LastName == UserTestUtilities.ValidUserLastName &&
                              m.UserName == UserTestUtilities.ValidAddUserName &&
                              m.Email == UserTestUtilities.ValidUserEmail &&
                              m.ProfileImage == UserTestUtilities.ValidUserProfileImage);
    }

    [Fact]
    public async Task Consume_ShouldCreateUser_WhenUserCreatedEventIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var userCreatedEvent = new UserCreatedEvent(
            UserTestUtilities.InvalidUserId,
            UserTestUtilities.ValidAddUserName,
            UserTestUtilities.ValidUserEmail,
            UserTestUtilities.ValidUserFirstName,
            UserTestUtilities.ValidUserLastName,
            UserTestUtilities.ValidUserProfileImage);

        _userCreatedEventConsumeContext.Message.Returns(userCreatedEvent);

        // Act
        await _userCreatedEventConsumer.Consume(_userCreatedEventConsumeContext);
        var existingUser = await UserWriteRepository.GetByIdAsync(UserTestUtilities.InvalidUserId, CancellationToken);

        // Assert
        existingUser
            .Should()
            .Match<User>(m => m.Id == UserTestUtilities.InvalidUserId &&
                              m.FirstName == UserTestUtilities.ValidUserFirstName &&
                              m.LastName == UserTestUtilities.ValidUserLastName &&
                              m.UserName == UserTestUtilities.ValidAddUserName &&
                              m.Email == UserTestUtilities.ValidUserEmail &&
                              m.ProfileImage == UserTestUtilities.ValidUserProfileImage);
    }
}
