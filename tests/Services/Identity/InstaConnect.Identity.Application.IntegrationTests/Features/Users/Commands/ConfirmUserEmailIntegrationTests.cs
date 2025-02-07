using FluentAssertions;
using InstaConnect.Identity.Application.Features.Users.Commands.ConfirmUserEmail;
using InstaConnect.Identity.Application.IntegrationTests.Features.Users.Utilities;
using InstaConnect.Identity.Application.IntegrationTests.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Exceptions.Token;
using InstaConnect.Shared.Common.Exceptions.User;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Identity.Application.IntegrationTests.Features.Users.Commands;

public class ConfirmUserEmailIntegrationTests : BaseUserIntegrationTest
{
    public ConfirmUserEmailIntegrationTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {

    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(false, CancellationToken);
        var existingEmailConfirmationTokenValue = await CreateEmailConfirmationTokenAsync(existingUserId, UserTestUtilities.ValidUntil, CancellationToken);
        var command = new VerifyEmailConfirmationTokenCommand(null!, existingEmailConfirmationTokenValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(false, CancellationToken);
        var existingEmailConfirmationTokenValue = await CreateEmailConfirmationTokenAsync(existingUserId, UserTestUtilities.ValidUntil, CancellationToken);
        var command = new VerifyEmailConfirmationTokenCommand(SharedTestUtilities.GetString(length), existingEmailConfirmationTokenValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenTokenIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(false, CancellationToken);
        var existingEmailConfirmationTokenValue = await CreateEmailConfirmationTokenAsync(existingUserId, UserTestUtilities.ValidUntil, CancellationToken);
        var command = new VerifyEmailConfirmationTokenCommand(existingUserId, null!);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.TOKEN_MAX_LENGTH + 1)]
    [InlineData(UserConfigurations.TOKEN_MIN_LENGTH - 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenTokenLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(false, CancellationToken);
        var existingEmailConfirmationTokenValue = await CreateEmailConfirmationTokenAsync(existingUserId, UserTestUtilities.ValidUntil, CancellationToken);
        var command = new VerifyEmailConfirmationTokenCommand(existingUserId, SharedTestUtilities.GetString(length));

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(false, CancellationToken);
        var existingEmailConfirmationTokenValue = await CreateEmailConfirmationTokenAsync(existingUserId, UserTestUtilities.ValidUntil, CancellationToken);
        var command = new VerifyEmailConfirmationTokenCommand(UserTestUtilities.InvalidId, existingEmailConfirmationTokenValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserEmailAlreadyConfirmedExceptionn_WhenEmailIsConfirmed()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingEmailConfirmationTokenValue = await CreateEmailConfirmationTokenAsync(existingUserId, UserTestUtilities.ValidUntil, CancellationToken);
        var command = new VerifyEmailConfirmationTokenCommand(existingUserId, existingEmailConfirmationTokenValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserEmailAlreadyConfirmedException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowTokenNotFoundException_WhenTokenIsInvalid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(false, CancellationToken);
        var existingEmailConfirmationTokenValue = await CreateEmailConfirmationTokenAsync(existingUserId, UserTestUtilities.ValidUntil, CancellationToken);
        var command = new VerifyEmailConfirmationTokenCommand(existingUserId, UserTestUtilities.InvalidEmailConfirmationTokenValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<TokenNotFoundException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserForbiddenException_WhenUserDoesNotOwnToken()
    {
        // Arrange
        var existingEmailConfirmationTokenUserId = await CreateUserAsync(false, CancellationToken);
        var existingEmailConfirmationTokenValue = await CreateEmailConfirmationTokenAsync(existingEmailConfirmationTokenUserId, UserTestUtilities.ValidUntil, CancellationToken);
        var existingUserId = await CreateUserAsync(false, CancellationToken);
        var command = new VerifyEmailConfirmationTokenCommand(existingUserId, existingEmailConfirmationTokenValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserForbiddenException>();
    }

    [Fact]
    public async Task SendAsync_ShoulRemoveEmailConfirmationTokenFromRepository_WhenUserIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(false, CancellationToken);
        var existingEmailConfirmationTokenValue = await CreateEmailConfirmationTokenAsync(existingUserId, UserTestUtilities.ValidUntil, CancellationToken);
        var command = new VerifyEmailConfirmationTokenCommand(existingUserId, existingEmailConfirmationTokenValue);

        // Act
        await InstaConnectSender.SendAsync(command, CancellationToken);
        var user = await UserWriteRepository.GetByIdAsync(existingUserId, CancellationToken);

        // Assert
        user!
            .EmailConfirmationTokens
            .Should()
            .BeEmpty();
    }
}
