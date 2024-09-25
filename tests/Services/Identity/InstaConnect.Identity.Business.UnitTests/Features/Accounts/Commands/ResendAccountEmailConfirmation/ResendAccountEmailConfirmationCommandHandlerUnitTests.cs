using FluentAssertions;
using InstaConnect.Identity.Business.Features.Accounts.Commands.ResendAccountEmailConfirmation;
using InstaConnect.Identity.Business.Features.Accounts.Models;
using InstaConnect.Identity.Business.UnitTests.Features.Accounts.Utilities;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.User;
using NSubstitute;

namespace InstaConnect.Identity.Business.UnitTests.Features.Accounts.Commands.ResendAccountEmailConfirmation;

public class ResendAccountEmailConfirmationCommandHandlerUnitTests : BaseAccountUnitTest
{
    private readonly ResendAccountEmailConfirmationCommandHandler _commandHandler;

    public ResendAccountEmailConfirmationCommandHandlerUnitTests()
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
        var command = new ResendAccountEmailConfirmationCommand(InvalidEmail);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowAccountEmailAlreadyConfirmedException_WhenEmailIsConfirmed()
    {
        // Arrange
        var command = new ResendAccountEmailConfirmationCommand(ValidEmail);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AccountEmailAlreadyConfirmedException>();
    }

    [Fact]
    public async Task Handle_ShouldCallTheEmailConfirmationTokenPublisher_WhenRequestIsValid()
    {
        // Arrange
        var command = new ResendAccountEmailConfirmationCommand(ValidEmailWithUnconfirmedEmail);

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
        var command = new ResendAccountEmailConfirmationCommand(ValidEmailWithUnconfirmedEmail);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
