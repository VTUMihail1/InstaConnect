using FluentAssertions;
using InstaConnect.Posts.Application.Features.PostLikes.Commands.AddPostLike;
using InstaConnect.Posts.Application.Features.PostLikes.Models;
using InstaConnect.Posts.Application.UnitTests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Common.Features.PostLikes.Utilities;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Entitites;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Exceptions.Posts;
using InstaConnect.Shared.Common.Exceptions.User;
using NSubstitute;

namespace InstaConnect.Posts.Application.UnitTests.Features.PostLikes.Commands.AddPostLike;

public class AddPostLikeCommandHandlerUnitTests : BasePostLikeUnitTest
{
    private readonly AddPostLikeCommandHandler _commandHandler;

    public AddPostLikeCommandHandlerUnitTests()
    {
        _commandHandler = new(
            UnitOfWork,
            InstaConnectMapper,
            UserWriteRepository,
            PostWriteRepository,
            PostLikeWriteRepository);
    }

    [Fact]
    public async Task Handle_ShouldThrowUserNotFoundException_WhenCurrentUserIdIsInvalid()
    {
        // Arrange
        var command = new AddPostLikeCommand(
            PostLikeTestUtilities.InvalidUserId,
            PostLikeTestUtilities.ValidPostId);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowPostNotFoundException_WhenPostIdIsInvalid()
    {
        // Arrange
        var command = new AddPostLikeCommand(
            PostLikeTestUtilities.ValidCurrentUserId,
            PostLikeTestUtilities.InvalidPostId);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<PostNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowBadRequestException_WhenPostLikeAlreadyExists()
    {
        // Arrange
        var command = new AddPostLikeCommand(
            PostLikeTestUtilities.ValidPostLikeCurrentUserId,
            PostLikeTestUtilities.ValidPostLikePostId);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task Handle_ShouldReturnPostLikeCommandViewModel_WhenPostLikeIsValid()
    {
        // Arrange
        var command = new AddPostLikeCommand(
            PostLikeTestUtilities.ValidCurrentUserId,
            PostLikeTestUtilities.ValidPostId);

        // Act
        var response = await _commandHandler.Handle(command, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostLikeCommandViewModel>(m => !string.IsNullOrEmpty(m.Id));
    }

    [Fact]
    public async Task Handle_ShouldAddPostToRepository_WhenPostIsValid()
    {
        // Arrange
        var command = new AddPostLikeCommand(
            PostLikeTestUtilities.ValidCurrentUserId,
            PostLikeTestUtilities.ValidPostId);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        PostLikeWriteRepository
            .Received(1)
            .Add(Arg.Is<PostLike>(m =>
                !string.IsNullOrEmpty(m.Id) &&
                m.UserId == PostLikeTestUtilities.ValidCurrentUserId &&
                m.PostId == PostLikeTestUtilities.ValidPostId));
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenPostIsValid()
    {
        // Arrange
        var command = new AddPostLikeCommand(
            PostLikeTestUtilities.ValidCurrentUserId,
            PostLikeTestUtilities.ValidPostId);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
