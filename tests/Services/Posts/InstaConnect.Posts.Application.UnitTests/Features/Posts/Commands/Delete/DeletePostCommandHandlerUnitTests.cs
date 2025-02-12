using FluentAssertions;
using InstaConnect.Posts.Application.Features.Posts.Commands.Delete;
using InstaConnect.Posts.Application.UnitTests.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entitites;
using InstaConnect.Shared.Common.Exceptions.Posts;
using InstaConnect.Shared.Common.Exceptions.User;
using NSubstitute;

namespace InstaConnect.Posts.Application.UnitTests.Features.Posts.Commands.Delete;

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
        var existingPost = CreatePost();
        var command = new DeletePostCommand(
            PostTestUtilities.InvalidId,
            existingPost.UserId
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
        var existingUser = CreateUser();
        var existingPost = CreatePost();
        var command = new DeletePostCommand(
            existingPost.Id,
            existingUser.Id
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
        var existingPost = CreatePost();
        var command = new DeletePostCommand(
            existingPost.Id,
            existingPost.UserId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await PostWriteRepository
            .Received(1)
            .GetByIdAsync(existingPost.Id, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldDeletePostFromRepository_WhenPostIdIsValid()
    {
        // Arrange
        var existingPost = CreatePost();
        var command = new DeletePostCommand(
            existingPost.Id,
            existingPost.UserId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        PostWriteRepository
            .Received(1)
            .Delete(Arg.Is<Post>(m => m.Id == existingPost.Id &&
                                      m.UserId == existingPost.UserId &&
                                      m.Title == existingPost.Title &&
                                      m.Content == existingPost.Content));
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenPostIdIsValid()
    {
        // Arrange
        var existingPost = CreatePost();
        var command = new DeletePostCommand(
            existingPost.Id,
            existingPost.UserId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
