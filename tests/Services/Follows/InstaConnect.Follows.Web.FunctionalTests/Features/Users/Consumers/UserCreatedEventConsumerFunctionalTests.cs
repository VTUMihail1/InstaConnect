﻿using FluentAssertions;
using InstaConnect.Follows.Common.Features.Users.Utilities;
using InstaConnect.Follows.Data.Features.Users.Abstractions;
using InstaConnect.Follows.Data.Features.Users.Models.Entities;
using InstaConnect.Follows.Web.Features.Users.Consumers;
using InstaConnect.Follows.Web.FunctionalTests.Features.Users.Utilities;
using InstaConnect.Follows.Web.FunctionalTests.Utilities;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Common.Utilities;
using MassTransit.Testing;

namespace InstaConnect.Follows.Web.FunctionalTests.Features.Users.Consumers;

    public class UserCreatedEventConsumerFunctionalTests : BaseUserFunctionalTest
    {
        public UserCreatedEventConsumerFunctionalTests(FollowsFunctionalTestWebAppFactory followFunctionalTestWebAppFactory) : base(followFunctionalTestWebAppFactory)
        {
        }

        [Fact]
        public async Task Consume_ShouldNotCreateUser_WhenUserCreatedEventIsInvalid()
        {
            // Arrange
            var existingUserId = await CreateUserAsync(CancellationToken);
            var userCreatedEvent = new UserCreatedEvent(
                existingUserId,
                UserTestUtilities.ValidAddName,
                UserTestUtilities.ValidAddEmail,
                UserTestUtilities.ValidAddFirstName,
                UserTestUtilities.ValidAddLastName,
                UserTestUtilities.ValidAddProfileImage);

            // Act
            await TestHarness.Bus.Publish(userCreatedEvent, CancellationToken);
            await TestHarness.Published.Any<UserCreatedEvent>();
            await TestHarness.Consumed.Any<UserCreatedEvent>();

            var existingUser = await UserWriteRepository.GetByIdAsync(existingUserId, CancellationToken);

            // Assert
            existingUser
                .Should()
                .Match<User>(m => m.Id == existingUserId &&
                                  m.FirstName == UserTestUtilities.ValidFirstName &&
                                  m.LastName == UserTestUtilities.ValidLastName &&
                                  m.UserName == UserTestUtilities.ValidName &&
                                  m.Email == UserTestUtilities.ValidEmail &&
                                  m.ProfileImage == UserTestUtilities.ValidProfileImage);
        }

        [Fact]
        public async Task Consume_ShouldCreateUser_WhenUserCreatedEventIsValid()
        {
            // Arrange
            var existingUserId = await CreateUserAsync(CancellationToken);
            var userCreatedEvent = new UserCreatedEvent(
                UserTestUtilities.InvalidId,
                UserTestUtilities.ValidAddName,
                UserTestUtilities.ValidAddEmail,
                UserTestUtilities.ValidAddFirstName,
                UserTestUtilities.ValidAddLastName,
                UserTestUtilities.ValidAddProfileImage);

            // Act
            await TestHarness.Bus.Publish(userCreatedEvent, CancellationToken);
            await TestHarness.Published.Any<UserCreatedEvent>();
            await TestHarness.Consumed.Any<UserCreatedEvent>();
            
            var existingUser = await UserWriteRepository.GetByIdAsync(UserTestUtilities.InvalidId, CancellationToken);

            // Assert
            existingUser
                .Should()
                .Match<User>(m => m.Id == UserTestUtilities.InvalidId &&
                                  m.FirstName == UserTestUtilities.ValidAddFirstName &&
                                  m.LastName == UserTestUtilities.ValidAddLastName &&
                                  m.UserName == UserTestUtilities.ValidAddName &&
                                  m.Email == UserTestUtilities.ValidAddEmail &&
                                  m.ProfileImage == UserTestUtilities.ValidAddProfileImage);
        }

        [Fact]
        public async Task Consume_ShouldCreateUser_WhenUserCreatedEventIsValidAndIdCaseDoesNotMatch()
        {
            // Arrange
            var existingUserId = await CreateUserAsync(CancellationToken);
            var userCreatedEvent = new UserCreatedEvent(
                SharedTestUtilities.GetNonCaseMatchingString(UserTestUtilities.InvalidId),
                UserTestUtilities.ValidAddName,
                UserTestUtilities.ValidAddEmail,
                UserTestUtilities.ValidAddFirstName,
                UserTestUtilities.ValidAddLastName,
                UserTestUtilities.ValidAddProfileImage);

            // Act
            await TestHarness.Bus.Publish(userCreatedEvent, CancellationToken);
            await TestHarness.Published.Any<UserCreatedEvent>();
            await TestHarness.Consumed.Any<UserCreatedEvent>();
            
            var existingUser = await UserWriteRepository.GetByIdAsync(UserTestUtilities.InvalidId, CancellationToken);

            // Assert
            existingUser
                .Should()
                .Match<User>(m => m.Id == SharedTestUtilities.GetNonCaseMatchingString(UserTestUtilities.InvalidId) &&
                                  m.FirstName == UserTestUtilities.ValidAddFirstName &&
                                  m.LastName == UserTestUtilities.ValidAddLastName &&
                                  m.UserName == UserTestUtilities.ValidAddName &&
                                  m.Email == UserTestUtilities.ValidAddEmail &&
                                  m.ProfileImage == UserTestUtilities.ValidAddProfileImage);
        }

        [Fact]
        public async Task Consume_ShouldReceiveEvent_WhenUserCreatedEventIsRaised()
        {
            // Arrange
            var existingUserId = await CreateUserAsync(CancellationToken);
            var userCreatedEvent = new UserCreatedEvent(
                existingUserId,
                UserTestUtilities.ValidAddName,
                UserTestUtilities.ValidAddEmail,
                UserTestUtilities.ValidAddFirstName,
                UserTestUtilities.ValidAddLastName,
                UserTestUtilities.ValidAddProfileImage);

            // Act
            await TestHarness.Bus.Publish(userCreatedEvent, CancellationToken);
            await TestHarness.Published.Any<UserCreatedEvent>();
            await TestHarness.Consumed.Any<UserCreatedEvent>();
            
            var result = await TestHarness.Consumed.Any<UserCreatedEvent>(m =>
                                  m.Context.Message.Id == existingUserId &&
                                  m.Context.Message.FirstName == UserTestUtilities.ValidAddFirstName &&
                                  m.Context.Message.LastName == UserTestUtilities.ValidAddLastName &&
                                  m.Context.Message.UserName == UserTestUtilities.ValidAddName &&
                                  m.Context.Message.Email == UserTestUtilities.ValidAddEmail &&
                                  m.Context.Message.ProfileImage == UserTestUtilities.ValidAddProfileImage, CancellationToken);

            // Assert
            result.Should().BeTrue();
        }
    }
