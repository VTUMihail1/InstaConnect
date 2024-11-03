using System.Net;
using FluentAssertions;
using InstaConnect.Follows.Business.Features.Follows.Queries.GetFollowById;
using InstaConnect.Follows.Common.Features.Follows.Utilities;
using InstaConnect.Follows.Common.Features.Users.Utilities;
using InstaConnect.Follows.Web.Features.Follows.Controllers.v1;
using InstaConnect.Follows.Web.Features.Follows.Models.Requests;
using InstaConnect.Follows.Web.Features.Follows.Models.Responses;
using InstaConnect.Follows.Web.UnitTests.Features.Follows.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace InstaConnect.Follows.Web.UnitTests.Features.Follows.Controllers.v1;

public class GetFollowByIdUnitTests : BaseFollowUnitTest
{
    private readonly FollowController _followController;

    public GetFollowByIdUnitTests()
    {
        _followController = new(
            InstaConnectMapper,
            InstaConnectSender,
            CurrentUserContext);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var existingCurrentUserId = CreateCurrentUser();
        var existingFollowingId = CreateUser();
        var existingFollowId = CreateFollow(existingCurrentUserId, existingFollowingId);
        var request = new GetFollowByIdRequest()
        {
            Id = existingFollowId
        };

        // Act
        var response = await _followController.GetByIdAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == StatusCodes.Status200OK);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnMessageViewModel_WhenRequestIsValid()
    {
        // Arrange
        var existingCurrentUserId = CreateCurrentUser();
        var existingFollowingId = CreateUser();
        var existingFollowId = CreateFollow(existingCurrentUserId, existingFollowingId);
        var request = new GetFollowByIdRequest()
        {
            Id = existingFollowId
        };

        // Act
        var response = await _followController.GetByIdAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<FollowQueryResponse>(m => m.Id == existingFollowId &&
                                                 m.FollowerId == existingCurrentUserId &&
                                                 m.FollowerName == UserTestUtilities.ValidName &&
                                                 m.FollowerProfileImage == UserTestUtilities.ValidProfileImage &&
                                                 m.FollowingId == existingFollowingId &&
                                                 m.FollowingName == UserTestUtilities.ValidName &&
                                                 m.FollowingProfileImage == UserTestUtilities.ValidProfileImage);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var existingCurrentUserId = CreateCurrentUser();
        var existingFollowingId = CreateUser();
        var existingFollowId = CreateFollow(existingCurrentUserId, existingFollowingId);
        var request = new GetFollowByIdRequest()
        {
            Id = existingFollowId
        };

        // Act
        await _followController.GetByIdAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetFollowByIdQuery>(m => m.Id == existingFollowId), CancellationToken);
    }
}
