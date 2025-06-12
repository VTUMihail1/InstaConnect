using InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Delete;

namespace InstaConnect.Posts.Application.UnitTests.Features.PostCommentLikes.Commands.Delete;

public class DeletePostCommentLikeCommandHandlerUnitTests : BasePostCommentLikeUnitTest
{
    private readonly DeletePostCommentLikeCommandHandler _commandHandler;

    public DeletePostCommentLikeCommandHandlerUnitTests()
    {
        _commandHandler = new(
            UnitOfWork,
            PostWriteRepository,
            PostCommentLikeService);
    }

    [Fact]
    public async Task Handle_ShouldThrowPostNotFoundException_WhenPostIdIsInvalid()
    {
        // Arrange
        var existingPostCommentLike = CreatePostCommentLike();
        var command = new DeletePostCommentLikeCommand(
            existingPostCommentLike.Id,
            PostTestUtilities.InvalidId,
            existingPostCommentLike.PostCommentId,
            existingPostCommentLike.UserId
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
        var existingPostCommentLike = CreatePostCommentLike();
        var command = new DeletePostCommentLikeCommand(
            existingPostCommentLike.Id,
            existingPostCommentLike.PostComment.PostId,
            PostCommentTestUtilities.InvalidId,
            existingPostCommentLike.UserId
        );

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<PostNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowPostCommentLikeNotFoundException_WhenPostCommentLikeIdIsInvalid()
    {
        // Arrange
        var existingPostCommentLike = CreatePostCommentLike();
        var command = new DeletePostCommentLikeCommand(
            PostCommentLikeTestUtilities.InvalidId,
            existingPostCommentLike.PostComment.PostId,
            existingPostCommentLike.PostCommentId,
            existingPostCommentLike.UserId
        );

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<PostCommentLikeNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldGetPostLikeByIdFromRepository_WhenPostLikeIdIsValid()
    {
        // Arrange
        var existingPostCommentLike = CreatePostCommentLike();
        var command = new DeletePostCommentLikeCommand(
            existingPostCommentLike.Id,
            existingPostCommentLike.PostComment.PostId,
            existingPostCommentLike.PostCommentId,
            existingPostCommentLike.UserId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await PostWriteRepository
            .Received(1)
            .GetByIdAsync(existingPostCommentLike.PostComment.PostId, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldDeletePostCommentLikeFromRepository_WhenPostCommentLikeIdIsValid()
    {
        // Arrange
        var existingPostCommentLike = CreatePostCommentLike();
        var command = new DeletePostCommentLikeCommand(
            existingPostCommentLike.Id,
            existingPostCommentLike.PostComment.PostId,
            existingPostCommentLike.PostCommentId,
            existingPostCommentLike.UserId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await PostCommentLikeService
            .Received(1)
            .DeleteAsync(
                  existingPostCommentLike.PostComment.Post,
                  existingPostCommentLike.PostCommentId,
                  existingPostCommentLike.Id,
                  existingPostCommentLike.UserId,
                  CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenPostCommentLikeIdIsValid()
    {
        // Arrange
        var existingPostCommentLike = CreatePostCommentLike();
        var command = new DeletePostCommentLikeCommand(
            existingPostCommentLike.Id,
            existingPostCommentLike.PostComment.PostId,
            existingPostCommentLike.PostCommentId,
            existingPostCommentLike.UserId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
