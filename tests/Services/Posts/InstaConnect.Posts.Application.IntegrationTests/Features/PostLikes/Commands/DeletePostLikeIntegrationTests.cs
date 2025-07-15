using InstaConnect.Common.Exceptions;
using InstaConnect.Posts.Application.Features.PostLikes.Commands.Delete;

namespace InstaConnect.Posts.Application.IntegrationTests.Features.PostLikes.Commands;

public class DeletePostLikeIntegrationTests : BasePostLikeIntegrationTest
{
    public DeletePostLikeIntegrationTests(PostWebApplicationFactory postsWebApplicationFactory) : base(postsWebApplicationFactory)
    {

    }

    [Fact]
    public async Task SendAsync_ShouldThrowValidationException_WhenIdIsNull()
    {
        // Arrange
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);

        var command = new DeletePostLikeCommand(
            null,
            existingPostLike.UserId
        );

        // Act
        var action = async () => await ApplicationSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<InvalidValidationException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostLikeConfigurations.IdMinLength - 1)]
    [InlineData(PostLikeConfigurations.IdMaxLength + 1)]
    public async Task SendAsync_ShouldThrowValidationException_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);

        var command = new DeletePostLikeCommand(
            DataFaker.GetString(length),
            existingPostLike.UserId
        );

        // Act
        var action = async () => await ApplicationSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<InvalidValidationException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowValidationException_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);

        var command = new DeletePostLikeCommand(
            existingPostLike.Id,
            null
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
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);

        var command = new DeletePostLikeCommand(
            existingPostLike.Id,
            DataFaker.GetString(length)
        );

        // Act
        var action = async () => await ApplicationSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<InvalidValidationException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowPostLikeNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var command = new DeletePostLikeCommand(
            PostLikeTestUtilities.InvalidId,
            existingPostLike.UserId
        );

        // Act
        var action = async () => await ApplicationSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<PostLikeNotFoundException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowAccountForbiddenException_WhenCurrentUserIdIsInvalid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var command = new DeletePostLikeCommand(
            existingPostLike.Id,
            existingUser.Id
        );

        // Act
        var action = async () => await ApplicationSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<PostForbiddenException>();
    }

    [Fact]
    public async Task SendAsync_ShouldDeletePostLike_WhenPostLikeIsValid()
    {
        // Arrange
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var command = new DeletePostLikeCommand(
            existingPostLike.Id,
            existingPostLike.UserId
        );

        // Act
        await ApplicationSender.SendAsync(command, CancellationToken);
        var postLike = await PostLikeWriteRepository.GetByIdAsync(existingPostLike.Id, CancellationToken);

        // Assert
        postLike
            .Should()
            .BeNull();
    }

    [Fact]
    public async Task SendAsync_ShouldDeletePostLike_WhenPostLikeIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var command = new DeletePostLikeCommand(
            DataFaker.GetDifferentCaseString(existingPostLike.Id),
            existingPostLike.UserId
        );

        // Act
        await ApplicationSender.SendAsync(command, CancellationToken);
        var postLike = await PostLikeWriteRepository.GetByIdAsync(existingPostLike.Id, CancellationToken);

        // Assert
        postLike
            .Should()
            .BeNull();
    }
}
