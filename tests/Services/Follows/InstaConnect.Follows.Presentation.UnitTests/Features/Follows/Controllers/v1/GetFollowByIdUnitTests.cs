using FluentAssertions;
using InstaConnect.Follows.Application.Features.Follows.Queries.GetFollowById;
using InstaConnect.Follows.Common.Features.Users.Utilities;
using InstaConnect.Follows.Presentation.Features.Follows.Controllers.v1;
using InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;
using InstaConnect.Follows.Presentation.Features.Follows.Models.Responses;
using InstaConnect.Follows.Presentation.UnitTests.Features.Follows.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace InstaConnect.Follows.Presentation.UnitTests.Features.Follows.Controllers.v1;

public class GetFollowByIdUnitTests : BaseFollowUnitTest
{
    private readonly FollowController _followController;

    public GetFollowByIdUnitTests()
    {
        _followController = new(
            InstaConnectMapper,
            InstaConnectSender);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var existingFollow = CreateFollow();
        var request = new GetFollowByIdRequest()
        {
            Id = existingFollow.Id
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
        var existingFollow = CreateFollow();
        var request = new GetFollowByIdRequest()
        {
            Id = existingFollow.Id
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
            .Match<FollowQueryResponse>(m => m.Id == existingFollow.Id &&
                                                 m.FollowerId == existingFollow.FollowerId &&
                                                 m.FollowerName == UserTestUtilities.ValidName &&
                                                 m.FollowerProfileImage == UserTestUtilities.ValidProfileImage &&
                                                 m.FollowingId == existingFollow.FollowingId &&
                                                 m.FollowingName == UserTestUtilities.ValidName &&
                                                 m.FollowingProfileImage == UserTestUtilities.ValidProfileImage);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var existingFollow = CreateFollow();
        var request = new GetFollowByIdRequest()
        {
            Id = existingFollow.Id
        };

        // Act
        await _followController.GetByIdAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetFollowByIdQuery>(m => m.Id == existingFollow.Id), CancellationToken);
    }
}
