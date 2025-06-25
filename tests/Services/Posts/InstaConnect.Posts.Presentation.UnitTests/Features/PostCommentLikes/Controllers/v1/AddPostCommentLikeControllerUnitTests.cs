using InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Add;

namespace InstaConnect.Posts.Presentation.UnitTests.Features.PostCommentLikes.Controllers.v1;

public class AddPostCommentLikeControllerUnitTests : BasePostCommentLikeUnitTest
{
    private readonly PostCommentLikeController _postCommentLikeController;

    public AddPostCommentLikeControllerUnitTests()
    {
        _postCommentLikeController = new(
            ApplicationMapper,
            ApplicationSender);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var existingPostCommentLike = CreatePostCommentLike();
        var request = new AddPostCommentLikeRequest(
            existingPostCommentLike.UserId,
            new(existingPostCommentLike.PostCommentId)
        );

        // Act
        var response = await _postCommentLikeController.AddAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == StatusCodes.Status200OK);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnPostCommentLikeViewModel_WhenRequestIsValid()
    {
        // Arrange
        var existingPostCommentLike = CreatePostCommentLike();
        var request = new AddPostCommentLikeRequest(
            existingPostCommentLike.UserId,
            new(existingPostCommentLike.PostCommentId)
        );

        // Act
        var response = await _postCommentLikeController.AddAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<PostCommentLikeCommandResponse>(m => m.Id == existingPostCommentLike.Id);
    }

    [Fact]
    public async Task AddAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var existingPostCommentLike = CreatePostCommentLike();
        var request = new AddPostCommentLikeRequest(
            existingPostCommentLike.UserId,
            new(existingPostCommentLike.PostCommentId)
        );

        // Act
        await _postCommentLikeController.AddAsync(request, CancellationToken);

        // Assert
        await ApplicationSender
            .Received(1)
            .SendAsync(Arg.Is<AddPostCommentLikeCommand>(m => m.CurrentUserId == existingPostCommentLike.UserId &&
                                                     m.PostCommentId == existingPostCommentLike.PostCommentId),
                                                     CancellationToken);
    }
}
