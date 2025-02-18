using InstaConnect.Posts.Application.Features.PostLikes.Commands.Delete;

namespace InstaConnect.Posts.Presentation.UnitTests.Features.PostLikes.Controllers.v1;

public class DeletePostLikeControllerUnitTests : BasePostLikeUnitTest
{
    private readonly PostLikeController _postLikeController;

    public DeletePostLikeControllerUnitTests()
    {
        _postLikeController = new(
            InstaConnectMapper,
            InstaConnectSender);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var existingPostLike = CreatePostLike();
        var request = new DeletePostLikeRequest(
            existingPostLike.Id,
            existingPostLike.UserId
        );

        // Act
        var response = await _postLikeController.DeleteAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<NoContentResult>(m => m.StatusCode == StatusCodes.Status204NoContent);
    }

    [Fact]
    public async Task DeleteAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var existingPostLike = CreatePostLike();
        var request = new DeletePostLikeRequest(
            existingPostLike.Id,
            existingPostLike.UserId
        );

        // Act
        await _postLikeController.DeleteAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
            .Received(1)
            .SendAsync(Arg.Is<DeletePostLikeCommand>(m => m.Id == existingPostLike.Id &&
                                                    m.CurrentUserId == existingPostLike.UserId),
                                                    CancellationToken);
    }
}
