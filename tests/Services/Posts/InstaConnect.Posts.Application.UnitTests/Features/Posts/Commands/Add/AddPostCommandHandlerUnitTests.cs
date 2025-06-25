using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Posts.Application.UnitTests.Features.Posts.Commands.Add;

public class AddPostCommandHandlerUnitTests : BasePostUnitTest
{
    private readonly User _user;
    private readonly Post _post;
    private readonly AddPostCommandBuilder _commandBuilder;
    private readonly AddPostCommandHandler _commandHandler;

    public AddPostCommandHandlerUnitTests()
    {
        _user = SetupUser();
        var postBuilder = new PostBuilder(_user);
        _post = postBuilder.Create();
        _commandBuilder = new(_post);
        _commandHandler = new(
            UnitOfWork,
            PostFactory,
            ApplicationMapper,
            PostWriteRepository,
            UserWriteRepository);

        PostFactory.SetupGet(_user, _post);
    }

    [Fact]
    public async Task Handle_ShouldThrowUserNotFoundException_WhenUserIdIsInvalid()
    {
        // Arrange
        var command = _commandBuilder.WithInvalidUserId().Create();

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.ShouldThrowUserNotFoundExceptionAsync();
    }

    [Fact]
    public async Task Handle_ShouldReturnResponse_WhenCommandIsValid()
    {
        // Arrange
        var command = _commandBuilder.Create();

        // Act
        var response = await _commandHandler.Handle(command, CancellationToken);

        // Assert
        response.ShouldSatisfy(_post);
    }

    [Fact]
    public async Task Handle_ShouldCallThePostFactory_WhenCommandIsValid()
    {
        // Arrange
        var command = _commandBuilder.Create();

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        PostFactory.ShouldReceiveOneGet(command);
    }

    [Fact]
    public async Task Handle_ShouldAddPostToRepository_WhenCommandIsValid()
    {
        // Arrange
        var command = _commandBuilder.Create();

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        PostWriteRepository.ShouldReceiveOneAdd(_post, command);
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
