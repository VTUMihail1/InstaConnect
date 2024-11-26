using FluentAssertions;
using InstaConnect.Identity.Application.Features.Users.Commands.DeleteCurrentUser;
using InstaConnect.Identity.Application.UnitTests.Features.Users.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Domain.Features.Users.Models.Entitites;
using InstaConnect.Shared.Application.Contracts.Users;
using InstaConnect.Shared.Common.Exceptions.User;
using NSubstitute;

namespace InstaConnect.Identity.Application.UnitTests.Features.Users.Commands.DeleteCurrentUser;

public class DeleteCurrentUserCommandHandlerUnitTests : BaseUserUnitTest
{
    private readonly DeleteCurrentUserCommandHandler _commandHandler;

    public DeleteCurrentUserCommandHandlerUnitTests()
    {
        _commandHandler = new(
            UnitOfWork,
            EventPublisher,
            InstaConnectMapper,
            UserWriteRepository);
    }

    [Fact]
    public async Task Handle_ShouldThrowUserNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var command = new DeleteCurrentUserCommand(
            UserTestUtilities.InvalidId
        );

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldDeleteTheUserFromTheRepository_WhenRequestIsValid()
    {
        // Arrange
        var command = new DeleteCurrentUserCommand(
            UserTestUtilities.ValidId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        UserWriteRepository
            .Received(1)
            .Delete(Arg.Is<User>(u => u.Id == UserTestUtilities.ValidId &&
                                      u.FirstName == UserTestUtilities.ValidFirstName &&
                                      u.LastName == UserTestUtilities.ValidLastName &&
                                      u.UserName == UserTestUtilities.ValidName &&
                                      u.Email == UserTestUtilities.ValidEmail &&
                                      u.ProfileImage == UserTestUtilities.ValidProfileImage));
    }

    [Fact]
    public async Task Handle_ShouldPublishUserDeletedEvent_WhenRequestIsValid()
    {
        // Arrange
        var command = new DeleteCurrentUserCommand(
            UserTestUtilities.ValidId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await EventPublisher
            .Received(1)
            .PublishAsync(Arg.Is<UserDeletedEvent>(u => u.Id == UserTestUtilities.ValidId), CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldCallUnitOfWorkCommit_WhenRequestIsValid()
    {
        // Arrange
        var command = new DeleteCurrentUserCommand(
            UserTestUtilities.ValidId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
