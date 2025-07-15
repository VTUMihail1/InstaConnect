using InstaConnect.Common.Exceptions;
using InstaConnect.Posts.Application.Features.PostLikes.Commands.Add;
using InstaConnect.Posts.Domain.Features.Users.Exceptions;

namespace InstaConnect.Posts.Application.IntegrationTests.Features.PostLikes.Commands;

public class AddPostLikeIntegrationTests : BasePostLikeIntegrationTest
{
    public AddPostLikeIntegrationTests(PostWebApplicationFactory postsWebApplicationFactory) : base(postsWebApplicationFactory)
    {

    }

    [Fact]
    public async Task SendAsync_ShouldThrowValidationException_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var command = new AddPostLikeCommand(
            null,
            existingPost.Id
        );

        // Act
        var action = async () => await ApplicationSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<InvalidValidationException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task SendAsync_ShouldThrowValidationException_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var command = new AddPostLikeCommand(
            DataFaker.GetString(length),
            existingPost.Id
        );

        // Act
        var action = async () => await ApplicationSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<InvalidValidationException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowValidationException_WhenPostIdIsNull()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var command = new AddPostLikeCommand(
            existingUser.Id,
            null
        );

        // Act
        var action = async () => await ApplicationSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<InvalidValidationException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostConfigurations.IdMinLength - 1)]
    [InlineData(PostConfigurations.IdMaxLength + 1)]
    public async Task SendAsync_ShouldThrowValidationException_WhenPostIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var command = new AddPostLikeCommand(
            existingUser.Id,
            DataFaker.GetString(length)
        );

        // Act
        var action = async () => await ApplicationSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<InvalidValidationException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserNotFoundException_WhenCurrentUserIdIsInvalid()
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var command = new AddPostLikeCommand(
            UserTestUtilities.InvalidId,
            existingPost.Id
        );

        // Act
        var action = async () => await ApplicationSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowPostNotFoundException_WhenPostIdIsInvalid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var command = new AddPostLikeCommand(
            existingUser.Id,
            PostTestUtilities.InvalidId
        );

        // Act
        var action = async () => await ApplicationSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<PostNotFoundException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowPostLikeAlreadyExistsException_WhenPostLikeAlreadyExists()
    {
        // Arrange
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var command = new AddPostLikeCommand(
            existingPostLike.UserId,
            existingPostLike.PostId
        );

        // Act
        var action = async () => await ApplicationSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<PostLikeAlreadyExistsException>();
    }

    [Fact]
    public async Task SendAsync_ShouldAddPostLike_WhenPostLikeIsValid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var existingPost = await CreatePostAsync(CancellationToken);
        var command = new AddPostLikeCommand(
            existingUser.Id,
            existingPost.Id
        );

        // Act
        var response = await ApplicationSender.SendAsync(command, CancellationToken);
        var postLike = await PostLikeWriteRepository.GetByIdAsync(response.Id, CancellationToken);

        // Assert
        postLike
            .Should()
            .Match<PostLike>(p => p.Id == response.Id &&
                                     p.UserId == existingUser.Id &&
                                     p.PostId == existingPost.Id);
    }
}
