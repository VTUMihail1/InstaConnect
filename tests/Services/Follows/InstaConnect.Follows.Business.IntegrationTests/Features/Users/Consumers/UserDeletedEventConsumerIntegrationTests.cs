﻿using FluentAssertions;
using InstaConnect.Follows.Business.Features.Users.Consumers;
using InstaConnect.Follows.Business.IntegrationTests.Utilities;
using InstaConnect.Follows.Data.Features.Users.Models.Entities;
using InstaConnect.Shared.Business.Contracts.Users;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace InstaConnect.Follows.Business.IntegrationTests.Features.Users.Consumers;

public class UserDeletedEventConsumerIntegrationTests : BaseFollowIntegrationTest
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
        var userDeletedEvent = new UserDeletedEvent(InvalidUserId);

        _userDeletedEventConsumeContext.Message.Returns(userDeletedEvent);

        // Act
        await _userDeletedEventConsumer.Consume(_userDeletedEventConsumeContext);
        var existingUser = await UserWriteRepository.GetByIdAsync(existingUserId, CancellationToken);

        // Assert
        existingUser
            .Should()
            .Match<User>(m => m.Id == existingUserId &&
                              m.FirstName == ValidUserFirstName &&
                              m.LastName == ValidUserLastName &&
                              m.UserName == ValidUserName &&
                              m.Email == ValidUserEmail &&
                              m.ProfileImage == ValidUserProfileImage);
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
}
