using InstaConnect.Posts.Application.Features.PostComments.Commands.Update;

namespace InstaConnect.Posts.Application.UnitTests.Features.PostComments.Commands.Update;

public class UpdatePostCommentCommandHandlerUnitTests : BasePostCommentUnitTest
{
    private readonly UpdatePostCommentCommandHandler _commandHandler;

    public UpdatePostCommentCommandHandlerUnitTests()
    {
        _commandHandler = new(
            UnitOfWork,
            InstaConnectMapper,
            PostCommentService,
            PostWriteRepository);
    }

    [Fact]
    public async Task Handle_ShouldThrowPostCommentNotFoundException_WhenPostIdIsInvalid()
    {
        // Arrange
        var existingPostComment = CreatePostComment();
        var command = new UpdatePostCommentCommand(
            PostCommentTestUtilities.InvalidId,
            existingPostComment.PostId,
            existingPostComment.UserId,
            PostCommentTestUtilities.ValidUpdateContent
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
        var command = new UpdatePostCommentCommand(
            existingPostComment.Id,
            existingPostComment.PostId,
            existingUser.Id,
            PostCommentTestUtilities.ValidUpdateContent
        );

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserForbiddenException>();
    }

    [Fact]
    public async Task Handle_ShouldDeletePostFromRepository_WhenPostIdIsValid()
    {
        // Arrange
        var existingPostComment = CreatePostComment();
        var command = new UpdatePostCommentCommand(
            existingPostComment.Id,
            existingPostComment.PostId,
            existingPostComment.UserId,
            PostCommentTestUtilities.ValidUpdateContent
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await PostCommentService
            .Received(1)
            .UpdateAsync(
                existingPostComment.Post,
                existingPostComment.Id,
                existingPostComment.UserId,
                PostCommentTestUtilities.ValidUpdateContent,
                CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenPostIdIsValid()
    {
        // Arrange
        var existingPostComment = CreatePostComment();
        var command = new UpdatePostCommentCommand(
            existingPostComment.Id,
            existingPostComment.PostId,
            existingPostComment.UserId,
            PostCommentTestUtilities.ValidUpdateContent
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
