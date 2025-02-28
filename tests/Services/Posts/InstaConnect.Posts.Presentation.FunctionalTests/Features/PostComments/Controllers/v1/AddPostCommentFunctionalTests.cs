using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Posts.Common.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.PostComments.Controllers.v1;

public class AddPostCommentFunctionalTests : BasePostCommentFunctionalTest
{
    public AddPostCommentFunctionalTests(PostsWebApplicationFactory postsWebApplicationFactory) : base(postsWebApplicationFactory)
    {

    }

    [Fact]
    public async Task AddAsync_ShouldReturnUnauthorizedResponse_WhenUserIsUnauthorized()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new AddPostCommentRequest(
            existingUser.Id,
            new(existingPost.Id, PostCommentTestUtilities.ValidAddContent)
        );

        // Act
        var response = await PostCommentsClient.AddStatusCodeUnauthorizedAsync(request, CancellationToken);

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
        var request = new AddPostCommentRequest(
            existingUser.Id,
            new(null, PostCommentTestUtilities.ValidAddContent)
        );

        // Act
        var response = await PostCommentsClient.AddStatusCodeAsync(request, CancellationToken);

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
        var request = new AddPostCommentRequest(
            existingUser.Id,
            new(SharedTestUtilities.GetString(length), PostCommentTestUtilities.ValidAddContent)
        );

        // Act
        var response = await PostCommentsClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenContentIsNull()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new AddPostCommentRequest(
            existingUser.Id,
            new(existingPost.Id, null)
        );

        // Act
        var response = await PostCommentsClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostCommentConfigurations.ContentMinLength - 1)]
    [InlineData(PostCommentConfigurations.ContentMaxLength + 1)]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenContentLengthIsInvalid(int length)
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new AddPostCommentRequest(
            existingUser.Id,
            new(existingPost.Id, SharedTestUtilities.GetString(length))
        );

        // Act
        var response = await PostCommentsClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new AddPostCommentRequest(
            null,
            new(existingPost.Id, PostCommentTestUtilities.ValidAddContent)
        );

        // Act
        var response = await PostCommentsClient.AddStatusCodeAsync(request, CancellationToken);

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
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new AddPostCommentRequest(
            SharedTestUtilities.GetString(length),
            new(existingPost.Id, PostCommentTestUtilities.ValidAddContent)
        );

        // Act
        var response = await PostCommentsClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnNotFoundResponse_WhenCurrentUserIsInvalid()
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new AddPostCommentRequest(
            UserTestUtilities.InvalidId,
            new(existingPost.Id, PostCommentTestUtilities.ValidAddContent)
        );

        // Act
        var response = await PostCommentsClient.AddStatusCodeAsync(request, CancellationToken);

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
        var request = new AddPostCommentRequest(
            existingUser.Id,
            new(PostTestUtilities.InvalidId, PostCommentTestUtilities.ValidAddContent)
        );

        // Act
        var response = await PostCommentsClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new AddPostCommentRequest(
            existingUser.Id,
            new(existingPost.Id, PostCommentTestUtilities.ValidAddContent)
        );

        // Act
        var response = await PostCommentsClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task AddAsync_ShouldAddPostComment_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new AddPostCommentRequest(
            existingUser.Id,
            new(existingPost.Id, PostCommentTestUtilities.ValidAddContent)
        );

        // Act
        var response = await PostCommentsClient.AddAsync(request, CancellationToken);
        var postComment = await PostCommentWriteRepository.GetByIdAsync(response.Id, CancellationToken);

        // Assert
        postComment
            .Should()
            .Match<PostComment>(m => m.Id == response.Id &&
                                 m.UserId == existingUser.Id &&
                                 m.PostId == existingPost.Id &&
                                 m.Content == PostCommentTestUtilities.ValidAddContent);
    }
}
