using FluentAssertions;
using InstaConnect.Posts.Business.Features.PostLikes.Commands.DeletePostLike;
using InstaConnect.Posts.Business.UnitTests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Common.Features.PostLikes.Utilities;
using InstaConnect.Posts.Data.Features.PostLikes.Models.Entitites;
using InstaConnect.Shared.Common.Exceptions.PostLike;
using InstaConnect.Shared.Common.Exceptions.User;
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
            PostLikeTestUtilities.InvalidId,
            PostLikeTestUtilities.ValidPostLikeCurrentUserId
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
            PostLikeTestUtilities.ValidId,
            PostLikeTestUtilities.ValidCurrentUserId
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
            PostLikeTestUtilities.ValidId,
            PostLikeTestUtilities.ValidPostLikeCurrentUserId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await PostLikeWriteRepository
            .Received(1)
            .GetByIdAsync(PostLikeTestUtilities.ValidId, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldDeletePostLikeFromRepository_WhenPostLikeIdIsValid()
    {
        // Arrange
        var command = new DeletePostLikeCommand(
            PostLikeTestUtilities.ValidId,
            PostLikeTestUtilities.ValidPostLikeCurrentUserId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        PostLikeWriteRepository
            .Received(1)
            .Delete(Arg.Is<PostLike>(m => m.Id == PostLikeTestUtilities.ValidId &&
                                          m.UserId == PostLikeTestUtilities.ValidPostLikeCurrentUserId &&
                                          m.PostId == PostLikeTestUtilities.ValidPostLikePostId));
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenPostLikeIdIsValid()
    {
        // Arrange
        var command = new DeletePostLikeCommand(
            PostLikeTestUtilities.ValidId,
            PostLikeTestUtilities.ValidPostLikeCurrentUserId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
