using FluentAssertions;
using InstaConnect.Posts.Business.Features.Users.Consumers;
using InstaConnect.Posts.Business.IntegrationTests.Features.Users.Utilities;
using InstaConnect.Posts.Business.IntegrationTests.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;
using InstaConnect.Posts.Data.Features.Users.Models.Entitites;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Common.Utilities;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace InstaConnect.Posts.Business.IntegrationTests.Features.Users.Consumers;

public class UserUpdatedEventConsumerIntegrationTests : BaseUserIntegrationTest
{
    private readonly UserUpdatedEventConsumer _userUpdatedEventConsumer;
    private readonly ConsumeContext<UserUpdatedEvent> _userUpdatedEventConsumeContext;

    public UserUpdatedEventConsumerIntegrationTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {
        _userUpdatedEventConsumer = ServiceScope.ServiceProvider.GetRequiredService<UserUpdatedEventConsumer>();

        _userUpdatedEventConsumeContext = Substitute.For<ConsumeContext<UserUpdatedEvent>>();
    }

    [Fact]
    public async Task Consume_ShouldNotUpdateUser_WhenUserUpdatedEventIsInvalid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var userUpdatedEvent = new UserUpdatedEvent(
            UserTestUtilities.InvalidUserId,
            UserTestUtilities.ValidUpdateUserName,
            UserTestUtilities.ValidUserEmail,
            UserTestUtilities.ValidUserFirstName,
            UserTestUtilities.ValidUserLastName,
            UserTestUtilities.ValidUserProfileImage);

        _userUpdatedEventConsumeContext.Message.Returns(userUpdatedEvent);

        // Act
        await _userUpdatedEventConsumer.Consume(_userUpdatedEventConsumeContext);
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
    public async Task Consume_ShouldUpdateUser_WhenUserUpdatedEventIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var userUpdatedEvent = new UserUpdatedEvent(
            existingUserId,
            UserTestUtilities.ValidUpdateUserName,
            UserTestUtilities.ValidUserEmail,
            UserTestUtilities.ValidUserFirstName,
            UserTestUtilities.ValidUserLastName,
            UserTestUtilities.ValidUserProfileImage);

        _userUpdatedEventConsumeContext.Message.Returns(userUpdatedEvent);

        // Act
        await _userUpdatedEventConsumer.Consume(_userUpdatedEventConsumeContext);
        var existingUser = await UserWriteRepository.GetByIdAsync(existingUserId, CancellationToken);

        // Assert
        existingUser
            .Should()
            .Match<User>(m => m.Id == existingUserId &&
                              m.FirstName == UserTestUtilities.ValidUserFirstName &&
                              m.LastName == UserTestUtilities.ValidUserLastName &&
                              m.UserName == UserTestUtilities.ValidUpdateUserName &&
                              m.Email == UserTestUtilities.ValidUserEmail &&
                              m.ProfileImage == UserTestUtilities.ValidUserProfileImage);
    }

    [Fact]
    public async Task Consume_ShouldUpdateUser_WhenUserUpdatedEventIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var userUpdatedEvent = new UserUpdatedEvent(
            SharedTestUtilities.GetNonCaseMatchingString(existingUserId),
            UserTestUtilities.ValidUpdateUserName,
            UserTestUtilities.ValidUserEmail,
            UserTestUtilities.ValidUserFirstName,
            UserTestUtilities.ValidUserLastName,
            UserTestUtilities.ValidUserProfileImage);

        _userUpdatedEventConsumeContext.Message.Returns(userUpdatedEvent);

        // Act
        await _userUpdatedEventConsumer.Consume(_userUpdatedEventConsumeContext);
        var existingUser = await UserWriteRepository.GetByIdAsync(existingUserId, CancellationToken);

        // Assert
        existingUser
            .Should()
            .Match<User>(m => m.Id == existingUserId &&
                              m.FirstName == UserTestUtilities.ValidUserFirstName &&
                              m.LastName == UserTestUtilities.ValidUserLastName &&
                              m.UserName == UserTestUtilities.ValidUpdateUserName &&
                              m.Email == UserTestUtilities.ValidUserEmail &&
                              m.ProfileImage == UserTestUtilities.ValidUserProfileImage);
    }
}
