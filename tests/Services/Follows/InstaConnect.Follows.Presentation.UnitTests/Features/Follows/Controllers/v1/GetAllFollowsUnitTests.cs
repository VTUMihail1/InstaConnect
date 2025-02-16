using FluentAssertions;

using InstaConnect.Follows.Application.Features.Follows.Queries.GetAll;
using InstaConnect.Follows.Common.Features.Follows.Utilities;
using InstaConnect.Follows.Presentation.Features.Follows.Controllers.v1;
using InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;
using InstaConnect.Follows.Presentation.Features.Follows.Models.Responses;
using InstaConnect.Follows.Presentation.UnitTests.Features.Follows.Utilities;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using NSubstitute;

namespace InstaConnect.Follows.Presentation.UnitTests.Features.Follows.Controllers.v1;
public class GetAllFollowsUnitTests : BaseFollowUnitTest
{
    private readonly FollowController _followController;

    public GetAllFollowsUnitTests()
    {
        _followController = new(
            InstaConnectMapper,
            InstaConnectSender);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var existingFollow = CreateFollow();
        var request = new GetAllFollowsRequest(
            existingFollow.FollowerId,
            existingFollow.Follower.UserName,
            existingFollow.FollowingId,
            existingFollow.Following.UserName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue
        );

        // Act
        var response = await _followController.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == StatusCodes.Status200OK);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnFollowPaginationQueryResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingFollow = CreateFollow();
        var request = new GetAllFollowsRequest(
            existingFollow.FollowerId,
            existingFollow.Follower.UserName,
            existingFollow.FollowingId,
            existingFollow.Following.UserName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue
        );

        // Act
        var response = await _followController.GetAllAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<FollowPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                                 m.Id == existingFollow.Id &&
                                                                 m.FollowerId == existingFollow.FollowerId &&
                                                                 m.FollowerName == existingFollow.Follower.UserName &&
                                                                 m.FollowerProfileImage == existingFollow.Follower.ProfileImage &&
                                                                 m.FollowingId == existingFollow.FollowingId &&
                                                                 m.FollowingName == existingFollow.Following.UserName &&
                                                                 m.FollowingProfileImage == existingFollow.Following.ProfileImage) &&
                                                              mc.Page == FollowTestUtilities.ValidPageValue &&
                                                              mc.PageSize == FollowTestUtilities.ValidPageSizeValue &&
                                                              mc.TotalCount == FollowTestUtilities.ValidTotalCountValue &&
                                                              !mc.HasNextPage &&
                                                              !mc.HasPreviousPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var existingFollow = CreateFollow();
        var request = new GetAllFollowsRequest(
            existingFollow.FollowerId,
            existingFollow.Follower.UserName,
            existingFollow.FollowingId,
            existingFollow.Following.UserName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue
        );

        // Act
        var response = await _followController.GetAllAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetAllFollowsQuery>(m =>
                  m.FollowerId == existingFollow.FollowerId &&
                  m.FollowerName == existingFollow.Follower.UserName &&
                  m.FollowingId == existingFollow.FollowingId &&
                  m.FollowingName == existingFollow.Following.UserName &&
                  m.SortOrder == FollowTestUtilities.ValidSortOrderProperty &&
                  m.SortPropertyName == FollowTestUtilities.ValidSortPropertyName &&
                  m.Page == FollowTestUtilities.ValidPageValue &&
                  m.PageSize == FollowTestUtilities.ValidPageSizeValue), CancellationToken);
    }
}
