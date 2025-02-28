using InstaConnect.Posts.Common.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.PostComments.Controllers.v1;

public class UpdatePostCommentFunctionalTests : BasePostCommentFunctionalTest
{
    public UpdatePostCommentFunctionalTests(PostsWebApplicationFactory postsWebApplicationFactory) : base(postsWebApplicationFactory)
    {

    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnUnauthorizedResponse_WhenUserIsUnauthorized()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var request = new UpdatePostCommentRequest(
            existingPostComment.Id,
            existingPostComment.UserId,
            new(existingPostComment.Content));

        // Act
        var response = await PostCommentsClient.UpdateStatusCodeUnauthorizedAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.Unauthorized);
    }

    [Theory]
    [InlineData(PostCommentConfigurations.IdMinLength - 1)]
    [InlineData(PostCommentConfigurations.IdMaxLength + 1)]
    public async Task UpdateAsync_ShouldReturnBadRequestResponse_WhenIdIsInvalid(int length)
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var request = new UpdatePostCommentRequest(
            SharedTestUtilities.GetString(length),
            existingPostComment.UserId,
            new(existingPostComment.Content));

        // Act
        var response = await PostCommentsClient.UpdateStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnBadRequestResponse_WhenContentIsNull()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var request = new UpdatePostCommentRequest(
            existingPostComment.Id,
            existingPostComment.UserId,
            new(null));

        // Act
        var response = await PostCommentsClient.UpdateStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostCommentConfigurations.ContentMinLength - 1)]
    [InlineData(PostCommentConfigurations.ContentMaxLength + 1)]
    public async Task UpdateAsync_ShouldReturnBadRequestResponse_WhenContentLengthIsInvalid(int length)
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var request = new UpdatePostCommentRequest(
            existingPostComment.Id,
            existingPostComment.UserId,
            new(SharedTestUtilities.GetString(length)));

        // Act
        var response = await PostCommentsClient.UpdateStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var request = new UpdatePostCommentRequest(
            existingPostComment.Id,
            null,
            new(existingPostComment.Content));

        // Act
        var response = await PostCommentsClient.UpdateStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task UpdateAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var request = new UpdatePostCommentRequest(
            existingPostComment.Id,
            SharedTestUtilities.GetString(length),
            new(existingPostComment.Content));

        // Act
        var response = await PostCommentsClient.UpdateStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnNotFoundResponse_WhenIdIsInvalid()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var request = new UpdatePostCommentRequest(
            PostCommentTestUtilities.InvalidId,
            existingPostComment.UserId,
            new(existingPostComment.Content));

        // Act
        var response = await PostCommentsClient.UpdateStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnForbiddenResponse_WhenCurrentUserIdDoesNotOwnThePostCommentIdInvalid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var request = new UpdatePostCommentRequest(
            existingPostComment.Id,
            existingUser.Id,
            new(existingPostComment.Content));

        // Act
        var response = await PostCommentsClient.UpdateStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.Forbidden);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var request = new UpdatePostCommentRequest(
            existingPostComment.Id,
            existingPostComment.UserId,
            new(existingPostComment.Content));

        // Act
        var response = await PostCommentsClient.UpdateStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnPostCommentViewModel_WhenRequestIsValid()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var request = new UpdatePostCommentRequest(
            existingPostComment.Id,
            existingPostComment.UserId,
            new(existingPostComment.Content));

        // Act
        var response = await PostCommentsClient.UpdateAsync(request, CancellationToken);

        // Assert

        response
            .Should()
            .Match<PostCommentCommandResponse>(m => m.Id == existingPostComment.Id);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdatePostComment_WhenRequestIsValid()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var request = new UpdatePostCommentRequest(
            existingPostComment.Id,
            existingPostComment.UserId,
            new(existingPostComment.Content));

        // Act
        var response = await PostCommentsClient.UpdateAsync(request, CancellationToken);

        var postComment = await PostCommentWriteRepository.GetByIdAsync(response.Id, CancellationToken);

        // Arrange
        postComment
            .Should()
            .Match<PostComment>(m => m.Id == existingPostComment.Id &&
                                 m.UserId == existingPostComment.UserId &&
                                 m.PostId == existingPostComment.PostId &&
                                 m.Content == existingPostComment.Content);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdatePostComment_WhenRequestIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var request = new UpdatePostCommentRequest(
            SharedTestUtilities.GetNonCaseMatchingString(existingPostComment.Id),
            existingPostComment.UserId,
            new(existingPostComment.Content));

        // Act
        var response = await PostCommentsClient.UpdateAsync(request, CancellationToken);
        var postComment = await PostCommentWriteRepository.GetByIdAsync(response.Id, CancellationToken);

        // Arrange
        postComment
            .Should()
            .Match<PostComment>(m => m.Id == existingPostComment.Id &&
                                 m.UserId == existingPostComment.UserId &&
                                 m.PostId == existingPostComment.PostId &&
                                 m.Content == existingPostComment.Content);
    }
}
