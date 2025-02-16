using FluentAssertions;

using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;
using InstaConnect.Posts.Presentation.Features.Posts.Controllers.v1;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Responses;
using InstaConnect.Posts.Presentation.UnitTests.Features.Posts.Utilities;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using NSubstitute;

namespace InstaConnect.Posts.Presentation.UnitTests.Features.Posts.Controllers.v1;

public class GetPostByIdControllerUnitTests : BasePostUnitTest
{
    private readonly PostController _postController;

    public GetPostByIdControllerUnitTests()
    {
        _postController = new(
            InstaConnectMapper,
            InstaConnectSender);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var existingPost = CreatePost();
        var request = new GetPostByIdRequest(existingPost.Id);

        // Act
        var response = await _postController.GetByIdAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == StatusCodes.Status200OK);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnMessageViewModel_WhenRequestIsValid()
    {
        // Arrange
        var existingPost = CreatePost();
        var request = new GetPostByIdRequest(existingPost.Id);

        // Act
        var response = await _postController.GetByIdAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<PostQueryResponse>(m => m.Id == existingPost.Id &&
                                                 m.Title == existingPost.Title &&
                                                 m.Content == existingPost.Content &&
                                                 m.UserId == existingPost.UserId &&
                                                 m.UserName == existingPost.User.UserName &&
                                                 m.UserProfileImage == existingPost.User.ProfileImage);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var existingPost = CreatePost();
        var request = new GetPostByIdRequest(existingPost.Id);

        // Act
        await _postController.GetByIdAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetPostByIdQuery>(m => m.Id == existingPost.Id), CancellationToken);
    }
}
