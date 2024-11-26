using FluentAssertions;
using InstaConnect.Identity.Application.Features.Users.Commands.ResetUserPassword;
using InstaConnect.Identity.Application.IntegrationTests.Features.Users.Utilities;
using InstaConnect.Identity.Application.IntegrationTests.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Domain.Features.Users.Models.Entitites;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Exceptions.Token;
using InstaConnect.Shared.Common.Exceptions.User;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Identity.Application.IntegrationTests.Features.Users.Commands;

public class ResetUserPasswordIntegrationTests : BaseUserIntegrationTest
{
    public ResetUserPasswordIntegrationTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {

    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingForgotPasswordTokenValue = await CreateForgotPasswordTokenAsync(existingUserId, UserTestUtilities.ValidUntil, CancellationToken);
        var command = new ResetUserPasswordCommand(
            null!,
            existingForgotPasswordTokenValue,
            UserTestUtilities.ValidUpdatePassword,
            UserTestUtilities.ValidUpdatePassword);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(UserBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingForgotPasswordTokenValue = await CreateForgotPasswordTokenAsync(existingUserId, UserTestUtilities.ValidUntil, CancellationToken);
        var command = new ResetUserPasswordCommand(
            SharedTestUtilities.GetString(length),
            existingForgotPasswordTokenValue,
            UserTestUtilities.ValidUpdatePassword,
            UserTestUtilities.ValidUpdatePassword);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenTokenIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingForgotPasswordTokenValue = await CreateForgotPasswordTokenAsync(existingUserId, UserTestUtilities.ValidUntil, CancellationToken);
        var command = new ResetUserPasswordCommand(
            existingUserId,
            null!,
            UserTestUtilities.ValidUpdatePassword,
            UserTestUtilities.ValidUpdatePassword);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserBusinessConfigurations.TOKEN_MAX_LENGTH + 1)]
    [InlineData(UserBusinessConfigurations.TOKEN_MIN_LENGTH - 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenTokenLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(false, CancellationToken);
        var existingForgotPasswordTokenValue = await CreateForgotPasswordTokenAsync(existingUserId, UserTestUtilities.ValidUntil, CancellationToken);
        var command = new ResetUserPasswordCommand(
            existingUserId,
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidUpdatePassword,
            UserTestUtilities.ValidUpdatePassword);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenPasswordIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingForgotPasswordTokenValue = await CreateForgotPasswordTokenAsync(existingUserId, UserTestUtilities.ValidUntil, CancellationToken);
        var command = new ResetUserPasswordCommand(
            existingUserId,
            existingForgotPasswordTokenValue,
            null!,
            null!);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserBusinessConfigurations.PASSWORD_MAX_LENGTH + 1)]
    [InlineData(UserBusinessConfigurations.PASSWORD_MIN_LENGTH - 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenPasswordLengthIsInvalid(int length)
    {
        // Arrange
        var invalidPassword = SharedTestUtilities.GetString(length);
        var existingUserId = await CreateUserAsync(false, CancellationToken);
        var existingForgotPasswordTokenValue = await CreateForgotPasswordTokenAsync(existingUserId, UserTestUtilities.ValidUntil, CancellationToken);
        var command = new ResetUserPasswordCommand(
            existingUserId,
            SharedTestUtilities.GetString(length),
            invalidPassword,
            invalidPassword);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenPasswordAndConfirmPasswordDoNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingForgotPasswordTokenValue = await CreateForgotPasswordTokenAsync(existingUserId, UserTestUtilities.ValidUntil, CancellationToken);
        var command = new ResetUserPasswordCommand(
            existingUserId,
            existingForgotPasswordTokenValue,
            UserTestUtilities.ValidUpdatePassword,
            UserTestUtilities.InvalidPassword);

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
        var existingForgotPasswordTokenValue = await CreateForgotPasswordTokenAsync(existingUserId, UserTestUtilities.ValidUntil, CancellationToken);
        var command = new ResetUserPasswordCommand(
            UserTestUtilities.InvalidId,
            existingForgotPasswordTokenValue,
            UserTestUtilities.ValidUpdatePassword,
            UserTestUtilities.ValidUpdatePassword);


        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowTokenNotFoundException_WhenTokenIsInvalid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(false, CancellationToken);
        var existingForgotPasswordTokenValue = await CreateForgotPasswordTokenAsync(existingUserId, UserTestUtilities.ValidUntil, CancellationToken);
        var command = new ResetUserPasswordCommand(
            existingUserId,
            UserTestUtilities.InvalidEmailConfirmationTokenValue,
            UserTestUtilities.ValidUpdatePassword,
            UserTestUtilities.ValidUpdatePassword);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<TokenNotFoundException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserForbiddenException_WhenUserDoesNotOwnToken()
    {
        // Arrange
        var existingForgotPasswordTokenUserId = await CreateUserAsync(false, CancellationToken);
        var existingForgotPasswordTokenValue = await CreateForgotPasswordTokenAsync(existingForgotPasswordTokenUserId, UserTestUtilities.ValidUntil, CancellationToken);
        var existingUserId = await CreateUserAsync(false, CancellationToken);
        var command = new ResetUserPasswordCommand(
            existingUserId,
            existingForgotPasswordTokenValue,
            UserTestUtilities.ValidUpdatePassword,
            UserTestUtilities.ValidUpdatePassword);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserForbiddenException>();
    }

    [Fact]
    public async Task SendAsync_ShouldUpdateUserPasswordToRepository_WhenUserIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(false, CancellationToken);
        var existingForgotPasswordTokenValue = await CreateForgotPasswordTokenAsync(existingUserId, UserTestUtilities.ValidUntil, CancellationToken);
        var command = new ResetUserPasswordCommand(
            existingUserId,
            existingForgotPasswordTokenValue,
            UserTestUtilities.ValidUpdatePassword,
            UserTestUtilities.ValidUpdatePassword);

        // Act
        await InstaConnectSender.SendAsync(command, CancellationToken);
        var user = await UserWriteRepository.GetByIdAsync(existingUserId, CancellationToken);

        // Assert
        user!
            .Should()
            .Match<User>(p => p.Id == existingUserId &&
                              p.FirstName == UserTestUtilities.ValidFirstName &&
                              p.LastName == UserTestUtilities.ValidLastName &&
                              p.UserName == UserTestUtilities.ValidName &&
                              p.Email == UserTestUtilities.ValidEmail &&
                              PasswordHasher.Verify(UserTestUtilities.ValidUpdatePassword, p.PasswordHash) &&
                              p.ProfileImage == UserTestUtilities.ValidProfileImage);
    }

    [Fact]
    public async Task SendAsync_ShouldRemoveEmailConfirmationTokenFromRepository_WhenUserIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(false, CancellationToken);
        var existingForgotPasswordTokenValue = await CreateForgotPasswordTokenAsync(existingUserId, UserTestUtilities.ValidUntil, CancellationToken);
        var command = new ResetUserPasswordCommand(
            existingUserId,
            existingForgotPasswordTokenValue,
            UserTestUtilities.ValidUpdatePassword,
            UserTestUtilities.ValidUpdatePassword);

        // Act
        await InstaConnectSender.SendAsync(command, CancellationToken);
        var user = await UserWriteRepository.GetByIdAsync(existingUserId, CancellationToken);

        // Assert
        user!
            .ForgotPasswordTokens
            .Should()
            .BeEmpty();
    }
}
