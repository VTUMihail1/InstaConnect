using FluentValidation.TestHelper;
using InstaConnect.Identity.Application.Features.Users.Commands.ConfirmUserEmail;
using InstaConnect.Identity.Application.UnitTests.Features.Users.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Identity.Application.UnitTests.Features.Users.Commands.ConfirmUserEmail;

public class VerifyEmailConfirmationTokenCommandValidatorUnitTests : BaseUserUnitTest
{
    private readonly VerifyEmailConfirmationTokenCommandValidator _commandValidator;

    public VerifyEmailConfirmationTokenCommandValidatorUnitTests()
    {
        _commandValidator = new VerifyEmailConfirmationTokenCommandValidator();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForUserId_WhenUserIdIsNull()
    {
        // Arrange
        var command = new VerifyEmailConfirmationTokenCommand(
            null!,
            UserTestUtilities.ValidEmailConfirmationTokenValue);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.UserId);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public void TestValidate_ShouldHaveAnErrorForUserId_WhenUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var command = new VerifyEmailConfirmationTokenCommand(
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidEmailConfirmationTokenValue);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.UserId);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForTokenId_WhenTokenIdIsNull()
    {
        // Arrange
        var command = new VerifyEmailConfirmationTokenCommand(
            UserTestUtilities.ValidId,
            null!);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Token);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.TOKEN_MIN_LENGTH - 1)]
    [InlineData(UserConfigurations.TOKEN_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForToken_WhenTokenLengthIsInvalid(int length)
    {
        // Arrange
        var command = new VerifyEmailConfirmationTokenCommand(
            UserTestUtilities.ValidId,
            SharedTestUtilities.GetString(length));

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Token);
    }

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenModelIsValid()
    {
        // Arrange
        var command = new VerifyEmailConfirmationTokenCommand(
            UserTestUtilities.ValidId,
            UserTestUtilities.ValidEmailConfirmationTokenValue);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
