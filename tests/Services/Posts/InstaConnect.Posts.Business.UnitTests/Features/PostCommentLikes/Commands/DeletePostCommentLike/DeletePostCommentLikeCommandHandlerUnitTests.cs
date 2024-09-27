using FluentAssertions;
using InstaConnect.Posts.Business.Features.PostCommentLikes.Commands.DeletePostCommentLike;
using InstaConnect.Posts.Business.UnitTests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Data.Features.PostCommentLikes.Models.Entitites;
using InstaConnect.Shared.Business.Exceptions.PostCommentLike;
using InstaConnect.Shared.Business.Exceptions.User;
using NSubstitute;

namespace InstaConnect.Posts.Business.UnitTests.Features.PostCommentLikes.Commands.DeletePostCommentLike;

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
        var command = new DeletePostCommentLikeCommand(
            InvalidId,
            ValidPostCommentLikeCurrentUserId
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
        var command = new DeletePostCommentLikeCommand(
            ValidId,
            ValidCurrentUserId
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
        var command = new DeletePostCommentLikeCommand(
            ValidId,
            ValidPostCommentLikeCurrentUserId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await PostCommentLikeWriteRepository
            .Received(1)
            .GetByIdAsync(ValidId, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldDeletePostCommentLikeFromRepository_WhenPostCommentLikeIdIsValid()
    {
        // Arrange
        var command = new DeletePostCommentLikeCommand(
            ValidId,
            ValidPostCommentLikeCurrentUserId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        PostCommentLikeWriteRepository
            .Received(1)
            .Delete(Arg.Is<PostCommentLike>(m => m.Id == ValidId &&
                                          m.UserId == ValidPostCommentLikeCurrentUserId &&
                                          m.PostCommentId == ValidPostCommentLikePostCommentId));
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenPostCommentLikeIdIsValid()
    {
        // Arrange
        var command = new DeletePostCommentLikeCommand(
            ValidId,
            ValidPostCommentLikeCurrentUserId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
