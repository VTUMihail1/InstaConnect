using InstaConnect.Posts.Application.Features.PostComments.Queries.GetById;

namespace InstaConnect.Posts.Presentation.UnitTests.Features.PostComments.Controllers.v1;

public class GetPostCommentByIdControllerUnitTests : BasePostCommentUnitTest
{
    private readonly PostCommentController _postCommentController;

    public GetPostCommentByIdControllerUnitTests()
    {
        _postCommentController = new(
            InstaConnectMapper,
            InstaConnectSender);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var existingPostComment = CreatePostComment();
        var request = new GetPostCommentByIdRequest(
            existingPostComment.Id
        );

        // Act
        var response = await _postCommentController.GetByIdAsync(request, CancellationToken);

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
        var existingPostComment = CreatePostComment();
        var request = new GetPostCommentByIdRequest(
            existingPostComment.Id
        );

        // Act
        var response = await _postCommentController.GetByIdAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<PostCommentQueryResponse>(m => m.Id == existingPostComment.Id &&
                                                 m.PostId == existingPostComment.PostId &&
                                                 m.Content == existingPostComment.Content &&
                                                 m.UserId == existingPostComment.UserId &&
                                                 m.UserName == existingPostComment.User.UserName &&
                                                 m.UserProfileImage == existingPostComment.User.ProfileImage);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var existingPostComment = CreatePostComment();
        var request = new GetPostCommentByIdRequest(
            existingPostComment.Id
        );

        // Act
        await _postCommentController.GetByIdAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetPostCommentByIdQuery>(m => m.Id == existingPostComment.Id), CancellationToken);
    }
}
