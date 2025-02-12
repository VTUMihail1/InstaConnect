using FluentAssertions;
using InstaConnect.Identity.Application.Features.Users.Commands.DeleteUserById;
using InstaConnect.Identity.Application.UnitTests.Features.Users.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Domain.Features.Users.Models.Entitites;
using InstaConnect.Shared.Application.Contracts.Users;
using InstaConnect.Shared.Common.Exceptions.User;
using NSubstitute;

namespace InstaConnect.Identity.Application.UnitTests.Features.Users.Commands.DeleteUserById;

public class DeleteUserCommandHandlerUnitTests : BaseUserUnitTest
{
    private readonly DeleteUserCommandHandler _commandHandler;

    public DeleteUserCommandHandlerUnitTests()
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
        var existingUser = CreateUser();
        var command = new DeleteUserCommand(
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
        var existingUser = CreateUser();
        var command = new DeleteUserCommand(
            existingUser.Id
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        UserWriteRepository
            .Received(1)
            .Delete(Arg.Is<User>(u => u.Id == existingUser.Id &&
                                      u.FirstName == existingUser.FirstName &&
                                      u.LastName == existingUser.LastName &&
                                      u.UserName == existingUser.UserName &&
                                      u.Email == existingUser.Email &&
                                      u.ProfileImage == existingUser.ProfileImage &&
                                      u.PasswordHash == UserTestUtilities.ValidPasswordHash));
    }

    [Fact]
    public async Task Handle_ShouldPublishUserDeletedEvent_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var command = new DeleteUserCommand(
            existingUser.Id
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await EventPublisher
            .Received(1)
            .PublishAsync(Arg.Is<UserDeletedEvent>(u => u.Id == existingUser.Id), CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldCallUnitOfWorkCommit_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var command = new DeleteUserCommand(
            existingUser.Id
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
