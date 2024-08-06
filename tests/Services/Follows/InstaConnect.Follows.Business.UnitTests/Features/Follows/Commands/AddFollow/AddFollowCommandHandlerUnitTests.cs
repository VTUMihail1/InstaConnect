using FluentAssertions;
using InstaConnect.Follows.Business.Features.Follows.Commands.AddFollow;
using InstaConnect.Follows.Business.Features.Follows.Models;
using InstaConnect.Follows.Business.UnitTests.Features.Follows.Utilities;
using InstaConnect.Follows.Data.Features.Follows.Models.Entities;
using InstaConnect.Shared.Business.Exceptions.Base;
using InstaConnect.Shared.Business.Exceptions.User;
using NSubstitute;

namespace InstaConnect.Follows.Business.UnitTests.Features.Follows.Commands.AddFollow;

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
        var command = new AddFollowCommand(
            InvalidUserId,
            ValidCurrentUserId);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowUserNotFoundException_WhenFollowingIdIsInvalid()
    {
        // Arrange
        var command = new AddFollowCommand(
            ValidCurrentUserId,
            InvalidUserId);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowBadRequestException_WhenFollowAlreadyExists()
    {
        // Arrange
        var command = new AddFollowCommand(
            ValidFollowCurrentUserId,
            ValidFollowFollowingId);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task Handle_ShouldReturnFollowCommandViewModel_WhenFollowIsValid()
    {
        // Arrange
        var command = new AddFollowCommand(
            ValidCurrentUserId,
            ValidFollowingId);

        // Act
        var response = await _commandHandler.Handle(command, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowCommandViewModel>(m => m.Id == ValidId);
    }

    [Fact]
    public async Task Handle_ShouldAddFollowToRepository_WhenFollowIsValid()
    {
        // Arrange
        var command = new AddFollowCommand(
            ValidCurrentUserId,
            ValidFollowingId);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        FollowWriteRepository
            .Received(1)
            .Add(Arg.Is<Follow>(m =>
                m.FollowerId == ValidCurrentUserId &&
                m.FollowingId == ValidFollowingId));
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenFollowIsValid()
    {
        // Arrange
        var command = new AddFollowCommand(
            ValidCurrentUserId,
            ValidFollowingId);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
