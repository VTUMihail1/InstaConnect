using InstaConnect.Posts.Application.Features.PostComments.Commands.Update;

namespace InstaConnect.Posts.Presentation.UnitTests.Features.PostComments.Controllers.v1;

public class UpdatePostCommentControllerUnitTests : BasePostCommentUnitTest
{
    private readonly PostCommentController _postCommentController;

    public UpdatePostCommentControllerUnitTests()
    {
        _postCommentController = new(
            InstaConnectMapper,
            InstaConnectSender);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var existingPostComment = CreatePostComment();
        var request = new UpdatePostCommentRequest(
            existingPostComment.Id,
            existingPostComment.UserId,
            new(existingPostComment.Content)
        );

        // Act
        var response = await _postCommentController.UpdateAsync(request, CancellationToken);

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
        var existingPostComment = CreatePostComment();
        var request = new UpdatePostCommentRequest(
            existingPostComment.Id,
            existingPostComment.UserId,
            new(existingPostComment.Content)
        );

        // Act
        var response = await _postCommentController.UpdateAsync(request, CancellationToken);

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
    public async Task UpdateAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var existingPostComment = CreatePostComment();
        var request = new UpdatePostCommentRequest(
            existingPostComment.Id,
            existingPostComment.UserId,
            new(existingPostComment.Content)
        );

        // Act
        await _postCommentController.UpdateAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
            .Received(1)
            .SendAsync(Arg.Is<UpdatePostCommentCommand>(m => m.Id == existingPostComment.Id &&
                                                      m.CurrentUserId == existingPostComment.UserId &&
                                                      m.Content == existingPostComment.Content),
                                                    CancellationToken);
    }
}
