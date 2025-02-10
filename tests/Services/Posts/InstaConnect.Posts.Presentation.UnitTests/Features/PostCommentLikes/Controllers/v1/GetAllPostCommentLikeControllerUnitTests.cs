using System.Net;
using FluentAssertions;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.AddPostCommentLike;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.DeletePostCommentLike;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAllPostCommentLikes;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetPostCommentLikeById;
using InstaConnect.Posts.Common.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;
using InstaConnect.Posts.Presentation.Features.PostCommentLikes.Controllers.v1;
using InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Requests;
using InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Responses;
using InstaConnect.Posts.Presentation.UnitTests.Features.PostCommentLikes.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace InstaConnect.Posts.Presentation.UnitTests.Features.PostCommentLikes.Controllers.v1;

public class GetAllPostCommentLikeControllerUnitTests : BasePostCommentLikeUnitTest
{
    private readonly PostCommentLikeController _postCommentLikeController;

    public GetAllPostCommentLikeControllerUnitTests()
    {
        _postCommentLikeController = new(
            InstaConnectMapper,
            InstaConnectSender);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var existingPostCommentLike = CreatePostCommentLike();
        var request = new GetAllPostCommentLikesRequest(
            existingPostCommentLike.UserId,
            UserTestUtilities.ValidName,
            existingPostCommentLike.PostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue
        );

        // Act
        var response = await _postCommentLikeController.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == StatusCodes.Status200OK);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnPostCommentLikePaginationQueryResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingPostCommentLike = CreatePostCommentLike();
        var request = new GetAllPostCommentLikesRequest(
            existingPostCommentLike.UserId,
            UserTestUtilities.ValidName,
            existingPostCommentLike.PostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue
        );

        // Act
        var response = await _postCommentLikeController.GetAllAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<PostCommentLikePaginationQueryResponse>(mc => mc.Items.All(m =>
                                                                 m.Id == existingPostCommentLike.Id &&
                                                                 m.PostCommentId == existingPostCommentLike.PostCommentId &&
                                                                 m.UserId == existingPostCommentLike.UserId &&
                                                                 m.UserName == UserTestUtilities.ValidName &&
                                                                 m.UserProfileImage == UserTestUtilities.ValidProfileImage) &&
                                                              mc.Page == PostCommentLikeTestUtilities.ValidPageValue &&
                                                              mc.PageSize == PostCommentLikeTestUtilities.ValidPageSizeValue &&
                                                              mc.TotalCount == PostCommentLikeTestUtilities.ValidTotalCountValue &&
                                                              !mc.HasNextPage &&
                                                              !mc.HasPreviousPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var existingPostCommentLike = CreatePostCommentLike();
        var request = new GetAllPostCommentLikesRequest(
            existingPostCommentLike.UserId,
            UserTestUtilities.ValidName,
            existingPostCommentLike.PostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue
        );

        // Act
        var response = await _postCommentLikeController.GetAllAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetAllPostCommentLikesQuery>(m =>
                  m.UserId == existingPostCommentLike.UserId &&
                  m.UserName == UserTestUtilities.ValidName &&
                  m.PostCommentId == existingPostCommentLike.PostCommentId &&
                  m.SortOrder == PostCommentLikeTestUtilities.ValidSortOrderProperty &&
                  m.SortPropertyName == PostCommentLikeTestUtilities.ValidSortPropertyName &&
                  m.Page == PostCommentLikeTestUtilities.ValidPageValue &&
                  m.PageSize == PostCommentLikeTestUtilities.ValidPageSizeValue), CancellationToken);
    }
}
