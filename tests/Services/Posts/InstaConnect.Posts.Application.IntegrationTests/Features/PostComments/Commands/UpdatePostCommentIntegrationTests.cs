using InstaConnect.Common.Exceptions;
using InstaConnect.Posts.Application.Features.PostComments.Commands.Update;

namespace InstaConnect.Posts.Application.IntegrationTests.Features.PostComments.Commands;

public class UpdatePostCommentIntegrationTests : BasePostCommentIntegrationTest
{
    public UpdatePostCommentIntegrationTests(PostsWebApplicationFactory postsWebApplicationFactory) : base(postsWebApplicationFactory)
    {

    }

    [Fact]
    public async Task SendAsync_ShouldThrowValidationException_WhenIdIsNull()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var command = new UpdatePostCommentCommand(
            null,
            existingPostComment.UserId,
            existingPostComment.Content
        );

        // Act
        var action = async () => await ApplicationSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<InvalidValidationException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostCommentConfigurations.IdMinLength - 1)]
    [InlineData(PostCommentConfigurations.IdMaxLength + 1)]
    public async Task SendAsync_ShouldThrowValidationException_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var command = new UpdatePostCommentCommand(
            DataFaker.GetString(length),
            existingPostComment.UserId,
            existingPostComment.Content
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
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var command = new UpdatePostCommentCommand(
            existingPostComment.Id,
            null,
            existingPostComment.Content
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
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var command = new UpdatePostCommentCommand(
            existingPostComment.Id,
            DataFaker.GetString(length),
            existingPostComment.Content
        );

        // Act
        var action = async () => await ApplicationSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<InvalidValidationException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowValidationException_WhenContentIsNull()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var command = new UpdatePostCommentCommand(
            existingPostComment.Id,
            existingPostComment.UserId,
            null
        );

        // Act
        var action = async () => await ApplicationSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<InvalidValidationException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostCommentConfigurations.ContentMinLength - 1)]
    [InlineData(PostCommentConfigurations.ContentMaxLength + 1)]
    public async Task SendAsync_ShouldThrowValidationException_WhenContentLengthIsInvalid(int length)
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var command = new UpdatePostCommentCommand(
            existingPostComment.Id,
            existingPostComment.UserId,
            DataFaker.GetString(length)
        );

        // Act
        var action = async () => await ApplicationSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<InvalidValidationException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowPostCommentNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var command = new UpdatePostCommentCommand(
            PostCommentTestUtilities.InvalidId,
            existingPostComment.UserId,
            existingPostComment.Content
        );

        // Act
        var action = async () => await ApplicationSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<PostCommentNotFoundException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowAccountForbiddenException_WhenCurrentUserIdIsInvalid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var command = new UpdatePostCommentCommand(
            existingPostComment.Id,
            existingUser.Id,
            existingPostComment.Content
        );

        // Act
        var action = async () => await ApplicationSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<PostForbiddenException>();
    }

    [Fact]
    public async Task SendAsync_ShouldUpdatePostComment_WhenPostCommentIsValid()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var command = new UpdatePostCommentCommand(
            existingPostComment.Id,
            existingPostComment.UserId,
            existingPostComment.Content
        );

        // Act
        var response = await ApplicationSender.SendAsync(command, CancellationToken);
        var postComment = await PostCommentWriteRepository.GetByIdAsync(response.Id, CancellationToken);

        // Assert
        postComment
            .Should()
            .Match<PostComment>(p => p.Id == existingPostComment.Id &&
                                     p.UserId == existingPostComment.UserId &&
                                     p.PostId == existingPostComment.PostId &&
                                     p.Content == existingPostComment.Content);
    }

    [Fact]
    public async Task SendAsync_ShouldUpdatePostComment_WhenPostCommentIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var command = new UpdatePostCommentCommand(
            DataFaker.GetDifferentCaseString(existingPostComment.Id),
            existingPostComment.UserId,
            existingPostComment.Content
        );

        // Act
        var response = await ApplicationSender.SendAsync(command, CancellationToken);
        var postComment = await PostCommentWriteRepository.GetByIdAsync(response.Id, CancellationToken);

        // Assert
        postComment
            .Should()
            .Match<PostComment>(p => p.Id == existingPostComment.Id &&
                                     p.UserId == existingPostComment.UserId &&
                                     p.PostId == existingPostComment.PostId &&
                                     p.Content == existingPostComment.Content);
    }
}
