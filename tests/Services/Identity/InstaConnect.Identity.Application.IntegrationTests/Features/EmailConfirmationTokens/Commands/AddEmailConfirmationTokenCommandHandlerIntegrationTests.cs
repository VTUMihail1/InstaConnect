using InstaConnect.Common.Application.Contracts.EmailConfirmationTokens;
using InstaConnect.Common.Exceptions;
using InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Commands.Add;

namespace InstaConnect.Identity.Application.IntegrationTests.Features.EmailConfirmationTokens.Commands;

public class AddEmailConfirmationTokenCommandHandlerIntegrationTests : BaseEmailConfirmationTokenIntegrationTest
{
    public AddEmailConfirmationTokenCommandHandlerIntegrationTests(IdentityWebApplicationFactory identityWebApplicationFactory) : base(identityWebApplicationFactory)
    {

    }

    [Fact]
    public async Task SendAsync_ShouldThrowValidationException_WhenEmailIsNull()
    {
        // Arrange
        var command = new AddEmailConfirmationTokenCommand(null);

        // Act
        var action = async () => await ApplicationSender.SendAsync(command, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<InvalidValidationException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.EmailMinLength - 1)]
    [InlineData(UserConfigurations.EmailMaxLength + 1)]
    public async Task SendAsync_ShouldThrowValidationException_WhenEmailLengthIsInvalid(int length)
    {
        // Arrange
        var command = new AddEmailConfirmationTokenCommand(DataFaker.GetString(length));

        // Act
        var action = async () => await ApplicationSender.SendAsync(command, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<InvalidValidationException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserNotFoundException_WhenEmailIsInvalid()
    {
        // Arrange
        var command = new AddEmailConfirmationTokenCommand(UserTestUtilities.ValidAddEmail);

        // Act
        var action = async () => await ApplicationSender.SendAsync(command, CancellationToken);

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
        var action = async () => await ApplicationSender.SendAsync(command, CancellationToken);

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
        await ApplicationSender.SendAsync(command, CancellationToken);
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
        await ApplicationSender.SendAsync(command, CancellationToken);

        await TestHarness.InactivityTask;
        var result = await TestHarness.Published.Any<UserConfirmEmailTokenCreatedEventRequest>(m =>
                              m.Context.Message.Email == existingUser.Email);

        // Assert
        result
            .Should()
            .BeTrue();
    }
}
