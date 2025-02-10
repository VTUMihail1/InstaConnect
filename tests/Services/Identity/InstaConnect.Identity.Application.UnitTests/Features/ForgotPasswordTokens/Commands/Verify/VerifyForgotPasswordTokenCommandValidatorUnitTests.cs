using FluentValidation.TestHelper;
using InstaConnect.Identity.Application.Features.Users.Commands.ResetUserPassword;
using InstaConnect.Identity.Application.UnitTests.Features.Users.Utilities;
using InstaConnect.Identity.Common.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Identity.Application.UnitTests.Features.Users.Commands.ResetUserPassword;

public class VerifyForgotPasswordTokenCommandValidatorUnitTests : BaseForgotPasswordTokenUnitTest
{
    private readonly VerifyForgotPasswordTokenCommandValidator _commandValidator;

    public VerifyForgotPasswordTokenCommandValidatorUnitTests()
    {
        _commandValidator = new VerifyForgotPasswordTokenCommandValidator();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdIsNull()
    {
        // Arrange
        var existingForgotPasswordToken = CreateForgotPasswordToken();
        var command = new VerifyForgotPasswordTokenCommand(
            null!,
            existingForgotPasswordToken.Value,
            UserTestUtilities.ValidUpdatePassword,
            UserTestUtilities.ValidUpdatePassword
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
        var existingForgotPasswordToken = CreateForgotPasswordToken();
        var command = new VerifyForgotPasswordTokenCommand(
            SharedTestUtilities.GetString(length),
            existingForgotPasswordToken.Value,
            UserTestUtilities.ValidUpdatePassword,
            UserTestUtilities.ValidUpdatePassword
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
        var existingForgotPasswordToken = CreateForgotPasswordToken();
        var command = new VerifyForgotPasswordTokenCommand(
            existingForgotPasswordToken.UserId,
            null!,
            UserTestUtilities.ValidUpdatePassword,
            UserTestUtilities.ValidUpdatePassword
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Token);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(ForgotPasswordTokenConfigurations.ValueMinLength - 1)]
    [InlineData(ForgotPasswordTokenConfigurations.ValueMaxLength + 1)]
    public void TestValidate_ShouldHaveAnErrorForToken_WhenTokenLengthIsInvalid(int length)
    {
        // Arrange
        var existingForgotPasswordToken = CreateForgotPasswordToken();
        var command = new VerifyForgotPasswordTokenCommand(
            existingForgotPasswordToken.UserId,
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidUpdatePassword,
            UserTestUtilities.ValidUpdatePassword
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
        var existingForgotPasswordToken = CreateForgotPasswordToken();
        var command = new VerifyForgotPasswordTokenCommand(
            existingForgotPasswordToken.UserId,
            existingForgotPasswordToken.Value,
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
        var existingForgotPasswordToken = CreateForgotPasswordToken();
        var password = SharedTestUtilities.GetString(length);
        var command = new VerifyForgotPasswordTokenCommand(
            existingForgotPasswordToken.UserId,
            existingForgotPasswordToken.Value,
            password,
            password
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
        var existingForgotPasswordToken = CreateForgotPasswordToken();
        var command = new VerifyForgotPasswordTokenCommand(
            existingForgotPasswordToken.UserId,
            existingForgotPasswordToken.Value,
            UserTestUtilities.ValidUpdatePassword,
            UserTestUtilities.ValidPassword
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
        var existingForgotPasswordToken = CreateForgotPasswordToken();
        var command = new VerifyForgotPasswordTokenCommand(
            existingForgotPasswordToken.UserId,
            existingForgotPasswordToken.Value,
            UserTestUtilities.ValidUpdatePassword,
            UserTestUtilities.ValidUpdatePassword
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
