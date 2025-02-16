using FluentAssertions;

using InstaConnect.Posts.Application.Features.PostComments.Commands.Delete;
using InstaConnect.Posts.Application.UnitTests.Features.PostComments.Utilities;
using InstaConnect.Posts.Common.Features.PostComments.Utilities;
using InstaConnect.Posts.Domain.Features.PostComments.Exceptions;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Entitites;
using InstaConnect.Shared.Common.Exceptions.Users;

using NSubstitute;

namespace InstaConnect.Posts.Application.UnitTests.Features.PostComments.Commands.Delete;

public class DeletePostCommentCommandHandlerUnitTests : BasePostCommentUnitTest
{
    private readonly DeletePostCommentCommandHandler _commandHandler;

    public DeletePostCommentCommandHandlerUnitTests()
    {
        _commandHandler = new(
            UnitOfWork,
            PostCommentWriteRepository);
    }

    [Fact]
    public async Task Handle_ShouldThrowPostCommentNotFoundException_WhenPostIdIsInvalid()
    {
        // Arrange
        var existingPostComment = CreatePostComment();
        var command = new DeletePostCommentCommand(
            PostCommentTestUtilities.InvalidId,
            existingPostComment.UserId
        );

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<PostCommentNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowAccountForbiddenException_WhenCurrentUserIdIsInvalid()
    {
        // Arrange
        var existingUser = CreateUser();
        var existingPostComment = CreatePostComment();
        var command = new DeletePostCommentCommand(
            existingPostComment.Id,
            existingUser.Id
        );

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserForbiddenException>();
    }

    [Fact]
    public async Task Handle_ShouldGetPostCommentByIdFromRepository_WhenPostCommentIdIsValid()
    {
        // Arrange
        var existingPostComment = CreatePostComment();
        var command = new DeletePostCommentCommand(
            existingPostComment.Id,
            existingPostComment.UserId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await PostCommentWriteRepository
            .Received(1)
            .GetByIdAsync(existingPostComment.Id, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldDeletePostCommentFromRepository_WhenPostCommentIdIsValid()
    {
        // Arrange
        var existingPostComment = CreatePostComment();
        var command = new DeletePostCommentCommand(
            existingPostComment.Id,
            existingPostComment.UserId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        PostCommentWriteRepository
            .Received(1)
            .Delete(Arg.Is<PostComment>(m => m.Id == existingPostComment.Id &&
                                             m.UserId == existingPostComment.UserId &&
                                             m.PostId == existingPostComment.PostId &&
                                             m.Content == existingPostComment.Content));
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenPostCommentIdIsValid()
    {
        // Arrange
        var existingPostComment = CreatePostComment();
        var command = new DeletePostCommentCommand(
            existingPostComment.Id,
            existingPostComment.UserId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
