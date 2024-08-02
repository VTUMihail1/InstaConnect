using FluentAssertions;
using InstaConnect.Follows.Business.Features.Follows.Commands.DeleteFollow;
using InstaConnect.Follows.Business.UnitTests.Utilities;
using InstaConnect.Follows.Data.Features.Follows.Models.Entities;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.Follow;
using InstaConnect.Shared.Business.Exceptions.Message;
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
            InvalidId,
            ValidFollowCurrentUserId
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
            ValidId,
            ValidCurrentUserId
        );

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AccountForbiddenException>();
    }

    [Fact]
    public async Task Handle_ShouldGetFollowByIdFromRepository_WhenFollowIdIsValid()
    {
        // Arrange
        var command = new DeleteFollowCommand(
            ValidId,
            ValidFollowCurrentUserId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await FollowWriteRepository
            .Received(1)
            .GetByIdAsync(ValidId, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldDeleteMessageFromRepository_WhenMessageIdIsValid()
    {
        // Arrange
        var command = new DeleteFollowCommand(
            ValidId,
            ValidFollowCurrentUserId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        FollowWriteRepository
            .Received(1)
            .Delete(Arg.Is<Follow>(m => m.Id == ValidId &&
                                         m.FollowerId == ValidFollowCurrentUserId &&
                                         m.FollowingId == ValidFollowFollowingId));
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync_WhenMessageIdIsValid()
    {
        // Arrange
        var command = new DeleteFollowCommand(
            ValidId,
            ValidFollowCurrentUserId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
