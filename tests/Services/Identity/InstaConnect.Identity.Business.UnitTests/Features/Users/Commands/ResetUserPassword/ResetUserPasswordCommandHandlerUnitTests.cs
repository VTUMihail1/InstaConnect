using FluentAssertions;
using InstaConnect.Identity.Business.Features.Users.Commands.ResetUserPassword;
using InstaConnect.Identity.Business.UnitTests.Features.Users.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Data.Features.ForgotPasswordTokens.Models.Entitites;
using InstaConnect.Shared.Common.Exceptions.Token;
using InstaConnect.Shared.Common.Exceptions.User;
using NSubstitute;

namespace InstaConnect.Identity.Business.UnitTests.Features.Users.Commands.ResetUserPassword;

public class ResetUserPasswordCommandHandlerUnitTests : BaseUserUnitTest
{
    private readonly ResetUserPasswordCommandHandler _commandHandler;

    public ResetUserPasswordCommandHandlerUnitTests()
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
        var command = new ResetUserPasswordCommand(
            UserTestUtilities.InvalidId,
            UserTestUtilities.ValidForgotPasswordTokenValue,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidPassword);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowTokenNotFoundException_WhenTokenValueIsInvalid()
    {
        // Arrange
        var command = new ResetUserPasswordCommand(
            UserTestUtilities.ValidId,
            UserTestUtilities.InvalidForgotPasswordTokenValue,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidPassword);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<TokenNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowUserForbiddenException_WhenTokenIsNotOwnedByUser()
    {
        // Arrange
        var command = new ResetUserPasswordCommand(
            UserTestUtilities.ValidId,
            UserTestUtilities.ValidForgotPasswordTokenValueWithTokenUser,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidPassword);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserForbiddenException>();
    }

    [Fact]
    public async Task Handle_ShouldGetUserByIdFromRepository_WhenRequestIsValid()
    {
        // Arrange
        var command = new ResetUserPasswordCommand(
            UserTestUtilities.ValidId,
            UserTestUtilities.ValidForgotPasswordTokenValue,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidPassword);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UserWriteRepository
            .Received(1)
            .GetByIdAsync(UserTestUtilities.ValidId, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldHashPassword_WhenRequestIsValid()
    {
        // Arrange
        var command = new ResetUserPasswordCommand(
            UserTestUtilities.ValidId,
            UserTestUtilities.ValidForgotPasswordTokenValue,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidPassword);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        PasswordHasher
            .Received(1)
            .Hash(UserTestUtilities.ValidPassword);
    }

    [Fact]
    public async Task Handle_ShouldGetForgotPasswordTokenByValueFromRepository_WhenRequestIsValid()
    {
        // Arrange
        var command = new ResetUserPasswordCommand(
            UserTestUtilities.ValidId,
            UserTestUtilities.ValidForgotPasswordTokenValue,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidPassword);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await ForgotPasswordTokenWriteRepository
            .Received(1)
            .GetByValueAsync(UserTestUtilities.ValidForgotPasswordTokenValue, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldDeleteEmailConfirmationTokenToRepository_WhenRequestIsValid()
    {
        // Arrange
        var command = new ResetUserPasswordCommand(
            UserTestUtilities.ValidId,
            UserTestUtilities.ValidForgotPasswordTokenValue,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidPassword);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        ForgotPasswordTokenWriteRepository
            .Received(1)
            .Delete(Arg.Is<ForgotPasswordToken>(ec => ec.Value == UserTestUtilities.ValidForgotPasswordTokenValue &&
                                                         ec.ValidUntil == UserTestUtilities.ValidUntil &&
                                                         ec.UserId == UserTestUtilities.ValidId));
    }

    [Fact]
    public async Task Handle_ShouldResetUserPasswordToRepository_WhenRequestIsValid()
    {
        // Arrange
        var command = new ResetUserPasswordCommand(
            UserTestUtilities.ValidId,
            UserTestUtilities.ValidForgotPasswordTokenValue,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidPassword);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UserWriteRepository
            .Received(1)
            .ResetPasswordAsync(UserTestUtilities.ValidId, UserTestUtilities.ValidPasswordHash, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldCallTheUnitOfWorkSaveChanges_WhenRequestIsValid()
    {
        // Arrange
        var command = new ResetUserPasswordCommand(
            UserTestUtilities.ValidId,
            UserTestUtilities.ValidForgotPasswordTokenValue,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidPassword);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
