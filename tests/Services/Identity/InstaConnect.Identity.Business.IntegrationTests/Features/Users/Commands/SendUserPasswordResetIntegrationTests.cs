using FluentAssertions;
using InstaConnect.Identity.Business.Features.Users.Commands.SendUserPasswordReset;
using InstaConnect.Identity.Business.IntegrationTests.Features.Users.Utilities;
using InstaConnect.Identity.Business.IntegrationTests.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Shared.Business.Contracts.Emails;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Exceptions.User;
using InstaConnect.Shared.Common.Utilities;
using MassTransit.Testing;

namespace InstaConnect.Identity.Business.IntegrationTests.Features.Users.Commands;

public class SendUserPasswordResetIntegrationTests : BaseUserIntegrationTest
{
    public SendUserPasswordResetIntegrationTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {

    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenEmailIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var command = new SendUserPasswordResetCommand(null!);

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
        var command = new SendUserPasswordResetCommand(SharedTestUtilities.GetString(length));

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserNotFoundException_WhenEmailIsInvalid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var command = new SendUserPasswordResetCommand(UserTestUtilities.InvalidEmail);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task SendAsync_ShouldAddForgotPasswordTokenToRepository_WhenUserIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var command = new SendUserPasswordResetCommand(UserTestUtilities.ValidEmail);

        // Act
        await InstaConnectSender.SendAsync(command, CancellationToken);
        var user = await UserWriteRepository.GetByIdAsync(existingUserId, CancellationToken);

        // Assert
        user!
            .ForgotPasswordTokens
            .Should()
            .NotBeEmpty();
    }

    [Fact]
    public async Task SendAsync_ShouldPublishUserForgotPasswordTokenCreatedEvent_WhenUserIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var command = new SendUserPasswordResetCommand(UserTestUtilities.ValidEmail);

        // Act
        await InstaConnectSender.SendAsync(command, CancellationToken);
        var user = await UserWriteRepository.GetByIdAsync(existingUserId, CancellationToken);
        var url = string.Format(GatewayOptions.UrlTemplate, user!.Id, user.EmailConfirmationTokens.FirstOrDefault());

        await TestHarness.InactivityTask;
        var result = await TestHarness.Published.Any<UserForgotPasswordTokenCreatedEvent>(m =>
                              m.Context.Message.Email == UserTestUtilities.ValidEmail &&
                              m.Context.Message.RedirectUrl == url, CancellationToken);

        // Assert
        result.Should().BeTrue();
    }
}
