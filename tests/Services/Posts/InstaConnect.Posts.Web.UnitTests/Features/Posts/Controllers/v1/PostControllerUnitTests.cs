using System.Net;
using FluentAssertions;
using InstaConnect.Posts.Business.Features.Posts.Commands.AddPost;
using InstaConnect.Posts.Business.Features.Posts.Commands.DeletePost;
using InstaConnect.Posts.Business.Features.Posts.Commands.UpdatePost;
using InstaConnect.Posts.Business.Features.Posts.Queries.GetAllFilteredPosts;
using InstaConnect.Posts.Business.Features.Posts.Queries.GetPostById;
using InstaConnect.Posts.Web.Features.Posts.Controllers.v1;
using InstaConnect.Posts.Web.Features.Posts.Models.Requests;
using InstaConnect.Posts.Web.Features.Posts.Models.Responses;
using InstaConnect.Posts.Web.UnitTests.Features.Posts.Utilities;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace InstaConnect.Posts.Web.UnitTests.Features.Posts.Controllers.v1;
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
    public async Task GetAllFilteredAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetAllPostsRequest()
        {
            UserId = ValidCurrentUserId,
            UserName = ValidUserName,
            Title = ValidTitle,
            SortOrder = ValidSortOrderProperty,
            SortPropertyName = ValidSortPropertyName,
            Page = ValidPageValue,
            PageSize = ValidPageSizeValue,
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
    public async Task GetAllFilteredAsync_ShouldReturnPostPaginationQueryResponse_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetAllPostsRequest()
        {
            UserId = ValidCurrentUserId,
            UserName = ValidUserName,
            Title = ValidTitle,
            SortOrder = ValidSortOrderProperty,
            SortPropertyName = ValidSortPropertyName,
            Page = ValidPageValue,
            PageSize = ValidPageSizeValue,
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
                                                                 m.Id == ValidId &&
                                                                 m.Title == ValidTitle &&
                                                                 m.Content == ValidContent &&
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
        var request = new GetAllPostsRequest()
        {
            UserId = ValidCurrentUserId,
            UserName = ValidUserName,
            Title = ValidTitle,
            SortOrder = ValidSortOrderProperty,
            SortPropertyName = ValidSortPropertyName,
            Page = ValidPageValue,
            PageSize = ValidPageSizeValue,
        };

        // Act
        var response = await _postController.GetAllAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetAllPostsQuery>(m =>
                  m.UserId == ValidCurrentUserId &&
                  m.UserName == ValidUserName &&
                  m.Title == ValidTitle &&
                  m.SortOrder == ValidSortOrderProperty &&
                  m.SortPropertyName == ValidSortPropertyName &&
                  m.Page == ValidPageValue &&
                  m.PageSize == ValidPageSizeValue), CancellationToken);
    }

    [Fact]
    public async Task GetAllFilteredAsync_ShouldCallTheCurrentUserContext_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetAllPostsRequest()
        {
            UserId = ValidCurrentUserId,
            UserName = ValidUserName,
            Title = ValidTitle,
            SortOrder = ValidSortOrderProperty,
            SortPropertyName = ValidSortPropertyName,
            Page = ValidPageValue,
            PageSize = ValidPageSizeValue,
        };

        // Act
        await _postController.GetAllAsync(request, CancellationToken);

        // Assert
        CurrentUserContext.Received(1);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetPostByIdRequest()
        {
            Id = ValidId
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
            Id = ValidId
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
            .Match<PostQueryResponse>(m => m.Id == ValidId &&
                                                 m.Title == ValidTitle &&
                                                 m.Content == ValidContent &&
                                                 m.UserId == ValidCurrentUserId &&
                                                 m.UserName == ValidUserName &&
                                                 m.UserProfileImage == ValidUserProfileImage);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        var request = new GetPostByIdRequest()
        {
            Id = ValidId
        };

        // Act
        await _postController.GetByIdAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetPostByIdQuery>(m => m.Id == ValidId), CancellationToken);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldCallTheCurrentUserContext_WhenRequestIsValid()
    {
        var request = new GetPostByIdRequest()
        {
            Id = ValidId
        };

        // Act
        await _postController.GetByIdAsync(request, CancellationToken);

        // Assert
        CurrentUserContext.Received(1);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new AddPostRequest()
        {
            AddPostBindingModel = new(ValidTitle, ValidContent)
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
            AddPostBindingModel = new(ValidTitle, ValidContent)
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
            .Match<PostCommandResponse>(m => m.Id == ValidId);
    }

    [Fact]
    public async Task AddAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var request = new AddPostRequest()
        {
            AddPostBindingModel = new(ValidTitle, ValidContent)
        };

        // Act
        await _postController.AddAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
            .Received(1)
            .SendAsync(Arg.Is<AddPostCommand>(m => m.CurrentUserId == ValidCurrentUserId &&
                                                     m.Title == ValidTitle &&
                                                     m.Content == ValidContent),
                                                     CancellationToken);
    }

    [Fact]
    public async Task AddAsync_ShouldCallTheCurrentUserContext_WhenRequestIsValid()
    {
        // Arrange
        var request = new AddPostRequest()
        {
            AddPostBindingModel = new(ValidTitle, ValidContent)
        };

        // Act
        await _postController.AddAsync(request, CancellationToken);

        // Assert
        CurrentUserContext.Received(1);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new UpdatePostRequest()
        {
            Id = ValidId,
            UpdatePostBindingModel = new(ValidTitle, ValidContent)
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
            Id = ValidId,
            UpdatePostBindingModel = new(ValidTitle, ValidContent)
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
            .Match<PostCommandResponse>(m => m.Id == ValidId);
    }

    [Fact]
    public async Task UpdateAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var request = new UpdatePostRequest()
        {
            Id = ValidId,
            UpdatePostBindingModel = new(ValidTitle, ValidContent)
        };

        // Act
        await _postController.UpdateAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
            .Received(1)
            .SendAsync(Arg.Is<UpdatePostCommand>(m => m.Id == ValidId &&
                                                      m.CurrentUserId == ValidCurrentUserId &&
                                                      m.Title == ValidTitle &&
                                                      m.Content == ValidContent),
                                                    CancellationToken);
    }

    [Fact]
    public async Task UpdateAsync_ShouldCallTheCurrentUserContext_WhenRequestIsValid()
    {
        // Arrange
        var request = new UpdatePostRequest()
        {
            Id = ValidId,
            UpdatePostBindingModel = new(ValidTitle, ValidContent)
        };

        // Act
        await _postController.UpdateAsync(request, CancellationToken);

        // Assert
        CurrentUserContext.Received(1);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new DeletePostRequest()
        {
            Id = ValidId
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
            Id = ValidId
        };

        // Act
        await _postController.DeleteAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
            .Received(1)
            .SendAsync(Arg.Is<DeletePostCommand>(m => m.Id == ValidId &&
                                                    m.CurrentUserId == ValidCurrentUserId),
                                                    CancellationToken);
    }

    [Fact]
    public async Task DeleteAsync_ShouldCallTheCurrentUserContext_WhenRequestIsValid()
    {
        // Arrange
        var request = new DeletePostRequest()
        {
            Id = ValidId
        };

        // Act
        await _postController.DeleteAsync(request, CancellationToken);

        // Assert
        CurrentUserContext.Received(1);
    }
}
