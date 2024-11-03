using FluentAssertions;
using InstaConnect.Posts.Business.Features.Posts.Commands.AddPost;
using InstaConnect.Posts.Business.Features.Posts.Models;
using InstaConnect.Posts.Business.UnitTests.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Posts.Data.Features.Posts.Models.Entitites;
using InstaConnect.Shared.Common.Exceptions.User;
using NSubstitute;

namespace InstaConnect.Posts.Business.UnitTests.Features.Posts.Commands.AddPost;

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
            PostTestUtilities.InvalidUserId,
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidContent);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldReturnPostCommandViewModel_WhenPostIsValid()
    {
        // Arrange
        var command = new AddPostCommand(
            PostTestUtilities.ValidCurrentUserId,
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidContent);

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
        var command = new AddPostCommand(
            PostTestUtilities.ValidCurrentUserId,
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidContent);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        PostWriteRepository
            .Received(1)
            .Add(Arg.Is<Post>(m =>
                !string.IsNullOrEmpty(m.Id) &&
                m.UserId == PostTestUtilities.ValidCurrentUserId &&
                m.Title == PostTestUtilities.ValidTitle &&
                m.Content == PostTestUtilities.ValidContent));
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenPostIsValid()
    {
        // Arrange
        var command = new AddPostCommand(
            PostTestUtilities.ValidCurrentUserId,
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidContent);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
