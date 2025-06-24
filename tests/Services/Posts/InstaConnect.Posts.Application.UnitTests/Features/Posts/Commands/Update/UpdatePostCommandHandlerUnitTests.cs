using InstaConnect.Posts.Application.Features.Posts.Commands.Update;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.Assertions;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Posts.Application.UnitTests.Features.Posts.Commands.Update;

public class UpdatePostCommandHandlerUnitTests : BasePostUnitTest
{
    private readonly User _user;
    private readonly Post _post;
    private readonly UpdatePostCommandBuilder _commandBuilder;
    private readonly UpdatePostCommandHandler _commandHandler;

    public UpdatePostCommandHandlerUnitTests()
    {
        _user = SetupUser();
        _post = SetupPost(_user);
        var updatePost = new PostBuilder(_post)
            .WithTitle(PostDataFaker.GetTitle())
            .WithContent(PostDataFaker.GetContent())
            .Create();
        _commandBuilder = new(updatePost);
        _commandHandler = new(
            UnitOfWork,
            PostService,
            InstaConnectMapper,
            PostWriteRepository);

        PostService.SetupUpdate(_post, updatePost);
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
    public async Task Handle_ShouldUpdateToPostService_WhenCommandIsValid()
    {
        // Arrange
        var command = _commandBuilder.Create();

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        PostService.ShouldReceiveOneUpdate(_post, command);
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
        PostWriteRepository.ShouldReceiveOneUpdate(_post, command);
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
