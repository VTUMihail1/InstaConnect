using System.Net;
using FluentAssertions;
using InstaConnect.Posts.Business.Features.PostCommentLikes.Commands.AddPostCommentLike;
using InstaConnect.Posts.Business.Features.PostCommentLikes.Commands.DeletePostCommentLike;
using InstaConnect.Posts.Business.Features.PostCommentLikes.Queries.GetAllPostCommentLikes;
using InstaConnect.Posts.Business.Features.PostCommentLikes.Queries.GetPostCommentLikeById;
using InstaConnect.Posts.Common.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Web.Features.PostCommentLikes.Controllers.v1;
using InstaConnect.Posts.Web.Features.PostCommentLikes.Models.Requests;
using InstaConnect.Posts.Web.Features.PostCommentLikes.Models.Responses;
using InstaConnect.Posts.Web.UnitTests.Features.PostCommentLikes.Utilities;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace InstaConnect.Posts.Web.UnitTests.Features.PostCommentLikes.Controllers.v1;

public class PostCommentLikeControllerUnitTests : BasePostCommentLikeUnitTest
{
    private readonly PostCommentLikeController _postCommentLikeController;

    public PostCommentLikeControllerUnitTests()
    {
        _postCommentLikeController = new(
            InstaConnectMapper,
            InstaConnectSender,
            CurrentUserContext);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetAllPostCommentLikesRequest()
        {
            UserId = PostCommentLikeTestUtilities.ValidCurrentUserId,
            UserName = PostCommentLikeTestUtilities.ValidUserName,
            PostCommentId = PostCommentLikeTestUtilities.ValidPostCommentId,
            SortOrder = PostCommentLikeTestUtilities.ValidSortOrderProperty,
            SortPropertyName = PostCommentLikeTestUtilities.ValidSortPropertyName,
            Page = PostCommentLikeTestUtilities.ValidPageValue,
            PageSize = PostCommentLikeTestUtilities.ValidPageSizeValue,
        };

        // Act
        var response = await _postCommentLikeController.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.OK));
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnPostCommentLikePaginationQueryResponse_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetAllPostCommentLikesRequest()
        {
            UserId = PostCommentLikeTestUtilities.ValidCurrentUserId,
            UserName = PostCommentLikeTestUtilities.ValidUserName,
            PostCommentId = PostCommentLikeTestUtilities.ValidPostCommentId,
            SortOrder = PostCommentLikeTestUtilities.ValidSortOrderProperty,
            SortPropertyName = PostCommentLikeTestUtilities.ValidSortPropertyName,
            Page = PostCommentLikeTestUtilities.ValidPageValue,
            PageSize = PostCommentLikeTestUtilities.ValidPageSizeValue,
        };

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
                                                                 m.Id == PostCommentLikeTestUtilities.ValidId &&
                                                                 m.PostCommentId == PostCommentLikeTestUtilities.ValidPostCommentId &&
                                                                 m.UserId == PostCommentLikeTestUtilities.ValidCurrentUserId &&
                                                                 m.UserName == PostCommentLikeTestUtilities.ValidUserName &&
                                                                 m.UserProfileImage == PostCommentLikeTestUtilities.ValidUserProfileImage) &&
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
        var request = new GetAllPostCommentLikesRequest()
        {
            UserId = PostCommentLikeTestUtilities.ValidCurrentUserId,
            UserName = PostCommentLikeTestUtilities.ValidUserName,
            PostCommentId = PostCommentLikeTestUtilities.ValidPostCommentId,
            SortOrder = PostCommentLikeTestUtilities.ValidSortOrderProperty,
            SortPropertyName = PostCommentLikeTestUtilities.ValidSortPropertyName,
            Page = PostCommentLikeTestUtilities.ValidPageValue,
            PageSize = PostCommentLikeTestUtilities.ValidPageSizeValue,
        };

        // Act
        var response = await _postCommentLikeController.GetAllAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetAllPostCommentLikesQuery>(m =>
                  m.UserId == PostCommentLikeTestUtilities.ValidCurrentUserId &&
                  m.UserName == PostCommentLikeTestUtilities.ValidUserName &&
                  m.PostCommentId == PostCommentLikeTestUtilities.ValidPostCommentId &&
                  m.SortOrder == PostCommentLikeTestUtilities.ValidSortOrderProperty &&
                  m.SortPropertyName == PostCommentLikeTestUtilities.ValidSortPropertyName &&
                  m.Page == PostCommentLikeTestUtilities.ValidPageValue &&
                  m.PageSize == PostCommentLikeTestUtilities.ValidPageSizeValue), CancellationToken);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetPostCommentLikeByIdRequest()
        {
            Id = PostCommentLikeTestUtilities.ValidId
        };

        // Act
        var response = await _postCommentLikeController.GetByIdAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.OK));
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnMessageViewModel_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetPostCommentLikeByIdRequest()
        {
            Id = PostCommentLikeTestUtilities.ValidId
        };

        // Act
        var response = await _postCommentLikeController.GetByIdAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<PostCommentLikeQueryResponse>(m => m.Id == PostCommentLikeTestUtilities.ValidId &&
                                                 m.PostCommentId == PostCommentLikeTestUtilities.ValidPostCommentId &&
                                                 m.UserId == PostCommentLikeTestUtilities.ValidCurrentUserId &&
                                                 m.UserName == PostCommentLikeTestUtilities.ValidUserName &&
                                                 m.UserProfileImage == PostCommentLikeTestUtilities.ValidUserProfileImage);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        var request = new GetPostCommentLikeByIdRequest()
        {
            Id = PostCommentLikeTestUtilities.ValidId
        };

        // Act
        await _postCommentLikeController.GetByIdAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetPostCommentLikeByIdQuery>(m => m.Id == PostCommentLikeTestUtilities.ValidId), CancellationToken);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new AddPostCommentLikeRequest()
        {
            AddPostCommentLikeBindingModel = new(PostCommentLikeTestUtilities.ValidPostCommentId)
        };

        // Act
        var response = await _postCommentLikeController.AddAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.OK));
    }

    [Fact]
    public async Task AddAsync_ShouldReturnPostCommentLikeViewModel_WhenRequestIsValid()
    {
        // Arrange
        var request = new AddPostCommentLikeRequest()
        {
            AddPostCommentLikeBindingModel = new(PostCommentLikeTestUtilities.ValidPostCommentId)
        };

        // Act
        var response = await _postCommentLikeController.AddAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<PostCommentLikeCommandResponse>(m => m.Id == PostCommentLikeTestUtilities.ValidId);
    }

    [Fact]
    public async Task AddAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var request = new AddPostCommentLikeRequest()
        {
            AddPostCommentLikeBindingModel = new(PostCommentLikeTestUtilities.ValidPostCommentId)
        };

        // Act
        await _postCommentLikeController.AddAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
            .Received(1)
            .SendAsync(Arg.Is<AddPostCommentLikeCommand>(m => m.CurrentUserId == PostCommentLikeTestUtilities.ValidCurrentUserId &&
                                                     m.PostCommentId == PostCommentLikeTestUtilities.ValidPostCommentId),
                                                     CancellationToken);
    }

    [Fact]
    public async Task AddAsync_ShouldCallTheCurrentUserContext_WhenRequestIsValid()
    {
        // Arrange
        var request = new AddPostCommentLikeRequest()
        {
            AddPostCommentLikeBindingModel = new(PostCommentLikeTestUtilities.ValidPostCommentId)
        };

        // Act
        await _postCommentLikeController.AddAsync(request, CancellationToken);

        // Assert
        CurrentUserContext
            .Received(1)
            .GetCurrentUser();
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new DeletePostCommentLikeRequest()
        {
            Id = PostCommentLikeTestUtilities.ValidId
        };

        // Act
        var response = await _postCommentLikeController.DeleteAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<NoContentResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.NoContent));
    }

    [Fact]
    public async Task DeleteAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var request = new DeletePostCommentLikeRequest()
        {
            Id = PostCommentLikeTestUtilities.ValidId
        };

        // Act
        await _postCommentLikeController.DeleteAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
            .Received(1)
            .SendAsync(Arg.Is<DeletePostCommentLikeCommand>(m => m.Id == PostCommentLikeTestUtilities.ValidId &&
                                                    m.CurrentUserId == PostCommentLikeTestUtilities.ValidCurrentUserId),
                                                    CancellationToken);
    }

    [Fact]
    public async Task DeleteAsync_ShouldCallTheCurrentUserContext_WhenRequestIsValid()
    {
        // Arrange
        var request = new DeletePostCommentLikeRequest()
        {
            Id = PostCommentLikeTestUtilities.ValidId
        };

        // Act
        await _postCommentLikeController.DeleteAsync(request, CancellationToken);

        // Assert
        CurrentUserContext
            .Received(1)
            .GetCurrentUser();
    }
}
