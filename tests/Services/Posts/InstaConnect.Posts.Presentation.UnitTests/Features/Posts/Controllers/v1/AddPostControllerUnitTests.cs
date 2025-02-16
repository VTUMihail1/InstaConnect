using FluentAssertions;

using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Posts.Presentation.Features.Posts.Controllers.v1;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Responses;
using InstaConnect.Posts.Presentation.UnitTests.Features.Posts.Utilities;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using NSubstitute;

namespace InstaConnect.Posts.Presentation.UnitTests.Features.Posts.Controllers.v1;

public class AddPostControllerUnitTests : BasePostUnitTest
{
    private readonly PostController _postController;

    public AddPostControllerUnitTests()
    {
        _postController = new(
            InstaConnectMapper,
            InstaConnectSender);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var existingPost = CreatePost();
        var request = new AddPostRequest(
            existingPost.UserId,
            new(PostTestUtilities.ValidAddTitle, PostTestUtilities.ValidAddContent)
        );

        // Act
        var response = await _postController.AddAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == StatusCodes.Status200OK);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnPostViewModel_WhenRequestIsValid()
    {
        // Arrange
        var existingPost = CreatePost();
        var request = new AddPostRequest(
            existingPost.UserId,
            new(PostTestUtilities.ValidAddTitle, PostTestUtilities.ValidAddContent)
        );

        // Act
        var response = await _postController.AddAsync(request, CancellationToken);

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
    public async Task AddAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var existingPost = CreatePost();
        var request = new AddPostRequest(
            existingPost.UserId,
            new(PostTestUtilities.ValidAddTitle, PostTestUtilities.ValidAddContent)
        );

        // Act
        await _postController.AddAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
            .Received(1)
            .SendAsync(Arg.Is<AddPostCommand>(m => m.CurrentUserId == existingPost.UserId &&
                                                     m.Title == PostTestUtilities.ValidAddTitle &&
                                                     m.Content == PostTestUtilities.ValidAddContent),
                                                     CancellationToken);
    }
}
