using FluentAssertions;
using InstaConnect.Identity.Application.Features.Users.Commands.ResendUserEmailConfirmation;
using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Identity.Application.UnitTests.Features.Users.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Shared.Common.Exceptions.User;
using NSubstitute;

namespace InstaConnect.Identity.Application.UnitTests.Features.Users.Commands.ResendUserEmailConfirmation;

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
        var command = new ResendUserEmailConfirmationCommand(UserTestUtilities.InvalidEmail);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowUserEmailAlreadyConfirmedException_WhenEmailIsConfirmed()
    {
        // Arrange
        var command = new ResendUserEmailConfirmationCommand(UserTestUtilities.ValidEmail);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserEmailAlreadyConfirmedException>();
    }

    [Fact]
    public async Task Handle_ShouldCallTheEmailConfirmationTokenPublisher_WhenRequestIsValid()
    {
        // Arrange
        var command = new ResendUserEmailConfirmationCommand(UserTestUtilities.ValidEmailWithUnconfirmedEmail);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await EmailConfirmationTokenPublisher
            .Received(1)
            .PublishEmailConfirmationTokenAsync(Arg.Is<CreateEmailConfirmationTokenModel>(uc => uc.UserId == UserTestUtilities.ValidIdWithUnconfirmedEmail &&
                                                                                          uc.Email == UserTestUtilities.ValidEmailWithUnconfirmedEmail), CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldCallTheUnitOfWorkSaveChanges_WhenRequestIsValid()
    {
        // Arrange
        var command = new ResendUserEmailConfirmationCommand(UserTestUtilities.ValidEmailWithUnconfirmedEmail);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
