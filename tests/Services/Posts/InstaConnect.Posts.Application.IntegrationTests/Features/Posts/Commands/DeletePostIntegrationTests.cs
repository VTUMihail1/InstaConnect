using FluentAssertions;
using InstaConnect.Posts.Application.Features.Posts.Commands.Delete;
using InstaConnect.Posts.Application.IntegrationTests.Features.Posts.Utilities;
using InstaConnect.Posts.Application.IntegrationTests.Utilities;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Exceptions.Posts;
using InstaConnect.Shared.Common.Exceptions.User;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Posts.Application.IntegrationTests.Features.Posts.Commands;

public class DeletePostIntegrationTests : BasePostIntegrationTest
{
    public DeletePostIntegrationTests(PostsWebApplicationFactory postsWebApplicationFactory) : base(postsWebApplicationFactory)
    {

    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdIsNull()
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var command = new DeletePostCommand(
            null,
            existingPost.UserId
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostConfigurations.IdMinLength - 1)]
    [InlineData(PostConfigurations.IdMaxLength + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);

        var command = new DeletePostCommand(
            SharedTestUtilities.GetString(length),
            existingPost.UserId
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
        var existingPost = await CreatePostAsync(CancellationToken);
        var command = new DeletePostCommand(
            existingPost.Id,
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
        var existingPost = await CreatePostAsync(CancellationToken);
        var command = new DeletePostCommand(
            existingPost.Id,
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
        var existingPost = await CreatePostAsync(CancellationToken);
        var command = new DeletePostCommand(
            PostTestUtilities.InvalidId,
            existingPost.UserId
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
        var existingUser = await CreateUserAsync(CancellationToken);
        var existingPost = await CreatePostAsync(CancellationToken);
        var command = new DeletePostCommand(
            existingPost.Id,
            existingUser.Id
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
        var existingPost = await CreatePostAsync(CancellationToken);
        var command = new DeletePostCommand(
            existingPost.Id,
            existingPost.UserId
        );

        // Act
        await InstaConnectSender.SendAsync(command, CancellationToken);
        var post = await PostWriteRepository.GetByIdAsync(existingPost.Id, CancellationToken);

        // Assert
        post
            .Should()
            .BeNull();
    }

    [Fact]
    public async Task SendAsync_ShouldDeletePost_WhenPostIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var command = new DeletePostCommand(
            SharedTestUtilities.GetNonCaseMatchingString(existingPost.Id),
            existingPost.UserId
        );

        // Act
        await InstaConnectSender.SendAsync(command, CancellationToken);
        var post = await PostWriteRepository.GetByIdAsync(existingPost.Id, CancellationToken);

        // Assert
        post
            .Should()
            .BeNull();
    }
}
