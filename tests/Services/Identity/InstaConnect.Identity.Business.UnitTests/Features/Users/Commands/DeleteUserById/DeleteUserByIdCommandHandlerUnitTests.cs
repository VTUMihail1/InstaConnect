using FluentAssertions;
using InstaConnect.Identity.Business.Features.Users.Commands.DeleteUserById;
using InstaConnect.Identity.Business.UnitTests.Features.Users.Utilities;
using InstaConnect.Identity.Data.Features.Users.Models.Entitites;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Business.Exceptions.User;
using NSubstitute;

namespace InstaConnect.Identity.Business.UnitTests.Features.Users.Commands.DeleteUserById;

public class DeleteUserByIdCommandHandlerUnitTests : BaseUserUnitTest
{
    private readonly DeleteUserByIdCommandHandler _commandHandler;

    public DeleteUserByIdCommandHandlerUnitTests()
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
        var command = new DeleteUserByIdCommand(
            InvalidId
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
        var command = new DeleteUserByIdCommand(
            ValidId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        UserWriteRepository
            .Received(1)
            .Delete(Arg.Is<User>(u => u.Id == ValidId &&
                                      u.FirstName == ValidFirstName &&
                                      u.LastName == ValidLastName &&
                                      u.UserName == ValidName &&
                                      u.Email == ValidEmail &&
                                      u.ProfileImage == ValidProfileImage));
    }

    [Fact]
    public async Task Handle_ShouldPublishUserDeletedEvent_WhenRequestIsValid()
    {
        // Arrange
        var command = new DeleteUserByIdCommand(
            ValidId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await EventPublisher
            .Received(1)
            .PublishAsync(Arg.Is<UserDeletedEvent>(u => u.Id == ValidId), CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldCallUnitOfWorkCommit_WhenRequestIsValid()
    {
        // Arrange
        var command = new DeleteUserByIdCommand(
            ValidId
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
