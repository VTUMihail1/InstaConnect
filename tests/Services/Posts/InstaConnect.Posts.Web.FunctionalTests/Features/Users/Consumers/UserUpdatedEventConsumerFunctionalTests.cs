﻿using FluentAssertions;
using InstaConnect.Posts.Common.Features.Users.Utilities;
using InstaConnect.Posts.Web.FunctionalTests.Features.Users.Utilities;
using InstaConnect.Posts.Web.FunctionalTests.Utilities;
using InstaConnect.Shared.Business.Contracts.Users;
using MassTransit.Testing;

namespace InstaConnect.Posts.Web.FunctionalTests.Features.Users.Consumers;

public class UserUpdatedEventConsumerFunctionalTests : BaseUserFunctionalTest
{
    public UserUpdatedEventConsumerFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {
    }

    [Fact]
    public async Task Consume_ShouldReceiveEvent_WhenUserUpdatedEventIsRaised()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var userUpdatedEvent = new UserUpdatedEvent(existingUserId, UserTestUtilities.ValidUserName, UserTestUtilities.ValidUserEmail, UserTestUtilities.ValidUserFirstName, UserTestUtilities.ValidUserLastName, UserTestUtilities.ValidUserProfileImage);

        // Act
        await TestHarness.Start();
        await TestHarness.Bus.Publish(userUpdatedEvent, CancellationToken);
        await TestHarness.InactivityTask;
        await TestHarness.Stop();

        var result = await TestHarness.Consumed.Any<UserUpdatedEvent>(m =>
                              m.Context.Message.Id == existingUserId &&
                              m.Context.Message.FirstName == UserTestUtilities.ValidUserFirstName &&
                              m.Context.Message.LastName == UserTestUtilities.ValidUserLastName &&
                              m.Context.Message.UserName == UserTestUtilities.ValidUserName &&
                              m.Context.Message.Email == UserTestUtilities.ValidUserEmail &&
                              m.Context.Message.ProfileImage == UserTestUtilities.ValidUserProfileImage, CancellationToken);

        // Assert
        result.Should().BeTrue();
    }
}
