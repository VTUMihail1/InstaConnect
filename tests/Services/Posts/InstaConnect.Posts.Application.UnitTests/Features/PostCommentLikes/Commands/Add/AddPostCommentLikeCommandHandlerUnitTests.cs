using InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Add;

namespace InstaConnect.Posts.Application.UnitTests.Features.PostCommentLikes.Commands.Add;

public class AddPostCommentLikeCommandHandlerUnitTests : BasePostCommentLikeUnitTest
{
    private readonly AddPostCommentLikeCommandHandler _commandHandler;

    public AddPostCommentLikeCommandHandlerUnitTests()
    {
        _commandHandler = new(
            UnitOfWork,
            InstaConnectMapper,
            UserWriteRepository,
            PostCommentWriteRepository,
            PostCommentLikeWriteRepository);
    }

    [Fact]
    public async Task Handle_ShouldThrowUserNotFoundException_WhenCurrentUserIdIsInvalid()
    {
        // Arrange
        var existingPostComment = CreatePostComment();
        var command = new AddPostCommentLikeCommand(
            UserTestUtilities.InvalidId,
            existingPostComment.Id);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowPostCommentNotFoundException_WhenPostCommentIdIsInvalid()
    {
        // Arrange
        var existingUser = CreateUser();
        var command = new AddPostCommentLikeCommand(
            existingUser.Id,
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
        var existingUser = CreateUser();
        var existingPostComment = CreatePostComment();
        var command = new AddPostCommentLikeCommand(
            existingUser.Id,
            existingPostComment.Id);

        // Act
        var response = await _commandHandler.Handle(command, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentLikeCommandViewModel>(m => !string.IsNullOrEmpty(m.Id));
    }

    [Fact]
    public async Task Handle_ShouldAddPostCommentLikeToRepository_WhenPostCommentLikeIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var existingPostComment = CreatePostComment();
        var command = new AddPostCommentLikeCommand(
            existingUser.Id,
            existingPostComment.Id);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        PostCommentLikeWriteRepository
            .Received(1)
            .Add(Arg.Is<PostCommentLike>(m =>
                !string.IsNullOrEmpty(m.Id) &&
                m.UserId == existingUser.Id &&
                m.PostCommentId == existingPostComment.Id));
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenPostCommentLikeIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var existingPostComment = CreatePostComment();
        var command = new AddPostCommentLikeCommand(
            existingUser.Id,
            existingPostComment.Id);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
