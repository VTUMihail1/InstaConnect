using FluentAssertions;
using InstaConnect.Follows.Application.Features.Follows.Commands.AddFollow;
using InstaConnect.Follows.Application.Features.Follows.Models;
using InstaConnect.Follows.Application.UnitTests.Features.Follows.Utilities;
using InstaConnect.Follows.Common.Features.Follows.Utilities;
using InstaConnect.Follows.Domain.Features.Follows.Models.Entities;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Exceptions.User;
using NSubstitute;

namespace InstaConnect.Follows.Application.UnitTests.Features.Follows.Commands.AddFollow;

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
        var existingFollowerId = CreateUser();
        var existingFollowingId = CreateUser();
        var command = new AddFollowCommand(
            FollowTestUtilities.InvalidUserId,
            existingFollowingId);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowUserNotFoundException_WhenFollowingIdIsInvalid()
    {
        // Arrange
        var existingFollowerId = CreateUser();
        var existingFollowingId = CreateUser();
        var command = new AddFollowCommand(
            existingFollowerId,
            FollowTestUtilities.InvalidUserId);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowBadRequestException_WhenFollowAlreadyExists()
    {
        // Arrange
        var existingFollowerId = CreateUser();
        var existingFollowingId = CreateUser();
        var existingFollowId = CreateFollow(existingFollowerId, existingFollowingId);
        var command = new AddFollowCommand(
            existingFollowerId,
            existingFollowingId);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task Handle_ShouldReturnFollowCommandViewModel_WhenFollowIsValid()
    {
        // Arrange
        var existingFollowerId = CreateUser();
        var existingFollowingId = CreateUser();
        var command = new AddFollowCommand(
            existingFollowerId,
            existingFollowingId);

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
        var existingFollowerId = CreateUser();
        var existingFollowingId = CreateUser();
        var command = new AddFollowCommand(
            existingFollowerId,
            existingFollowingId);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        FollowWriteRepository
            .Received(1)
            .Add(Arg.Is<Follow>(m =>
                !string.IsNullOrEmpty(m.Id) &&
                m.FollowerId == existingFollowerId &&
                m.FollowingId == existingFollowingId));
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenFollowIsValid()
    {
        // Arrange
        var existingFollowerId = CreateUser();
        var existingFollowingId = CreateUser();
        var command = new AddFollowCommand(
            existingFollowerId,
            existingFollowingId);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
