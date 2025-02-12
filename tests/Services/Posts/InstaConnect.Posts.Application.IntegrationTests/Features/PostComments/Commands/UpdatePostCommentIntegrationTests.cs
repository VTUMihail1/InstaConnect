using FluentAssertions;
using InstaConnect.Posts.Application.Features.PostComments.Commands.UpdatePostComment;
using InstaConnect.Posts.Application.IntegrationTests.Features.PostComments.Utilities;
using InstaConnect.Posts.Application.IntegrationTests.Utilities;
using InstaConnect.Posts.Common.Features.PostComments.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Entitites;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Exceptions.PostComment;
using InstaConnect.Shared.Common.Exceptions.User;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Posts.Application.IntegrationTests.Features.PostComments.Commands;

public class UpdatePostCommentIntegrationTests : BasePostCommentIntegrationTest
{
    public UpdatePostCommentIntegrationTests(PostsWebApplicationFactory postsWebApplicationFactory) : base(postsWebApplicationFactory)
    {

    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdIsNull()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var command = new UpdatePostCommentCommand(
            null,
            existingPostComment.UserId,
            PostCommentTestUtilities.ValidUpdateContent
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
        var command = new UpdatePostCommentCommand(
            SharedTestUtilities.GetString(length),
            existingPostComment.UserId,
            PostCommentTestUtilities.ValidUpdateContent
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
        var command = new UpdatePostCommentCommand(
            existingPostComment.Id,
            null,
            PostCommentTestUtilities.ValidUpdateContent
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
        var command = new UpdatePostCommentCommand(
            existingPostComment.Id,
            SharedTestUtilities.GetString(length),
            PostCommentTestUtilities.ValidUpdateContent
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenContentIsNull()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var command = new UpdatePostCommentCommand(
            existingPostComment.Id,
            existingPostComment.UserId,
            null
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostCommentConfigurations.ContentMinLength - 1)]
    [InlineData(PostCommentConfigurations.ContentMaxLength + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenContentLengthIsInvalid(int length)
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var command = new UpdatePostCommentCommand(
            existingPostComment.Id,
            existingPostComment.UserId,
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
        var command = new UpdatePostCommentCommand(
            PostCommentTestUtilities.InvalidId,
            existingPostComment.UserId,
            PostCommentTestUtilities.ValidUpdateContent
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
        var command = new UpdatePostCommentCommand(
            existingPostComment.Id,
            existingUser.Id,
            PostCommentTestUtilities.ValidUpdateContent
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserForbiddenException>();
    }

    [Fact]
    public async Task SendAsync_ShouldUpdatePostComment_WhenPostCommentIsValid()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var command = new UpdatePostCommentCommand(
            existingPostComment.Id,
            existingPostComment.UserId,
            PostCommentTestUtilities.ValidUpdateContent
        );

        // Act
        var response = await InstaConnectSender.SendAsync(command, CancellationToken);
        var postComment = await PostCommentWriteRepository.GetByIdAsync(existingPostComment.Id, CancellationToken);

        // Assert
        postComment
            .Should()
            .Match<PostComment>(p => p.Id == existingPostComment.Id &&
                                     p.UserId == existingPostComment.UserId &&
                                     p.PostId == existingPostComment.PostId &&
                                     p.Content == PostCommentTestUtilities.ValidUpdateContent);
    }

    [Fact]
    public async Task SendAsync_ShouldUpdatePostComment_WhenPostCommentIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingPostComment = await CreatePostCommentAsync(CancellationToken);
        var command = new UpdatePostCommentCommand(
            SharedTestUtilities.GetNonCaseMatchingString(existingPostComment.Id),
            existingPostComment.UserId,
            PostCommentTestUtilities.ValidUpdateContent
        );

        // Act
        var response = await InstaConnectSender.SendAsync(command, CancellationToken);
        var postComment = await PostCommentWriteRepository.GetByIdAsync(existingPostComment.Id, CancellationToken);

        // Assert
        postComment
            .Should()
            .Match<PostComment>(p => p.Id == existingPostComment.Id &&
                                     p.UserId == existingPostComment.UserId &&
                                     p.PostId == existingPostComment.PostId &&
                                     p.Content == PostCommentTestUtilities.ValidUpdateContent);
    }
}
