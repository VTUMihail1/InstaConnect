using System.Net;
using FluentAssertions;
using InstaConnect.Posts.Application.Features.Posts.Commands.AddPost;
using InstaConnect.Posts.Application.Features.Posts.Commands.DeletePost;
using InstaConnect.Posts.Application.Features.Posts.Commands.UpdatePost;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAllPosts;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetPostById;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Posts.Presentation.Features.Posts.Controllers.v1;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Responses;
using InstaConnect.Posts.Presentation.UnitTests.Features.Posts.Utilities;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace InstaConnect.Posts.Presentation.UnitTests.Features.Posts.Controllers.v1;
public class PostControllerUnitTests : BasePostUnitTest
{
    private readonly PostController _postController;

    public PostControllerUnitTests()
    {
        _postController = new(
            InstaConnectMapper,
            InstaConnectSender,
            CurrentUserContext);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetAllPostsRequest()
        {
            UserId = PostTestUtilities.ValidCurrentUserId,
            UserName = PostTestUtilities.ValidUserName,
            Title = PostTestUtilities.ValidTitle,
            SortOrder = PostTestUtilities.ValidSortOrderProperty,
            SortPropertyName = PostTestUtilities.ValidSortPropertyName,
            Page = PostTestUtilities.ValidPageValue,
            PageSize = PostTestUtilities.ValidPageSizeValue,
        };

        // Act
        var response = await _postController.GetAllAsync(request, CancellationToken);

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
        var request = new GetAllPostsRequest()
        {
            UserId = PostTestUtilities.ValidCurrentUserId,
            UserName = PostTestUtilities.ValidUserName,
            Title = PostTestUtilities.ValidTitle,
            SortOrder = PostTestUtilities.ValidSortOrderProperty,
            SortPropertyName = PostTestUtilities.ValidSortPropertyName,
            Page = PostTestUtilities.ValidPageValue,
            PageSize = PostTestUtilities.ValidPageSizeValue,
        };

        // Act
        var response = await _postController.GetAllAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<PostPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                                 m.Id == PostTestUtilities.ValidId &&
                                                                 m.Title == PostTestUtilities.ValidTitle &&
                                                                 m.Content == PostTestUtilities.ValidContent &&
                                                                 m.UserId == PostTestUtilities.ValidCurrentUserId &&
                                                                 m.UserName == PostTestUtilities.ValidUserName &&
                                                                 m.UserProfileImage == PostTestUtilities.ValidUserProfileImage) &&
                                                              mc.Page == PostTestUtilities.ValidPageValue &&
                                                              mc.PageSize == PostTestUtilities.ValidPageSizeValue &&
                                                              mc.TotalCount == PostTestUtilities.ValidTotalCountValue &&
                                                              !mc.HasNextPage &&
                                                              !mc.HasPreviousPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetAllPostsRequest()
        {
            UserId = PostTestUtilities.ValidCurrentUserId,
            UserName = PostTestUtilities.ValidUserName,
            Title = PostTestUtilities.ValidTitle,
            SortOrder = PostTestUtilities.ValidSortOrderProperty,
            SortPropertyName = PostTestUtilities.ValidSortPropertyName,
            Page = PostTestUtilities.ValidPageValue,
            PageSize = PostTestUtilities.ValidPageSizeValue,
        };

