using System.Net;
using FluentAssertions;
using InstaConnect.Posts.Business.Features.PostCommentLikes.Commands.AddPostCommentLike;
using InstaConnect.Posts.Business.Features.PostCommentLikes.Commands.DeletePostCommentLike;
using InstaConnect.Posts.Business.Features.PostCommentLikes.Queries.GetAllFilteredPostCommentLikes;
using InstaConnect.Posts.Business.Features.PostCommentLikes.Queries.GetAllPostCommentLikes;
using InstaConnect.Posts.Business.Features.PostCommentLikes.Queries.GetPostCommentLikeById;
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
            SortOrder = ValidSortOrderProperty,
            SortPropertyName = ValidSortPropertyName,
            Page = ValidPageValue,
            PageSize = ValidPageSizeValue,
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
            SortOrder = ValidSortOrderProperty,
            SortPropertyName = ValidSortPropertyName,
            Page = ValidPageValue,
            PageSize = ValidPageSizeValue,
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
                                                                 m.Id == ValidId &&
                                                                 m.PostCommentId == ValidPostCommentId &&
                                                                 m.UserId == ValidCurrentUserId &&
                                                                 m.UserName == ValidUserName &&
                                                                 m.UserProfileImage == ValidUserProfileImage) &&
                                                              mc.Page == ValidPageValue &&
                                                              mc.PageSize == ValidPageSizeValue &&
                                                              mc.TotalCount == ValidTotalCountValue &&
                                                              !mc.HasNextPage &&
                                                              !mc.HasPreviousPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetAllPostCommentLikesRequest()
        {
            SortOrder = ValidSortOrderProperty,
            SortPropertyName = ValidSortPropertyName,
            Page = ValidPageValue,
            PageSize = ValidPageSizeValue,
        };

        // Act
        var response = await _postCommentLikeController.GetAllAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetAllPostCommentLikesQuery>(m =>
                  m.SortOrder == ValidSortOrderProperty &&
                  m.SortPropertyName == ValidSortPropertyName &&
                  m.Page == ValidPageValue &&
                  m.PageSize == ValidPageSizeValue), CancellationToken);
    }

    [Fact]
    public async Task GetAllAsync_ShouldCallTheCurrentUserContext_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetAllPostCommentLikesRequest()
        {
            SortOrder = ValidSortOrderProperty,
            SortPropertyName = ValidSortPropertyName,
            Page = ValidPageValue,
            PageSize = ValidPageSizeValue,
        };

        // Act
        await _postCommentLikeController.GetAllAsync(request, CancellationToken);

        // Assert
        CurrentUserContext.Received(1);
    }

    [Fact]
    public async Task GetAllFilteredAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetAllFilteredPostCommentLikesRequest()
        {
            UserId = ValidCurrentUserId,
            UserName = ValidUserName,
            PostCommentId = ValidPostCommentId,
            SortOrder = ValidSortOrderProperty,
            SortPropertyName = ValidSortPropertyName,
            Page = ValidPageValue,
            PageSize = ValidPageSizeValue,
        };

        // Act
        var response = await _postCommentLikeController.GetAllFilteredAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.OK));
    }

    [Fact]
    public async Task GetAllFilteredAsync_ShouldReturnPostCommentLikePaginationQueryResponse_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetAllFilteredPostCommentLikesRequest()
        {
            UserId = ValidCurrentUserId,
            UserName = ValidUserName,
            PostCommentId = ValidPostCommentId,
            SortOrder = ValidSortOrderProperty,
            SortPropertyName = ValidSortPropertyName,
            Page = ValidPageValue,
            PageSize = ValidPageSizeValue,
        };

        // Act
        var response = await _postCommentLikeController.GetAllFilteredAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<PostCommentLikePaginationQueryResponse>(mc => mc.Items.All(m =>
                                                                 m.Id == ValidId &&
                                                                 m.PostCommentId == ValidPostCommentId &&
                                                                 m.UserId == ValidCurrentUserId &&
                                                                 m.UserName == ValidUserName &&
                                                                 m.UserProfileImage == ValidUserProfileImage) &&
                                                              mc.Page == ValidPageValue &&
                                                              mc.PageSize == ValidPageSizeValue &&
                                                              mc.TotalCount == ValidTotalCountValue &&
                                                              !mc.HasNextPage &&
                                                              !mc.HasPreviousPage);
    }

    [Fact]
    public async Task GetAllFilteredAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetAllFilteredPostCommentLikesRequest()
        {
            UserId = ValidCurrentUserId,
            UserName = ValidUserName,
            PostCommentId = ValidPostCommentId,
            SortOrder = ValidSortOrderProperty,
            SortPropertyName = ValidSortPropertyName,
            Page = ValidPageValue,
            PageSize = ValidPageSizeValue,
        };

        // Act
        var response = await _postCommentLikeController.GetAllFilteredAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetAllFilteredPostCommentLikesQuery>(m =>
                  m.UserId == ValidCurrentUserId &&
                  m.UserName == ValidUserName &&
                  m.PostCommentId == ValidPostCommentId &&
                  m.SortOrder == ValidSortOrderProperty &&
                  m.SortPropertyName == ValidSortPropertyName &&
                  m.Page == ValidPageValue &&
                  m.PageSize == ValidPageSizeValue), CancellationToken);
    }

    [Fact]
    public async Task GetAllFilteredAsync_ShouldCallTheCurrentUserContext_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetAllFilteredPostCommentLikesRequest()
        {
            UserId = ValidCurrentUserId,
            UserName = ValidUserName,
            PostCommentId = ValidPostCommentId,
            SortOrder = ValidSortOrderProperty,
            SortPropertyName = ValidSortPropertyName,
            Page = ValidPageValue,
            PageSize = ValidPageSizeValue,
        };

        // Act
        await _postCommentLikeController.GetAllFilteredAsync(request, CancellationToken);

        // Assert
        CurrentUserContext.Received(1);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetPostCommentLikeByIdRequest()
        {
            Id = ValidId
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
            Id = ValidId
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
            .Match<PostCommentLikeQueryResponse>(m => m.Id == ValidId &&
                                                 m.PostCommentId == ValidPostCommentId &&
                                                 m.UserId == ValidCurrentUserId &&
                                                 m.UserName == ValidUserName &&
                                                 m.UserProfileImage == ValidUserProfileImage);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        var request = new GetPostCommentLikeByIdRequest()
        {
            Id = ValidId
        };

        // Act
        await _postCommentLikeController.GetByIdAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetPostCommentLikeByIdQuery>(m => m.Id == ValidId), CancellationToken);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldCallTheCurrentUserContext_WhenRequestIsValid()
    {
        var request = new GetPostCommentLikeByIdRequest()
        {
            Id = ValidId
        };

        // Act
        await _postCommentLikeController.GetByIdAsync(request, CancellationToken);

        // Assert
        CurrentUserContext.Received(1);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new AddPostCommentLikeRequest()
        {
            AddPostCommentLikeBindingModel = new(ValidPostCommentId)
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
            AddPostCommentLikeBindingModel = new(ValidPostCommentId)
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
            .Match<PostCommentLikeCommandResponse>(m => m.Id == ValidId);
    }

    [Fact]
    public async Task AddAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var request = new AddPostCommentLikeRequest()
        {
            AddPostCommentLikeBindingModel = new(ValidPostCommentId)
        };

        // Act
        await _postCommentLikeController.AddAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
            .Received(1)
            .SendAsync(Arg.Is<AddPostCommentLikeCommand>(m => m.CurrentUserId == ValidCurrentUserId &&
                                                     m.PostCommentId == ValidPostCommentId),
                                                     CancellationToken);
    }

    [Fact]
    public async Task AddAsync_ShouldCallTheCurrentUserContext_WhenRequestIsValid()
    {
        // Arrange
        var request = new AddPostCommentLikeRequest()
        {
            AddPostCommentLikeBindingModel = new(ValidPostCommentId)
        };

        // Act
        await _postCommentLikeController.AddAsync(request, CancellationToken);

        // Assert
        CurrentUserContext.Received(1);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new DeletePostCommentLikeRequest()
        {
            Id = ValidId
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
            Id = ValidId
        };

        // Act
        await _postCommentLikeController.DeleteAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
            .Received(1)
            .SendAsync(Arg.Is<DeletePostCommentLikeCommand>(m => m.Id == ValidId &&
                                                    m.CurrentUserId == ValidCurrentUserId),
                                                    CancellationToken);
    }

    [Fact]
    public async Task DeleteAsync_ShouldCallTheCurrentUserContext_WhenRequestIsValid()
    {
        // Arrange
        var request = new DeletePostCommentLikeRequest()
        {
            Id = ValidId
        };

        // Act
        await _postCommentLikeController.DeleteAsync(request, CancellationToken);

        // Assert
        CurrentUserContext.Received(1);
    }
}
