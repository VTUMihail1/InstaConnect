using FluentAssertions;
using InstaConnect.Posts.Application.Features.PostLikes.Commands.Delete;
using InstaConnect.Posts.Application.UnitTests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Common.Features.PostLikes.Utilities;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Entitites;
using InstaConnect.Shared.Common.Exceptions.PostLike;
using InstaConnect.Shared.Common.Exceptions.User;
using NSubstitute;

namespace InstaConnect.Posts.Application.UnitTests.Features.PostLikes.Commands.DeletePostLike;

public class DeletePostLikeCommandHandlerUnitTests : BasePostLikeUnitTest
{
    private readonly DeletePostLikeCommandHandler _commandHandler;

    public DeletePostLikeCommandHandlerUnitTests()
    {
        _commandHandler = new(
            UnitOfWork,
            PostLikeWriteRepository);
    }

    [Fact]
    public async Task Handle_ShouldThrowPostLikeNotFoundException_WhenPostLikeIdIsInvalid()
    {
        // Arrange
        var existingPostLike = CreatePostLike();
        var command = new DeletePostLikeCommand(
            PostLikeTestUtilities.InvalidId,
            existingPostLike.UserId
        );

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<PostLikeNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowAccountForbiddenException_WhenCurrentUserIdIsInvalid()
    {
        // Arrange
        var existingUser = CreateUser();
        var existingPostLike = CreatePostLike();
        var command = new DeletePostLikeCommand(
            existingPostLike.Id,
            existingUser.Id
        );

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserForbiddenException>();
    }

    [Fact]
    public async Task Handle_ShouldGetPostLikeByIdFromRepository_WhenPostLikeIdIsValid()
    {
        // Arrange
        var existingPostLike = CreatePostLike();
        var command = new DeletePostLikeCommand(
            existingPostLike.Id,
            existingPostLike.UserId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await PostLikeWriteRepository
            .Received(1)
            .GetByIdAsync(existingPostLike.Id, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldDeletePostLikeFromRepository_WhenPostLikeIdIsValid()
    {
        // Arrange
        var existingPostLike = CreatePostLike();
        var command = new DeletePostLikeCommand(
            existingPostLike.Id,
            existingPostLike.UserId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        PostLikeWriteRepository
            .Received(1)
            .Delete(Arg.Is<PostLike>(m => m.Id == existingPostLike.Id &&
                                          m.UserId == existingPostLike.UserId &&
                                          m.PostId == existingPostLike.PostId));
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenPostLikeIdIsValid()
    {
        // Arrange
        var existingPostLike = CreatePostLike();
        var command = new DeletePostLikeCommand(
            existingPostLike.Id,
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
