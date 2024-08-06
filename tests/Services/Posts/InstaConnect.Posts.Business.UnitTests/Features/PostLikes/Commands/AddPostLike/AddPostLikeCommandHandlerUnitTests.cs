using FluentAssertions;
using InstaConnect.Follows.Business.UnitTests.Features.Follows.Utilities;
using InstaConnect.Posts.Business.Features.PostLikes.Commands.AddPostLike;
using InstaConnect.Posts.Business.Features.PostLikes.Models;
using InstaConnect.Posts.Data.Features.PostLikes.Models.Entitites;
using InstaConnect.Shared.Business.Exceptions.Base;
using InstaConnect.Shared.Business.Exceptions.Posts;
using InstaConnect.Shared.Business.Exceptions.User;
using NSubstitute;

namespace InstaConnect.Follows.Business.UnitTests.Features.Follows.Commands.AddFollow;

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
            InvalidUserId,
            ValidPostId);

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
            ValidCurrentUserId,
            InvalidPostId);

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
            ValidPostLikeCurrentUserId,
            ValidPostLikePostId);

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
            ValidCurrentUserId,
            ValidPostId);

        // Act
        var response = await _commandHandler.Handle(command, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostLikeCommandViewModel>(m => m.Id == ValidId);
    }

    [Fact]
    public async Task Handle_ShouldAddPostToRepository_WhenPostIsValid()
    {
        // Arrange
        var command = new AddPostLikeCommand(
            ValidCurrentUserId,
            ValidPostId);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        PostLikeWriteRepository
            .Received(1)
            .Add(Arg.Is<PostLike>(m =>
                m.UserId == ValidCurrentUserId &&
                m.PostId == ValidPostId));
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenPostIsValid()
    {
        // Arrange
        var command = new AddPostLikeCommand(
            ValidCurrentUserId,
            ValidPostId);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
