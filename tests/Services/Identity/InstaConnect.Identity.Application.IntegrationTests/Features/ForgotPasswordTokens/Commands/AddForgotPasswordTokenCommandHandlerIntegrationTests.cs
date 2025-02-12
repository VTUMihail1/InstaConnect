using FluentAssertions;
using InstaConnect.Identity.Application.Features.Users.Commands.SendUserPasswordReset;
using InstaConnect.Identity.Application.IntegrationTests.Features.Users.Utilities;
using InstaConnect.Identity.Application.IntegrationTests.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Shared.Application.Contracts.Emails;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Exceptions.User;
using InstaConnect.Shared.Common.Utilities;
using MassTransit.Testing;

namespace InstaConnect.Identity.Application.IntegrationTests.Features.Users.Commands;

public class AddForgotPasswordTokenCommandHandlerIntegrationTests : BaseUserIntegrationTest
{
    public AddForgotPasswordTokenCommandHandlerIntegrationTests(IdentityWebApplicationFactory identityWebApplicationFactory) : base(identityWebApplicationFactory)
    {

    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenEmailIsNull()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var command = new AddForgotPasswordTokenCommand(null);

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
        var command = new AddForgotPasswordTokenCommand(SharedTestUtilities.GetString(length));

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
        var command = new AddForgotPasswordTokenCommand(UserTestUtilities.ValidAddEmail);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task SendAsync_ShouldAddForgotPasswordTokenToRepository_WhenUserIsValid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var command = new AddForgotPasswordTokenCommand(existingUser.Email);

        // Act
        await InstaConnectSender.SendAsync(command, CancellationToken);
        var user = await UserWriteRepository.GetByIdAsync(existingUser.Id, CancellationToken);

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
        var existingUser = await CreateUserAsync(CancellationToken);
        var command = new AddForgotPasswordTokenCommand(existingUser.Email);

        // Act
        await InstaConnectSender.SendAsync(command, CancellationToken);
        var user = await UserWriteRepository.GetByIdAsync(existingUser.Id, CancellationToken);
        await TestHarness.InactivityTask;
        var result = await TestHarness.Published.Any<UserForgotPasswordTokenCreatedEvent>(m =>
                              m.Context.Message.Email == existingUser.Email);

        // Assert
        result
            .Should()
            .BeTrue();
    }
}
