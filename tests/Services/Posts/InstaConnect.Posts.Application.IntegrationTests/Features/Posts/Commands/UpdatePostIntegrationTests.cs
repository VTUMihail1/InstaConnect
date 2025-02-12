using FluentAssertions;
using InstaConnect.Posts.Application.Features.Posts.Commands.Update;
using InstaConnect.Posts.Application.IntegrationTests.Features.Posts.Utilities;
using InstaConnect.Posts.Application.IntegrationTests.Utilities;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entitites;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Exceptions.Posts;
using InstaConnect.Shared.Common.Exceptions.User;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Posts.Application.IntegrationTests.Features.Posts.Commands;

public class UpdatePostIntegrationTests : BasePostIntegrationTest
{
    public UpdatePostIntegrationTests(PostsWebApplicationFactory postsWebApplicationFactory) : base(postsWebApplicationFactory)
    {

    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdIsNull()
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var command = new UpdatePostCommand(
            null,
            existingPost.UserId,
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
    [InlineData(PostConfigurations.IdMinLength - 1)]
    [InlineData(PostConfigurations.IdMaxLength + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var command = new UpdatePostCommand(
            SharedTestUtilities.GetString(length),
            existingPost.UserId,
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
        var existingPost = await CreatePostAsync(CancellationToken);
        var command = new UpdatePostCommand(
            existingPost.Id,
            null,
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
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var command = new UpdatePostCommand(
            existingPost.Id,
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
        var existingPost = await CreatePostAsync(CancellationToken);
        var command = new UpdatePostCommand(
            existingPost.Id,
            existingPost.UserId,
            null,
            PostTestUtilities.ValidUpdateContent
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostConfigurations.TitleMinLength - 1)]
    [InlineData(PostConfigurations.TitleMaxLength + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenTitleLengthIsInvalid(int length)
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var command = new UpdatePostCommand(
            existingPost.Id,
            existingPost.UserId,
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
        var existingPost = await CreatePostAsync(CancellationToken);
        var command = new UpdatePostCommand(
            existingPost.Id,
            existingPost.UserId,
            PostTestUtilities.ValidUpdateTitle,
            null
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostConfigurations.ContentMinLength - 1)]
    [InlineData(PostConfigurations.ContentMaxLength + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenContentLengthIsInvalid(int length)
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var command = new UpdatePostCommand(
            existingPost.Id,
            existingPost.UserId,
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
        var existingPost = await CreatePostAsync(CancellationToken);
        var command = new UpdatePostCommand(
            PostTestUtilities.InvalidId,
            existingPost.UserId,
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
        var existingUser = await CreateUserAsync(CancellationToken);
        var existingPost = await CreatePostAsync(CancellationToken);
        var command = new UpdatePostCommand(
            existingPost.Id,
            existingUser.Id,
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
        var existingPost = await CreatePostAsync(CancellationToken);
        var command = new UpdatePostCommand(
            existingPost.Id,
            existingPost.UserId,
            PostTestUtilities.ValidUpdateTitle,
            PostTestUtilities.ValidUpdateContent
        );

        // Act
        var response = await InstaConnectSender.SendAsync(command, CancellationToken);
        var post = await PostWriteRepository.GetByIdAsync(existingPost.Id, CancellationToken);

        // Assert
        post
            .Should()
            .Match<Post>(p => p.Id == existingPost.Id &&
                              p.UserId == existingPost.UserId &&
                              p.Title == PostTestUtilities.ValidUpdateTitle &&
                              p.Content == PostTestUtilities.ValidUpdateContent);
    }

    [Fact]
    public async Task SendAsync_ShouldUpdatePost_WhenPostIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var command = new UpdatePostCommand(
            SharedTestUtilities.GetNonCaseMatchingString(existingPost.Id),
            existingPost.UserId,
            PostTestUtilities.ValidUpdateTitle,
            PostTestUtilities.ValidUpdateContent
        );

        // Act
        var response = await InstaConnectSender.SendAsync(command, CancellationToken);
        var post = await PostWriteRepository.GetByIdAsync(existingPost.Id, CancellationToken);

        // Assert
        post
            .Should()
            .Match<Post>(p => p.Id == existingPost.Id &&
                              p.UserId == existingPost.UserId &&
                              p.Title == PostTestUtilities.ValidUpdateTitle &&
                              p.Content == PostTestUtilities.ValidUpdateContent);
    }
}
