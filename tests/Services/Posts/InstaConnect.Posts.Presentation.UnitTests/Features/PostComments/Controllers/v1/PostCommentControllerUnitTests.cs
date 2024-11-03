using System.Net;
using FluentAssertions;
using InstaConnect.Posts.Business.Features.PostComments.Commands.AddPostComment;
using InstaConnect.Posts.Business.Features.PostComments.Commands.DeletePostComment;
using InstaConnect.Posts.Business.Features.PostComments.Commands.UpdatePostComment;
using InstaConnect.Posts.Business.Features.PostComments.Queries.GetAllPostComments;
using InstaConnect.Posts.Business.Features.PostComments.Queries.GetPostCommentById;
using InstaConnect.Posts.Common.Features.PostComments.Utilities;
using InstaConnect.Posts.Web.Features.PostComments.Controllers.v1;
using InstaConnect.Posts.Web.Features.PostComments.Models.Requests;
using InstaConnect.Posts.Web.Features.PostComments.Models.Responses;
using InstaConnect.Posts.Web.UnitTests.Features.PostComments.Utilities;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace InstaConnect.Posts.Web.UnitTests.Features.PostComments.Controllers.v1;
public class PostCommentControllerUnitTests : BasePostCommentUnitTest
{
    private readonly PostCommentController _postCommentController;

