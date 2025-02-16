using FluentAssertions;

using InstaConnect.Follows.Application.Features.Follows.Commands.Add;
using InstaConnect.Follows.Application.Features.Follows.Models;
using InstaConnect.Follows.Application.UnitTests.Features.Follows.Utilities;
using InstaConnect.Follows.Common.Features.Users.Utilities;
using InstaConnect.Follows.Domain.Features.Follows.Exceptions;
using InstaConnect.Follows.Domain.Features.Follows.Models.Entities;
using InstaConnect.Shared.Common.Exceptions.Users;

using NSubstitute;

namespace InstaConnect.Follows.Application.UnitTests.Features.Follows.Commands.Add;

public class AddFollowCommandHandlerUnitTests : BaseFollowUnitTest
{
    private readonly AddFollowCommandHandler _commandHandler;

    public AddFollowCommandHandlerUnitTests()
    {
        _commandHandler = new(
            UnitOfWork,
            InstaConnectMapper,
            UserWriteRepository,
            FollowWriteRepository);
    }

    [Fact]
    public async Task Handle_ShouldThrowUserNotFoundException_WhenCurrentUserIdIsInvalid()
    {
        // Arrange
        var existingFollower = CreateUser();
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
        var existingFollowing = CreateUser();
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
        var existingFollower = CreateUser();
        var existingFollowing = CreateUser();
        var command = new AddFollowCommand(
            existingFollower.Id,
            existingFollowing.Id);

        // Act
        var response = await _commandHandler.Handle(command, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowCommandViewModel>(m => !string.IsNullOrEmpty(m.Id));
    }

    [Fact]
    public async Task Handle_ShouldAddFollowToRepository_WhenFollowIsValid()
    {
        // Arrange
        var existingFollower = CreateUser();
        var existingFollowing = CreateUser();
        var command = new AddFollowCommand(
            existingFollower.Id,
            existingFollowing.Id);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        FollowWriteRepository
            .Received(1)
            .Add(Arg.Is<Follow>(m =>
                !string.IsNullOrEmpty(m.Id) &&
                m.FollowerId == existingFollower.Id &&
                m.FollowingId == existingFollowing.Id));
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenFollowIsValid()
    {
        // Arrange
        var existingFollower = CreateUser();
        var existingFollowing = CreateUser();
        var command = new AddFollowCommand(
            existingFollower.Id,
            existingFollowing.Id);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
