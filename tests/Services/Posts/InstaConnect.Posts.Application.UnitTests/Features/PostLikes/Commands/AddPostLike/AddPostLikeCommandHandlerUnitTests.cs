﻿using InstaConnect.Posts.Application.Features.PostLikes.Commands.Add;

namespace InstaConnect.Posts.Application.UnitTests.Features.PostLikes.Commands.AddPostLike;

public class AddPostLikeCommandHandlerUnitTests : BasePostLikeUnitTest
{
    private readonly AddPostLikeCommandHandler _commandHandler;

    public AddPostLikeCommandHandlerUnitTests()
    {
        _commandHandler = new(
            UnitOfWork,
            InstaConnectMapper,
            UserWriteRepository,
            PostWriteRepository,
            PostLikeWriteRepository);
    }

    [Fact]
    public async Task Handle_ShouldThrowUserNotFoundException_WhenCurrentUserIdIsInvalid()
    {
        // Arrange
        var existingPost = CreatePost();
        var command = new AddPostLikeCommand(
            UserTestUtilities.InvalidId,
            existingPost.Id);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowPostNotFoundException_WhenPostIdIsInvalid()
    {
        // Arrange
        var existingUser = CreateUser();
        var command = new AddPostLikeCommand(
            existingUser.Id,
            PostTestUtilities.InvalidId);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<PostNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowPostLikeAlreadyExistsException_WhenPostLikeAlreadyExists()
    {
        // Arrange
        var existingPostLike = CreatePostLike();
        var command = new AddPostLikeCommand(
            existingPostLike.UserId,
            existingPostLike.PostId);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<PostLikeAlreadyExistsException>();
    }

    [Fact]
    public async Task Handle_ShouldReturnPostLikeCommandViewModel_WhenPostLikeIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var existingPost = CreatePost();
        var command = new AddPostLikeCommand(
            existingUser.Id,
            existingPost.Id);

        // Act
        var response = await _commandHandler.Handle(command, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostLikeCommandViewModel>(m => !string.IsNullOrEmpty(m.Id));
    }

    [Fact]
    public async Task Handle_ShouldAddPostToRepository_WhenPostIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var existingPost = CreatePost();
        var command = new AddPostLikeCommand(
            existingUser.Id,
            existingPost.Id);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        PostLikeWriteRepository
            .Received(1)
            .Add(Arg.Is<PostLike>(m =>
                !string.IsNullOrEmpty(m.Id) &&
                m.UserId == existingUser.Id &&
                m.PostId == existingPost.Id));
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenPostIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var existingPost = CreatePost();
        var command = new AddPostLikeCommand(
            existingUser.Id,
            existingPost.Id);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
