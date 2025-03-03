﻿using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetById;

namespace InstaConnect.Posts.Presentation.UnitTests.Features.PostCommentLikes.Controllers.v1;

public class GetPostCommentLikeByIdControllerUnitTests : BasePostCommentLikeUnitTest
{
    private readonly PostCommentLikeController _postCommentLikeController;

    public GetPostCommentLikeByIdControllerUnitTests()
    {
        _postCommentLikeController = new(
            InstaConnectMapper,
            InstaConnectSender);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var existingPostCommentLike = CreatePostCommentLike();
        var request = new GetPostCommentLikeByIdRequest(
            existingPostCommentLike.Id
        );

        // Act
        var response = await _postCommentLikeController.GetByIdAsync(request, CancellationToken);

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
        var existingPostCommentLike = CreatePostCommentLike();
        var request = new GetPostCommentLikeByIdRequest(
            existingPostCommentLike.Id
        );

        // Act
        var response = await _postCommentLikeController.GetByIdAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<PostCommentLikeQueryResponse>(m => m.Id == existingPostCommentLike.Id &&
                                                 m.PostCommentId == existingPostCommentLike.PostCommentId &&
                                                 m.UserId == existingPostCommentLike.UserId &&
                                                 m.UserName == existingPostCommentLike.User.UserName &&
                                                 m.UserProfileImage == existingPostCommentLike.User.ProfileImage);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var existingPostCommentLike = CreatePostCommentLike();
        var request = new GetPostCommentLikeByIdRequest(
            existingPostCommentLike.Id
        );

        // Act
        await _postCommentLikeController.GetByIdAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetPostCommentLikeByIdQuery>(m => m.Id == existingPostCommentLike.Id), CancellationToken);
    }
}
