﻿using FluentAssertions;
using InstaConnect.Identity.Business.Features.Users.Commands.LoginUser;
using InstaConnect.Identity.Business.Features.Users.Models;
using InstaConnect.Identity.Business.IntegrationTests.Features.Users.Utilities;
using InstaConnect.Identity.Business.IntegrationTests.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Exceptions.User;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Identity.Business.IntegrationTests.Features.Users.Commands;

public class LoginUserIntegrationTests : BaseUserIntegrationTest
{
    public LoginUserIntegrationTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {

    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenEmailIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var command = new LoginUserCommand(
            null!,
            UserTestUtilities.ValidPassword
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserBusinessConfigurations.EMAIL_MIN_LENGTH - 1)]
    [InlineData(UserBusinessConfigurations.EMAIL_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenEmailLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var command = new LoginUserCommand(
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidPassword
        );

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
        var command = new LoginUserCommand(
            UserTestUtilities.ValidEmail,
            null!
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserBusinessConfigurations.PASSWORD_MIN_LENGTH - 1)]
    [InlineData(UserBusinessConfigurations.PASSWORD_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenPasswordLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var command = new LoginUserCommand(
            UserTestUtilities.ValidEmail,
            SharedTestUtilities.GetString(length)
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserInvalidDetailsException_WhenEmailIsInvalid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var command = new LoginUserCommand(
            UserTestUtilities.InvalidEmail,
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
        var existingUserId = await CreateUserAsync(CancellationToken);
        var command = new LoginUserCommand(
            UserTestUtilities.ValidEmail,
            UserTestUtilities.InvalidPassword
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
        var existingUserId = await CreateUserAsync(false, CancellationToken);
        var command = new LoginUserCommand(
            UserTestUtilities.ValidEmail,
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
        var existingUserId = await CreateUserAsync(CancellationToken);
        var command = new LoginUserCommand(
            UserTestUtilities.ValidEmail,
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
