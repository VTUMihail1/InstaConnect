using System.Net;
using FluentAssertions;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetPostLikeById;
using InstaConnect.Posts.Common.Features.Users.Utilities;
using InstaConnect.Posts.Presentation.Features.PostLikes.Controllers.v1;
using InstaConnect.Posts.Presentation.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Presentation.Features.PostLikes.Models.Responses;
using InstaConnect.Posts.Presentation.UnitTests.Features.PostLikes.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

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
                                                 m.UserName == UserTestUtilities.ValidName &&
                                                 m.UserProfileImage == UserTestUtilities.ValidProfileImage);
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
