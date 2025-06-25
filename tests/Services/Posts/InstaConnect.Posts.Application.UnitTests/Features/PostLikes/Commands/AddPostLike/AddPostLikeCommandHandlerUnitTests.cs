using InstaConnect.Posts.Application.Features.PostLikes.Commands.Add;
using InstaConnect.Posts.Domain.Features.Users.Exceptions;

namespace InstaConnect.Posts.Application.UnitTests.Features.PostLikes.Commands.AddPostLike;

public class AddPostLikeCommandHandlerUnitTests : BasePostLikeUnitTest
{
    private readonly AddPostLikeCommandHandler _commandHandler;

    public AddPostLikeCommandHandlerUnitTests()
    {
        _commandHandler = new(
            UnitOfWork,
            PostLikeService,
            ApplicationMapper,
            UserWriteRepository,
            PostWriteRepository);
    }

    [Fact]
    public async Task Handle_ShouldThrowUserNotFoundException_WhenCurrentUserIdIsInvalid()
    {
        // Arrange
        var existingPostLike = CreatePostLikeFactory();
        var command = new AddPostLikeCommand(
            UserTestUtilities.InvalidId,
            existingPostLike.Id);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowPostNotFoundException_WhenPostIdIsInvalid()
    {
        // Arrange
        var existingPostLike = CreatePostLikeFactory();
        var command = new AddPostLikeCommand(
            existingPostLike.UserId,
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
        var existingPostLike = CreatePostLikeFactory();
        var command = new AddPostLikeCommand(
            existingPostLike.UserId,
            existingPostLike.PostId);

        // Act
        var response = await _commandHandler.Handle(command, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostLikeCommandViewModel>(m => m.Id == existingPostLike.Id);
    }

    [Fact]
    public async Task Handle_ShouldAddPostLikeToRepository_WhenPostIsValid()
    {
        // Arrange
        var existingPostLike = CreatePostLikeFactory();
        var command = new AddPostLikeCommand(
            existingPostLike.UserId,
            existingPostLike.PostId);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await PostLikeService
            .Received(1)
            .AddAsync(existingPostLike.Post, existingPostLike.UserId, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenPostIsValid()
    {
        // Arrange
        var existingPostLike = CreatePostLikeFactory();
        var command = new AddPostLikeCommand(
            existingPostLike.UserId,
            existingPostLike.PostId);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
