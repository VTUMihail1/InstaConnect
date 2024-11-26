using FluentAssertions;
using InstaConnect.Posts.Application.Features.Posts.Commands.DeletePost;
using InstaConnect.Posts.Application.UnitTests.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entitites;
using InstaConnect.Shared.Common.Exceptions.Posts;
using InstaConnect.Shared.Common.Exceptions.User;
using NSubstitute;

namespace InstaConnect.Posts.Application.UnitTests.Features.Posts.Commands.DeletePost;

public class DeletePostCommandHandlerUnitTests : BasePostUnitTest
{
    private readonly DeletePostCommandHandler _commandHandler;

    public DeletePostCommandHandlerUnitTests()
    {
        _commandHandler = new(
            UnitOfWork,
            PostWriteRepository);
    }

    [Fact]
    public async Task Handle_ShouldThrowPostNotFoundException_WhenPostIdIsInvalid()
    {
        // Arrange
        var command = new DeletePostCommand(
            PostTestUtilities.InvalidId,
            PostTestUtilities.ValidPostCurrentUserId
        );

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<PostNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowAccountForbiddenException_WhenCurrentUserIdIsInvalid()
    {
        // Arrange
        var command = new DeletePostCommand(
            PostTestUtilities.ValidId,
            PostTestUtilities.ValidCurrentUserId
        );

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserForbiddenException>();
    }

    [Fact]
    public async Task Handle_ShouldGetPostByIdFromRepository_WhenPostIdIsValid()
    {
        // Arrange
        var command = new DeletePostCommand(
            PostTestUtilities.ValidId,
            PostTestUtilities.ValidPostCurrentUserId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await PostWriteRepository
            .Received(1)
            .GetByIdAsync(PostTestUtilities.ValidId, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldDeletePostFromRepository_WhenPostIdIsValid()
    {
        // Arrange
        var command = new DeletePostCommand(
            PostTestUtilities.ValidId,
            PostTestUtilities.ValidPostCurrentUserId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        PostWriteRepository
            .Received(1)
            .Delete(Arg.Is<Post>(m => m.Id == PostTestUtilities.ValidId &&
                                      m.UserId == PostTestUtilities.ValidPostCurrentUserId &&
                                      m.Title == PostTestUtilities.ValidTitle &&
                                      m.Content == PostTestUtilities.ValidContent));
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenPostIdIsValid()
    {
        // Arrange
        var command = new DeletePostCommand(
            PostTestUtilities.ValidId,
            PostTestUtilities.ValidPostCurrentUserId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
