using FluentAssertions;

using InstaConnect.Posts.Application.Features.Posts.Commands.Update;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Posts.Presentation.Features.Posts.Controllers.v1;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Responses;
using InstaConnect.Posts.Presentation.UnitTests.Features.Posts.Utilities;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using NSubstitute;

namespace InstaConnect.Posts.Presentation.UnitTests.Features.Posts.Controllers.v1;

public class UpdatePostControllerUnitTests : BasePostUnitTest
{
    private readonly PostController _postController;

    public UpdatePostControllerUnitTests()
    {
        _postController = new(
            InstaConnectMapper,
            InstaConnectSender);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var existingPost = CreatePost();
        var request = new UpdatePostRequest(
            existingPost.Id,
            existingPost.UserId,
            new(PostTestUtilities.ValidUpdateTitle, PostTestUtilities.ValidUpdateContent)
        );

        // Act
        var response = await _postController.UpdateAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == StatusCodes.Status200OK);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnPostViewModel_WhenRequestIsValid()
    {
        // Arrange
        var existingPost = CreatePost();
        var request = new UpdatePostRequest(
            existingPost.Id,
            existingPost.UserId,
            new(PostTestUtilities.ValidUpdateTitle, PostTestUtilities.ValidUpdateContent)
        );

        // Act
        var response = await _postController.UpdateAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<PostCommandResponse>(m => m.Id == existingPost.Id);
    }

    [Fact]
    public async Task UpdateAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var existingPost = CreatePost();
        var request = new UpdatePostRequest(
            existingPost.Id,
            existingPost.UserId,
            new(PostTestUtilities.ValidUpdateTitle, PostTestUtilities.ValidUpdateContent)
        );

        // Act
        await _postController.UpdateAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
            .Received(1)
            .SendAsync(Arg.Is<UpdatePostCommand>(m => m.Id == existingPost.Id &&
                                                      m.CurrentUserId == existingPost.UserId &&
                                                      m.Title == PostTestUtilities.ValidUpdateTitle &&
                                                      m.Content == PostTestUtilities.ValidUpdateContent),
                                                    CancellationToken);
    }
}
