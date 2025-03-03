﻿using InstaConnect.Posts.Application.Features.Posts.Commands.Update;

namespace InstaConnect.Posts.Application.UnitTests.Features.Posts.Commands.Update;

public class UpdatePostCommandHandlerUnitTests : BasePostUnitTest
{
    private readonly UpdatePostCommandHandler _commandHandler;

    public UpdatePostCommandHandlerUnitTests()
    {
        _commandHandler = new(
            UnitOfWork,
            InstaConnectMapper,
            PostWriteRepository);
    }

    [Fact]
    public async Task Handle_ShouldThrowPostNotFoundException_WhenPostIdIsInvalid()
    {
        // Arrange
        var existingPost = CreatePost();
        var command = new UpdatePostCommand(
            PostTestUtilities.InvalidId,
            existingPost.UserId,
            PostTestUtilities.ValidUpdateTitle,
            PostTestUtilities.ValidUpdateContent
        );

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<PostNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowAccountForbiddenException_WhenCurrentUserIdIsInvalid()
    {
        // Arrange
        var existingUser = CreateUser();
        var existingPost = CreatePost();
        var command = new UpdatePostCommand(
            existingPost.Id,
            existingUser.Id,
            PostTestUtilities.ValidUpdateTitle,
            PostTestUtilities.ValidUpdateContent
        );

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserForbiddenException>();
    }

    [Fact]
    public async Task Handle_ShouldGetPostByIdFromRepository_WhenPostIdIsValid()
    {
        // Arrange
        var existingPost = CreatePost();
        var command = new UpdatePostCommand(
            existingPost.Id,
            existingPost.UserId,
            PostTestUtilities.ValidUpdateTitle,
            PostTestUtilities.ValidUpdateContent
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await PostWriteRepository
            .Received(1)
            .GetByIdAsync(existingPost.Id, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldDeletePostFromRepository_WhenPostIdIsValid()
    {
        // Arrange
        var existingPost = CreatePost();
        var command = new UpdatePostCommand(
            existingPost.Id,
            existingPost.UserId,
            PostTestUtilities.ValidUpdateTitle,
            PostTestUtilities.ValidUpdateContent
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        PostWriteRepository
            .Received(1)
            .Update(Arg.Is<Post>(m => m.Id == existingPost.Id &&
                                      m.UserId == existingPost.UserId &&
                                      m.Title == PostTestUtilities.ValidUpdateTitle &&
                                      m.Content == PostTestUtilities.ValidUpdateContent));
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenPostIdIsValid()
    {
        // Arrange
        var existingPost = CreatePost();
        var command = new UpdatePostCommand(
            existingPost.Id,
            existingPost.UserId,
            PostTestUtilities.ValidUpdateTitle,
            PostTestUtilities.ValidUpdateContent
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
