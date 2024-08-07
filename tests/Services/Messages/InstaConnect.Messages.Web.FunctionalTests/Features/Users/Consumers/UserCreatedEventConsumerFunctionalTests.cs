﻿using FluentAssertions;
using InstaConnect.Messages.Web.FunctionalTests.Features.Users.Utilities;
using InstaConnect.Messages.Web.FunctionalTests.Utilities;
using InstaConnect.Shared.Business.Contracts.Users;
using MassTransit.Testing;

namespace InstaConnect.Messages.Web.FunctionalTests.Features.Users.Consumers;

public class UserCreatedEventConsumerFunctionalTests : BaseUserFunctionalTest
{
    public UserCreatedEventConsumerFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {
    }

    [Fact]
    public async Task Consume_ShouldReceiveEvent_WhenUserCreatedEventIsRaised()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var userUpdatedEvent = new UserUpdatedEvent(
            existingUserId,
            ValidUserName,
            ValidUserEmail,
            ValidUserFirstName,
            ValidUserLastName,
            ValidUserProfileImage);

        // Act
        await TestHarness.Start();
        await TestHarness.Bus.Publish(userUpdatedEvent, CancellationToken);
        await TestHarness.InactivityTask;
        await TestHarness.Stop();

        var result = await TestHarness.Consumed.Any<UserUpdatedEvent>(m =>
                              m.Context.Message.Id == existingUserId &&
                              m.Context.Message.FirstName == ValidUserFirstName &&
                              m.Context.Message.LastName == ValidUserLastName &&
                              m.Context.Message.UserName == ValidUserName &&
                              m.Context.Message.Email == ValidUserEmail &&
                              m.Context.Message.ProfileImage == ValidUserProfileImage, CancellationToken);

        // Assert
        result.Should().BeTrue();
    }
}