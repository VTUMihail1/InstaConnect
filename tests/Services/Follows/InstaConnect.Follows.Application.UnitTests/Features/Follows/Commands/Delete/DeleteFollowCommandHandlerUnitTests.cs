using FluentAssertions;

using InstaConnect.Follows.Application.Features.Follows.Commands.Delete;
using InstaConnect.Follows.Application.UnitTests.Features.Follows.Utilities;
using InstaConnect.Follows.Common.Features.Follows.Utilities;
using InstaConnect.Follows.Domain.Features.Follows.Exceptions;
using InstaConnect.Follows.Domain.Features.Follows.Models.Entities;
using InstaConnect.Shared.Common.Exceptions.Users;

using NSubstitute;

namespace InstaConnect.Follows.Application.UnitTests.Features.Follows.Commands.Delete;

public class DeleteFollowCommandHandlerUnitTests : BaseFollowUnitTest
{
    private readonly DeleteFollowCommandHandler _commandHandler;

    public DeleteFollowCommandHandlerUnitTests()
    {
        _commandHandler = new(
            UnitOfWork,
            FollowWriteRepository);
    }

    [Fact]
    public async Task Handle_ShouldThrowFollowNotFoundException_WhenFollowIdIsInvalid()
    {
        // Arrange
        var existingFollowId = CreateFollow();
        var command = new DeleteFollowCommand(
            FollowTestUtilities.InvalidId,
            existingFollowId.FollowerId
        );

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<FollowNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowAccountForbiddenException_WhenCurrentUserIdIsInvalid()
    {
        // Arrange
        var existingUser = CreateUser();
        var existingFollow = CreateFollow();
        var command = new DeleteFollowCommand(
            existingFollow.Id,
            existingUser.Id
        );

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserForbiddenException>();
    }

    [Fact]
    public async Task Handle_ShouldGetFollowByIdFromRepository_WhenFollowIdIsValid()
    {
        // Arrange
        var existingFollow = CreateFollow();
        var command = new DeleteFollowCommand(
            existingFollow.Id,
            existingFollow.FollowerId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await FollowWriteRepository
            .Received(1)
            .GetByIdAsync(existingFollow.Id, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldDeleteFollowFromRepository_WhenFollowIdIsValid()
    {
        // Arrange
        var existingFollow = CreateFollow();
        var command = new DeleteFollowCommand(
            existingFollow.Id,
            existingFollow.FollowerId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        FollowWriteRepository
            .Received(1)
            .Delete(Arg.Is<Follow>(m => m.Id == existingFollow.Id &&
                                         m.FollowerId == existingFollow.FollowerId &&
                                         m.FollowingId == existingFollow.FollowingId));
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenFollowIdIsValid()
    {
        // Arrange
        var existingFollow = CreateFollow();
        var command = new DeleteFollowCommand(
            existingFollow.Id,
            existingFollow.FollowerId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
