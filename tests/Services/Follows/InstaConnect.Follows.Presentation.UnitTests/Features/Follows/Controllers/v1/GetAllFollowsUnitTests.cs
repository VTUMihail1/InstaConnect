using System.Net;
using FluentAssertions;
using InstaConnect.Follows.Business.Features.Follows.Commands.AddFollow;
using InstaConnect.Follows.Business.Features.Follows.Commands.DeleteFollow;
using InstaConnect.Follows.Business.Features.Follows.Queries.GetAllFollows;
using InstaConnect.Follows.Business.Features.Follows.Queries.GetFollowById;
using InstaConnect.Follows.Common.Features.Follows.Utilities;
using InstaConnect.Follows.Common.Features.Users.Utilities;
using InstaConnect.Follows.Web.Features.Follows.Controllers.v1;
using InstaConnect.Follows.Web.Features.Follows.Models.Binding;
using InstaConnect.Follows.Web.Features.Follows.Models.Requests;
using InstaConnect.Follows.Web.Features.Follows.Models.Responses;
using InstaConnect.Follows.Web.UnitTests.Features.Follows.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace InstaConnect.Follows.Web.UnitTests.Features.Follows.Controllers.v1;
public class GetAllFollowsUnitTests : BaseFollowUnitTest
{
    private readonly FollowController _followController;

    public GetAllFollowsUnitTests()
    {
        _followController = new(
            InstaConnectMapper,
            InstaConnectSender,
            CurrentUserContext);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var existingCurrentUserId = CreateCurrentUser();
        var existingFollowingId = CreateUser();
        var existingFollowId = CreateFollow(existingCurrentUserId, existingFollowingId);
        var request = new GetAllFollowsRequest()
        {
            FollowerId = existingCurrentUserId,
            FollowerName = UserTestUtilities.ValidName,
            FollowingId = existingFollowingId,
            FollowingName = UserTestUtilities.ValidName,
            SortOrder = FollowTestUtilities.ValidSortOrderProperty,
            SortPropertyName = FollowTestUtilities.ValidSortPropertyName,
            Page = FollowTestUtilities.ValidPageValue,
            PageSize = FollowTestUtilities.ValidPageSizeValue,
        };

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
        var existingCurrentUserId = CreateCurrentUser();
        var existingFollowingId = CreateUser();
        var existingFollowId = CreateFollow(existingCurrentUserId, existingFollowingId);
        var request = new GetAllFollowsRequest()
        {
            FollowerId = existingCurrentUserId,
            FollowerName = UserTestUtilities.ValidName,
            FollowingId = existingFollowingId,
            FollowingName = UserTestUtilities.ValidName,
            SortOrder = FollowTestUtilities.ValidSortOrderProperty,
            SortPropertyName = FollowTestUtilities.ValidSortPropertyName,
            Page = FollowTestUtilities.ValidPageValue,
            PageSize = FollowTestUtilities.ValidPageSizeValue,
        };

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
                                                                 m.Id == existingFollowId &&
                                                                 m.FollowerId == existingCurrentUserId &&
                                                                 m.FollowerName == UserTestUtilities.ValidName &&
                                                                 m.FollowerProfileImage == UserTestUtilities.ValidProfileImage &&
                                                                 m.FollowingId == existingFollowingId &&
                                                                 m.FollowingName == UserTestUtilities.ValidName &&
                                                                 m.FollowingProfileImage == UserTestUtilities.ValidProfileImage) &&
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
        var existingCurrentUserId = CreateCurrentUser();
        var existingFollowingId = CreateUser();
        var existingFollowId = CreateFollow(existingCurrentUserId, existingFollowingId);
        var request = new GetAllFollowsRequest()
        {
            FollowerId = existingCurrentUserId,
            FollowerName = UserTestUtilities.ValidName,
            FollowingId = existingFollowingId,
            FollowingName = UserTestUtilities.ValidName,
            SortOrder = FollowTestUtilities.ValidSortOrderProperty,
            SortPropertyName = FollowTestUtilities.ValidSortPropertyName,
            Page = FollowTestUtilities.ValidPageValue,
            PageSize = FollowTestUtilities.ValidPageSizeValue,
        };

        // Act
        var response = await _followController.GetAllAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetAllFollowsQuery>(m =>
                  m.FollowerId == existingCurrentUserId &&
                  m.FollowerName == UserTestUtilities.ValidName &&
                  m.FollowingId == existingFollowingId &&
                  m.FollowingName == UserTestUtilities.ValidName &&
                  m.SortOrder == FollowTestUtilities.ValidSortOrderProperty &&
                  m.SortPropertyName == FollowTestUtilities.ValidSortPropertyName &&
                  m.Page == FollowTestUtilities.ValidPageValue &&
                  m.PageSize == FollowTestUtilities.ValidPageSizeValue), CancellationToken);
    }
}
