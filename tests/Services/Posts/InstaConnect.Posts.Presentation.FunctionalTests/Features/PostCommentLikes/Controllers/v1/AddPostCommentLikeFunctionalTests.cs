﻿namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.PostCommentLikes.Controllers.v1;

public class AddPostCommentLikeFunctionalTests : BasePostCommentLikeFunctionalTest
{
    public AddPostCommentLikeFunctionalTests(PostsWebApplicationFactory postsWebApplicationFactory) : base(postsWebApplicationFactory)
    {

    }

    [Fact]
    public async Task AddAsync_ShouldReturnUnauthorizedResponse_WhenUserIsUnauthorized()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var request = new AddPostCommentLikeRequest(
            existingUser.Id,
            new(existingPostComment.Id));

        // Act
        var response = await PostCommentLikesClient.AddStatusCodeUnauthorizedAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenPostCommentIdIsNull()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new AddPostCommentLikeRequest(
            existingUser.Id,
            new(null));

        // Act
        var response = await PostCommentLikesClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostCommentConfigurations.IdMinLength - 1)]
    [InlineData(PostCommentConfigurations.IdMaxLength + 1)]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenPostCommentIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new AddPostCommentLikeRequest(
            existingUser.Id,
            new(SharedTestUtilities.GetString(length)));

        // Act
        var response = await PostCommentLikesClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var request = new AddPostCommentLikeRequest(
            null,
            new(existingPostComment.Id));

        // Act
        var response = await PostCommentLikesClient.AddStatusCodeAsync(request, CancellationToken);

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
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var request = new AddPostCommentLikeRequest(
            SharedTestUtilities.GetString(length),
            new(existingPostComment.Id));

        // Act
        var response = await PostCommentLikesClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnNotFoundResponse_WhenCurrentUserIsInvalid()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var request = new AddPostCommentLikeRequest(
            UserTestUtilities.InvalidId,
            new(existingPostComment.Id));

        // Act
        var response = await PostCommentLikesClient.AddStatusCodeAsync(request, CancellationToken);

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
        var request = new AddPostCommentLikeRequest(
            existingUser.Id,
            new(PostCommentTestUtilities.InvalidId));

        // Act
        var response = await PostCommentLikesClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenPostCommentLikeAlreadyExists()
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var request = new AddPostCommentLikeRequest(
            existingPostCommentLike.UserId,
            new(existingPostCommentLike.PostCommentId));

        // Act
        var response = await PostCommentLikesClient.AddStatusCodeAsync(request, CancellationToken);

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
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var request = new AddPostCommentLikeRequest(
            existingUser.Id,
            new(existingPostComment.Id));

        // Act
        var response = await PostCommentLikesClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task AddAsync_ShouldAddPostCommentLike_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var request = new AddPostCommentLikeRequest(
            existingUser.Id,
            new(existingPostComment.Id));

        // Act
        var response = await PostCommentLikesClient.AddAsync(request, CancellationToken);

        var postCommentLike = await PostCommentLikeWriteRepository.GetByIdAsync(response.Id, CancellationToken);

        // Assert
        postCommentLike
            .Should()
            .Match<PostCommentLike>(m => m.Id == response.Id &&
                                 m.UserId == existingUser.Id &&
                                 m.PostCommentId == existingPostComment.Id);
    }
}
