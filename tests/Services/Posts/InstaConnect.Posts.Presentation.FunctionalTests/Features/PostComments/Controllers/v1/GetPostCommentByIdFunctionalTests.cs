using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Posts.Common.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.PostComments.Controllers.v1;

public class GetPostCommentByIdFunctionalTests : BasePostCommentFunctionalTest
{
    public GetPostCommentByIdFunctionalTests(PostsWebApplicationFactory postsWebApplicationFactory) : base(postsWebApplicationFactory)
    {

    }

    [Theory]
    [InlineData(PostCommentConfigurations.IdMinLength - 1)]
    [InlineData(PostCommentConfigurations.IdMaxLength + 1)]
    public async Task GetByIdAsync_ShouldReturnBadRequestResponse_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var request = new GetPostCommentByIdRequest(
            SharedTestUtilities.GetString(length)
        );

        // Act
        var response = await PostCommentsClient.GetByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }


    [Fact]
    public async Task GetByIdAsync_ShouldReturnNotFoundResponse_WhenIdIsInvalid()
    {
        // Arrange
        var request = new GetPostCommentByIdRequest(
            PostCommentTestUtilities.InvalidId
        );

        // Act
        var response = await PostCommentsClient.GetByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var request = new GetPostCommentByIdRequest(
            existingPostComment.Id
        );

        // Act
        var response = await PostCommentsClient.GetByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnPostCommentViewResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var request = new GetPostCommentByIdRequest(
            existingPostComment.Id
        );

        // Act
        var response = await PostCommentsClient.GetByIdAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentQueryResponse>(m => m.Id == existingPostComment.Id &&
                                 m.Content == existingPostComment.Content &&
                                 m.UserId == existingPostComment.UserId &&
                                 m.UserName == existingPostComment.User.UserName &&
                                 m.UserProfileImage == existingPostComment.User.ProfileImage &&
                                 m.PostId == existingPostComment.PostId);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnPostCommentViewResponse_WhenRequestIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var request = new GetPostCommentByIdRequest(
            SharedTestUtilities.GetNonCaseMatchingString(existingPostComment.Id)
        );

        // Act
        var response = await PostCommentsClient.GetByIdAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentQueryResponse>(m => m.Id == existingPostComment.Id &&
                                 m.Content == existingPostComment.Content &&
                                 m.UserId == existingPostComment.UserId &&
                                 m.UserName == existingPostComment.User.UserName &&
                                 m.UserProfileImage == existingPostComment.User.ProfileImage &&
                                 m.PostId == existingPostComment.PostId);
    }
}
