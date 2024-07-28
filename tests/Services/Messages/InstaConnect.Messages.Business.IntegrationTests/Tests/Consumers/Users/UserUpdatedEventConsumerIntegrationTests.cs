﻿using FluentAssertions;
using InstaConnect.Messages.Business.IntegrationTests.Utilities;
using InstaConnect.Messages.Business.Consumers.Users;
using InstaConnect.Messages.Data.Models.Entities;
using InstaConnect.Shared.Business.Contracts.Users;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace InstaConnect.Messages.Business.IntegrationTests.Tests.Consumers.Users;

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
    public async Task Consume_ShouldNotUpdateUser_WhenUserUpdatedEventIsInvalid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var userUpdatedEvent = new UserUpdatedEvent(
            InvalidUserId,
            ValidUpdateUserName,
            ValidUserEmail,
            ValidUserFirstName,
            ValidUserLastName,
            ValidUserProfileImage);

        _userUpdatedEventConsumeContext.Message.Returns(userUpdatedEvent);

        // Act
        await _userUpdatedEventConsumer.Consume(_userUpdatedEventConsumeContext);
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
    public async Task Consume_ShouldUpdateUser_WhenUserUpdatedEventIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var userUpdatedEvent = new UserUpdatedEvent(
            existingUserId,
            ValidUpdateUserName,
            ValidUserEmail,
            ValidUserFirstName,
            ValidUserLastName,
            ValidUserProfileImage);

        _userUpdatedEventConsumeContext.Message.Returns(userUpdatedEvent);

        // Act
        await _userUpdatedEventConsumer.Consume(_userUpdatedEventConsumeContext);
        var existingUser = await UserReadRepository.GetByIdAsync(existingUserId, CancellationToken);

        // Assert
        existingUser
            .Should()
            .Match<User>(m => m.Id == existingUserId &&
                              m.FirstName == ValidUserFirstName &&
                              m.LastName == ValidUserFirstName &&
                              m.UserName == ValidUpdateUserName &&
                              m.Email == ValidUserFirstName &&
                              m.ProfileImage == ValidUserFirstName);
    }
}
