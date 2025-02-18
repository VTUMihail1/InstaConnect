using InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Commands.Add;
using InstaConnect.Shared.Application.Contracts.ForgotPasswordTokens;

namespace InstaConnect.Identity.Application.IntegrationTests.Features.ForgotPasswordTokens.Commands;

public class AddForgotPasswordTokenCommandHandlerIntegrationTests : BaseUserIntegrationTest
{
    public AddForgotPasswordTokenCommandHandlerIntegrationTests(IdentityWebApplicationFactory identityWebApplicationFactory) : base(identityWebApplicationFactory)
    {

    }

    [Fact]
    public async Task SendAsync_ShouldThrowValidationException_WhenEmailIsNull()
    {
        // Arrange
        var command = new AddForgotPasswordTokenCommand(null);

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
        var command = new AddForgotPasswordTokenCommand(SharedTestUtilities.GetString(length));

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<AppValidationException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserNotFoundException_WhenEmailIsInvalid()
    {
        // Arrange
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
        await TestHarness.InactivityTask;

        var result = await TestHarness.Published.Any<UserForgotPasswordTokenCreatedEvent>(m =>
                              m.Context.Message.Email == existingUser.Email);

        // Assert
        result
            .Should()
            .BeTrue();
    }
}
