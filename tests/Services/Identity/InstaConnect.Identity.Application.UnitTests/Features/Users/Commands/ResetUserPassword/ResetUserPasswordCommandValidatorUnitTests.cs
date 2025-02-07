using FluentValidation.TestHelper;
using InstaConnect.Identity.Application.Features.Users.Commands.ResetUserPassword;
using InstaConnect.Identity.Application.UnitTests.Features.Users.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Identity.Application.UnitTests.Features.Users.Commands.ResetUserPassword;

public class ResetUserPasswordCommandValidatorUnitTests : BaseUserUnitTest
{
    private readonly VerifyForgotPasswordTokenCommandValidator _commandValidator;

    public ResetUserPasswordCommandValidatorUnitTests()
    {
        _commandValidator = new VerifyForgotPasswordTokenCommandValidator();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdIsNull()
    {
        // Arrange
        var command = new VerifyForgotPasswordTokenCommand(
            null!,
            UserTestUtilities.ValidForgotPasswordTokenValue,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidPassword
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.UserId);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var command = new VerifyForgotPasswordTokenCommand(
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidForgotPasswordTokenValue,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidPassword
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.UserId);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForToken_WhenTokenIsNull()
    {
        // Arrange
        var command = new VerifyForgotPasswordTokenCommand(
            UserTestUtilities.ValidName,
            null!,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidPassword
        );

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
        var command = new VerifyForgotPasswordTokenCommand(
            UserTestUtilities.ValidName,
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidPassword
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Token);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForPassword_WhenPasswordIsNull()
    {
        // Arrange
        var command = new VerifyForgotPasswordTokenCommand(
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidEmail,
            null!,
            null!
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Password);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.PasswordMinLength - 1)]
    [InlineData(UserConfigurations.PasswordMaxLength + 1)]
    public void TestValidate_ShouldHaveAnErrorForPassword_WhenPasswordLengthIsInvalid(int length)
    {
        // Arrange
        var invalidPassword = SharedTestUtilities.GetString(length);
        var command = new VerifyForgotPasswordTokenCommand(
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidEmail,
            invalidPassword,
            invalidPassword
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Password);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForConfirmPassword_WhenConfirmPasswordDoesNotMatchPassword()
    {
        // Arrange
        var command = new VerifyForgotPasswordTokenCommand(
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidEmail,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.InvalidPassword
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.ConfirmPassword);
    }

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenModelIsValid()
    {
        // Arrange
        var command = new VerifyForgotPasswordTokenCommand(
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidEmail,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidPassword
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
