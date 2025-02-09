using FluentAssertions;
using InstaConnect.Identity.Application.Features.Users.Commands.ResetUserPassword;
using InstaConnect.Identity.Application.UnitTests.Features.Users.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Entitites;
using InstaConnect.Shared.Common.Exceptions.Token;
using InstaConnect.Shared.Common.Exceptions.User;
using NSubstitute;

namespace InstaConnect.Identity.Application.UnitTests.Features.Users.Commands.ResetUserPassword;

public class VerifyForgotPasswordTokenCommandHandlerUnitTests : BaseForgotPasswordTokenUnitTest
{
    private readonly VerifyForgotPasswordTokenCommandHandler _commandHandler;

    public VerifyForgotPasswordTokenCommandHandlerUnitTests()
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
        var existingForgotPasswordToken = CreateForgotPasswordToken();
        var command = new VerifyForgotPasswordTokenCommand(
            UserTestUtilities.InvalidId,
            existingForgotPasswordToken.Value,
            UserTestUtilities.ValidUpdatePassword,
            UserTestUtilities.ValidUpdatePassword);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowTokenNotFoundException_WhenTokenValueIsInvalid()
    {
        // Arrange
        var existingForgotPasswordToken = CreateForgotPasswordToken();
        var command = new VerifyForgotPasswordTokenCommand(
            existingForgotPasswordToken.UserId,
            ForgotPasswordTokenTestUtilities.InvalidValue,
            UserTestUtilities.ValidUpdatePassword,
            UserTestUtilities.ValidUpdatePassword);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<TokenNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowUserForbiddenException_WhenTokenIsNotOwnedByUser()
    {
        // Arrange
        var existingUser = CreateUser();
        var existingForgotPasswordToken = CreateForgotPasswordToken();
        var command = new VerifyForgotPasswordTokenCommand(
            existingUser.Id,
            existingForgotPasswordToken.Value,
            UserTestUtilities.ValidUpdatePassword,
            UserTestUtilities.ValidUpdatePassword);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserForbiddenException>();
    }

    [Fact]
    public async Task Handle_ShouldGetUserByIdFromRepository_WhenRequestIsValid()
    {
        // Arrange
        var existingForgotPasswordToken = CreateForgotPasswordToken();
        var command = new VerifyForgotPasswordTokenCommand(
            existingForgotPasswordToken.UserId,
            existingForgotPasswordToken.Value,
            UserTestUtilities.ValidUpdatePassword,
            UserTestUtilities.ValidUpdatePassword);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UserWriteRepository
            .Received(1)
            .GetByIdAsync(existingForgotPasswordToken.UserId, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldHashPassword_WhenRequestIsValid()
    {
        // Arrange
        var existingForgotPasswordToken = CreateForgotPasswordToken();
        var command = new VerifyForgotPasswordTokenCommand(
            existingForgotPasswordToken.UserId,
            existingForgotPasswordToken.Value,
            UserTestUtilities.ValidUpdatePassword,
            UserTestUtilities.ValidUpdatePassword);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        PasswordHasher
            .Received(1)
            .Hash(UserTestUtilities.ValidUpdatePassword);
    }

    [Fact]
    public async Task Handle_ShouldGetForgotPasswordTokenByValueFromRepository_WhenRequestIsValid()
    {
        // Arrange
        var existingForgotPasswordToken = CreateForgotPasswordToken();
        var command = new VerifyForgotPasswordTokenCommand(
            existingForgotPasswordToken.UserId,
            existingForgotPasswordToken.Value,
            UserTestUtilities.ValidUpdatePassword,
            UserTestUtilities.ValidUpdatePassword);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await ForgotPasswordTokenWriteRepository
            .Received(1)
            .GetByValueAsync(existingForgotPasswordToken.Value, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldDeleteEmailConfirmationTokenToRepository_WhenRequestIsValid()
    {
        // Arrange
        var existingForgotPasswordToken = CreateForgotPasswordToken();
        var command = new VerifyForgotPasswordTokenCommand(
            existingForgotPasswordToken.UserId,
            existingForgotPasswordToken.Value,
            UserTestUtilities.ValidUpdatePassword,
            UserTestUtilities.ValidUpdatePassword);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        ForgotPasswordTokenWriteRepository
            .Received(1)
            .Delete(Arg.Is<ForgotPasswordToken>(ec => ec.Value == existingForgotPasswordToken.Value &&
                                                         ec.ValidUntil == existingForgotPasswordToken.ValidUntil &&
                                                         ec.UserId == existingForgotPasswordToken.UserId));
    }

    [Fact]
    public async Task Handle_ShouldResetUserPasswordToRepository_WhenRequestIsValid()
    {
        // Arrange
        var existingForgotPasswordToken = CreateForgotPasswordToken();
        var command = new VerifyForgotPasswordTokenCommand(
            existingForgotPasswordToken.UserId,
            existingForgotPasswordToken.Value,
            UserTestUtilities.ValidUpdatePassword,
            UserTestUtilities.ValidUpdatePassword);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UserWriteRepository
            .Received(1)
            .ResetPasswordAsync(existingForgotPasswordToken.UserId, UserTestUtilities.ValidUpdatePasswordHash, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldCallTheUnitOfWorkSaveChanges_WhenRequestIsValid()
    {
        // Arrange
        var existingForgotPasswordToken = CreateForgotPasswordToken();
        var command = new VerifyForgotPasswordTokenCommand(
            existingForgotPasswordToken.UserId,
            existingForgotPasswordToken.Value,
            UserTestUtilities.ValidUpdatePassword,
            UserTestUtilities.ValidUpdatePassword);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
