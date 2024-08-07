using FluentAssertions;
using InstaConnect.Follows.Business.UnitTests.Features.Follows.Utilities;
using InstaConnect.Posts.Business.Features.PostComments.Commands.UpdatePostComment;
using InstaConnect.Posts.Data.Features.PostComments.Models.Entitites;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.PostComment;
using NSubstitute;

namespace InstaConnect.Follows.Business.UnitTests.Features.Follows.Commands.DeleteFollow;

public class UpdatePostCommentCommandHandlerUnitTests : BasePostCommentUnitTest
{
    private readonly UpdatePostCommentCommandHandler _commandHandler;

    public UpdatePostCommentCommandHandlerUnitTests()
    {
        _commandHandler = new(
            UnitOfWork,
            InstaConnectMapper,
            PostCommentWriteRepository);
    }

    [Fact]
    public async Task Handle_ShouldThrowPostCommentNotFoundException_WhenPostIdIsInvalid()
    {
        // Arrange
        var command = new UpdatePostCommentCommand(
            InvalidId,
            ValidPostCommentCurrentUserId,
            ValidContent
        );

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<PostCommentNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowAccountForbiddenException_WhenCurrentUserIdIsInvalid()
    {
        // Arrange
        var command = new UpdatePostCommentCommand(
            ValidId,
            ValidCurrentUserId,
            ValidContent
        );

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AccountForbiddenException>();
    }

    [Fact]
    public async Task Handle_ShouldGetPostCommentByIdFromRepository_WhenPostCommentIdIsValid()
    {
        // Arrange
        var command = new UpdatePostCommentCommand(
            ValidId,
            ValidPostCommentCurrentUserId,
            ValidContent
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await PostCommentWriteRepository
            .Received(1)
            .GetByIdAsync(ValidId, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldDeletePostFromRepository_WhenPostIdIsValid()
    {
        // Arrange
        var command = new UpdatePostCommentCommand(
            ValidId,
            ValidPostCommentCurrentUserId,
            ValidContent
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        PostCommentWriteRepository
            .Received(1)
            .Update(Arg.Is<PostComment>(m => m.Id == ValidId &&
                                      m.UserId == ValidPostCommentCurrentUserId &&
                                      m.Content == ValidContent));
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenPostIdIsValid()
    {
        // Arrange
        var command = new UpdatePostCommentCommand(
            ValidId,
            ValidPostCommentCurrentUserId,
            ValidContent
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
