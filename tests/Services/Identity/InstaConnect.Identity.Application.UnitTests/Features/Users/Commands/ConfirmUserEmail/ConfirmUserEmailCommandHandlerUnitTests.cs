using FluentAssertions;
using InstaConnect.Identity.Business.Features.Users.Commands.ConfirmUserEmail;
using InstaConnect.Identity.Business.UnitTests.Features.Users.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Data.Features.EmailConfirmationTokens.Models.Entitites;
using InstaConnect.Shared.Common.Exceptions.Token;
using InstaConnect.Shared.Common.Exceptions.User;
using NSubstitute;

namespace InstaConnect.Identity.Business.UnitTests.Features.Users.Commands.ConfirmUserEmail;

public class ConfirmUserEmailCommandHandlerUnitTests : BaseUserUnitTest
{
    private readonly ConfirmUserEmailCommandHandler _commandHandler;

    public ConfirmUserEmailCommandHandlerUnitTests()
    {
        _commandHandler = new(
            UnitOfWork,
            UserWriteRepository,
            EmailConfirmationTokenWriteRepository);
    }

    [Fact]
    public async Task Handle_ShouldThrowUserNotFoundException_WhenEmailIsInvalid()
    {
        // Arrange
        var command = new ConfirmUserEmailCommand(
            UserTestUtilities.InvalidId,
            UserTestUtilities.ValidEmailConfirmationTokenValue);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowUserEmailAlreadyConfirmedException_WhenEmailIsConfirmed()
    {
        // Arrange
        var command = new ConfirmUserEmailCommand(
            UserTestUtilities.ValidId,
            UserTestUtilities.ValidEmailConfirmationTokenValue);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserEmailAlreadyConfirmedException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowTokenNotFoundException_WhenTokenValueIsInvalid()
    {
        // Arrange
        var command = new ConfirmUserEmailCommand(
            UserTestUtilities.ValidIdWithUnconfirmedEmail,
            UserTestUtilities.InvalidEmailConfirmationTokenValue);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<TokenNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowUserForbiddenException_WhenTokenIsNotOwnedByUser()
    {
        // Arrange
        var command = new ConfirmUserEmailCommand(
            UserTestUtilities.ValidIdWithUnconfirmedEmail,
            UserTestUtilities.ValidEmailConfirmationTokenValueWithTokenUser);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserForbiddenException>();
    }

    [Fact]
    public async Task Handle_ShouldGetUserByIdFromRepository_WhenRequestIsValid()
    {
        // Arrange
        var command = new ConfirmUserEmailCommand(
            UserTestUtilities.ValidIdWithUnconfirmedEmail,
            UserTestUtilities.ValidEmailConfirmationTokenValue);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UserWriteRepository
            .Received(1)
            .GetByIdAsync(UserTestUtilities.ValidIdWithUnconfirmedEmail, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldGetEmailConfirmationTokenByValueFromRepository_WhenRequestIsValid()
    {
        // Arrange
        var command = new ConfirmUserEmailCommand(
            UserTestUtilities.ValidIdWithUnconfirmedEmail,
            UserTestUtilities.ValidEmailConfirmationTokenValue);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await EmailConfirmationTokenWriteRepository
            .Received(1)
            .GetByValueAsync(UserTestUtilities.ValidEmailConfirmationTokenValue, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldDeleteEmailConfirmationTokenToRepository_WhenRequestIsValid()
    {
        // Arrange
        var command = new ConfirmUserEmailCommand(
            UserTestUtilities.ValidIdWithUnconfirmedEmail,
            UserTestUtilities.ValidEmailConfirmationTokenValue);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        EmailConfirmationTokenWriteRepository
            .Received(1)
            .Delete(Arg.Is<EmailConfirmationToken>(ec => ec.Value == UserTestUtilities.ValidEmailConfirmationTokenValue &&
                                                         ec.ValidUntil == UserTestUtilities.ValidUntil &&
                                                         ec.UserId == UserTestUtilities.ValidIdWithUnconfirmedEmail));
    }

    [Fact]
    public async Task Handle_ShouldConfirmUserEmailToRepository_WhenRequestIsValid()
    {
        // Arrange
        var command = new ConfirmUserEmailCommand(
            UserTestUtilities.ValidIdWithUnconfirmedEmail,
            UserTestUtilities.ValidEmailConfirmationTokenValue);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UserWriteRepository
            .Received(1)
            .ConfirmEmailAsync(UserTestUtilities.ValidIdWithUnconfirmedEmail, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldCallTheUnitOfWorkSaveChanges_WhenRequestIsValid()
    {
        // Arrange
        var command = new ConfirmUserEmailCommand(
            UserTestUtilities.ValidIdWithUnconfirmedEmail,
            UserTestUtilities.ValidEmailConfirmationTokenValue);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
