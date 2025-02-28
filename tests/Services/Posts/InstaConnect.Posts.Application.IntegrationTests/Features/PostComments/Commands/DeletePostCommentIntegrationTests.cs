using InstaConnect.Posts.Application.Features.PostComments.Commands.Delete;

namespace InstaConnect.Posts.Application.IntegrationTests.Features.PostComments.Commands;

public class DeletePostCommentIntegrationTests : BasePostCommentIntegrationTest
{
    public DeletePostCommentIntegrationTests(PostsWebApplicationFactory postsWebApplicationFactory) : base(postsWebApplicationFactory)
    {

    }

    [Fact]
    public async Task SendAsync_ShouldThrowValidationException_WhenIdIsNull()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);

        var command = new DeletePostCommentCommand(
            null,
            existingPostComment.UserId
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AppValidationException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostCommentConfigurations.IdMinLength - 1)]
    [InlineData(PostCommentConfigurations.IdMaxLength + 1)]
    public async Task SendAsync_ShouldThrowValidationException_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);

        var command = new DeletePostCommentCommand(
            SharedTestUtilities.GetString(length),
            existingPostComment.UserId
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AppValidationException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowValidationException_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);

        var command = new DeletePostCommentCommand(
            existingPostComment.Id,
            null
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AppValidationException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task SendAsync_ShouldThrowValidationException_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);

        var command = new DeletePostCommentCommand(
            existingPostComment.Id,
            SharedTestUtilities.GetString(length)
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AppValidationException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowPostCommentNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var command = new DeletePostCommentCommand(
            PostCommentTestUtilities.InvalidId,
            existingPostComment.UserId
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<PostCommentNotFoundException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowAccountForbiddenException_WhenCurrentUserIdIsInvalid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var command = new DeletePostCommentCommand(
            existingPostComment.Id,
            existingUser.Id
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserForbiddenException>();
    }

    [Fact]
    public async Task SendAsync_ShouldDeletePostComment_WhenPostCommentIsValid()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var command = new DeletePostCommentCommand(
            existingPostComment.Id,
            existingPostComment.UserId
        );

        // Act
        await InstaConnectSender.SendAsync(command, CancellationToken);
        var postComment = await PostCommentWriteRepository.GetByIdAsync(existingPostComment.Id, CancellationToken);

        // Assert
        postComment
            .Should()
            .BeNull();
    }

    [Fact]
    public async Task SendAsync_ShouldDeletePostComment_WhenPostCommentIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var command = new DeletePostCommentCommand(
            SharedTestUtilities.GetNonCaseMatchingString(existingPostComment.Id),
            existingPostComment.UserId
        );

        // Act
        await InstaConnectSender.SendAsync(command, CancellationToken);
        var postComment = await PostCommentWriteRepository.GetByIdAsync(existingPostComment.Id, CancellationToken);

        // Assert
        postComment
            .Should()
            .BeNull();
    }
}
