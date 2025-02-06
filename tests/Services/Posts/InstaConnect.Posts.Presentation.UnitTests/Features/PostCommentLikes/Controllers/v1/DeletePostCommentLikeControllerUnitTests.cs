using System.Net;
using FluentAssertions;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.DeletePostCommentLike;
using InstaConnect.Posts.Presentation.Features.PostCommentLikes.Controllers.v1;
using InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Requests;
using InstaConnect.Posts.Presentation.UnitTests.Features.PostCommentLikes.Utilities;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace InstaConnect.Posts.Presentation.UnitTests.Features.PostCommentLikes.Controllers.v1;

public class DeletePostCommentLikeControllerUnitTests : BasePostCommentLikeUnitTest
{
    private readonly PostCommentLikeController _postCommentLikeController;

    public DeletePostCommentLikeControllerUnitTests()
    {
        _postCommentLikeController = new(
            InstaConnectMapper,
            InstaConnectSender);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var existingPostCommentLike = CreatePostCommentLike();
        var request = new DeletePostCommentLikeRequest(
            existingPostCommentLike.Id,
            existingPostCommentLike.UserId
        );

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
        var existingPostCommentLike = CreatePostCommentLike();
        var request = new DeletePostCommentLikeRequest(
            existingPostCommentLike.Id,
            existingPostCommentLike.UserId
        );

        // Act
        await _postCommentLikeController.DeleteAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
            .Received(1)
            .SendAsync(Arg.Is<DeletePostCommentLikeCommand>(m => m.Id == existingPostCommentLike.Id &&
                                                    m.CurrentUserId == existingPostCommentLike.UserId),
                                                    CancellationToken);
    }
}
