using FluentAssertions;

using InstaConnect.Identity.Application.Features.Users.Commands.Login;
using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Identity.Application.IntegrationTests.Features.Users.Utilities;
using InstaConnect.Identity.Application.IntegrationTests.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Domain.Features.Users.Exceptions;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Identity.Application.IntegrationTests.Features.Users.Commands;

public class LoginUserCommandHandlerIntegrationTests : BaseUserIntegrationTest
{
    public LoginUserCommandHandlerIntegrationTests(IdentityWebApplicationFactory identityWebApplicationFactory) : base(identityWebApplicationFactory)
    {

    }

    [Fact]
    public async Task SendAsync_ShouldThrowValidationException_WhenEmailIsNull()
    {
        // Arrange
        var existingUserClaim = await CreateUserClaimAsync(CancellationToken);
        var command = new LoginUserCommand(
            null,
            UserTestUtilities.ValidPassword
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<AppValidationException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.EmailMinLength - 1)]
    [InlineData(UserConfigurations.EmailMaxLength + 1)]
    public async Task SendAsync_ShouldThrowValidationException_WhenEmailLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserClaim = await CreateUserClaimAsync(CancellationToken);
        var command = new LoginUserCommand(
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidPassword
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AppValidationException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowValidationException_WhenPasswordIsNull()
    {
        // Arrange
        var existingUserClaim = await CreateUserClaimAsync(CancellationToken);
        var command = new LoginUserCommand(
            existingUserClaim.User.Email,
            null
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AppValidationException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.PasswordMinLength - 1)]
    [InlineData(UserConfigurations.PasswordMaxLength + 1)]
    public async Task SendAsync_ShouldThrowValidationException_WhenPasswordLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserClaim = await CreateUserClaimAsync(CancellationToken);
        var command = new LoginUserCommand(
            existingUserClaim.User.Email,
            SharedTestUtilities.GetString(length)
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AppValidationException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserInvalidDetailsException_WhenEmailIsInvalid()
    {
        // Arrange
        var existingUserClaim = await CreateUserClaimAsync(CancellationToken);
        var command = new LoginUserCommand(
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidPassword
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserInvalidDetailsException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserInvalidDetailsException_WhenPasswordIsInvalid()
    {
        // Arrange
        var existingUserClaim = await CreateUserClaimAsync(CancellationToken);
        var command = new LoginUserCommand(
            existingUserClaim.User.Email,
            UserTestUtilities.ValidAddPassword
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserInvalidDetailsException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserEmailNotConfirmedException_WhenEmailIsNotConfirmed()
    {
        // Arrange
        var existingUserClaim = await CreateUserClaimWithUnconfirmedUserEmailAsync(CancellationToken);
        var command = new LoginUserCommand(
            existingUserClaim.User.Email,
            UserTestUtilities.ValidPassword
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserEmailNotConfirmedException>();
    }

    [Fact]
    public async Task SendAsync_ShouldReturnUserTokenCommandViewModel_WhenUserIsValid()
    {
        // Arrange
        var existingUserClaim = await CreateUserClaimAsync(CancellationToken);
        var command = new LoginUserCommand(
            existingUserClaim.User.Email,
            UserTestUtilities.ValidPassword
        );

        // Act
        var response = await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserTokenCommandViewModel>(p => !string.IsNullOrEmpty(p.Value) &&
                                                   p.ValidUntil != default);
    }
}
