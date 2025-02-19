using InstaConnect.Follows.Application.Features.Follows.Commands.Add;

namespace InstaConnect.Follows.Application.UnitTests.Features.Follows.Commands.Add;

public class AddFollowCommandHandlerUnitTests : BaseFollowUnitTest
{
    private readonly AddFollowCommandHandler _commandHandler;

    public AddFollowCommandHandlerUnitTests()
    {
        _commandHandler = new(
            UnitOfWork,
            FollowFactory,
            InstaConnectMapper,
            UserWriteRepository,
            FollowWriteRepository);
    }

    [Fact]
    public async Task Handle_ShouldThrowUserNotFoundException_WhenCurrentUserIdIsInvalid()
    {
        // Arrange
        var existingFollowing = CreateUser();
        var command = new AddFollowCommand(
            UserTestUtilities.InvalidId,
            existingFollowing.Id);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowUserNotFoundException_WhenFollowingIdIsInvalid()
    {
        // Arrange
        var existingFollower = CreateUser();
        var command = new AddFollowCommand(
            existingFollower.Id,
            UserTestUtilities.InvalidId);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowFollowAlreadyExistsException_WhenFollowAlreadyExists()
    {
        // Arrange
        var existingFollow = CreateFollow();
        var command = new AddFollowCommand(
            existingFollow.FollowerId,
            existingFollow.FollowingId);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<FollowAlreadyExistsException>();
    }

    [Fact]
    public async Task Handle_ShouldReturnFollowCommandViewModel_WhenFollowIsValid()
    {
        // Arrange
        var existingFollow = CreateFollowFactory();
        var command = new AddFollowCommand(
            existingFollow.FollowerId,
            existingFollow.FollowingId);

        // Act
        var response = await _commandHandler.Handle(command, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowCommandViewModel>(m => m.Id == existingFollow.Id);
    }

    [Fact]
    public async Task Handle_ShouldGetFollowFromFactory_WhenFollowIsValid()
    {
        // Arrange
        var existingFollow = CreateFollowFactory();
        var command = new AddFollowCommand(
            existingFollow.FollowerId,
            existingFollow.FollowingId);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        FollowFactory
            .Received(1)
            .Get(existingFollow.FollowerId, existingFollow.FollowingId);
    }

    [Fact]
    public async Task Handle_ShouldAddFollowToRepository_WhenFollowIsValid()
    {
        // Arrange
        var existingFollow = CreateFollowFactory();
        var command = new AddFollowCommand(
            existingFollow.FollowerId,
            existingFollow.FollowingId);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        FollowWriteRepository
            .Received(1)
            .Add(Arg.Is<Follow>(m =>
                m.Id == existingFollow.Id &&
                m.FollowerId == existingFollow.FollowerId &&
                m.FollowingId == existingFollow.FollowingId));
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenFollowIsValid()
    {
        // Arrange
        var existingFollow = CreateFollowFactory();
        var command = new AddFollowCommand(
            existingFollow.FollowerId,
            existingFollow.FollowingId);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
