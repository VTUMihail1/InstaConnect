using InstaConnect.Posts.Application.Features.Posts.Commands.Delete;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Posts.Application.UnitTests.Features.Posts.Commands.Delete;

public class DeletePostCommandHandlerUnitTests : BasePostUnitTest
{
    private readonly User _user;
    private readonly Post _post;
    private readonly DeletePostCommandBuilder _commandBuilder;
    private readonly DeletePostCommandHandler _commandHandler;

    public DeletePostCommandHandlerUnitTests()
    {
        _user = SetupUser();
        _post = SetupPost(_user);
        _commandBuilder = new(_post);
        _commandHandler = new(
            UnitOfWork,
            PostWriteRepository);
    }

    [Fact]
    public async Task Handle_ShouldThrowPostNotFoundException_WhenPostIdIsInvalid()
    {
        // Arrange
        var command = _commandBuilder.WithInvalidId().Create();

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.ShouldThrowPostNotFoundExceptionAsync();
    }

    [Fact]
    public async Task Handle_ShouldThrowAccountForbiddenException_WhenUserIdIsInvalid()
    {
        // Arrange
        var user = SetupUser();
        var command = _commandBuilder.WithUserId(user.Id).Create();

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.ShouldThrowUserForbiddenExceptionAsync();
    }

    [Fact]
    public async Task Handle_ShouldGetPostFromRepository_WhenCommandIsValid()
    {
        // Arrange
        var command = _commandBuilder.Create();

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await PostWriteRepository.ShouldReceiveOneGetByIdAsync(_post, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldDeletePostFromRepository_WhenCommandIsValid()
    {
        // Arrange
        var command = _commandBuilder.Create();

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        PostWriteRepository.ShouldReceiveOneDelete(_post);
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenCommandIsValid()
    {
        // Arrange
        var command = _commandBuilder.Create();

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork.ShouldReceiveOneSaveChangesAsync(CancellationToken);
    }
}
