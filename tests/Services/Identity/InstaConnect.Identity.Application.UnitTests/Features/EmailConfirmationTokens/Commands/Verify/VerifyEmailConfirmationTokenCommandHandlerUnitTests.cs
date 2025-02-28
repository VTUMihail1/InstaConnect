using InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Commands.Verify;
using InstaConnect.Identity.Common.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Common.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Application.UnitTests.Features.EmailConfirmationTokens.Commands.Verify;

public class VerifyEmailConfirmationTokenCommandHandlerUnitTests : BaseEmailConfirmationTokenUnitTest
{
    private readonly VerifyEmailConfirmationTokenCommandHandler _commandHandler;

    public VerifyEmailConfirmationTokenCommandHandlerUnitTests()
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
        var existingEmailConfirmationToken = CreateEmailConfirmationToken();
        var command = new VerifyEmailConfirmationTokenCommand(
            UserTestUtilities.InvalidId,
            existingEmailConfirmationToken.Value);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowUserEmailAlreadyConfirmedException_WhenEmailIsConfirmed()
    {
        // Arrange
        var existingEmailConfirmationToken = CreateEmailConfirmationTokenWithConfirmedUser();
        var command = new VerifyEmailConfirmationTokenCommand(
            existingEmailConfirmationToken.UserId,
            existingEmailConfirmationToken.Value);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserEmailAlreadyConfirmedException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowTokenNotFoundException_WhenTokenValueIsInvalid()
    {
        // Arrange
        var existingEmailConfirmationToken = CreateEmailConfirmationToken();
        var command = new VerifyEmailConfirmationTokenCommand(
            existingEmailConfirmationToken.UserId,
            EmailConfirmationTokenTestUtilities.InvalidValue);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<EmailConfirmationTokenNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowUserForbiddenException_WhenTokenIsNotOwnedByUser()
    {
        // Arrange
        var existingUser = CreateUser();
        var existingEmailConfirmationToken = CreateEmailConfirmationToken();
        var command = new VerifyEmailConfirmationTokenCommand(
            existingUser.Id,
            existingEmailConfirmationToken.Value);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserForbiddenException>();
    }

    [Fact]
    public async Task Handle_ShouldGetUserByIdFromRepository_WhenRequestIsValid()
    {
        // Arrange
        var existingEmailConfirmationToken = CreateEmailConfirmationToken();
        var command = new VerifyEmailConfirmationTokenCommand(
            existingEmailConfirmationToken.UserId,
            existingEmailConfirmationToken.Value);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UserWriteRepository
            .Received(1)
            .GetByIdAsync(existingEmailConfirmationToken.UserId, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldGetEmailConfirmationTokenByValueFromRepository_WhenRequestIsValid()
    {
        // Arrange
        var existingEmailConfirmationToken = CreateEmailConfirmationToken();
        var command = new VerifyEmailConfirmationTokenCommand(
            existingEmailConfirmationToken.UserId,
            existingEmailConfirmationToken.Value);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await EmailConfirmationTokenWriteRepository
            .Received(1)
            .GetByValueAsync(existingEmailConfirmationToken.Value, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldDeleteEmailConfirmationTokenToRepository_WhenRequestIsValid()
    {
        // Arrange
        var existingEmailConfirmationToken = CreateEmailConfirmationToken();
        var command = new VerifyEmailConfirmationTokenCommand(
            existingEmailConfirmationToken.UserId,
            existingEmailConfirmationToken.Value);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        EmailConfirmationTokenWriteRepository
            .Received(1)
            .Delete(Arg.Is<EmailConfirmationToken>(ec => ec.Value == existingEmailConfirmationToken.Value &&
                                                         ec.ValidUntil == existingEmailConfirmationToken.ValidUntil &&
                                                         ec.UserId == existingEmailConfirmationToken.UserId));
    }

    [Fact]
    public async Task Handle_ShouldConfirmUserEmailToRepository_WhenRequestIsValid()
    {
        // Arrange
        var existingEmailConfirmationToken = CreateEmailConfirmationToken();
        var command = new VerifyEmailConfirmationTokenCommand(
            existingEmailConfirmationToken.UserId,
            existingEmailConfirmationToken.Value);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UserWriteRepository
            .Received(1)
            .ConfirmEmailAsync(existingEmailConfirmationToken.UserId, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldCallTheUnitOfWorkSaveChanges_WhenRequestIsValid()
    {
        // Arrange
        var existingEmailConfirmationToken = CreateEmailConfirmationToken();
        var command = new VerifyEmailConfirmationTokenCommand(
            existingEmailConfirmationToken.UserId,
            existingEmailConfirmationToken.Value);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
