using FluentAssertions;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAll;
using InstaConnect.Posts.Common.Features.PostLikes.Utilities;
using InstaConnect.Posts.Presentation.Features.PostLikes.Controllers.v1;
using InstaConnect.Posts.Presentation.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Presentation.Features.PostLikes.Models.Responses;
using InstaConnect.Posts.Presentation.UnitTests.Features.PostLikes.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace InstaConnect.Posts.Presentation.UnitTests.Features.PostLikes.Controllers.v1;

public class GetAllPostLikeControllerUnitTests : BasePostLikeUnitTest
{
    private readonly PostLikeController _postLikeController;

    public GetAllPostLikeControllerUnitTests()
    {
        _postLikeController = new(
            InstaConnectMapper,
            InstaConnectSender);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var existingPostLike = CreatePostLike();
        var request = new GetAllPostLikesRequest(
            existingPostLike.UserId,
            existingPostLike.User.UserName,
            existingPostLike.PostId,
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue
        );

        // Act
        var response = await _postLikeController.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == StatusCodes.Status200OK);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnPostLikePaginationQueryResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingPostLike = CreatePostLike();
        var request = new GetAllPostLikesRequest(
            existingPostLike.UserId,
            existingPostLike.User.UserName,
            existingPostLike.PostId,
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue
        );

        // Act
        var response = await _postLikeController.GetAllAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<PostLikePaginationQueryResponse>(mc => mc.Items.All(m =>
                                                                 m.Id == existingPostLike.Id &&
                                                                 m.PostId == existingPostLike.PostId &&
                                                                 m.UserId == existingPostLike.UserId &&
                                                                 m.UserName == existingPostLike.User.UserName &&
                                                                 m.UserProfileImage == existingPostLike.User.ProfileImage) &&
                                                              mc.Page == PostLikeTestUtilities.ValidPageValue &&
                                                              mc.PageSize == PostLikeTestUtilities.ValidPageSizeValue &&
                                                              mc.TotalCount == PostLikeTestUtilities.ValidTotalCountValue &&
                                                              !mc.HasNextPage &&
                                                              !mc.HasPreviousPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var existingPostLike = CreatePostLike();
        var request = new GetAllPostLikesRequest(
            existingPostLike.UserId,
            existingPostLike.User.UserName,
            existingPostLike.PostId,
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue
        );

        // Act
        var response = await _postLikeController.GetAllAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetAllPostLikesQuery>(m =>
                  m.UserId == existingPostLike.UserId &&
                  m.UserName == existingPostLike.User.UserName &&
                  m.PostId == existingPostLike.PostId &&
                  m.SortOrder == PostLikeTestUtilities.ValidSortOrderProperty &&
                  m.SortPropertyName == PostLikeTestUtilities.ValidSortPropertyName &&
                  m.Page == PostLikeTestUtilities.ValidPageValue &&
                  m.PageSize == PostLikeTestUtilities.ValidPageSizeValue), CancellationToken);
    }
}