        // Act
        var response = await _postController.GetAllAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetAllPostsQuery>(m =>
                  m.UserId == PostTestUtilities.ValidCurrentUserId &&
                  m.UserName == PostTestUtilities.ValidUserName &&
                  m.Title == PostTestUtilities.ValidTitle &&
                  m.SortOrder == PostTestUtilities.ValidSortOrderProperty &&
                  m.SortPropertyName == PostTestUtilities.ValidSortPropertyName &&
                  m.Page == PostTestUtilities.ValidPageValue &&
                  m.PageSize == PostTestUtilities.ValidPageSizeValue), CancellationToken);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetPostByIdRequest()
        {
            Id = PostTestUtilities.ValidId
        };

        // Act
        var response = await _postController.GetByIdAsync(request, CancellationToken);

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
        var request = new GetPostByIdRequest()
        {
            Id = PostTestUtilities.ValidId
        };

        // Act
        var response = await _postController.GetByIdAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<PostQueryResponse>(m => m.Id == PostTestUtilities.ValidId &&
                                                 m.Title == PostTestUtilities.ValidTitle &&
                                                 m.Content == PostTestUtilities.ValidContent &&
                                                 m.UserId == PostTestUtilities.ValidCurrentUserId &&
                                                 m.UserName == PostTestUtilities.ValidUserName &&
                                                 m.UserProfileImage == PostTestUtilities.ValidUserProfileImage);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        var request = new GetPostByIdRequest()
        {
            Id = PostTestUtilities.ValidId
        };

        // Act
        await _postController.GetByIdAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetPostByIdQuery>(m => m.Id == PostTestUtilities.ValidId), CancellationToken);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new AddPostRequest()
        {
            AddPostBindingModel = new(PostTestUtilities.ValidTitle, PostTestUtilities.ValidContent)
        };

        // Act
        var response = await _postController.AddAsync(request, CancellationToken);

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
        var request = new AddPostRequest()
        {
            AddPostBindingModel = new(PostTestUtilities.ValidTitle, PostTestUtilities.ValidContent)
        };

        // Act
        var response = await _postController.AddAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<PostCommandResponse>(m => m.Id == PostTestUtilities.ValidId);
    }

    [Fact]
    public async Task AddAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var request = new AddPostRequest()
        {
            AddPostBindingModel = new(PostTestUtilities.ValidTitle, PostTestUtilities.ValidContent)
        };

        // Act
        await _postController.AddAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
            .Received(1)
            .SendAsync(Arg.Is<AddPostCommand>(m => m.CurrentUserId == PostTestUtilities.ValidCurrentUserId &&
                                                     m.Title == PostTestUtilities.ValidTitle &&
                                                     m.Content == PostTestUtilities.ValidContent),
                                                     CancellationToken);
    }

    [Fact]
    public async Task AddAsync_ShouldCallTheCurrentUserContext_WhenRequestIsValid()
    {
        // Arrange
        var request = new AddPostRequest()
        {
            AddPostBindingModel = new(PostTestUtilities.ValidTitle, PostTestUtilities.ValidContent)
        };

        // Act
        await _postController.AddAsync(request, CancellationToken);

        // Assert
        CurrentUserContext
            .Received(1)
            .GetCurrentUser();
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new UpdatePostRequest()
        {
            Id = PostTestUtilities.ValidId,
            UpdatePostBindingModel = new(PostTestUtilities.ValidTitle, PostTestUtilities.ValidContent)
        };

        // Act
        var response = await _postController.UpdateAsync(request, CancellationToken);

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
        var request = new UpdatePostRequest()
        {
            Id = PostTestUtilities.ValidId,
            UpdatePostBindingModel = new(PostTestUtilities.ValidTitle, PostTestUtilities.ValidContent)
        };

        // Act
        var response = await _postController.UpdateAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<PostCommandResponse>(m => m.Id == PostTestUtilities.ValidId);
    }

    [Fact]
    public async Task UpdateAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var request = new UpdatePostRequest()
        {
            Id = PostTestUtilities.ValidId,
            UpdatePostBindingModel = new(PostTestUtilities.ValidTitle, PostTestUtilities.ValidContent)
        };

        // Act
        await _postController.UpdateAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
            .Received(1)
            .SendAsync(Arg.Is<UpdatePostCommand>(m => m.Id == PostTestUtilities.ValidId &&
                                                      m.CurrentUserId == PostTestUtilities.ValidCurrentUserId &&
                                                      m.Title == PostTestUtilities.ValidTitle &&
                                                      m.Content == PostTestUtilities.ValidContent),
                                                    CancellationToken);
    }

    [Fact]
    public async Task UpdateAsync_ShouldCallTheCurrentUserContext_WhenRequestIsValid()
    {
        // Arrange
        var request = new UpdatePostRequest()
        {
            Id = PostTestUtilities.ValidId,
            UpdatePostBindingModel = new(PostTestUtilities.ValidTitle, PostTestUtilities.ValidContent)
        };

        // Act
        await _postController.UpdateAsync(request, CancellationToken);

        // Assert
        CurrentUserContext
            .Received(1)
            .GetCurrentUser();
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new DeletePostRequest()
        {
            Id = PostTestUtilities.ValidId
        };

        // Act
        var response = await _postController.DeleteAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<NoContentResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.NoContent));
    }

    [Fact]
    public async Task DeleteAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var request = new DeletePostRequest()
        {
            Id = PostTestUtilities.ValidId
        };

        // Act
        await _postController.DeleteAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
            .Received(1)
            .SendAsync(Arg.Is<DeletePostCommand>(m => m.Id == PostTestUtilities.ValidId &&
                                                    m.CurrentUserId == PostTestUtilities.ValidCurrentUserId),
                                                    CancellationToken);
    }

    [Fact]
    public async Task DeleteAsync_ShouldCallTheCurrentUserContext_WhenRequestIsValid()
    {
        // Arrange
        var request = new DeletePostRequest()
        {
            Id = PostTestUtilities.ValidId
        };

        // Act
        await _postController.DeleteAsync(request, CancellationToken);

        // Assert
        CurrentUserContext
            .Received(1)
            .GetCurrentUser();
    }
}
