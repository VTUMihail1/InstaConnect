using InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Add;
using InstaConnect.Posts.Domain.Features.Users.Exceptions;

namespace InstaConnect.Posts.Application.UnitTests.Features.PostCommentLikes.Commands.Add;

public class AddPostCommentLikeCommandHandlerUnitTests : BasePostCommentLikeUnitTest
{
    private readonly AddPostCommentLikeCommandHandler _commandHandler;

    public AddPostCommentLikeCommandHandlerUnitTests()
    {
        _commandHandler = new(
            UnitOfWork,
            ApplicationMapper,
            UserWriteRepository,
            PostWriteRepository,
            PostCommentLikeService);
    }

    [Fact]
    public async Task Handle_ShouldThrowUserNotFoundException_WhenCurrentUserIdIsInvalid()
    {
        // Arrange
        var existingPostCommentLike = CreatePostCommentLikeFactory();
        var command = new AddPostCommentLikeCommand(
            UserTestUtilities.InvalidId,
            existingPostCommentLike.PostComment.PostId,
            existingPostCommentLike.Id);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowPostNotFoundException_WhePostIdIsInvalid()
    {
        // Arrange
        var existingPostCommentLike = CreatePostCommentLikeFactory();
        var command = new AddPostCommentLikeCommand(
            existingPostCommentLike.UserId,
            PostTestUtilities.InvalidId,
            existingPostCommentLike.Id);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<PostNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowPostCommentNotFoundException_WhenPostCommentIdIsInvalid()
    {
        // Arrange
        var existingPostCommentLike = CreatePostCommentLikeFactory();
        var command = new AddPostCommentLikeCommand(
            existingPostCommentLike.UserId,
            existingPostCommentLike.PostComment.PostId,
            PostCommentTestUtilities.InvalidId);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<PostCommentNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowPostCommentLikeAlreadyExistsException_WhenPostCommentLikeAlreadyExists()
    {
        // Arrange
        var existingPostCommentLike = CreatePostCommentLike();
        var command = new AddPostCommentLikeCommand(
            existingPostCommentLike.UserId,
            existingPostCommentLike.PostComment.PostId,
            existingPostCommentLike.PostCommentId);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<PostCommentLikeAlreadyExistsException>();
    }

    [Fact]
    public async Task Handle_ShouldReturnPostCommentLikeCommandViewModel_WhenPostCommentLikeIsValid()
    {
        // Arrange
        var existingPostCommentLike = CreatePostCommentLikeFactory();
        var command = new AddPostCommentLikeCommand(
            existingPostCommentLike.UserId,
            existingPostCommentLike.PostComment.PostId,
            existingPostCommentLike.PostCommentId);

        // Act
        var response = await _commandHandler.Handle(command, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentLikeCommandViewModel>(m => m.Id == existingPostCommentLike.Id);
    }

    [Fact]
    public async Task Handle_ShouldGetUserFromRepository_WhenPostCommentLikeIsValid()
    {
        // Arrange
        var existingPostCommentLike = CreatePostCommentLikeFactory();
        var command = new AddPostCommentLikeCommand(
            existingPostCommentLike.UserId,
            existingPostCommentLike.PostComment.PostId,
            existingPostCommentLike.PostCommentId);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UserWriteRepository
            .Received(1)
            .GetByIdAsync(
                existingPostCommentLike.UserId,
                CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldGetPostFromRepository_WhenPostCommentLikeIsValid()
    {
        // Arrange
        var existingPostCommentLike = CreatePostCommentLikeFactory();
        var command = new AddPostCommentLikeCommand(
            existingPostCommentLike.UserId,
            existingPostCommentLike.PostComment.PostId,
            existingPostCommentLike.PostCommentId);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await PostWriteRepository
            .Received(1)
            .GetByIdAsync(
                existingPostCommentLike.PostComment.PostId,
                CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldAddPostCommentLikeToRepository_WhenPostCommentLikeIsValid()
    {
        // Arrange
        var existingPostCommentLike = CreatePostCommentLikeFactory();
        var command = new AddPostCommentLikeCommand(
            existingPostCommentLike.UserId,
            existingPostCommentLike.PostComment.PostId,
            existingPostCommentLike.PostCommentId);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await PostCommentLikeService
            .Received(1)
            .AddAsync(
                existingPostCommentLike.PostComment.Post,
                existingPostCommentLike.Id,
                existingPostCommentLike.UserId,
                CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenPostCommentLikeIsValid()
    {
        // Arrange
        var existingPostCommentLike = CreatePostCommentLikeFactory();
        var command = new AddPostCommentLikeCommand(
            existingPostCommentLike.UserId,
            existingPostCommentLike.PostComment.PostId,
            existingPostCommentLike.PostCommentId);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
