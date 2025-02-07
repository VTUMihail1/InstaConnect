using FluentAssertions;
using InstaConnect.Identity.Application.Features.Users.Commands.ResendUserEmailConfirmation;
using InstaConnect.Identity.Application.IntegrationTests.Features.Users.Utilities;
using InstaConnect.Identity.Application.IntegrationTests.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Shared.Application.Contracts.Emails;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Exceptions.User;
using InstaConnect.Shared.Common.Utilities;
using MassTransit.Testing;

namespace InstaConnect.Identity.Application.IntegrationTests.Features.Users.Commands;

public class ResendUserEmailConfirmationIntegrationTests : BaseUserIntegrationTest
{
    public ResendUserEmailConfirmationIntegrationTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {

    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenEmailIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(false, CancellationToken);
        var command = new AddEmailConfirmationTokenCommand(null!);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.EmailMinLength - 1)]
    [InlineData(UserConfigurations.EmailMaxLength + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenEmailLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(false, CancellationToken);
        var command = new AddEmailConfirmationTokenCommand(SharedTestUtilities.GetString(length));

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserNotFoundException_WhenEmailIsInvalid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(false, CancellationToken);
        var command = new AddEmailConfirmationTokenCommand(UserTestUtilities.InvalidEmail);

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
        var command = new AddEmailConfirmationTokenCommand(UserTestUtilities.ValidEmail);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserEmailAlreadyConfirmedException>();
    }

    [Fact]
    public async Task SendAsync_ShouldAddEmailConfirmationTokenToRepository_WhenUserIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(false, CancellationToken);
        var command = new AddEmailConfirmationTokenCommand(UserTestUtilities.ValidEmail);

        // Act
        await InstaConnectSender.SendAsync(command, CancellationToken);
        var user = await UserWriteRepository.GetByIdAsync(existingUserId, CancellationToken);

        // Assert
        user!
            .EmailConfirmationTokens
            .Should()
            .NotBeEmpty();
    }

    [Fact]
    public async Task SendAsync_ShouldPublishUserConfirmEmailTokenCreatedEvent_WhenUserIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(false, CancellationToken);
        var command = new AddEmailConfirmationTokenCommand(UserTestUtilities.ValidEmail);

        // Act
        await InstaConnectSender.SendAsync(command, CancellationToken);
        var user = await UserWriteRepository.GetByIdAsync(existingUserId, CancellationToken);
        var url = string.Format(EmailConfirmationOptions.UrlTemplate, user!.Id, user.EmailConfirmationTokens.FirstOrDefault()!.Value);

        await TestHarness.InactivityTask;
        var result = await TestHarness.Published.Any<UserConfirmEmailTokenCreatedEvent>(m =>
                              m.Context.Message.Email == UserTestUtilities.ValidEmail &&
                              m.Context.Message.RedirectUrl == url, CancellationToken);

        // Assert
        result.Should().BeTrue();
    }
}
