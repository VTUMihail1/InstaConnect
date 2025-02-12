using FluentAssertions;
using InstaConnect.Posts.Application.Features.PostComments.Commands.DeletePostComment;
using InstaConnect.Posts.Application.IntegrationTests.Features.PostComments.Utilities;
using InstaConnect.Posts.Application.IntegrationTests.Utilities;
using InstaConnect.Posts.Common.Features.PostComments.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Exceptions.PostComment;
using InstaConnect.Shared.Common.Exceptions.User;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Posts.Application.IntegrationTests.Features.PostComments.Commands;

public class DeletePostCommentIntegrationTests : BasePostCommentIntegrationTest
{
    public DeletePostCommentIntegrationTests(PostsWebApplicationFactory postsWebApplicationFactory) : base(postsWebApplicationFactory)
    {

    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdIsNull()
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
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostCommentConfigurations.IdMinLength - 1)]
    [InlineData(PostCommentConfigurations.IdMaxLength + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdLengthIsInvalid(int length)
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
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenCurrentUserIdIsNull()
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
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenCurrentUserIdLengthIsInvalid(int length)
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
        await action.Should().ThrowAsync<BadRequestException>();
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
