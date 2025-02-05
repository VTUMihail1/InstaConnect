using System.Net;
using FluentAssertions;
using InstaConnect.Posts.Application.Features.PostLikes.Commands.AddPostLike;
using InstaConnect.Posts.Presentation.Features.PostLikes.Controllers.v1;
using InstaConnect.Posts.Presentation.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Presentation.Features.PostLikes.Models.Responses;
using InstaConnect.Posts.Presentation.UnitTests.Features.PostLikes.Utilities;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

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
            .Match<OkObjectResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.OK));
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
