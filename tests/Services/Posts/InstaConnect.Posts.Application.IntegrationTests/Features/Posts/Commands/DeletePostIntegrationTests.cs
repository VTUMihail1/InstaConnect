using FluentAssertions;
using InstaConnect.Posts.Application.Features.Posts.Commands.DeletePost;
using InstaConnect.Posts.Application.IntegrationTests.Features.Posts.Utilities;
using InstaConnect.Posts.Application.IntegrationTests.Utilities;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Exceptions.Posts;
using InstaConnect.Shared.Common.Exceptions.User;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Posts.Application.IntegrationTests.Features.Posts.Commands;

public class DeletePostIntegrationTests : BasePostIntegrationTest
{
    public DeletePostIntegrationTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {

    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var command = new DeletePostCommand(
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
    [InlineData(PostBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(PostBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);

        var command = new DeletePostCommand(
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
        var command = new DeletePostCommand(
            existingPostId,
            null!
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH - 1)]
    [InlineData(PostBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var command = new DeletePostCommand(
            existingPostId,
            SharedTestUtilities.GetString(length)
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowPostNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var command = new DeletePostCommand(
            PostTestUtilities.InvalidId,
            existingUserId
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<PostNotFoundException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowAccountForbiddenException_WhenCurrentUserIdIsInvalid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingPostUserId, CancellationToken);
        var command = new DeletePostCommand(
            existingPostId,
            existingUserId
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserForbiddenException>();
    }

    [Fact]
    public async Task SendAsync_ShouldDeletePost_WhenPostIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var command = new DeletePostCommand(
            existingPostId,
            existingUserId
        );

        // Act
        await InstaConnectSender.SendAsync(command, CancellationToken);
        var post = await PostWriteRepository.GetByIdAsync(existingPostId, CancellationToken);

        // Assert
        post
            .Should()
            .BeNull();
    }

    [Fact]
    public async Task SendAsync_ShouldDeletePost_WhenPostIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var command = new DeletePostCommand(
            SharedTestUtilities.GetNonCaseMatchingString(existingPostId),
            existingUserId
        );

        // Act
        await InstaConnectSender.SendAsync(command, CancellationToken);
        var post = await PostWriteRepository.GetByIdAsync(existingPostId, CancellationToken);

        // Assert
        post
            .Should()
            .BeNull();
    }
}
