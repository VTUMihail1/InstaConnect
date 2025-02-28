using InstaConnect.Posts.Common.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.PostCommentLikes.Controllers.v1;

public class DeletePostCommentLikeFunctionalTests : BasePostCommentLikeFunctionalTest
{
    public DeletePostCommentLikeFunctionalTests(PostsWebApplicationFactory postsWebApplicationFactory) : base(postsWebApplicationFactory)
    {

    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnUnauthorizedResponse_WhenUserIsUnauthorized()
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var request = new DeletePostCommentLikeRequest(
            existingPostCommentLike.Id,
            existingPostCommentLike.UserId);

        // Act
        var response = await PostCommentLikesClient.DeleteStatusCodeUnauthorizedAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.Unauthorized);
    }

    [Theory]
    [InlineData(PostCommentLikeConfigurations.IdMinLength - 1)]
    [InlineData(PostCommentLikeConfigurations.IdMaxLength + 1)]
    public async Task DeleteAsync_ShouldReturnBadRequestResponse_WhenIdIsInvalid(int length)
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var request = new DeletePostCommentLikeRequest(
            SharedTestUtilities.GetString(length),
            existingPostCommentLike.UserId);

        // Act
        var response = await PostCommentLikesClient.DeleteStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var request = new DeletePostCommentLikeRequest(
            existingPostCommentLike.Id,
            null);

        // Act
        var response = await PostCommentLikesClient.DeleteStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task DeleteAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var request = new DeletePostCommentLikeRequest(
            existingPostCommentLike.Id,
            SharedTestUtilities.GetString(length));

        // Act
        var response = await PostCommentLikesClient.DeleteStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnNotFoundResponse_WhenIdIsInvalid()
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var request = new DeletePostCommentLikeRequest(
            PostCommentLikeTestUtilities.InvalidId,
            existingPostCommentLike.UserId);

        // Act
        var response = await PostCommentLikesClient.DeleteStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnForbiddenResponse_WhenCurrentUserIdDoesNotOwnThePostCommentLikeIdInvalid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var request = new DeletePostCommentLikeRequest(
            existingPostCommentLike.Id,
            existingUser.Id);

        // Act
        var response = await PostCommentLikesClient.DeleteStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.Forbidden);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnNoContentResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var request = new DeletePostCommentLikeRequest(
            existingPostCommentLike.Id,
            existingPostCommentLike.UserId);

        // Act
        var response = await PostCommentLikesClient.DeleteStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task DeleteAsync_ShouldDeletePostCommentLike_WhenRequestIsValid()
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var request = new DeletePostCommentLikeRequest(
            existingPostCommentLike.Id,
            existingPostCommentLike.UserId);

        // Act
        await PostCommentLikesClient.DeleteAsync(request, CancellationToken);

        var message = await PostCommentLikeWriteRepository.GetByIdAsync(existingPostCommentLike.Id, CancellationToken);

        // Assert
        message
            .Should()
            .BeNull();
    }

    [Fact]
    public async Task DeleteAsync_ShouldDeletePostCommentLike_WhenRequestIsValidAndIdDoesNotMatchCase()
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var request = new DeletePostCommentLikeRequest(
            SharedTestUtilities.GetNonCaseMatchingString(existingPostCommentLike.Id),
            existingPostCommentLike.UserId);

        // Act
        await PostCommentLikesClient.DeleteAsync(request, CancellationToken);

        var message = await PostCommentLikeWriteRepository.GetByIdAsync(existingPostCommentLike.Id, CancellationToken);

        // Assert
        message
            .Should()
            .BeNull();
    }
}
