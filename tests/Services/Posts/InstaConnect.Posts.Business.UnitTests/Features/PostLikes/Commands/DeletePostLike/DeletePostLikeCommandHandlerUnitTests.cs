using FluentAssertions;
using InstaConnect.Posts.Business.Features.PostLikes.Commands.DeletePostLike;
using InstaConnect.Posts.Business.UnitTests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Data.Features.PostLikes.Models.Entitites;
using InstaConnect.Shared.Business.Exceptions.PostLike;
using InstaConnect.Shared.Business.Exceptions.User;
using NSubstitute;

namespace InstaConnect.Posts.Business.UnitTests.Features.PostLikes.Commands.DeletePostLike;

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
        var command = new DeletePostLikeCommand(
            InvalidId,
            ValidPostLikeCurrentUserId
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
        var command = new DeletePostLikeCommand(
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
        var command = new DeletePostLikeCommand(
            ValidId,
            ValidPostLikeCurrentUserId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await PostLikeWriteRepository
            .Received(1)
            .GetByIdAsync(ValidId, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldDeletePostLikeFromRepository_WhenPostLikeIdIsValid()
    {
        // Arrange
        var command = new DeletePostLikeCommand(
            ValidId,
            ValidPostLikeCurrentUserId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        PostLikeWriteRepository
            .Received(1)
            .Delete(Arg.Is<PostLike>(m => m.Id == ValidId &&
                                          m.UserId == ValidPostLikeCurrentUserId &&
                                          m.PostId == ValidPostLikePostId));
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenPostLikeIdIsValid()
    {
        // Arrange
        var command = new DeletePostLikeCommand(
            ValidId,
            ValidPostLikeCurrentUserId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
