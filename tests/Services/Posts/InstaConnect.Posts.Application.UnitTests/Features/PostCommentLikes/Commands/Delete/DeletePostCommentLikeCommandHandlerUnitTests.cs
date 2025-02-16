using FluentAssertions;

using InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Delete;
using InstaConnect.Posts.Application.UnitTests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Common.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Exceptions;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Entitites;
using InstaConnect.Shared.Common.Exceptions.Users;

using NSubstitute;

namespace InstaConnect.Posts.Application.UnitTests.Features.PostCommentLikes.Commands.Delete;

public class DeletePostCommentLikeCommandHandlerUnitTests : BasePostCommentLikeUnitTest
{
    private readonly DeletePostCommentLikeCommandHandler _commandHandler;

    public DeletePostCommentLikeCommandHandlerUnitTests()
    {
        _commandHandler = new(
            UnitOfWork,
            PostCommentLikeWriteRepository);
    }

    [Fact]
    public async Task Handle_ShouldThrowPostCommentLikeNotFoundException_WhenPostCommentLikeIdIsInvalid()
    {
        // Arrange
        var existingPostCommentLike = CreatePostCommentLike();
        var command = new DeletePostCommentLikeCommand(
            PostCommentLikeTestUtilities.InvalidId,
            existingPostCommentLike.UserId
        );

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<PostCommentLikeNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowAccountForbiddenException_WhenCurrentUserIdIsInvalid()
    {
        // Arrange
        var existingUser = CreateUser();
        var existingPostCommentLike = CreatePostCommentLike();
        var command = new DeletePostCommentLikeCommand(
            existingPostCommentLike.Id,
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
        var existingPostCommentLike = CreatePostCommentLike();
        var command = new DeletePostCommentLikeCommand(
            existingPostCommentLike.Id,
            existingPostCommentLike.UserId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await PostCommentLikeWriteRepository
            .Received(1)
            .GetByIdAsync(existingPostCommentLike.Id, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldDeletePostCommentLikeFromRepository_WhenPostCommentLikeIdIsValid()
    {
        // Arrange
        var existingPostCommentLike = CreatePostCommentLike();
        var command = new DeletePostCommentLikeCommand(
            existingPostCommentLike.Id,
            existingPostCommentLike.UserId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        PostCommentLikeWriteRepository
            .Received(1)
            .Delete(Arg.Is<PostCommentLike>(m => m.Id == existingPostCommentLike.Id &&
                                          m.UserId == existingPostCommentLike.UserId &&
                                          m.PostCommentId == existingPostCommentLike.PostCommentId));
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenPostCommentLikeIdIsValid()
    {
        // Arrange
        var existingPostCommentLike = CreatePostCommentLike();
        var command = new DeletePostCommentLikeCommand(
            existingPostCommentLike.Id,
            existingPostCommentLike.UserId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
