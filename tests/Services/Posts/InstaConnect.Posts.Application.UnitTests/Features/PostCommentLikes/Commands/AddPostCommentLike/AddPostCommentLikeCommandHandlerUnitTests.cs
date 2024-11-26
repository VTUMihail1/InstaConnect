using FluentAssertions;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.AddPostCommentLike;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Models;
using InstaConnect.Posts.Application.UnitTests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Common.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Entitites;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Exceptions.PostComment;
using InstaConnect.Shared.Common.Exceptions.User;
using NSubstitute;

namespace InstaConnect.Posts.Application.UnitTests.Features.PostCommentLikes.Commands.AddPostCommentLike;

public class AddPostCommentLikeCommandHandlerUnitTests : BasePostCommentLikeUnitTest
{
    private readonly AddPostCommentLikeCommandHandler _commandHandler;

    public AddPostCommentLikeCommandHandlerUnitTests()
    {
        _commandHandler = new(
            UnitOfWork,
            InstaConnectMapper,
            UserWriteRepository,
            PostCommentWriteRepository,
            PostCommentLikeWriteRepository);
    }

    [Fact]
    public async Task Handle_ShouldThrowUserNotFoundException_WhenCurrentUserIdIsInvalid()
    {
        // Arrange
        var command = new AddPostCommentLikeCommand(
            PostCommentLikeTestUtilities.InvalidUserId,
            PostCommentLikeTestUtilities.ValidPostCommentId);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowPostCommentNotFoundException_WhenPostCommentIdIsInvalid()
    {
        // Arrange
        var command = new AddPostCommentLikeCommand(
            PostCommentLikeTestUtilities.ValidCurrentUserId,
            PostCommentLikeTestUtilities.InvalidPostCommentId);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<PostCommentNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowBadRequestException_WhenPostCommentLikeAlreadyExists()
    {
        // Arrange
        var command = new AddPostCommentLikeCommand(
            PostCommentLikeTestUtilities.ValidPostCommentLikeCurrentUserId,
            PostCommentLikeTestUtilities.ValidPostCommentLikePostCommentId);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task Handle_ShouldReturnPostCommentLikeCommandViewModel_WhenPostCommentLikeIsValid()
    {
        // Arrange
        var command = new AddPostCommentLikeCommand(
            PostCommentLikeTestUtilities.ValidCurrentUserId,
            PostCommentLikeTestUtilities.ValidPostCommentId);

        // Act
        var response = await _commandHandler.Handle(command, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentLikeCommandViewModel>(m => !string.IsNullOrEmpty(m.Id));
    }

    [Fact]
    public async Task Handle_ShouldAddPostCommentLikeToRepository_WhenPostCommentLikeIsValid()
    {
        // Arrange
        var command = new AddPostCommentLikeCommand(
            PostCommentLikeTestUtilities.ValidCurrentUserId,
            PostCommentLikeTestUtilities.ValidPostCommentId);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        PostCommentLikeWriteRepository
            .Received(1)
            .Add(Arg.Is<PostCommentLike>(m =>
                !string.IsNullOrEmpty(m.Id) &&
                m.UserId == PostCommentLikeTestUtilities.ValidCurrentUserId &&
                m.PostCommentId == PostCommentLikeTestUtilities.ValidPostCommentId));
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenPostCommentLikeIsValid()
    {
        // Arrange
        var command = new AddPostCommentLikeCommand(
            PostCommentLikeTestUtilities.ValidCurrentUserId,
            PostCommentLikeTestUtilities.ValidPostCommentId);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
