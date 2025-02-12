using FluentAssertions;
using InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Commands.Add;
using InstaConnect.Identity.Application.IntegrationTests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Application.IntegrationTests.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Shared.Application.Contracts.Emails;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Exceptions.User;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Identity.Application.IntegrationTests.Features.EmailConfirmationTokens.Commands;

public class AddEmailConfirmationTokenCommandHandlerIntegrationTests : BaseEmailConfirmationTokenIntegrationTest
{
    public AddEmailConfirmationTokenCommandHandlerIntegrationTests(IdentityWebApplicationFactory identityWebApplicationFactory) : base(identityWebApplicationFactory)
    {

    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenEmailIsNull()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var command = new AddEmailConfirmationTokenCommand(null);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.EmailMinLength - 1)]
    [InlineData(UserConfigurations.EmailMaxLength + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenEmailLengthIsInvalid(int length)
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var command = new AddEmailConfirmationTokenCommand(SharedTestUtilities.GetString(length));

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserNotFoundException_WhenEmailIsInvalid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var command = new AddEmailConfirmationTokenCommand(UserTestUtilities.ValidAddEmail);

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
        var existingUser = await CreateUserWithConfirmedEmailAsync(CancellationToken);
        var command = new AddEmailConfirmationTokenCommand(existingUser.Email);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<UserEmailAlreadyConfirmedException>();
    }

    [Fact]
    public async Task SendAsync_ShouldAddEmailConfirmationTokenToRepository_WhenUserIsValid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var command = new AddEmailConfirmationTokenCommand(existingUser.Email);

        // Act
        await InstaConnectSender.SendAsync(command, CancellationToken);
        var user = await UserWriteRepository.GetByIdAsync(existingUser.Id, CancellationToken);

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
        var existingUser = await CreateUserAsync(CancellationToken);
        var command = new AddEmailConfirmationTokenCommand(existingUser.Email);

        // Act
        await InstaConnectSender.SendAsync(command, CancellationToken);
        var user = await UserWriteRepository.GetByIdAsync(existingUser.Id, CancellationToken);

        await TestHarness.InactivityTask;
        var result = await TestHarness.Published.Any<UserConfirmEmailTokenCreatedEvent>(m =>
                              m.Context.Message.Email == existingUser.Email);

        // Assert
        result
            .Should()
            .BeTrue();
    }
}
