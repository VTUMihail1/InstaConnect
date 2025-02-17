namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.PostLikes.Controllers.v1;

public class AddPostLikeFunctionalTests : BasePostLikeFunctionalTest
{
    public AddPostLikeFunctionalTests(PostsWebApplicationFactory postsWebApplicationFactory) : base(postsWebApplicationFactory)
    {

    }

    [Fact]
    public async Task AddAsync_ShouldReturnUnauthorizedResponse_WhenUserIsUnauthorized()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new AddPostLikeRequest(
            existingUser.Id,
            new(existingPost.Id));

        // Act
        var response = await PostLikesClient.AddStatusCodeUnauthorizedAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenPostIdIsNull()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new AddPostLikeRequest(
            existingUser.Id,
            new(null));

        // Act
        var response = await PostLikesClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostConfigurations.IdMinLength - 1)]
    [InlineData(PostConfigurations.IdMaxLength + 1)]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenPostIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new AddPostLikeRequest(
            existingUser.Id,
            new(SharedTestUtilities.GetString(length)));

        // Act
        var response = await PostLikesClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new AddPostLikeRequest(
            null,
            new(existingPost.Id));

        // Act
        var response = await PostLikesClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new AddPostLikeRequest(
            SharedTestUtilities.GetString(length),
            new(existingPost.Id));

        // Act
        var response = await PostLikesClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnNotFoundResponse_WhenCurrentUserIsInvalid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new AddPostLikeRequest(
            UserTestUtilities.InvalidId,
            new(existingPost.Id));

        // Act
        var response = await PostLikesClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnNotFoundResponse_WhenPostIdIsInvalid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new AddPostLikeRequest(
            existingUser.Id,
            new(PostTestUtilities.InvalidId));

        // Act
        var response = await PostLikesClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenPostLikeAlreadyExists()
    {
        // Arrange
        var existingPostLikeId = await CreatePostLikeAsync(CancellationToken);
        var request = new AddPostLikeRequest(
            existingPostLikeId.UserId,
            new(existingPostLikeId.PostId));

        // Act
        var response = await PostLikesClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new AddPostLikeRequest(
            existingUser.Id,
            new(existingPost.Id));

        // Act
        var response = await PostLikesClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task AddAsync_ShouldAddPostLike_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new AddPostLikeRequest(
            existingUser.Id,
            new(existingPost.Id));

        // Act
        var response = await PostLikesClient.AddAsync(request, CancellationToken);

        var postLike = await PostLikeWriteRepository.GetByIdAsync(response.Id, CancellationToken);

        // Assert
        postLike
            .Should()
            .Match<PostLike>(m => m.Id == response.Id &&
                                 m.UserId == existingUser.Id &&
                                 m.PostId == existingPost.Id);
    }
}
