using FluentAssertions;
using InstaConnect.Identity.Application.Features.Users.Commands.ResetUserPassword;
using InstaConnect.Identity.Application.IntegrationTests.Features.Users.Utilities;
using InstaConnect.Identity.Application.IntegrationTests.Utilities;
using InstaConnect.Identity.Common.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Domain.Features.Users.Models.Entitites;
using InstaConnect.Identity.Presentation.Features.Users.Models.Requests;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Exceptions.Token;
using InstaConnect.Shared.Common.Exceptions.User;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Identity.Application.IntegrationTests.Features.Users.Commands;

public class VerifyForgotPasswordTokenCommandHandlerIntegrationTests : BaseForgotPasswordTokenIntegrationTest
{
    public VerifyForgotPasswordTokenCommandHandlerIntegrationTests(IdentityWebApplicationFactory identityWebApplicationFactory) : base(identityWebApplicationFactory)
    {

    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdIsNull()
    {
        // Arrange
        var existingForgotPasswordToken = await CreateForgotPasswordTokenAsync(CancellationToken);
        var command = new VerifyForgotPasswordTokenCommand(
            null,
            existingForgotPasswordToken.Value,
            UserTestUtilities.ValidUpdatePassword,
            UserTestUtilities.ValidUpdatePassword);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingForgotPasswordToken = await CreateForgotPasswordTokenAsync(CancellationToken);
        var command = new VerifyForgotPasswordTokenCommand(
            SharedTestUtilities.GetString(length),
            existingForgotPasswordToken.Value,
            UserTestUtilities.ValidUpdatePassword,
            UserTestUtilities.ValidUpdatePassword);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenTokenIsNull()
    {
        // Arrange
        var existingForgotPasswordToken = await CreateForgotPasswordTokenAsync(CancellationToken);
        var command = new VerifyForgotPasswordTokenCommand(
            existingForgotPasswordToken.UserId,
            null,
            UserTestUtilities.ValidUpdatePassword,
            UserTestUtilities.ValidUpdatePassword);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(ForgotPasswordTokenConfigurations.ValueMinLength - 1)]
    [InlineData(ForgotPasswordTokenConfigurations.ValueMaxLength + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenTokenLengthIsInvalid(int length)
    {
        // Arrange
        var existingForgotPasswordToken = await CreateForgotPasswordTokenAsync(CancellationToken);
        var command = new VerifyForgotPasswordTokenCommand(
            existingForgotPasswordToken.UserId,
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidUpdatePassword,
            UserTestUtilities.ValidUpdatePassword);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenPasswordIsNull()
    {
        // Arrange
        var existingForgotPasswordToken = await CreateForgotPasswordTokenAsync(CancellationToken);
        var command = new VerifyForgotPasswordTokenCommand(
            existingForgotPasswordToken.UserId,
            existingForgotPasswordToken.Value,
            null,
            null);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.PasswordMaxLength + 1)]
    [InlineData(UserConfigurations.PasswordMinLength - 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenPasswordLengthIsInvalid(int length)
    {
        // Arrange
        var password = SharedTestUtilities.GetString(length);
        var existingForgotPasswordToken = await CreateForgotPasswordTokenAsync(CancellationToken);
        var command = new VerifyForgotPasswordTokenCommand(
            existingForgotPasswordToken.UserId,
            SharedTestUtilities.GetString(length),
            password,
            password);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenPasswordAndConfirmPasswordDoNotMatch()
    {
        // Arrange
        var existingForgotPasswordToken = await CreateForgotPasswordTokenAsync(CancellationToken);
        var command = new VerifyForgotPasswordTokenCommand(
            existingForgotPasswordToken.UserId,
            existingForgotPasswordToken.Value,
            UserTestUtilities.ValidUpdatePassword,
            UserTestUtilities.ValidPassword);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var existingForgotPasswordToken = await CreateForgotPasswordTokenAsync(CancellationToken);
        var command = new VerifyForgotPasswordTokenCommand(
            UserTestUtilities.InvalidId,
            existingForgotPasswordToken.Value,
            UserTestUtilities.ValidUpdatePassword,
            UserTestUtilities.ValidUpdatePassword);


        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowTokenNotFoundException_WhenTokenIsInvalid()
    {
        // Arrange
        var existingForgotPasswordToken = await CreateForgotPasswordTokenAsync(CancellationToken);
        var command = new VerifyForgotPasswordTokenCommand(
            existingForgotPasswordToken.UserId,
            ForgotPasswordTokenTestUtilities.InvalidValue,
            UserTestUtilities.ValidUpdatePassword,
            UserTestUtilities.ValidUpdatePassword);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<TokenNotFoundException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserForbiddenException_WhenUserDoesNotOwnToken()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var existingForgotPasswordToken = await CreateForgotPasswordTokenAsync(CancellationToken);
        var command = new VerifyForgotPasswordTokenCommand(
            existingUser.Id,
            existingForgotPasswordToken.Value,
            UserTestUtilities.ValidUpdatePassword,
            UserTestUtilities.ValidUpdatePassword);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<UserForbiddenException>();
    }

    [Fact]
    public async Task SendAsync_ShouldUpdateUserPasswordToRepository_WhenUserIsValid()
    {
        // Arrange
        var existingForgotPasswordToken = await CreateForgotPasswordTokenAsync(CancellationToken);
        var command = new VerifyForgotPasswordTokenCommand(
            existingForgotPasswordToken.UserId,
            existingForgotPasswordToken.Value,
            UserTestUtilities.ValidUpdatePassword,
            UserTestUtilities.ValidUpdatePassword);

        // Act
        await InstaConnectSender.SendAsync(command, CancellationToken);
        var user = await UserWriteRepository.GetByIdAsync(existingForgotPasswordToken.UserId, CancellationToken);

        // Assert
        user!
            .Should()
            .Match<User>(p => p.Id == existingForgotPasswordToken.UserId &&
                              p.FirstName == existingForgotPasswordToken.User.FirstName &&
                              p.LastName == existingForgotPasswordToken.User.LastName &&
                              p.UserName == existingForgotPasswordToken.User.UserName &&
                              p.Email == existingForgotPasswordToken.User.Email &&
                              PasswordHasher.Verify(UserTestUtilities.ValidUpdatePassword, p.PasswordHash) &&
                              p.ProfileImage == existingForgotPasswordToken.User.ProfileImage);
    }

    [Fact]
    public async Task SendAsync_ShouldRemoveForgotPasswordTokenFromRepository_WhenUserIsValid()
    {
        // Arrange
        var existingForgotPasswordToken = await CreateForgotPasswordTokenAsync(CancellationToken);
        var command = new VerifyForgotPasswordTokenCommand(
            existingForgotPasswordToken.UserId,
            existingForgotPasswordToken.Value,
            UserTestUtilities.ValidUpdatePassword,
            UserTestUtilities.ValidUpdatePassword);

        // Act
        await InstaConnectSender.SendAsync(command, CancellationToken);
        var user = await UserWriteRepository.GetByIdAsync(existingForgotPasswordToken.UserId, CancellationToken);

        // Assert
        user!
            .ForgotPasswordTokens
            .Should()
            .BeEmpty();
    }
}
