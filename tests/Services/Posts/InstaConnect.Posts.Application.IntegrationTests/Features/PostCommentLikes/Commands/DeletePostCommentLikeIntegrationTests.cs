using FluentAssertions;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.DeletePostCommentLike;
using InstaConnect.Posts.Application.IntegrationTests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Application.IntegrationTests.Utilities;
using InstaConnect.Posts.Common.Features.PostCommentLikes.Utilities;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Exceptions.PostCommentLike;
using InstaConnect.Shared.Common.Exceptions.User;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Posts.Application.IntegrationTests.Features.PostCommentLikes.Commands;

public class DeletePostCommentLikeIntegrationTests : BasePostCommentLikeIntegrationTest
{
    public DeletePostCommentLikeIntegrationTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {

    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var existingPostCommentLikeId = await CreatePostCommentLikeAsync(existingUserId, existingPostCommentId, CancellationToken);

        var command = new DeletePostCommentLikeCommand(
            null!,
            existingUserId
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostCommentLikeBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(PostCommentLikeBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var existingPostCommentLikeId = await CreatePostCommentLikeAsync(existingUserId, existingPostCommentId, CancellationToken);

        var command = new DeletePostCommentLikeCommand(
            SharedTestUtilities.GetString(length),
            existingUserId
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
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var existingPostCommentLikeId = await CreatePostCommentLikeAsync(existingUserId, existingPostCommentId, CancellationToken);

        var command = new DeletePostCommentLikeCommand(
            existingPostCommentLikeId,
            null!
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostCommentLikeBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH - 1)]
    [InlineData(PostCommentLikeBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var existingPostCommentLikeId = await CreatePostCommentLikeAsync(existingUserId, existingPostCommentId, CancellationToken);

        var command = new DeletePostCommentLikeCommand(
            existingPostCommentLikeId,
            SharedTestUtilities.GetString(length)
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowPostCommentLikeNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var existingPostCommentLikeId = await CreatePostCommentLikeAsync(existingUserId, existingPostCommentId, CancellationToken);
        var command = new DeletePostCommentLikeCommand(
            PostCommentLikeTestUtilities.InvalidId,
            existingUserId
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<PostCommentLikeNotFoundException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowAccountForbiddenException_WhenCurrentUserIdIsInvalid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var existingPostCommentLikeUserId = await CreateUserAsync(CancellationToken);
        var existingPostCommentLikeId = await CreatePostCommentLikeAsync(existingPostCommentLikeUserId, existingPostCommentId, CancellationToken);
        var command = new DeletePostCommentLikeCommand(
            existingPostCommentLikeId,
            existingUserId
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserForbiddenException>();
    }

    [Fact]
    public async Task SendAsync_ShouldDeletePostCommentLike_WhenPostCommentLikeIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var existingPostCommentLikeId = await CreatePostCommentLikeAsync(existingUserId, existingPostCommentId, CancellationToken);
        var command = new DeletePostCommentLikeCommand(
            existingPostCommentLikeId,
            existingUserId
        );

        // Act
        await InstaConnectSender.SendAsync(command, CancellationToken);
        var postCommentLike = await PostCommentLikeWriteRepository.GetByIdAsync(existingPostCommentLikeId, CancellationToken);

        // Assert
        postCommentLike
            .Should()
            .BeNull();
    }

    [Fact]
    public async Task SendAsync_ShouldDeletePostCommentLike_WhenPostCommentLikeIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var existingPostCommentLikeId = await CreatePostCommentLikeAsync(existingUserId, existingPostCommentId, CancellationToken);
        var command = new DeletePostCommentLikeCommand(
            SharedTestUtilities.GetNonCaseMatchingString(existingPostCommentLikeId),
            existingUserId
        );

        // Act
        await InstaConnectSender.SendAsync(command, CancellationToken);
        var postCommentLike = await PostCommentLikeWriteRepository.GetByIdAsync(existingPostCommentLikeId, CancellationToken);

        // Assert
        postCommentLike
            .Should()
            .BeNull();
    }
}
