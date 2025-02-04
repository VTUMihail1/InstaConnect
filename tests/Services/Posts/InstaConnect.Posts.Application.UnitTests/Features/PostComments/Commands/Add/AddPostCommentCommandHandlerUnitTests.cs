using FluentAssertions;
using InstaConnect.Posts.Application.Features.PostComments.Commands.AddPostComment;
using InstaConnect.Posts.Application.Features.PostComments.Models;
using InstaConnect.Posts.Application.UnitTests.Features.PostComments.Utilities;
using InstaConnect.Posts.Common.Features.PostComments.Utilities;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Entitites;
using InstaConnect.Shared.Common.Exceptions.Posts;
using InstaConnect.Shared.Common.Exceptions.User;
using NSubstitute;

namespace InstaConnect.Posts.Application.UnitTests.Features.PostComments.Commands.AddComment;

public class AddPostCommentCommandHandlerUnitTests : BasePostCommentUnitTest
{
    private readonly AddPostCommentCommandHandler _commandHandler;

    public AddPostCommentCommandHandlerUnitTests()
    {
        _commandHandler = new(
            UnitOfWork,
            InstaConnectMapper,
            UserWriteRepository,
            PostWriteRepository,
            PostCommentWriteRepository);
    }

    [Fact]
    public async Task Handle_ShouldThrowUserNotFoundException_WhenCurrentUserIdIsInvalid()
    {
        // Arrange
        var post = CreatePost();
        var user = CreateUser();
        var command = new AddPostCommentCommand(
            UserTestUtilities.InvalidId,
            post.Id,
            PostCommentTestUtilities.ValidAddContent);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowPostNotFoundException_WhenPostIdIsInvalid()
    {
        // Arrange
        var post = CreatePost();
        var user = CreateUser();
        var command = new AddPostCommentCommand(
            user.Id,
            PostTestUtilities.InvalidId,
            PostCommentTestUtilities.ValidAddContent);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<PostNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldReturnPostCommentCommandViewModel_WhenPostCommentIsValid()
    {
        // Arrange
        var post = CreatePost();
        var user = CreateUser();
        var command = new AddPostCommentCommand(
            user.Id,
            post.Id,
            PostCommentTestUtilities.ValidAddContent);

        // Act
        var response = await _commandHandler.Handle(command, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentCommandViewModel>(m => !string.IsNullOrEmpty(m.Id));
    }

    [Fact]
    public async Task Handle_ShouldAddPostToRepository_WhenPostIsValid()
    {
        // Arrange
        var post = CreatePost();
        var user = CreateUser();
        var command = new AddPostCommentCommand(
            user.Id,
            post.Id,
            PostCommentTestUtilities.ValidAddContent);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        PostCommentWriteRepository
            .Received(1)
            .Add(Arg.Is<PostComment>(m =>
                !string.IsNullOrEmpty(m.Id) &&
                m.UserId == user.Id &&
                m.PostId == post.Id &&
                m.Content == PostCommentTestUtilities.ValidAddContent));
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenPostIsValid()
    {
        // Arrange
        var post = CreatePost();
        var user = CreateUser();
        var command = new AddPostCommentCommand(
            user.Id,
            post.Id,
            PostCommentTestUtilities.ValidAddContent);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
