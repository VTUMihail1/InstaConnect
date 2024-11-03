using System.Net;
using FluentAssertions;
using InstaConnect.Posts.Business.Features.PostLikes.Commands.AddPostLike;
using InstaConnect.Posts.Business.Features.PostLikes.Commands.DeletePostLike;
using InstaConnect.Posts.Business.Features.PostLikes.Queries.GetAllPostLikes;
using InstaConnect.Posts.Business.Features.PostLikes.Queries.GetPostLikeById;
using InstaConnect.Posts.Common.Features.PostLikes.Utilities;
using InstaConnect.Posts.Web.Features.PostLikes.Controllers.v1;
using InstaConnect.Posts.Web.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Web.Features.PostLikes.Models.Responses;
using InstaConnect.Posts.Web.UnitTests.Features.PostLikes.Utilities;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace InstaConnect.Posts.Web.UnitTests.Features.PostLikes.Controllers.v1;

public class PostLikeControllerUnitTests : BasePostLikeUnitTest
{
    private readonly PostLikeController _postLikeController;

    public PostLikeControllerUnitTests()
    {
        _postLikeController = new(
            InstaConnectMapper,
            InstaConnectSender,
            CurrentUserContext);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetAllPostLikesRequest()
        {
            UserId = PostLikeTestUtilities.ValidCurrentUserId,
            UserName = PostLikeTestUtilities.ValidUserName,
            PostId = PostLikeTestUtilities.ValidPostId,
            SortOrder = PostLikeTestUtilities.ValidSortOrderProperty,
            SortPropertyName = PostLikeTestUtilities.ValidSortPropertyName,
            Page = PostLikeTestUtilities.ValidPageValue,
            PageSize = PostLikeTestUtilities.ValidPageSizeValue,
        };

        // Act
        var response = await _postLikeController.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.OK));
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnPostLikePaginationQueryResponse_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetAllPostLikesRequest()
        {
            UserId = PostLikeTestUtilities.ValidCurrentUserId,
            UserName = PostLikeTestUtilities.ValidUserName,
            PostId = PostLikeTestUtilities.ValidPostId,
            SortOrder = PostLikeTestUtilities.ValidSortOrderProperty,
            SortPropertyName = PostLikeTestUtilities.ValidSortPropertyName,
            Page = PostLikeTestUtilities.ValidPageValue,
            PageSize = PostLikeTestUtilities.ValidPageSizeValue,
        };

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
                                                                 m.Id == PostLikeTestUtilities.ValidId &&
                                                                 m.PostId == PostLikeTestUtilities.ValidPostId &&
                                                                 m.UserId == PostLikeTestUtilities.ValidCurrentUserId &&
                                                                 m.UserName == PostLikeTestUtilities.ValidUserName &&
                                                                 m.UserProfileImage == PostLikeTestUtilities.ValidUserProfileImage) &&
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
        var request = new GetAllPostLikesRequest()
        {
            UserId = PostLikeTestUtilities.ValidCurrentUserId,
            UserName = PostLikeTestUtilities.ValidUserName,
            PostId = PostLikeTestUtilities.ValidPostId,
            SortOrder = PostLikeTestUtilities.ValidSortOrderProperty,
            SortPropertyName = PostLikeTestUtilities.ValidSortPropertyName,
            Page = PostLikeTestUtilities.ValidPageValue,
            PageSize = PostLikeTestUtilities.ValidPageSizeValue,
        };

        // Act
        var response = await _postLikeController.GetAllAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetAllPostLikesQuery>(m =>
                  m.UserId == PostLikeTestUtilities.ValidCurrentUserId &&
                  m.UserName == PostLikeTestUtilities.ValidUserName &&
                  m.PostId == PostLikeTestUtilities.ValidPostId &&
                  m.SortOrder == PostLikeTestUtilities.ValidSortOrderProperty &&
                  m.SortPropertyName == PostLikeTestUtilities.ValidSortPropertyName &&
                  m.Page == PostLikeTestUtilities.ValidPageValue &&
                  m.PageSize == PostLikeTestUtilities.ValidPageSizeValue), CancellationToken);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetPostLikeByIdRequest()
        {
            Id = PostLikeTestUtilities.ValidId
        };

        // Act
        var response = await _postLikeController.GetByIdAsync(request, CancellationToken);

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
        var request = new GetPostLikeByIdRequest()
        {
            Id = PostLikeTestUtilities.ValidId
        };

        // Act
        var response = await _postLikeController.GetByIdAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<PostLikeQueryResponse>(m => m.Id == PostLikeTestUtilities.ValidId &&
                                                 m.PostId == PostLikeTestUtilities.ValidPostId &&
                                                 m.UserId == PostLikeTestUtilities.ValidCurrentUserId &&
                                                 m.UserName == PostLikeTestUtilities.ValidUserName &&
                                                 m.UserProfileImage == PostLikeTestUtilities.ValidUserProfileImage);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        var request = new GetPostLikeByIdRequest()
        {
            Id = PostLikeTestUtilities.ValidId
        };

        // Act
        await _postLikeController.GetByIdAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetPostLikeByIdQuery>(m => m.Id == PostLikeTestUtilities.ValidId), CancellationToken);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new AddPostLikeRequest()
        {
            AddPostLikeBindingModel = new(PostLikeTestUtilities.ValidPostId)
        };

        // Act
        var response = await _postLikeController.AddAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.OK));
    }

    [Fact]
    public async Task AddAsync_ShouldReturnPostLikeViewModel_WhenRequestIsValid()
    {
        // Arrange
        var request = new AddPostLikeRequest()
        {
            AddPostLikeBindingModel = new(PostLikeTestUtilities.ValidPostId)
        };

        // Act
        var response = await _postLikeController.AddAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<PostLikeCommandResponse>(m => m.Id == PostLikeTestUtilities.ValidId);
    }

    [Fact]
    public async Task AddAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var request = new AddPostLikeRequest()
        {
            AddPostLikeBindingModel = new(PostLikeTestUtilities.ValidPostId)
        };

        // Act
        await _postLikeController.AddAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
            .Received(1)
            .SendAsync(Arg.Is<AddPostLikeCommand>(m => m.CurrentUserId == PostLikeTestUtilities.ValidCurrentUserId &&
                                                     m.PostId == PostLikeTestUtilities.ValidPostId),
                                                     CancellationToken);
    }

    [Fact]
    public async Task AddAsync_ShouldCallTheCurrentUserContext_WhenRequestIsValid()
    {
        // Arrange
        var request = new AddPostLikeRequest()
        {
            AddPostLikeBindingModel = new(PostLikeTestUtilities.ValidPostId)
        };

        // Act
        await _postLikeController.AddAsync(request, CancellationToken);

        // Assert
        CurrentUserContext
            .Received(1)
            .GetCurrentUser();
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new DeletePostLikeRequest()
        {
            Id = PostLikeTestUtilities.ValidId
        };

        // Act
        var response = await _postLikeController.DeleteAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<NoContentResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.NoContent));
    }

    [Fact]
    public async Task DeleteAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var request = new DeletePostLikeRequest()
        {
            Id = PostLikeTestUtilities.ValidId
        };

        // Act
        await _postLikeController.DeleteAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
            .Received(1)
            .SendAsync(Arg.Is<DeletePostLikeCommand>(m => m.Id == PostLikeTestUtilities.ValidId &&
                                                    m.CurrentUserId == PostLikeTestUtilities.ValidCurrentUserId),
                                                    CancellationToken);
    }

    [Fact]
    public async Task DeleteAsync_ShouldCallTheCurrentUserContext_WhenRequestIsValid()
    {
        // Arrange
        var request = new DeletePostLikeRequest()
        {
            Id = PostLikeTestUtilities.ValidId
        };

        // Act
        await _postLikeController.DeleteAsync(request, CancellationToken);

        // Assert
        CurrentUserContext
            .Received(1)
            .GetCurrentUser();
    }
}
