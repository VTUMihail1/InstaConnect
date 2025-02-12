using FluentAssertions;
using InstaConnect.Identity.Application.Features.Users.Commands.ConfirmUserEmail;
using InstaConnect.Identity.Application.IntegrationTests.Features.Users.Utilities;
using InstaConnect.Identity.Application.IntegrationTests.Utilities;
using InstaConnect.Identity.Common.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Domain.Features.Users.Models.Entitites;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Exceptions.Token;
using InstaConnect.Shared.Common.Exceptions.User;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Identity.Application.IntegrationTests.Features.Users.Commands;

public class VerifyEmailConfirmationTokenCommandHandlerIntegrationTests : BaseEmailConfirmationTokenIntegrationTest
{
    public VerifyEmailConfirmationTokenCommandHandlerIntegrationTests(IdentityWebApplicationFactory identityWebApplicationFactory) : base(identityWebApplicationFactory)
    {

    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdIsNull()
    {
        // Arrange
        var existingEmailConfirmationToken = await CreateEmailConfirmationTokenAsync(CancellationToken);
        var command = new VerifyEmailConfirmationTokenCommand(null, existingEmailConfirmationToken.Value);

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
        var existingEmailConfirmationToken = await CreateEmailConfirmationTokenAsync(CancellationToken);
        var command = new VerifyEmailConfirmationTokenCommand(SharedTestUtilities.GetString(length), existingEmailConfirmationToken.Value);

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
        var existingEmailConfirmationToken = await CreateEmailConfirmationTokenAsync(CancellationToken);
        var command = new VerifyEmailConfirmationTokenCommand(existingEmailConfirmationToken.UserId, null);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(EmailConfirmationTokenConfigurations.ValueMinLength - 1)]
    [InlineData(EmailConfirmationTokenConfigurations.ValueMaxLength + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenTokenLengthIsInvalid(int length)
    {
        // Arrange
        var existingEmailConfirmationToken = await CreateEmailConfirmationTokenAsync(CancellationToken);
        var command = new VerifyEmailConfirmationTokenCommand(existingEmailConfirmationToken.UserId, SharedTestUtilities.GetString(length));

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
        var existingEmailConfirmationToken = await CreateEmailConfirmationTokenAsync(CancellationToken);
        var command = new VerifyEmailConfirmationTokenCommand(UserTestUtilities.InvalidId, existingEmailConfirmationToken.Value);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserEmailAlreadyConfirmedExceptionn_WhenEmailIsConfirmed()
    {
        // Arrange
        var existingEmailConfirmationToken = await CreateEmailConfirmationTokenWithConfirmedUserEmailAsync(CancellationToken);
        var command = new VerifyEmailConfirmationTokenCommand(existingEmailConfirmationToken.UserId, existingEmailConfirmationToken.Value);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<UserEmailAlreadyConfirmedException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowTokenNotFoundException_WhenTokenIsInvalid()
    {
        // Arrange
        var existingEmailConfirmationToken = await CreateEmailConfirmationTokenAsync(CancellationToken);
        var command = new VerifyEmailConfirmationTokenCommand(existingEmailConfirmationToken.UserId, EmailConfirmationTokenTestUtilities.InvalidValue);

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
        var existingEmailConfirmationToken = await CreateEmailConfirmationTokenAsync(CancellationToken);
        var command = new VerifyEmailConfirmationTokenCommand(existingUser.Id, existingEmailConfirmationToken.Value);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserForbiddenException>();
    }

    [Fact]
    public async Task SendAsync_ShoulRemoveEmailConfirmationTokenFromRepository_WhenUserIsValid()
    {
        // Arrange
        var existingEmailConfirmationToken = await CreateEmailConfirmationTokenAsync(CancellationToken);
        var command = new VerifyEmailConfirmationTokenCommand(existingEmailConfirmationToken.UserId, existingEmailConfirmationToken.Value);

        // Act
        await InstaConnectSender.SendAsync(command, CancellationToken);
        var user = await UserWriteRepository.GetByIdAsync(existingEmailConfirmationToken.UserId, CancellationToken);

        // Assert
        user!
            .EmailConfirmationTokens
            .Should()
            .BeEmpty();
    }

    [Fact]
    public async Task SendAsync_ShouldChangeUserPassword_WhenRequestIsValid()
    {
        // Arrange
        var existingEmailConfirmationToken = await CreateEmailConfirmationTokenAsync(CancellationToken);
        var command = new VerifyEmailConfirmationTokenCommand(
            existingEmailConfirmationToken.UserId, 
            existingEmailConfirmationToken.Value);


        // Act
        await InstaConnectSender.SendAsync(command, CancellationToken);
        var user = await UserWriteRepository.GetByIdAsync(existingEmailConfirmationToken.UserId, CancellationToken);

        // Assert
        user
            .Should()
            .Match<User>(p => p.Id == existingEmailConfirmationToken.User.Id &&
                              p.FirstName == existingEmailConfirmationToken.User.FirstName &&
                              p.LastName == existingEmailConfirmationToken.User.LastName &&
                              p.UserName == existingEmailConfirmationToken.User.UserName &&
                              p.Email == existingEmailConfirmationToken.User.Email &&
                              p.IsEmailConfirmed &&
                              p.ProfileImage == existingEmailConfirmationToken.User.ProfileImage);
    }
}
