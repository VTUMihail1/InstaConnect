using InstaConnect.Posts.Application.Features.PostComments.Commands.Add;

namespace InstaConnect.Posts.Application.UnitTests.Features.PostComments.Commands.Add;

public class AddPostCommentCommandHandlerUnitTests : BasePostCommentUnitTest
{
    private readonly AddPostCommentCommandHandler _commandHandler;

    public AddPostCommentCommandHandlerUnitTests()
    {
        _commandHandler = new(
            UnitOfWork,
            InstaConnectMapper,
            PostCommentService,
            UserWriteRepository,
            PostWriteRepository);
    }

    [Fact]
    public async Task Handle_ShouldThrowUserNotFoundException_WhenCurrentUserIdIsInvalid()
    {
        // Arrange
        var postComment = CreatePostCommentFactory();
        var command = new AddPostCommentCommand(
            UserTestUtilities.InvalidId,
            postComment.PostId,
            PostCommentTestUtilities.ValidAddContent);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowPostNotFoundException_WhenPostIdIsInvalid()
    {
        // Arrange
        var postComment = CreatePostCommentFactory();
        var command = new AddPostCommentCommand(
            postComment.UserId,
            PostTestUtilities.InvalidId,
            PostCommentTestUtilities.ValidAddContent);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<PostNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldReturnPostCommentCommandViewModel_WhenPostCommentIsValid()
    {
        // Arrange
        var postComment = CreatePostCommentFactory();
        var command = new AddPostCommentCommand(
            postComment.UserId,
            postComment.PostId,
            PostCommentTestUtilities.ValidAddContent);

        // Act
        var response = await _commandHandler.Handle(command, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentCommandViewModel>(m => m.Id == response.Id);
    }

    [Fact]
    public async Task Handle_ShouldAddPostToRepository_WhenPostIsValid()
    {
        // Arrange
        var postComment = CreatePostCommentFactory();
        var command = new AddPostCommentCommand(
            postComment.UserId,
            postComment.PostId,
            PostCommentTestUtilities.ValidAddContent);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        PostCommentService
            .Received(1)
            .Add(postComment.Post,
                 PostCommentTestUtilities.ValidAddContent,
                 postComment.UserId);
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenPostIsValid()
    {
        // Arrange
        var postComment = CreatePostCommentFactory();
        var command = new AddPostCommentCommand(
            postComment.UserId,
            postComment.PostId,
            PostCommentTestUtilities.ValidAddContent);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
