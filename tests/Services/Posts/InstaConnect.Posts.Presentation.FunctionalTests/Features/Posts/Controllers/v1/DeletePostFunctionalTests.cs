namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.Posts.Controllers.v1;

public class DeletePostFunctionalTests : BasePostFunctionalTest
{
    public DeletePostFunctionalTests(PostsWebApplicationFactory postsWebApplicationFactory) : base(postsWebApplicationFactory)
    {

    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnUnauthorizedResponse_WhenUserIsUnauthorized()
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new DeletePostRequest(
            existingPost.Id,
            existingPost.UserId
        );

        // Act
        var response = await PostsClient.DeleteStatusCodeUnauthorizedAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.Unauthorized);
    }

    [Theory]
    [InlineData(PostConfigurations.IdMinLength - 1)]
    [InlineData(PostConfigurations.IdMaxLength + 1)]
    public async Task DeleteAsync_ShouldReturnBadRequestResponse_WhenIdIsInvalid(int length)
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new DeletePostRequest(
            SharedTestUtilities.GetString(length),
            existingPost.UserId
        );

        // Act
        var response = await PostsClient.DeleteStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new DeletePostRequest(
            existingPost.Id,
            null
        );

        // Act
        var response = await PostsClient.DeleteStatusCodeAsync(request, CancellationToken);

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
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new DeletePostRequest(
            existingPost.Id,
            SharedTestUtilities.GetString(length)
        );

        // Act
        var response = await PostsClient.DeleteStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnNotFoundResponse_WhenIdIsInvalid()
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new DeletePostRequest(
            PostTestUtilities.InvalidId,
            existingPost.UserId
        );

        // Act
        var response = await PostsClient.DeleteStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnForbiddenResponse_WhenCurrentUserIdDoesNotOwnThePostIdInvalid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new DeletePostRequest(
            existingPost.Id,
            existingUser.Id
        );

        // Act
        var response = await PostsClient.DeleteStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.Forbidden);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnNoContentResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new DeletePostRequest(
            existingPost.Id,
            existingPost.UserId
        );

        // Act
        var response = await PostsClient.DeleteStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task DeleteAsync_ShouldDeletePost_WhenRequestIsValid()
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new DeletePostRequest(
            existingPost.Id,
            existingPost.UserId
        );

        // Act
        await PostsClient.DeleteAsync(request, CancellationToken);

        var message = await PostWriteRepository.GetByIdAsync(existingPost.Id, CancellationToken);

        // Assert
        message
            .Should()
            .BeNull();
    }

    [Fact]
    public async Task DeleteAsync_ShouldDeletePost_WhenRequestIsValidAndIdDoesNotMatchCase()
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new DeletePostRequest(
            SharedTestUtilities.GetNonCaseMatchingString(existingPost.Id),
            existingPost.UserId
        );

        // Act
        await PostsClient.DeleteAsync(request, CancellationToken);

        var message = await PostWriteRepository.GetByIdAsync(existingPost.Id, CancellationToken);

        // Assert
        message
            .Should()
            .BeNull();
    }
}
