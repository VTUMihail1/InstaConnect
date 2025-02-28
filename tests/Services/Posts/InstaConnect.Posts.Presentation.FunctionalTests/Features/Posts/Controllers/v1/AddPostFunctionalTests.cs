using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.Posts.Controllers.v1;

public class AddPostFunctionalTests : BasePostFunctionalTest
{
    public AddPostFunctionalTests(PostsWebApplicationFactory postsWebApplicationFactory) : base(postsWebApplicationFactory)
    {

    }

    [Fact]
    public async Task AddAsync_ShouldReturnUnauthorizedResponse_WhenUserIsUnauthorized()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new AddPostRequest(
            existingUser.Id,
            new(PostTestUtilities.ValidAddTitle, PostTestUtilities.ValidAddContent)
        );

        // Act
        var response = await PostsClient.AddStatusCodeUnauthorizedAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenTitleIsNull()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new AddPostRequest(
            existingUser.Id,
            new(null, PostTestUtilities.ValidAddContent)
        );

        // Act
        var response = await PostsClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostConfigurations.TitleMinLength - 1)]
    [InlineData(PostConfigurations.TitleMaxLength + 1)]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenTitleLengthIsInvalid(int length)
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new AddPostRequest(
            existingUser.Id,
            new(SharedTestUtilities.GetString(length), PostTestUtilities.ValidAddContent)
        );

        // Act
        var response = await PostsClient.AddStatusCodeAsync(request, CancellationToken);

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
        var request = new AddPostRequest(
            existingUser.Id,
            new(PostTestUtilities.ValidAddTitle, null)
        );

        // Act
        var response = await PostsClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostConfigurations.ContentMinLength - 1)]
    [InlineData(PostConfigurations.ContentMaxLength + 1)]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenContentLengthIsInvalid(int length)
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new AddPostRequest(
            existingUser.Id,
            new(PostTestUtilities.ValidAddTitle, SharedTestUtilities.GetString(length))
        );

        // Act
        var response = await PostsClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var request = new AddPostRequest(
            null,
            new(PostTestUtilities.ValidAddTitle, PostTestUtilities.ValidAddContent)
        );

        // Act
        var response = await PostsClient.AddStatusCodeAsync(request, CancellationToken);

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
        var request = new AddPostRequest(
            SharedTestUtilities.GetString(length),
            new(PostTestUtilities.ValidAddTitle, PostTestUtilities.ValidAddContent)
        );

        // Act
        var response = await PostsClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnNotFoundResponse_WhenCurrentUserIsInvalid()
    {
        // Arrange
        var request = new AddPostRequest(
            UserTestUtilities.InvalidId,
            new(PostTestUtilities.ValidAddTitle, PostTestUtilities.ValidAddContent)
        );

        // Act
        var response = await PostsClient.AddStatusCodeAsync(request, CancellationToken);

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
        var request = new AddPostRequest(
            existingUser.Id,
            new(PostTestUtilities.ValidAddTitle, PostTestUtilities.ValidAddContent)
        );

        // Act
        var response = await PostsClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task AddAsync_ShouldAddPost_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new AddPostRequest(
            existingUser.Id,
            new(PostTestUtilities.ValidAddTitle, PostTestUtilities.ValidAddContent)
        );

        // Act
        var response = await PostsClient.AddAsync(request, CancellationToken);

        var post = await PostWriteRepository.GetByIdAsync(response.Id, CancellationToken);

        // Assert
        post
            .Should()
            .Match<Post>(m => m.Id == response.Id &&
                                 m.UserId == existingUser.Id &&
                                 m.Content == PostTestUtilities.ValidAddContent &&
                                 m.Title == PostTestUtilities.ValidAddTitle);
    }
}
