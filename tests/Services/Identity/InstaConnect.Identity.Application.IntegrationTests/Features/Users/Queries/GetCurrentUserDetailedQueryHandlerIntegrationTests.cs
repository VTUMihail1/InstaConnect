﻿using FluentAssertions;
using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentUserDetailed;
using InstaConnect.Identity.Application.IntegrationTests.Features.Users.Utilities;
using InstaConnect.Identity.Application.IntegrationTests.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Exceptions.User;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Identity.Application.IntegrationTests.Features.Users.Queries;

public class GetCurrentDetailedUserQueryHandlerIntegrationTests : BaseUserIntegrationTest
{
    public GetCurrentDetailedUserQueryHandlerIntegrationTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var query = new GetCurrentDetailedUserQuery(null!);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var query = new GetCurrentDetailedUserQuery(SharedTestUtilities.GetString(length));

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var query = new GetCurrentDetailedUserQuery(UserTestUtilities.InvalidId);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task SendAsync_ShouldReturnUserViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var query = new GetCurrentDetailedUserQuery(existingUserId);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserDetailedQueryViewModel>(m => m.Id == existingUserId &&
                                          m.UserName == UserTestUtilities.ValidName &&
                                          m.FirstName == UserTestUtilities.ValidFirstName &&
                                          m.LastName == UserTestUtilities.ValidLastName &&
                                          m.ProfileImage == UserTestUtilities.ValidProfileImage &&
                                          m.Email == UserTestUtilities.ValidEmail);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnUserViewModelCollection_WhenQueryIsValidAndCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var query = new GetCurrentDetailedUserQuery(SharedTestUtilities.GetNonCaseMatchingString(existingUserId));

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserDetailedQueryViewModel>(m => m.Id == existingUserId &&
                                          m.UserName == UserTestUtilities.ValidName &&
                                          m.FirstName == UserTestUtilities.ValidFirstName &&
                                          m.LastName == UserTestUtilities.ValidLastName &&
                                          m.ProfileImage == UserTestUtilities.ValidProfileImage &&
                                          m.Email == UserTestUtilities.ValidEmail);
    }

    [Fact]
    public async Task SendAsync_ShouldSaveUserDetailedViewModelCollectionToCacheService_WhenQueryIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var query = new GetCurrentDetailedUserQuery(existingUserId);

        // Act
        await InstaConnectSender.SendAsync(query, CancellationToken);

        var result = await CacheHandler.GetAsync<UserDetailedQueryViewModel>(query.Key, CancellationToken);

        // Assert
        result
            .Should()
            .Match<UserDetailedQueryViewModel>(m => m.Id == existingUserId &&
                                          m.UserName == UserTestUtilities.ValidName &&
                                          m.FirstName == UserTestUtilities.ValidFirstName &&
                                          m.LastName == UserTestUtilities.ValidLastName &&
                                          m.ProfileImage == UserTestUtilities.ValidProfileImage &&
                                          m.Email == UserTestUtilities.ValidEmail);
    }
}
