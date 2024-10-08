﻿using FluentAssertions;
using InstaConnect.Posts.Business.Features.PostComments.Commands.AddPostComment;
using InstaConnect.Posts.Business.Features.PostComments.Models;
using InstaConnect.Posts.Business.UnitTests.Features.PostComments.Utilities;
using InstaConnect.Posts.Common.Features.PostComments.Utilities;
using InstaConnect.Posts.Data.Features.PostComments.Models.Entitites;
using InstaConnect.Shared.Common.Exceptions.Posts;
using InstaConnect.Shared.Common.Exceptions.User;
using NSubstitute;

namespace InstaConnect.Posts.Business.UnitTests.Features.PostComments.Commands.AddComment;

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
        var command = new AddPostCommentCommand(
            PostCommentTestUtilities.InvalidUserId,
            PostCommentTestUtilities.ValidPostId,
            PostCommentTestUtilities.ValidContent);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowPostNotFoundException_WhenPostIdIsInvalid()
    {
        // Arrange
        var command = new AddPostCommentCommand(
            PostCommentTestUtilities.ValidCurrentUserId,
            PostCommentTestUtilities.InvalidPostId,
            PostCommentTestUtilities.ValidContent);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<PostNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldReturnPostCommentCommandViewModel_WhenPostCommentIsValid()
    {
        // Arrange
        var command = new AddPostCommentCommand(
            PostCommentTestUtilities.ValidCurrentUserId,
            PostCommentTestUtilities.ValidPostId,
            PostCommentTestUtilities.ValidContent);

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
        var command = new AddPostCommentCommand(
            PostCommentTestUtilities.ValidCurrentUserId,
            PostCommentTestUtilities.ValidPostId,
            PostCommentTestUtilities.ValidContent);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        PostCommentWriteRepository
            .Received(1)
            .Add(Arg.Is<PostComment>(m =>
                !string.IsNullOrEmpty(m.Id) &&
                m.UserId == PostCommentTestUtilities.ValidCurrentUserId &&
                m.PostId == PostCommentTestUtilities.ValidPostId &&
                m.Content == PostCommentTestUtilities.ValidContent));
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenPostIsValid()
    {
        // Arrange
        var command = new AddPostCommentCommand(
            PostCommentTestUtilities.ValidCurrentUserId,
            PostCommentTestUtilities.ValidPostId,
            PostCommentTestUtilities.ValidContent);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
