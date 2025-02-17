namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.Posts.Controllers.v1;

public class GetPostByIdFunctionalTests : BasePostFunctionalTest
{
    public GetPostByIdFunctionalTests(PostsWebApplicationFactory postsWebApplicationFactory) : base(postsWebApplicationFactory)
    {

    }

    [Theory]
    [InlineData(PostConfigurations.IdMinLength - 1)]
    [InlineData(PostConfigurations.IdMaxLength + 1)]
    public async Task GetByIdAsync_ShouldReturnBadRequestResponse_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new GetPostByIdRequest(
            SharedTestUtilities.GetString(length)
        );

        // Act
        var response = await PostsClient.GetByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }


    [Fact]
    public async Task GetByIdAsync_ShouldReturnNotFoundResponse_WhenIdIsInvalid()
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new GetPostByIdRequest(
            PostTestUtilities.InvalidId
        );

        // Act
        var response = await PostsClient.GetByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new GetPostByIdRequest(
            existingPost.Id
        );

        // Act
        var response = await PostsClient.GetByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnPostViewResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new GetPostByIdRequest(
            existingPost.Id
        );

        // Act
        var response = await PostsClient.GetByIdAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostQueryResponse>(m => m.Id == existingPost.Id &&
                                 m.Content == existingPost.Content &&
                                 m.UserId == existingPost.UserId &&
                                 m.UserName == existingPost.User.UserName &&
                                 m.UserProfileImage == existingPost.User.ProfileImage &&
                                 m.Title == existingPost.Title);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnPostViewResponse_WhenRequestIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new GetPostByIdRequest(
            SharedTestUtilities.GetNonCaseMatchingString(existingPost.Id)
        );

        // Act
        var response = await PostsClient.GetByIdAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostQueryResponse>(m => m.Id == existingPost.Id &&
                                 m.Content == existingPost.Content &&
                                 m.UserId == existingPost.UserId &&
                                 m.UserName == existingPost.User.UserName &&
                                 m.UserProfileImage == existingPost.User.ProfileImage &&
                                 m.Title == existingPost.Title);
    }
}
