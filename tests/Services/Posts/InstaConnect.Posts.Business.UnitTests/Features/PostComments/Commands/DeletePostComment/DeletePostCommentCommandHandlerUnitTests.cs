using FluentAssertions;
using InstaConnect.Posts.Business.Features.PostComments.Commands.DeletePostComment;
using InstaConnect.Posts.Business.UnitTests.Features.PostComments.Utilities;
using InstaConnect.Posts.Common.Features.PostComments.Utilities;
using InstaConnect.Posts.Data.Features.PostComments.Models.Entitites;
using InstaConnect.Shared.Common.Exceptions.PostComment;
using InstaConnect.Shared.Common.Exceptions.User;
using NSubstitute;

namespace InstaConnect.Posts.Business.UnitTests.Features.PostComments.Commands.DeletePostComment;

public class DeletePostCommentCommandHandlerUnitTests : BasePostCommentUnitTest
{
    private readonly DeletePostCommentCommandHandler _commandHandler;

    public DeletePostCommentCommandHandlerUnitTests()
    {
        _commandHandler = new(
            UnitOfWork,
            PostCommentWriteRepository);
    }

    [Fact]
    public async Task Handle_ShouldThrowPostCommentNotFoundException_WhenPostIdIsInvalid()
    {
        // Arrange
        var command = new DeletePostCommentCommand(
            PostCommentTestUtilities.InvalidId,
            PostCommentTestUtilities.ValidPostCommentCurrentUserId
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
        var command = new DeletePostCommentCommand(
            PostCommentTestUtilities.ValidId,
            PostCommentTestUtilities.ValidCurrentUserId
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
        var command = new DeletePostCommentCommand(
            PostCommentTestUtilities.ValidId,
            PostCommentTestUtilities.ValidPostCommentCurrentUserId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await PostCommentWriteRepository
            .Received(1)
            .GetByIdAsync(PostCommentTestUtilities.ValidId, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldDeletePostCommentFromRepository_WhenPostCommentIdIsValid()
    {
        // Arrange
        var command = new DeletePostCommentCommand(
            PostCommentTestUtilities.ValidId,
            PostCommentTestUtilities.ValidPostCommentCurrentUserId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        PostCommentWriteRepository
            .Received(1)
            .Delete(Arg.Is<PostComment>(m => m.Id == PostCommentTestUtilities.ValidId &&
                                             m.UserId == PostCommentTestUtilities.ValidPostCommentCurrentUserId &&
                                             m.PostId == PostCommentTestUtilities.ValidPostCommentPostId &&
                                             m.Content == PostCommentTestUtilities.ValidContent));
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenPostCommentIdIsValid()
    {
        // Arrange
        var command = new DeletePostCommentCommand(
            PostCommentTestUtilities.ValidId,
            PostCommentTestUtilities.ValidPostCommentCurrentUserId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
