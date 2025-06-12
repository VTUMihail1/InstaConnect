using InstaConnect.Posts.Application.Features.PostLikes.Commands.Delete;

namespace InstaConnect.Posts.Application.UnitTests.Features.PostLikes.Commands.DeletePostLike;

public class DeletePostLikeCommandHandlerUnitTests : BasePostLikeUnitTest
{
    private readonly DeletePostLikeCommandHandler _commandHandler;

    public DeletePostLikeCommandHandlerUnitTests()
    {
        _commandHandler = new(
            UnitOfWork,
            PostLikeService,
            PostWriteRepository);
    }

    [Fact]
    public async Task Handle_ShouldThrowPostLikeNotFoundException_WhenPostLikeIdIsInvalid()
    {
        // Arrange
        var existingPostLike = CreatePostLike();
        var command = new DeletePostLikeCommand(
            PostLikeTestUtilities.InvalidId,
            existingPostLike.PostId,
            existingPostLike.UserId
        );

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<PostLikeNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowPostNotFoundException_WhenPostIdIsInvalid()
    {
        // Arrange
        var existingPostLike = CreatePostLike();
        var command = new DeletePostLikeCommand(
            existingPostLike.Id,
            PostTestUtilities.InvalidId,
            existingPostLike.UserId
        );

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<PostNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldGetPostLikeByIdFromRepository_WhenPostLikeIdIsValid()
    {
        // Arrange
        var existingPostLike = CreatePostLike();
        var command = new DeletePostLikeCommand(
            existingPostLike.Id,
            existingPostLike.PostId,
            existingPostLike.UserId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await PostWriteRepository
            .Received(1)
            .GetByIdAsync(existingPostLike.PostId, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldDeletePostLikeFromRepository_WhenPostLikeIdIsValid()
    {
        // Arrange
        var existingPostLike = CreatePostLike();
        var command = new DeletePostLikeCommand(
            existingPostLike.Id,
            existingPostLike.PostId,
            existingPostLike.UserId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await PostLikeService
            .Received(1)
            .DeleteAsync(existingPostLike.Post, existingPostLike.Id, existingPostLike.UserId, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenPostLikeIdIsValid()
    {
        // Arrange
        var existingPostLike = CreatePostLike();
        var command = new DeletePostLikeCommand(
            existingPostLike.Id,
            existingPostLike.PostId,
            existingPostLike.UserId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
