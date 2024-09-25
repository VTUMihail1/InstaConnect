using FluentAssertions;
using InstaConnect.Identity.Business.Features.Accounts.Commands.ResetAccountPassword;
using InstaConnect.Identity.Business.UnitTests.Features.Accounts.Utilities;
using InstaConnect.Identity.Data.Features.ForgotPasswordTokens.Models.Entitites;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.Token;
using InstaConnect.Shared.Business.Exceptions.User;
using NSubstitute;

namespace InstaConnect.Identity.Business.UnitTests.Features.Accounts.Commands.ResetAccountPassword;

public class ResetAccountPasswordCommandHandlerUnitTests : BaseAccountUnitTest
{
    private readonly ResetAccountPasswordCommandHandler _commandHandler;

    public ResetAccountPasswordCommandHandlerUnitTests()
    {
        _commandHandler = new(
            UnitOfWork,
            PasswordHasher,
            UserWriteRepository,
            ForgotPasswordTokenWriteRepository);
    }

    [Fact]
    public async Task Handle_ShouldThrowUserNotFoundException_WhenEmailIsInvalid()
    {
        // Arrange
        var command = new ResetAccountPasswordCommand(
            InvalidId,
            ValidForgotPasswordTokenValue,
            ValidPassword,
            ValidPassword);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowTokenNotFoundException_WhenTokenValueIsInvalid()
    {
        // Arrange
        var command = new ResetAccountPasswordCommand(
            ValidId,
            InvalidForgotPasswordTokenValue,
            ValidPassword,
            ValidPassword);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<TokenNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowAccountForbiddenException_WhenTokenIsNotOwnedByUser()
    {
        // Arrange
        var command = new ResetAccountPasswordCommand(
            ValidId,
            ValidForgotPasswordTokenValueWithTokenUser,
            ValidPassword,
            ValidPassword);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AccountForbiddenException>();
    }

    [Fact]
    public async Task Handle_ShouldGetUserByIdFromRepository_WhenRequestIsValid()
    {
        // Arrange
        var command = new ResetAccountPasswordCommand(
            ValidId,
            ValidForgotPasswordTokenValue,
            ValidPassword,
            ValidPassword);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UserWriteRepository
            .Received(1)
            .GetByIdAsync(ValidId, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldHashPassword_WhenRequestIsValid()
    {
        // Arrange
        var command = new ResetAccountPasswordCommand(
            ValidId,
            ValidForgotPasswordTokenValue,
            ValidPassword,
            ValidPassword);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        PasswordHasher
            .Received(1)
            .Hash(ValidPassword);
    }

    [Fact]
    public async Task Handle_ShouldGetForgotPasswordTokenByValueFromRepository_WhenRequestIsValid()
    {
        // Arrange
        var command = new ResetAccountPasswordCommand(
            ValidId,
            ValidForgotPasswordTokenValue,
            ValidPassword,
            ValidPassword);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await ForgotPasswordTokenWriteRepository
            .Received(1)
            .GetByValueAsync(ValidForgotPasswordTokenValue, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldDeleteEmailConfirmationTokenToRepository_WhenRequestIsValid()
    {
        // Arrange
        var command = new ResetAccountPasswordCommand(
            ValidId,
            ValidForgotPasswordTokenValue,
            ValidPassword,
            ValidPassword);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        ForgotPasswordTokenWriteRepository
            .Received(1)
            .Delete(Arg.Is<ForgotPasswordToken>(ec => ec.Value == ValidForgotPasswordTokenValue &&
                                                         ec.ValidUntil == ValidUntil &&
                                                         ec.UserId == ValidId));
    }

    [Fact]
    public async Task Handle_ShouldResetUserPasswordToRepository_WhenRequestIsValid()
    {
        // Arrange
        var command = new ResetAccountPasswordCommand(
            ValidId,
            ValidForgotPasswordTokenValue,
            ValidPassword,
            ValidPassword);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UserWriteRepository
            .Received(1)
            .ResetPasswordAsync(ValidId, ValidPasswordHash, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldCallTheUnitOfWorkSaveChanges_WhenRequestIsValid()
    {
        // Arrange
        var command = new ResetAccountPasswordCommand(
            ValidId,
            ValidForgotPasswordTokenValue,
            ValidPassword,
            ValidPassword);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
