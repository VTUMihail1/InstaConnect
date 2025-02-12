using FluentAssertions;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.DeletePostCommentLike;
using InstaConnect.Posts.Application.IntegrationTests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Application.IntegrationTests.Utilities;
using InstaConnect.Posts.Common.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Exceptions.PostCommentLike;
using InstaConnect.Shared.Common.Exceptions.User;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Posts.Application.IntegrationTests.Features.PostCommentLikes.Commands;

public class DeletePostCommentLikeIntegrationTests : BasePostCommentLikeIntegrationTest
{
    public DeletePostCommentLikeIntegrationTests(PostsWebApplicationFactory postsWebApplicationFactory) : base(postsWebApplicationFactory)
    {

    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdIsNull()
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);

        var command = new DeletePostCommentLikeCommand(
            null,
            existingPostCommentLike.UserId
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostCommentLikeConfigurations.IdMinLength - 1)]
    [InlineData(PostCommentLikeConfigurations.IdMaxLength + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);

        var command = new DeletePostCommentLikeCommand(
            SharedTestUtilities.GetString(length),
            existingPostCommentLike.UserId
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
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);

        var command = new DeletePostCommentLikeCommand(
            existingPostCommentLike.Id,
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
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);

        var command = new DeletePostCommentLikeCommand(
            existingPostCommentLike.Id,
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
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var command = new DeletePostCommentLikeCommand(
            PostCommentLikeTestUtilities.InvalidId,
            existingPostCommentLike.UserId
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
        var existingUser = await CreateUserAsync(CancellationToken);
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var command = new DeletePostCommentLikeCommand(
            existingPostCommentLike.Id,
            existingUser.Id
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
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var command = new DeletePostCommentLikeCommand(
            existingPostCommentLike.Id,
            existingPostCommentLike.UserId
        );

        // Act
        await InstaConnectSender.SendAsync(command, CancellationToken);
        var postCommentLike = await PostCommentLikeWriteRepository.GetByIdAsync(existingPostCommentLike.Id, CancellationToken);

        // Assert
        postCommentLike
            .Should()
            .BeNull();
    }

    [Fact]
    public async Task SendAsync_ShouldDeletePostCommentLike_WhenPostCommentLikeIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var command = new DeletePostCommentLikeCommand(
            SharedTestUtilities.GetNonCaseMatchingString(existingPostCommentLike.Id),
            existingPostCommentLike.UserId
        );

        // Act
        await InstaConnectSender.SendAsync(command, CancellationToken);
        var postCommentLike = await PostCommentLikeWriteRepository.GetByIdAsync(existingPostCommentLike.Id, CancellationToken);

        // Assert
        postCommentLike
            .Should()
            .BeNull();
    }
}
