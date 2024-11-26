using FluentAssertions;
using InstaConnect.Posts.Application.Features.PostLikes.Commands.AddPostLike;
using InstaConnect.Posts.Application.IntegrationTests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Application.IntegrationTests.Utilities;
using InstaConnect.Posts.Common.Features.PostLikes.Utilities;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Entitites;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Exceptions.Posts;
using InstaConnect.Shared.Common.Exceptions.User;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Posts.Application.IntegrationTests.Features.PostLikes.Commands;

public class AddPostLikeIntegrationTests : BasePostLikeIntegrationTest
{
    public AddPostLikeIntegrationTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {

    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var command = new AddPostLikeCommand(
            null!,
            existingPostId
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostLikeBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH - 1)]
    [InlineData(PostLikeBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var command = new AddPostLikeCommand(
            SharedTestUtilities.GetString(length),
            existingPostId
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenPostIdIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var command = new AddPostLikeCommand(
            existingUserId,
            null!
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostLikeBusinessConfigurations.POST_ID_MIN_LENGTH - 1)]
    [InlineData(PostLikeBusinessConfigurations.POST_ID_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenPostIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var command = new AddPostLikeCommand(
            existingUserId,
            SharedTestUtilities.GetString(length)
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserNotFoundException_WhenCurrentUserIdIsInvalid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var command = new AddPostLikeCommand(
            PostLikeTestUtilities.InvalidUserId,
            existingPostId
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowPostNotFoundException_WhenPostIdIsInvalid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var command = new AddPostLikeCommand(
            existingUserId,
            PostLikeTestUtilities.InvalidPostId
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<PostNotFoundException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenPostLikeAlreadyExists()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostLikeId = await CreatePostLikeAsync(existingUserId, existingPostId, CancellationToken);
        var command = new AddPostLikeCommand(
            existingUserId,
            existingPostId
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldAddPostLike_WhenPostLikeIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var command = new AddPostLikeCommand(
            existingUserId,
            existingPostId
        );

        // Act
        var response = await InstaConnectSender.SendAsync(command, CancellationToken);
        var postLike = await PostLikeWriteRepository.GetByIdAsync(response.Id, CancellationToken);

        // Assert
        postLike
            .Should()
            .Match<PostLike>(p => p.Id == response.Id &&
                                     p.UserId == existingUserId &&
                                     p.PostId == existingPostId);
    }
}
