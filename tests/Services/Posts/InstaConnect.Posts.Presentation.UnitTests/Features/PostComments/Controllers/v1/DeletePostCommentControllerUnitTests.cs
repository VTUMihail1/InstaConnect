using InstaConnect.Posts.Application.Features.PostComments.Commands.Delete;

namespace InstaConnect.Posts.Presentation.UnitTests.Features.PostComments.Controllers.v1;

public class DeletePostCommentControllerUnitTests : BasePostCommentUnitTest
{
    private readonly PostCommentController _postCommentController;

    public DeletePostCommentControllerUnitTests()
    {
        _postCommentController = new(
            InstaConnectMapper,
            InstaConnectSender);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var existingPostComment = CreatePostComment();
        var request = new DeletePostCommentRequest(
            existingPostComment.Id,
            existingPostComment.UserId
        );

        // Act
        var response = await _postCommentController.DeleteAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<NoContentResult>(m => m.StatusCode == StatusCodes.Status204NoContent);
    }

    [Fact]
    public async Task DeleteAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var existingPostComment = CreatePostComment();
        var request = new DeletePostCommentRequest(
            existingPostComment.Id,
            existingPostComment.UserId
        );

        // Act
        await _postCommentController.DeleteAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
            .Received(1)
            .SendAsync(Arg.Is<DeletePostCommentCommand>(m => m.Id == existingPostComment.Id &&
                                                    m.CurrentUserId == existingPostComment.UserId),
                                                    CancellationToken);
    }
}
