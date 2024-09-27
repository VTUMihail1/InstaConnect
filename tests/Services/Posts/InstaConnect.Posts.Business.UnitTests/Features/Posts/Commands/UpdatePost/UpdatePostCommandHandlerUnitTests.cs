using FluentAssertions;
using InstaConnect.Posts.Business.Features.Posts.Commands.UpdatePost;
using InstaConnect.Posts.Business.UnitTests.Features.Posts.Utilities;
using InstaConnect.Posts.Data.Features.Posts.Models.Entitites;
using InstaConnect.Shared.Business.Exceptions.Posts;
using InstaConnect.Shared.Business.Exceptions.User;
using NSubstitute;

namespace InstaConnect.Posts.Business.UnitTests.Features.Posts.Commands.UpdatePost;

public class UpdatePostCommandHandlerUnitTests : BasePostUnitTest
{
    private readonly UpdatePostCommandHandler _commandHandler;

    public UpdatePostCommandHandlerUnitTests()
    {
        _commandHandler = new(
            UnitOfWork,
            InstaConnectMapper,
            PostWriteRepository);
    }

    [Fact]
    public async Task Handle_ShouldThrowPostNotFoundException_WhenPostIdIsInvalid()
    {
        // Arrange
        var command = new UpdatePostCommand(
            InvalidId,
            ValidPostCurrentUserId,
            ValidTitle,
            ValidContent
        );

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<PostNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowAccountForbiddenException_WhenCurrentUserIdIsInvalid()
    {
        // Arrange
        var command = new UpdatePostCommand(
            ValidId,
            ValidCurrentUserId,
            ValidTitle,
            ValidContent
        );

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserForbiddenException>();
    }

    [Fact]
    public async Task Handle_ShouldGetPostByIdFromRepository_WhenPostIdIsValid()
    {
        // Arrange
        var command = new UpdatePostCommand(
            ValidId,
            ValidPostCurrentUserId,
            ValidTitle,
            ValidContent
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await PostWriteRepository
            .Received(1)
            .GetByIdAsync(ValidId, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldDeletePostFromRepository_WhenPostIdIsValid()
    {
        // Arrange
        var command = new UpdatePostCommand(
            ValidId,
            ValidPostCurrentUserId,
            ValidTitle,
            ValidContent
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        PostWriteRepository
            .Received(1)
            .Update(Arg.Is<Post>(m => m.Id == ValidId &&
                                      m.UserId == ValidPostCurrentUserId &&
                                      m.Title == ValidTitle &&
                                      m.Content == ValidContent));
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenPostIdIsValid()
    {
        // Arrange
        var command = new UpdatePostCommand(
            ValidId,
            ValidPostCurrentUserId,
            ValidTitle,
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