    public PostCommentControllerUnitTests()
    {
        _postCommentController = new(
            InstaConnectMapper,
            InstaConnectSender,
            CurrentUserContext);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetAllPostCommentsRequest()
        {
            UserId = PostCommentTestUtilities.ValidCurrentUserId,
            UserName = PostCommentTestUtilities.ValidUserName,
            PostId = PostCommentTestUtilities.ValidPostId,
            SortOrder = PostCommentTestUtilities.ValidSortOrderProperty,
            SortPropertyName = PostCommentTestUtilities.ValidSortPropertyName,
            Page = PostCommentTestUtilities.ValidPageValue,
            PageSize = PostCommentTestUtilities.ValidPageSizeValue,
        };

        // Act
        var response = await _postCommentController.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.OK));
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnPostPaginationQueryResponse_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetAllPostCommentsRequest()
        {
            UserId = PostCommentTestUtilities.ValidCurrentUserId,
            UserName = PostCommentTestUtilities.ValidUserName,
            PostId = PostCommentTestUtilities.ValidPostId,
            SortOrder = PostCommentTestUtilities.ValidSortOrderProperty,
            SortPropertyName = PostCommentTestUtilities.ValidSortPropertyName,
            Page = PostCommentTestUtilities.ValidPageValue,
            PageSize = PostCommentTestUtilities.ValidPageSizeValue,
        };

        // Act
        var response = await _postCommentController.GetAllAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<PostCommentPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                                 m.Id == PostCommentTestUtilities.ValidId &&
                                                                 m.PostId == PostCommentTestUtilities.ValidPostId &&
                                                                 m.Content == PostCommentTestUtilities.ValidContent &&
                                                                 m.UserId == PostCommentTestUtilities.ValidCurrentUserId &&
                                                                 m.UserName == PostCommentTestUtilities.ValidUserName &&
                                                                 m.UserProfileImage == PostCommentTestUtilities.ValidUserProfileImage) &&
                                                              mc.Page == PostCommentTestUtilities.ValidPageValue &&
                                                              mc.PageSize == PostCommentTestUtilities.ValidPageSizeValue &&
                                                              mc.TotalCount == PostCommentTestUtilities.ValidTotalCountValue &&
                                                              !mc.HasNextPage &&
                                                              !mc.HasPreviousPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetAllPostCommentsRequest()
        {
            UserId = PostCommentTestUtilities.ValidCurrentUserId,
            UserName = PostCommentTestUtilities.ValidUserName,
            PostId = PostCommentTestUtilities.ValidPostId,
            SortOrder = PostCommentTestUtilities.ValidSortOrderProperty,
            SortPropertyName = PostCommentTestUtilities.ValidSortPropertyName,
            Page = PostCommentTestUtilities.ValidPageValue,
            PageSize = PostCommentTestUtilities.ValidPageSizeValue,
        };

        // Act
        var response = await _postCommentController.GetAllAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetAllPostCommentsQuery>(m =>
                  m.UserId == PostCommentTestUtilities.ValidCurrentUserId &&
                  m.UserName == PostCommentTestUtilities.ValidUserName &&
                  m.PostId == PostCommentTestUtilities.ValidPostId &&
                  m.SortOrder == PostCommentTestUtilities.ValidSortOrderProperty &&
                  m.SortPropertyName == PostCommentTestUtilities.ValidSortPropertyName &&
                  m.Page == PostCommentTestUtilities.ValidPageValue &&
                  m.PageSize == PostCommentTestUtilities.ValidPageSizeValue), CancellationToken);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetPostCommentByIdRequest()
        {
            Id = PostCommentTestUtilities.ValidId
        };

        // Act
        var response = await _postCommentController.GetByIdAsync(request, CancellationToken);

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
        var request = new GetPostCommentByIdRequest()
        {
            Id = PostCommentTestUtilities.ValidId
        };

        // Act
        var response = await _postCommentController.GetByIdAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<PostCommentQueryResponse>(m => m.Id == PostCommentTestUtilities.ValidId &&
                                                 m.PostId == PostCommentTestUtilities.ValidPostId &&
                                                 m.Content == PostCommentTestUtilities.ValidContent &&
                                                 m.UserId == PostCommentTestUtilities.ValidCurrentUserId &&
                                                 m.UserName == PostCommentTestUtilities.ValidUserName &&
                                                 m.UserProfileImage == PostCommentTestUtilities.ValidUserProfileImage);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        var request = new GetPostCommentByIdRequest()
        {
            Id = PostCommentTestUtilities.ValidId
        };

        // Act
        await _postCommentController.GetByIdAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetPostCommentByIdQuery>(m => m.Id == PostCommentTestUtilities.ValidId), CancellationToken);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new AddPostCommentRequest()
        {
            AddPostCommentBindingModel = new(PostCommentTestUtilities.ValidPostId, PostCommentTestUtilities.ValidContent)
        };

        // Act
        var response = await _postCommentController.AddAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.OK));
    }

    [Fact]
    public async Task AddAsync_ShouldReturnPostViewModel_WhenRequestIsValid()
    {
        // Arrange
        var request = new AddPostCommentRequest()
        {
            AddPostCommentBindingModel = new(PostCommentTestUtilities.ValidPostId, PostCommentTestUtilities.ValidContent)
        };

        // Act
        var response = await _postCommentController.AddAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<PostCommentCommandResponse>(m => m.Id == PostCommentTestUtilities.ValidId);
    }

    [Fact]
    public async Task AddAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var request = new AddPostCommentRequest()
        {
            AddPostCommentBindingModel = new(PostCommentTestUtilities.ValidPostId, PostCommentTestUtilities.ValidContent)
        };

        // Act
        await _postCommentController.AddAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
            .Received(1)
            .SendAsync(Arg.Is<AddPostCommentCommand>(m => m.CurrentUserId == PostCommentTestUtilities.ValidCurrentUserId &&
                                                     m.PostId == PostCommentTestUtilities.ValidPostId &&
                                                     m.Content == PostCommentTestUtilities.ValidContent),
                                                     CancellationToken);
    }

    [Fact]
    public async Task AddAsync_ShouldCallTheCurrentUserContext_WhenRequestIsValid()
    {
        // Arrange
        var request = new AddPostCommentRequest()
        {
            AddPostCommentBindingModel = new(PostCommentTestUtilities.ValidPostId, PostCommentTestUtilities.ValidContent)
        };

        // Act
        await _postCommentController.AddAsync(request, CancellationToken);

        // Assert
        CurrentUserContext
            .Received(1)
            .GetCurrentUser();
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new UpdatePostCommentRequest()
        {
            Id = PostCommentTestUtilities.ValidId,
            UpdatePostCommentBindingModel = new(PostCommentTestUtilities.ValidContent)
        };

        // Act
        var response = await _postCommentController.UpdateAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.OK));
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnPostViewModel_WhenRequestIsValid()
    {
        // Arrange
        var request = new UpdatePostCommentRequest()
        {
            Id = PostCommentTestUtilities.ValidId,
            UpdatePostCommentBindingModel = new(PostCommentTestUtilities.ValidContent)
        };

        // Act
        var response = await _postCommentController.UpdateAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<PostCommentCommandResponse>(m => m.Id == PostCommentTestUtilities.ValidId);
    }

    [Fact]
    public async Task UpdateAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var request = new UpdatePostCommentRequest()
        {
            Id = PostCommentTestUtilities.ValidId,
            UpdatePostCommentBindingModel = new(PostCommentTestUtilities.ValidContent)
        };

        // Act
        await _postCommentController.UpdateAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
            .Received(1)
            .SendAsync(Arg.Is<UpdatePostCommentCommand>(m => m.Id == PostCommentTestUtilities.ValidId &&
                                                      m.CurrentUserId == PostCommentTestUtilities.ValidCurrentUserId &&
                                                      m.Content == PostCommentTestUtilities.ValidContent),
                                                    CancellationToken);
    }

    [Fact]
    public async Task UpdateAsync_ShouldCallTheCurrentUserContext_WhenRequestIsValid()
    {
        // Arrange
        var request = new UpdatePostCommentRequest()
        {
            Id = PostCommentTestUtilities.ValidId,
            UpdatePostCommentBindingModel = new(PostCommentTestUtilities.ValidContent)
        };

        // Act
        await _postCommentController.UpdateAsync(request, CancellationToken);

        // Assert
        CurrentUserContext
            .Received(1)
            .GetCurrentUser();
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new DeletePostCommentRequest()
        {
            Id = PostCommentTestUtilities.ValidId
        };

        // Act
        var response = await _postCommentController.DeleteAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<NoContentResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.NoContent));
    }

    [Fact]
    public async Task DeleteAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var request = new DeletePostCommentRequest()
        {
            Id = PostCommentTestUtilities.ValidId
        };

        // Act
        await _postCommentController.DeleteAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
            .Received(1)
            .SendAsync(Arg.Is<DeletePostCommentCommand>(m => m.Id == PostCommentTestUtilities.ValidId &&
                                                    m.CurrentUserId == PostCommentTestUtilities.ValidCurrentUserId),
                                                    CancellationToken);
    }

    [Fact]
    public async Task DeleteAsync_ShouldCallTheCurrentUserContext_WhenRequestIsValid()
    {
        // Arrange
        var request = new DeletePostCommentRequest()
        {
            Id = PostCommentTestUtilities.ValidId
        };

        // Act
        await _postCommentController.DeleteAsync(request, CancellationToken);

        // Assert
        CurrentUserContext
            .Received(1)
            .GetCurrentUser();
    }
}
