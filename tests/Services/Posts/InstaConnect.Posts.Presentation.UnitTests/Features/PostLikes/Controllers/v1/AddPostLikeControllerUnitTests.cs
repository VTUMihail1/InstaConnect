﻿using InstaConnect.Posts.Application.Features.PostLikes.Commands.Add;

namespace InstaConnect.Posts.Presentation.UnitTests.Features.PostLikes.Controllers.v1;

public class AddPostLikeControllerUnitTests : BasePostLikeUnitTest
{
    private readonly PostLikeController _postLikeController;

    public AddPostLikeControllerUnitTests()
    {
        _postLikeController = new(
            InstaConnectMapper,
            InstaConnectSender);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var existingPostLike = CreatePostLike();
        var request = new AddPostLikeRequest(
            existingPostLike.UserId,
            new(existingPostLike.PostId)
        );

        // Act
        var response = await _postLikeController.AddAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == StatusCodes.Status200OK);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnPostLikeViewModel_WhenRequestIsValid()
    {
        // Arrange
        var existingPostLike = CreatePostLike();
        var request = new AddPostLikeRequest(
            existingPostLike.UserId,
            new(existingPostLike.PostId)
        );

        // Act
        var response = await _postLikeController.AddAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<PostLikeCommandResponse>(m => m.Id == existingPostLike.Id);
    }

    [Fact]
    public async Task AddAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var existingPostLike = CreatePostLike();
        var request = new AddPostLikeRequest(
            existingPostLike.UserId,
            new(existingPostLike.PostId)
        );

        // Act
        await _postLikeController.AddAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
            .Received(1)
            .SendAsync(Arg.Is<AddPostLikeCommand>(m => m.CurrentUserId == existingPostLike.UserId &&
                                                     m.PostId == existingPostLike.PostId),
                                                     CancellationToken);
    }
}
