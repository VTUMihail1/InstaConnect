using FluentAssertions;
using InstaConnect.Posts.Application.Features.PostComments.Commands.UpdatePostComment;
using InstaConnect.Posts.Application.UnitTests.Features.PostComments.Utilities;
using InstaConnect.Posts.Common.Features.PostComments.Utilities;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Entitites;
using InstaConnect.Shared.Common.Exceptions.PostComment;
using InstaConnect.Shared.Common.Exceptions.User;
using NSubstitute;

namespace InstaConnect.Posts.Application.UnitTests.Features.PostComments.Commands.UpdatePostComment;

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
            PostCommentTestUtilities.InvalidId,
            PostCommentTestUtilities.ValidPostCommentCurrentUserId,
            PostCommentTestUtilities.ValidContent
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
            PostCommentTestUtilities.ValidId,
            PostCommentTestUtilities.ValidCurrentUserId,
            PostCommentTestUtilities.ValidContent
        );

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserForbiddenException>();
    }

    [Fact]
    public async Task Handle_ShouldGetPostCommentByIdFromRepository_WhenPostCommentIdIsValid()
    {
        // Arrange
        var command = new UpdatePostCommentCommand(
            PostCommentTestUtilities.ValidId,
            PostCommentTestUtilities.ValidPostCommentCurrentUserId,
            PostCommentTestUtilities.ValidContent
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await PostCommentWriteRepository
            .Received(1)
            .GetByIdAsync(PostCommentTestUtilities.ValidId, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldDeletePostFromRepository_WhenPostIdIsValid()
    {
        // Arrange
        var command = new UpdatePostCommentCommand(
            PostCommentTestUtilities.ValidId,
            PostCommentTestUtilities.ValidPostCommentCurrentUserId,
            PostCommentTestUtilities.ValidContent
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        PostCommentWriteRepository
            .Received(1)
            .Update(Arg.Is<PostComment>(m => m.Id == PostCommentTestUtilities.ValidId &&
                                      m.UserId == PostCommentTestUtilities.ValidPostCommentCurrentUserId &&
                                      m.Content == PostCommentTestUtilities.ValidContent));
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenPostIdIsValid()
    {
        // Arrange
        var command = new UpdatePostCommentCommand(
            PostCommentTestUtilities.ValidId,
            PostCommentTestUtilities.ValidPostCommentCurrentUserId,
            PostCommentTestUtilities.ValidContent
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
