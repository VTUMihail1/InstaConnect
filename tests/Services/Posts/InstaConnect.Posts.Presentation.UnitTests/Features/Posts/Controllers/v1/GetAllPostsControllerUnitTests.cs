using System.Net;
using FluentAssertions;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAllPosts;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;
using InstaConnect.Posts.Presentation.Features.Posts.Controllers.v1;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Responses;
using InstaConnect.Posts.Presentation.UnitTests.Features.Posts.Utilities;
using InstaConnect.Shared.Presentation.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace InstaConnect.Posts.Presentation.UnitTests.Features.Posts.Controllers.v1;

public class GetAllPostsControllerUnitTests : BasePostUnitTest
{
    private readonly PostController _postController;

    public GetAllPostsControllerUnitTests()
    {
        _postController = new(
            InstaConnectMapper,
            InstaConnectSender);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var existingPost = CreatePost();
        var request = new GetAllPostsRequest(
            existingPost.UserId,
            UserTestUtilities.ValidName,
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue
        );

        // Act
        var response = await _postController.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == StatusCodes.Status200OK);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnPostPaginationQueryResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingPost = CreatePost();
        var request = new GetAllPostsRequest(
            existingPost.UserId,
            UserTestUtilities.ValidName,
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue
        );

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
                                                                 m.Id == existingPost.Id &&
                                                                 m.Title == PostTestUtilities.ValidTitle &&
                                                                 m.Content == PostTestUtilities.ValidContent &&
                                                                 m.UserId == existingPost.UserId &&
                                                                 m.UserName == UserTestUtilities.ValidName &&
                                                                 m.UserProfileImage == UserTestUtilities.ValidProfileImage) &&
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
        var existingPost = CreatePost();
        var request = new GetAllPostsRequest(
            existingPost.UserId,
            UserTestUtilities.ValidName,
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue
        );

        // Act
        var response = await _postController.GetAllAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetAllPostsQuery>(m =>
                  m.UserId == existingPost.UserId &&
                  m.UserName == UserTestUtilities.ValidName &&
                  m.Title == PostTestUtilities.ValidTitle &&
                  m.SortOrder == PostTestUtilities.ValidSortOrderProperty &&
                  m.SortPropertyName == PostTestUtilities.ValidSortPropertyName &&
                  m.Page == PostTestUtilities.ValidPageValue &&
                  m.PageSize == PostTestUtilities.ValidPageSizeValue), CancellationToken);
    }
}
