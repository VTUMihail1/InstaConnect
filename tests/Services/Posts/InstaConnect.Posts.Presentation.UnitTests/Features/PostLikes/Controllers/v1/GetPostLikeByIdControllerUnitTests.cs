﻿using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetById;

namespace InstaConnect.Posts.Presentation.UnitTests.Features.PostLikes.Controllers.v1;

public class GetPostLikeByIdControllerUnitTests : BasePostLikeUnitTest
{
    private readonly PostLikeController _postLikeController;

    public GetPostLikeByIdControllerUnitTests()
    {
        _postLikeController = new(
            InstaConnectMapper,
            InstaConnectSender);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var existingPostLike = CreatePostLike();
        var request = new GetPostLikeByIdRequest(
            existingPostLike.Id
        );

        // Act
        var response = await _postLikeController.GetByIdAsync(request, CancellationToken);

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
        var existingPostLike = CreatePostLike();
        var request = new GetPostLikeByIdRequest(
            existingPostLike.Id
        );

        // Act
        var response = await _postLikeController.GetByIdAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<PostLikeQueryResponse>(m => m.Id == existingPostLike.Id &&
                                                 m.PostId == existingPostLike.PostId &&
                                                 m.UserId == existingPostLike.UserId &&
                                                 m.UserName == existingPostLike.User.UserName &&
                                                 m.UserProfileImage == existingPostLike.User.ProfileImage);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var existingPostLike = CreatePostLike();
        var request = new GetPostLikeByIdRequest(
            existingPostLike.Id
        );

        // Act
        await _postLikeController.GetByIdAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetPostLikeByIdQuery>(m => m.Id == existingPostLike.Id), CancellationToken);
    }
}
