using FluentAssertions;
using InstaConnect.Messages.Business.Features.Users.Consumers;
using InstaConnect.Messages.Business.IntegrationTests.Utilities;
using InstaConnect.Messages.Data.Features.Users.Models.Entities;
using InstaConnect.Shared.Business.Contracts.Users;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace InstaConnect.Messages.Business.IntegrationTests.Features.Users.Consumers.Users;

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
        var existingUserId = await CreateUserAsync(CancellationToken);
        var userCreatedEvent = new UserCreatedEvent(
            existingUserId,
            ValidAddUserName,
            ValidUserEmail,
            ValidUserFirstName,
            ValidUserLastName,
            ValidUserProfileImage);

        _userCreatedEventConsumeContext.Message.Returns(userCreatedEvent);

        // Act
        await _userCreatedEventConsumer.Consume(_userCreatedEventConsumeContext);
        var existingUser = await UserReadRepository.GetByIdAsync(existingUserId, CancellationToken);

        // Assert
        existingUser
            .Should()
            .Match<User>(m => m.Id == existingUserId &&
                              m.FirstName == ValidUserFirstName &&
                              m.LastName == ValidUserFirstName &&
                              m.UserName == ValidUserFirstName &&
                              m.Email == ValidUserFirstName &&
                              m.ProfileImage == ValidUserFirstName);
    }

    [Fact]
    public async Task Consume_ShouldCreateUser_WhenUserCreatedEventIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var userCreatedEvent = new UserCreatedEvent(
            InvalidUserId,
            ValidAddUserName,
            ValidUserEmail,
            ValidUserFirstName,
            ValidUserLastName,
            ValidUserProfileImage);

        _userCreatedEventConsumeContext.Message.Returns(userCreatedEvent);

        // Act
        await _userCreatedEventConsumer.Consume(_userCreatedEventConsumeContext);
        var existingUser = await UserReadRepository.GetByIdAsync(InvalidId, CancellationToken);

        // Assert
        existingUser
            .Should()
            .Match<User>(m => m.Id == InvalidUserId &&
                              m.FirstName == ValidUserFirstName &&
                              m.LastName == ValidUserLastName &&
                              m.UserName == ValidAddUserName &&
                              m.Email == ValidUserEmail &&
                              m.ProfileImage == ValidUserProfileImage);
    }
}
