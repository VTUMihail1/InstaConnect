﻿using FluentAssertions;
using InstaConnect.Follows.Business.Features.Follows.Commands.AddFollow;
using InstaConnect.Follows.Business.Features.Follows.Models;
using InstaConnect.Follows.Business.UnitTests.Features.Follows.Utilities;
using InstaConnect.Follows.Common.Features.Follows.Utilities;
using InstaConnect.Follows.Data.Features.Follows.Models.Entities;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Exceptions.User;
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
            FollowTestUtilities.InvalidUserId,
            FollowTestUtilities.ValidCurrentUserId);

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
            FollowTestUtilities.ValidCurrentUserId,
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
        var command = new AddFollowCommand(
            FollowTestUtilities.ValidFollowCurrentUserId,
            FollowTestUtilities.ValidFollowFollowingId);

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
            FollowTestUtilities.ValidCurrentUserId,
            FollowTestUtilities.ValidFollowingId);

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
        var command = new AddFollowCommand(
            FollowTestUtilities.ValidCurrentUserId,
            FollowTestUtilities.ValidFollowingId);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        FollowWriteRepository
            .Received(1)
            .Add(Arg.Is<Follow>(m =>
                !string.IsNullOrEmpty(m.Id) &&
                m.FollowerId == FollowTestUtilities.ValidCurrentUserId &&
                m.FollowingId == FollowTestUtilities.ValidFollowingId));
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenFollowIsValid()
    {
        // Arrange
        var command = new AddFollowCommand(
            FollowTestUtilities.ValidCurrentUserId,
            FollowTestUtilities.ValidFollowingId);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
