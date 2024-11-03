using FluentAssertions;
using InstaConnect.Messages.Business.Features.Users.Consumers;
using InstaConnect.Messages.Business.IntegrationTests.Features.Users.Utilities;
using InstaConnect.Messages.Business.IntegrationTests.Utilities;
using InstaConnect.Messages.Common.Features.Users.Utilities;
using InstaConnect.Messages.Data.Features.Users.Models.Entities;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Common.Utilities;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace InstaConnect.Messages.Business.IntegrationTests.Features.Users.Consumers;

public class UserDeletedEventConsumerIntegrationTests : BaseUserIntegrationTest
{
    private readonly UserDeletedEventConsumer _userDeletedEventConsumer;
    private readonly ConsumeContext<UserDeletedEvent> _userDeletedEventConsumeContext;

    public UserDeletedEventConsumerIntegrationTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {
        _userDeletedEventConsumer = ServiceScope.ServiceProvider.GetRequiredService<UserDeletedEventConsumer>();

        _userDeletedEventConsumeContext = Substitute.For<ConsumeContext<UserDeletedEvent>>();
    }

    [Fact]
    public async Task Consume_ShouldNotDeleteUser_WhenUserDeletedEventIsInvalid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var userDeletedEvent = new UserDeletedEvent(UserTestUtilities.InvalidUserId);

        _userDeletedEventConsumeContext.Message.Returns(userDeletedEvent);

        // Act
        await _userDeletedEventConsumer.Consume(_userDeletedEventConsumeContext);
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
    public async Task Consume_ShouldDeleteUser_WhenUserDeletedEventIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var userDeletedEvent = new UserDeletedEvent(existingUserId);

        _userDeletedEventConsumeContext.Message.Returns(userDeletedEvent);

        // Act
        await _userDeletedEventConsumer.Consume(_userDeletedEventConsumeContext);
        var existingUser = await UserWriteRepository.GetByIdAsync(existingUserId, CancellationToken);

        // Assert
        existingUser
            .Should()
            .BeNull();
    }

    [Fact]
    public async Task Consume_ShouldDeleteUser_WhenUserDeletedEventIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var userDeletedEvent = new UserDeletedEvent(SharedTestUtilities.GetNonCaseMatchingString(existingUserId));

        _userDeletedEventConsumeContext.Message.Returns(userDeletedEvent);

        // Act
        await _userDeletedEventConsumer.Consume(_userDeletedEventConsumeContext);
        var existingUser = await UserWriteRepository.GetByIdAsync(existingUserId, CancellationToken);

        // Assert
        existingUser
            .Should()
            .BeNull();
    }
}
