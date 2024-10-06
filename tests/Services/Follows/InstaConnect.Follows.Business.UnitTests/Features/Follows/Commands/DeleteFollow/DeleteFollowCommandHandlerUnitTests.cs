using FluentAssertions;
using InstaConnect.Follows.Business.Features.Follows.Commands.DeleteFollow;
using InstaConnect.Follows.Business.UnitTests.Features.Follows.Utilities;
using InstaConnect.Follows.Common.Features.Follows.Utilities;
using InstaConnect.Follows.Data.Features.Follows.Models.Entities;
using InstaConnect.Shared.Common.Exceptions.Follow;
using InstaConnect.Shared.Common.Exceptions.User;
using NSubstitute;

namespace InstaConnect.Follows.Business.UnitTests.Features.Follows.Commands.DeleteFollow;

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
        var command = new DeleteFollowCommand(
            FollowTestUtilities.InvalidId,
            FollowTestUtilities.ValidFollowCurrentUserId
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
        var command = new DeleteFollowCommand(
            FollowTestUtilities.ValidId,
            FollowTestUtilities.ValidCurrentUserId
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
        var command = new DeleteFollowCommand(
            FollowTestUtilities.ValidId,
            FollowTestUtilities.ValidFollowCurrentUserId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await FollowWriteRepository
            .Received(1)
            .GetByIdAsync(FollowTestUtilities.ValidId, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldDeleteFollowFromRepository_WhenFollowIdIsValid()
    {
        // Arrange
        var command = new DeleteFollowCommand(
            FollowTestUtilities.ValidId,
            FollowTestUtilities.ValidFollowCurrentUserId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        FollowWriteRepository
            .Received(1)
            .Delete(Arg.Is<Follow>(m => m.Id == FollowTestUtilities.ValidId &&
                                         m.FollowerId == FollowTestUtilities.ValidFollowCurrentUserId &&
                                         m.FollowingId == FollowTestUtilities.ValidFollowFollowingId));
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenFollowIdIsValid()
    {
        // Arrange
        var command = new DeleteFollowCommand(
            FollowTestUtilities.ValidId,
            FollowTestUtilities.ValidFollowCurrentUserId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
