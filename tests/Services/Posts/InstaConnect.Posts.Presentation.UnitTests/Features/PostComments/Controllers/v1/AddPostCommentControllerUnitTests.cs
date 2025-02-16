using FluentAssertions;

using InstaConnect.Posts.Application.Features.PostComments.Commands.Add;
using InstaConnect.Posts.Common.Features.PostComments.Utilities;
using InstaConnect.Posts.Presentation.Features.PostComments.Controllers.v1;
using InstaConnect.Posts.Presentation.Features.PostComments.Models.Requests;
using InstaConnect.Posts.Presentation.Features.PostComments.Models.Responses;
using InstaConnect.Posts.Presentation.UnitTests.Features.PostComments.Utilities;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using NSubstitute;

namespace InstaConnect.Posts.Presentation.UnitTests.Features.PostComments.Controllers.v1;

public class AddPostCommentControllerUnitTests : BasePostCommentUnitTest
{
    private readonly PostCommentController _postCommentController;

    public AddPostCommentControllerUnitTests()
    {
        _postCommentController = new(
            InstaConnectMapper,
            InstaConnectSender);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var existingPostComment = CreatePostComment();
        var request = new AddPostCommentRequest(
            existingPostComment.UserId,
            new(existingPostComment.PostId, PostCommentTestUtilities.ValidAddContent)
        );

        // Act
        var response = await _postCommentController.AddAsync(request, CancellationToken);

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
        var existingPostComment = CreatePostComment();
        var request = new AddPostCommentRequest(
            existingPostComment.UserId,
            new(existingPostComment.PostId, PostCommentTestUtilities.ValidAddContent)
        );

        // Act
        var response = await _postCommentController.AddAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<PostCommentCommandResponse>(m => m.Id == existingPostComment.Id);
    }

    [Fact]
    public async Task AddAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var existingPostComment = CreatePostComment();
        var request = new AddPostCommentRequest(
            existingPostComment.UserId,
            new(existingPostComment.PostId, PostCommentTestUtilities.ValidAddContent)
        );

        // Act
        await _postCommentController.AddAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
            .Received(1)
            .SendAsync(Arg.Is<AddPostCommentCommand>(m => m.CurrentUserId == existingPostComment.UserId &&
                                                     m.PostId == existingPostComment.PostId &&
                                                     m.Content == PostCommentTestUtilities.ValidAddContent),
                                                     CancellationToken);
    }
}
