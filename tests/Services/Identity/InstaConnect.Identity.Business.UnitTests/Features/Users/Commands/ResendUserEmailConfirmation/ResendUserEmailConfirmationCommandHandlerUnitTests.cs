using FluentAssertions;
using InstaConnect.Identity.Business.Features.Users.Commands.ResendUserEmailConfirmation;
using InstaConnect.Identity.Business.Features.Users.Models;
using InstaConnect.Identity.Business.UnitTests.Features.Users.Utilities;
using InstaConnect.Shared.Business.Exceptions.User;
using NSubstitute;

namespace InstaConnect.Identity.Business.UnitTests.Features.Users.Commands.ResendUserEmailConfirmation;

public class ResendUserEmailConfirmationCommandHandlerUnitTests : BaseUserUnitTest
{
    private readonly ResendUserEmailConfirmationCommandHandler _commandHandler;

    public ResendUserEmailConfirmationCommandHandlerUnitTests()
    {
        _commandHandler = new(
            UnitOfWork,
            InstaConnectMapper,
            UserWriteRepository,
            EmailConfirmationTokenPublisher);
    }

    [Fact]
    public async Task Handle_ShouldThrowUserNotFoundException_WhenEmailIsInvalid()
    {
        // Arrange
        var command = new ResendUserEmailConfirmationCommand(InvalidEmail);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowUserEmailAlreadyConfirmedException_WhenEmailIsConfirmed()
    {
        // Arrange
        var command = new ResendUserEmailConfirmationCommand(ValidEmail);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserEmailAlreadyConfirmedException>();
    }

    [Fact]
    public async Task Handle_ShouldCallTheEmailConfirmationTokenPublisher_WhenRequestIsValid()
    {
        // Arrange
        var command = new ResendUserEmailConfirmationCommand(ValidEmailWithUnconfirmedEmail);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await EmailConfirmationTokenPublisher
            .Received(1)
            .PublishEmailConfirmationTokenAsync(Arg.Is<CreateEmailConfirmationTokenModel>(uc => uc.UserId == ValidIdWithUnconfirmedEmail &&
                                                                                          uc.Email == ValidEmailWithUnconfirmedEmail), CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldCallTheUnitOfWorkSaveChanges_WhenRequestIsValid()
    {
        // Arrange
        var command = new ResendUserEmailConfirmationCommand(ValidEmailWithUnconfirmedEmail);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
