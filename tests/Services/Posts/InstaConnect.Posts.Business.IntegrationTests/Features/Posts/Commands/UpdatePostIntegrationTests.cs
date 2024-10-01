using Bogus;
using FluentAssertions;
using InstaConnect.Posts.Business.Features.Posts.Commands.UpdatePost;
using InstaConnect.Posts.Business.IntegrationTests.Features.Posts.Utilities;
using InstaConnect.Posts.Business.IntegrationTests.Utilities;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Posts.Data.Features.Posts.Models.Entitites;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Exceptions.Posts;
using InstaConnect.Shared.Common.Exceptions.User;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Posts.Business.IntegrationTests.Features.Posts.Commands;

public class UpdatePostIntegrationTests : BasePostIntegrationTest
{
    public UpdatePostIntegrationTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {

    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var command = new UpdatePostCommand(
            null!,
            existingUserId,
            PostTestUtilities.ValidUpdateTitle,
            PostTestUtilities.ValidUpdateContent
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
        var command = new UpdatePostCommand(
            SharedTestUtilities.GetString(length),
            existingUserId,
            PostTestUtilities.ValidUpdateTitle,
            PostTestUtilities.ValidUpdateContent
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
        var command = new UpdatePostCommand(
            existingPostId,
            null!,
            PostTestUtilities.ValidUpdateTitle,
            PostTestUtilities.ValidUpdateContent
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
        var command = new UpdatePostCommand(
            existingPostId,
            SharedTestUtilities.GetString(length),
            PostTestUtilities.ValidUpdateTitle,
            PostTestUtilities.ValidUpdateContent
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenTitleIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var command = new UpdatePostCommand(
            existingPostId,
            existingUserId,
            null!,
            PostTestUtilities.ValidUpdateContent
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostBusinessConfigurations.TITLE_MIN_LENGTH - 1)]
    [InlineData(PostBusinessConfigurations.TITLE_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenTitleLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var command = new UpdatePostCommand(
            existingPostId,
            existingUserId,
            SharedTestUtilities.GetString(length),
            PostTestUtilities.ValidUpdateContent
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
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var command = new UpdatePostCommand(
            existingPostId,
            existingUserId,
            PostTestUtilities.ValidUpdateTitle,
            null!
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostBusinessConfigurations.CONTENT_MIN_LENGTH - 1)]
    [InlineData(PostBusinessConfigurations.CONTENT_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenContentLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var command = new UpdatePostCommand(
            existingPostId,
            existingUserId,
            PostTestUtilities.ValidUpdateTitle,
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
        var command = new UpdatePostCommand(
            PostTestUtilities.InvalidId,
            existingUserId,
            PostTestUtilities.ValidUpdateTitle,
            PostTestUtilities.ValidUpdateContent
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
        var command = new UpdatePostCommand(
            existingPostId,
            existingUserId,
            PostTestUtilities.ValidUpdateTitle,
            PostTestUtilities.ValidUpdateContent
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserForbiddenException>();
    }

    [Fact]
    public async Task SendAsync_ShouldUpdatePost_WhenPostIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var command = new UpdatePostCommand(
            existingPostId,
            existingUserId,
            PostTestUtilities.ValidUpdateTitle,
            PostTestUtilities.ValidUpdateContent
        );

        // Act
        var response = await InstaConnectSender.SendAsync(command, CancellationToken);
        var post = await PostWriteRepository.GetByIdAsync(existingPostId, CancellationToken);

        // Assert
        post
            .Should()
            .Match<Post>(p => p.Id == existingPostId &&
                              p.UserId == existingUserId &&
                              p.Title == PostTestUtilities.ValidUpdateTitle &&
                              p.Content == PostTestUtilities.ValidUpdateContent);
    }

    [Fact]
    public async Task SendAsync_ShouldUpdatePost_WhenPostIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var command = new UpdatePostCommand(
            SharedTestUtilities.GetNonCaseMatchingString(existingPostId),
            existingUserId,
            PostTestUtilities.ValidUpdateTitle,
            PostTestUtilities.ValidUpdateContent
        );

        // Act
        var response = await InstaConnectSender.SendAsync(command, CancellationToken);
        var post = await PostWriteRepository.GetByIdAsync(existingPostId, CancellationToken);

        // Assert
        post
            .Should()
            .Match<Post>(p => p.Id == existingPostId &&
                              p.UserId == existingUserId &&
                              p.Title == PostTestUtilities.ValidUpdateTitle &&
                              p.Content == PostTestUtilities.ValidUpdateContent);
    }
}
