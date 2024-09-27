using FluentAssertions;
using InstaConnect.Identity.Business.Features.Users.Commands.ConfirmUserEmail;
using InstaConnect.Identity.Business.UnitTests.Features.Users.Utilities;
using InstaConnect.Identity.Data.Features.EmailConfirmationTokens.Models.Entitites;
using InstaConnect.Shared.Business.Exceptions.Token;
using InstaConnect.Shared.Business.Exceptions.User;
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
            InvalidId,
            ValidEmailConfirmationTokenValue);

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
            ValidId,
            ValidEmailConfirmationTokenValue);

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
            ValidIdWithUnconfirmedEmail,
            InvalidEmailConfirmationTokenValue);

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
            ValidIdWithUnconfirmedEmail,
            ValidEmailConfirmationTokenValueWithTokenUser);

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
            ValidIdWithUnconfirmedEmail,
            ValidEmailConfirmationTokenValue);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UserWriteRepository
            .Received(1)
            .GetByIdAsync(ValidIdWithUnconfirmedEmail, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldGetEmailConfirmationTokenByValueFromRepository_WhenRequestIsValid()
    {
        // Arrange
        var command = new ConfirmUserEmailCommand(
            ValidIdWithUnconfirmedEmail,
            ValidEmailConfirmationTokenValue);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await EmailConfirmationTokenWriteRepository
            .Received(1)
            .GetByValueAsync(ValidEmailConfirmationTokenValue, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldDeleteEmailConfirmationTokenToRepository_WhenRequestIsValid()
    {
        // Arrange
        var command = new ConfirmUserEmailCommand(
            ValidIdWithUnconfirmedEmail,
            ValidEmailConfirmationTokenValue);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        EmailConfirmationTokenWriteRepository
            .Received(1)
            .Delete(Arg.Is<EmailConfirmationToken>(ec => ec.Value == ValidEmailConfirmationTokenValue &&
                                                         ec.ValidUntil == ValidUntil &&
                                                         ec.UserId == ValidIdWithUnconfirmedEmail));
    }

    [Fact]
    public async Task Handle_ShouldConfirmUserEmailToRepository_WhenRequestIsValid()
    {
        // Arrange
        var command = new ConfirmUserEmailCommand(
            ValidIdWithUnconfirmedEmail,
            ValidEmailConfirmationTokenValue);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UserWriteRepository
            .Received(1)
            .ConfirmEmailAsync(ValidIdWithUnconfirmedEmail, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldCallTheUnitOfWorkSaveChanges_WhenRequestIsValid()
    {
        // Arrange
        var command = new ConfirmUserEmailCommand(
            ValidIdWithUnconfirmedEmail,
            ValidEmailConfirmationTokenValue);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
