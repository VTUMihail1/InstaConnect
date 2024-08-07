﻿using FluentAssertions;
using InstaConnect.Follows.Business.Features.Users.Consumers;
using InstaConnect.Follows.Business.IntegrationTests.Features.Users.Utilities;
using InstaConnect.Follows.Business.IntegrationTests.Utilities;
using InstaConnect.Follows.Data.Features.Users.Models.Entities;
using InstaConnect.Shared.Business.Contracts.Users;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace InstaConnect.Follows.Business.IntegrationTests.Features.Users.Consumers;

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
            ValidAddUserName,
            ValidUserEmail,
            ValidUserFirstName,
            ValidUserLastName,
            ValidUserProfileImage);

        _userCreatedEventConsumeContext.Message.Returns(userCreatedEvent);

        // Act
        await _userCreatedEventConsumer.Consume(_userCreatedEventConsumeContext);
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
        var existingUser = await UserWriteRepository.GetByIdAsync(InvalidUserId, CancellationToken);

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

    [Fact]
    public async Task Consume_ShouldCreateUser_WhenUserCreatedEventIsValidAndIdCaseDoesNotMatch()
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
        var existingUser = await UserWriteRepository.GetByIdAsync(InvalidUserId, CancellationToken);

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