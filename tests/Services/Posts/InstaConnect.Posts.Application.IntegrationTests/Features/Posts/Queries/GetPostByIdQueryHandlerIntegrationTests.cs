using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;

namespace InstaConnect.Posts.Application.IntegrationTests.Features.Posts.Queries;

public class GetPostByIdQueryHandlerIntegrationTests : BasePostIntegrationTest
{
    public GetPostByIdQueryHandlerIntegrationTests(PostsWebApplicationFactory postsWebApplicationFactory) : base(postsWebApplicationFactory)
    {
    }

    [Fact]
    public async Task SendAsync_ShouldThrowValidationException_WhenIdIsNull()
    {
        // Arrange
        var query = new GetPostByIdQuery(null);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AppValidationException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostConfigurations.IdMinLength - 1)]
    [InlineData(PostConfigurations.IdMaxLength + 1)]
    public async Task SendAsync_ShouldThrowValidationException_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var query = new GetPostByIdQuery(SharedTestUtilities.GetString(length));

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AppValidationException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowPostNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var query = new GetPostByIdQuery(PostTestUtilities.InvalidId);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<PostNotFoundException>();
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var query = new GetPostByIdQuery(existingPost.Id);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostQueryViewModel>(m => m.Id == existingPost.Id &&
                                          m.UserId == existingPost.UserId &&
                                          m.UserName == existingPost.User.UserName &&
                                          m.UserProfileImage == existingPost.User.ProfileImage &&
                                          m.Title == existingPost.Title &&
                                          m.Content == existingPost.Content);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnPostViewModelCollection_WhenQueryIsValidAndCaseDoesNotMatch()
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var query = new GetPostByIdQuery(SharedTestUtilities.GetNonCaseMatchingString(existingPost.Id));

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostQueryViewModel>(m => m.Id == existingPost.Id &&
                                          m.UserId == existingPost.UserId &&
                                          m.UserName == existingPost.User.UserName &&
                                          m.UserProfileImage == existingPost.User.ProfileImage &&
                                          m.Title == existingPost.Title &&
                                          m.Content == existingPost.Content);
    }
}
