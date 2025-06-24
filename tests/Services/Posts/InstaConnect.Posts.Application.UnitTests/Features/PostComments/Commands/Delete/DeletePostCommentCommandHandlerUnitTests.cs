using InstaConnect.Posts.Application.Features.PostComments.Commands.Delete;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Entities;

namespace InstaConnect.Posts.Application.UnitTests.Features.PostComments.Commands.Delete;

public class DeletePostCommentCommandHandlerUnitTests : BasePostCommentUnitTest
{
    private readonly DeletePostCommentCommandHandler _commandHandler;

    public DeletePostCommentCommandHandlerUnitTests()
    {
        _commandHandler = new(
            UnitOfWork,
            PostCommentService,
            PostWriteRepository);
    }

    [Fact]
    public async Task Handle_ShouldThrowPostException_WhenPostIdIsInvalid()
    {
        // Arrange
        var existingPostComment = CreatePostComment();
        var command = new DeletePostCommentCommand(
            existingPostComment.Id,
            PostTestUtilities.InvalidId,
            existingPostComment.UserId
        );

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<PostNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowPostCommentNotFoundException_WhenPostCommentIdIsInvalid()
    {
        // Arrange
        var existingPostComment = CreatePostComment();
        var command = new DeletePostCommentCommand(
            PostCommentTestUtilities.InvalidId,
            existingPostComment.PostId,
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
            existingPostComment.PostId,
            existingUser.Id
        );

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<PostForbiddenException>();
    }

    [Fact]
    public async Task Handle_ShouldDeletePostCommentFromRepository_WhenPostCommentIdIsValid()
    {
        // Arrange
        var existingPostComment = CreatePostComment();
        var command = new DeletePostCommentCommand(
            existingPostComment.Id,
            existingPostComment.PostId,
            existingPostComment.UserId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await PostCommentService
            .Received(1)
            .DeleteAsync(existingPostComment.Post,
                         existingPostComment.Id,
                         existingPostComment.UserId,
                         CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenPostCommentIdIsValid()
    {
        // Arrange
        var existingPostComment = CreatePostComment();
        var command = new DeletePostCommentCommand(
            existingPostComment.Id,
            existingPostComment.PostId,
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
