using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Application.UnitTests.Features.Posts.Commands.Add;

public class AddPostCommandHandlerUnitTests : BasePostUnitTest
{
    private readonly AddPostCommandHandler _commandHandler;

    public AddPostCommandHandlerUnitTests()
    {
        _commandHandler = new(
            UnitOfWork,
            InstaConnectMapper,
            PostWriteRepository,
            UserWriteRepository);
    }

    [Fact]
    public async Task Handle_ShouldThrowUserNotFoundException_WhenCurrentUserIdIsInvalid()
    {
        // Arrange
        var command = new AddPostCommand(
            UserTestUtilities.InvalidId,
            PostTestUtilities.ValidAddTitle,
            PostTestUtilities.ValidAddContent);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldReturnPostCommandViewModel_WhenPostIsValid()
    {
        // Arrange
        var existingPost = CreatePost();
        var command = new AddPostCommand(
            existingPost.UserId,
            PostTestUtilities.ValidAddTitle,
            PostTestUtilities.ValidAddContent);

        // Act
        var response = await _commandHandler.Handle(command, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommandViewModel>(m => !string.IsNullOrEmpty(m.Id));
    }

    [Fact]
    public async Task Handle_ShouldAddPostToRepository_WhenPostIsValid()
    {
        // Arrange
        var existingPost = CreatePost();
        var command = new AddPostCommand(
            existingPost.UserId,
            PostTestUtilities.ValidAddTitle,
            PostTestUtilities.ValidAddContent);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        PostWriteRepository
            .Received(1)
            .Add(Arg.Is<Post>(m =>
                !string.IsNullOrEmpty(m.Id) &&
                m.UserId == existingPost.UserId &&
                m.Title == PostTestUtilities.ValidAddTitle &&
                m.Content == PostTestUtilities.ValidAddContent));
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenPostIsValid()
    {
        // Arrange
        var existingPost = CreatePost();
        var command = new AddPostCommand(
            existingPost.UserId,
            PostTestUtilities.ValidAddTitle,
            PostTestUtilities.ValidAddContent);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
