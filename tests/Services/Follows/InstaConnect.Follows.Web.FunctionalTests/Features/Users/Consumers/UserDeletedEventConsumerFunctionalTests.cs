﻿using FluentAssertions;
using InstaConnect.Follows.Common.Features.Users.Utilities;
using InstaConnect.Follows.Data.Features.Users.Models.Entities;
using InstaConnect.Follows.Web.Features.Users.Consumers;
using InstaConnect.Follows.Web.FunctionalTests.Features.Users.Utilities;
using InstaConnect.Follows.Web.FunctionalTests.Utilities;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Common.Utilities;
using MassTransit.Testing;

namespace InstaConnect.Follows.Web.FunctionalTests.Features.Users.Consumers;

public class UserDeletedEventConsumerFunctionalTests : BaseUserFunctionalTest
{
    public UserDeletedEventConsumerFunctionalTests(FollowsFunctionalTestWebAppFactory followFunctionalTestWebAppFactory) : base(followFunctionalTestWebAppFactory)
    {
    }

    // TODO: Fix the tests to not collide with each other
    //[Fact]
    //public async Task Consume_ShouldNotDeleteUser_WhenUserDeletedEventIsInvalid()
    //{
    //    // Arrange
    //    var existingUserId = await CreateUserAsync(CancellationToken);
    //    var userDeletedEvent = new UserDeletedEvent(UserTestUtilities.InvalidId);

    //    // Act
    //    await TestHarness.Bus.Publish(userDeletedEvent, CancellationToken);
    //    await TestHarness.Published.Any<UserDeletedEvent>();
    //    await TestHarness.Consumed.Any<UserDeletedEvent>();

    //    var existingUser = await UserWriteRepository.GetByIdAsync(existingUserId, CancellationToken);

    //    // Assert
    //    existingUser
    //        .Should()
    //        .Match<User>(m => m.Id == existingUserId &&
    //                          m.FirstName == UserTestUtilities.ValidFirstName &&
    //                          m.LastName == UserTestUtilities.ValidLastName &&
    //                          m.UserName == UserTestUtilities.ValidName &&
    //                          m.Email == UserTestUtilities.ValidEmail &&
    //                          m.ProfileImage == UserTestUtilities.ValidProfileImage);
    //}

    //[Fact]
    //public async Task Consume_ShouldDeleteUser_WhenUserDeletedEventIsValid()
    //{
    //    // Arrange
    //    var existingUserId = await CreateUserAsync(CancellationToken);
    //    var userDeletedEvent = new UserDeletedEvent(existingUserId);

    //    // Act
    //    await TestHarness.Bus.Publish(userDeletedEvent, CancellationToken);
    //    await TestHarness.Published.Any<UserDeletedEvent>();
    //    await TestHarness.Consumed.Any<UserDeletedEvent>();

    //    var existingUser = await UserWriteRepository.GetByIdAsync(existingUserId, CancellationToken);

    //    // Assert
    //    existingUser
    //        .Should()
    //        .BeNull();
    //}

    //[Fact]
    //public async Task Consume_ShouldDeleteUser_WhenUserDeletedEventIsValidAndIdCaseDoesNotMatch()
    //{
    //    // Arrange
    //    var existingUserId = await CreateUserAsync(CancellationToken);
    //    var userDeletedEvent = new UserDeletedEvent(SharedTestUtilities.GetNonCaseMatchingString(existingUserId));

    //    // Act
    //    await TestHarness.Bus.Publish(userDeletedEvent, CancellationToken);
    //    await TestHarness.Published.Any<UserDeletedEvent>();
    //    await TestHarness.Consumed.Any<UserDeletedEvent>();

    //    var existingUser = await UserWriteRepository.GetByIdAsync(existingUserId, CancellationToken);

    //    // Assert
    //    existingUser
    //        .Should()
    //        .BeNull();
    //}

    //[Fact]
    //public async Task Consume_ShouldReceiveEvent_WhenUserDeletedEventIsRaised()
    //{
    //    // Arrange
    //    var existingUserId = await CreateUserAsync(CancellationToken);
    //    var userDeletedEvent = new UserDeletedEvent(existingUserId);

    //    // Act
    //    await TestHarness.Bus.Publish(userDeletedEvent, CancellationToken);
    //    await TestHarness.Published.Any<UserDeletedEvent>();
    //    await TestHarness.Consumed.Any<UserDeletedEvent>();

    //    var result = await TestHarness.Consumed.Any<UserDeletedEvent>(m => m.Context.Message.Id == existingUserId, CancellationToken);

    //    // Assert
    //    result.Should().BeTrue();
    //}
}
