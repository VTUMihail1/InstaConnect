﻿using System.Net;
using FluentAssertions;
using InstaConnect.Follows.Common.Features.Follows.Utilities;
using InstaConnect.Follows.Common.Features.Users.Utilities;
using InstaConnect.Follows.Domain.Features.Follows.Models.Entities;
using InstaConnect.Follows.Presentation.Features.Follows.Models.Binding;
using InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;
using InstaConnect.Follows.Presentation.FunctionalTests.Features.Follows.Utilities;
using InstaConnect.Follows.Presentation.FunctionalTests.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Follows.Presentation.FunctionalTests.Features.Follows.Controllers.v1;

public class AddFollowFunctionalTests : BaseFollowFunctionalTest
{
    public AddFollowFunctionalTests(FollowsFunctionalTestWebAppFactory followsFunctionalTestWebAppFactory) : base(followsFunctionalTestWebAppFactory)
    {

    }

    [Fact]
    public async Task AddAsync_ShouldReturnUnauthorizedResponse_WhenUserIsUnauthorized()
    {
        // Arrange
        var existingFollowing = await CreateUserAsync(CancellationToken);
        var existingFollower = await CreateUserAsync(CancellationToken);
        var request = new AddFollowRequest
        {
            CurrentUserId = existingFollower.Id,
            AddFollowBindingModel = new AddFollowBindingModel(existingFollowing.Id)
        };

        // Act
        var statusCode = await FollowsClient.AddStatusCodeUnauthorizedAsync(request, CancellationToken);

        // Assert
        statusCode
            .Should()
            .Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenFollowingIdIsNull()
    {
        // Arrange
        var existingFollowing = await CreateUserAsync(CancellationToken);
        var request = new AddFollowRequest
        {
            CurrentUserId = existingFollowing.Id,
            AddFollowBindingModel = new AddFollowBindingModel(null!)
        };

        // Act
        var statusCode = await FollowsClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        statusCode
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenFollowingIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingFollower = await CreateUserAsync(CancellationToken);
        var request = new AddFollowRequest
        {
            CurrentUserId = existingFollower.Id,
            AddFollowBindingModel = new AddFollowBindingModel(SharedTestUtilities.GetString(length))
        };

        // Act
        var statusCode = await FollowsClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        statusCode
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var existingFollowing = await CreateUserAsync(CancellationToken);
        var request = new AddFollowRequest
        {
            CurrentUserId = null!,
            AddFollowBindingModel = new AddFollowBindingModel(existingFollowing.Id)
        };

        // Act
        var statusCode = await FollowsClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        statusCode
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(FollowConfigurations.IdMinLength - 1)]
    [InlineData(FollowConfigurations.IdMaxLength + 1)]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingFollowing = await CreateUserAsync(CancellationToken);
        var request = new AddFollowRequest
        {
            CurrentUserId = SharedTestUtilities.GetString(length),
            AddFollowBindingModel = new AddFollowBindingModel(existingFollowing.Id)
        };

        // Act
        var statusCode = await FollowsClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        statusCode
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnNotFoundResponse_WhenCurrentUserIdIsInvalid()
    {
        // Arrange
        var existingFollowing = await CreateUserAsync(CancellationToken);
        var request = new AddFollowRequest
        {
            CurrentUserId = UserTestUtilities.InvalidId,
            AddFollowBindingModel = new AddFollowBindingModel(existingFollowing.Id)
        };

        // Act
        var statusCode = await FollowsClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        statusCode
            .Should()
            .Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnNotFoundResponse_WhenFollowingIdIsInvalid()
    {
        // Arrange
        var existingFollower = await CreateUserAsync(CancellationToken);
        var request = new AddFollowRequest
        {
            CurrentUserId = existingFollower.Id,
            AddFollowBindingModel = new AddFollowBindingModel(FollowTestUtilities.InvalidId)
        };

        // Act
        var statusCode = await FollowsClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        statusCode
            .Should()
            .Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenFollowAlreadyExists()
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var request = new AddFollowRequest
        {
            CurrentUserId = existingFollow.FollowerId,
            AddFollowBindingModel = new AddFollowBindingModel(existingFollow.FollowingId)
        };

        // Act
        var statusCode = await FollowsClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        statusCode
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingFollower = await CreateUserAsync(CancellationToken);
        var existingFollowing = await CreateUserAsync(CancellationToken);
        var request = new AddFollowRequest
        {
            CurrentUserId = existingFollower.Id,
            AddFollowBindingModel = new AddFollowBindingModel(existingFollowing.Id)
        };

        // Act
        var statusCode = await FollowsClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        statusCode
            .Should()
            .Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task AddAsync_ShouldAddFollow_WhenRequestIsValid()
    {
        // Arrange
        var existingFollower = await CreateUserAsync(CancellationToken);
        var existingFollowing = await CreateUserAsync(CancellationToken);
        var request = new AddFollowRequest
        {
            CurrentUserId = existingFollower.Id,
            AddFollowBindingModel = new AddFollowBindingModel(existingFollowing.Id)
        };

        // Act
        var response = await FollowsClient.AddAsync(request, CancellationToken);
        var message = await FollowWriteRepository.GetByIdAsync(response!.Id, CancellationToken);

        // Assert
        message
            .Should()
            .Match<Follow>(m => m.Id == response.Id &&
                                 m.FollowerId == existingFollower.Id &&
                                 m.FollowingId == existingFollowing.Id);
    }
}
