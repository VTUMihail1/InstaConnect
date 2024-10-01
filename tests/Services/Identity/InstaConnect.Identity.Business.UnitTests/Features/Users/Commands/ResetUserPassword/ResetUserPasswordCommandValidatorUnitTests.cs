using FluentValidation.TestHelper;
using InstaConnect.Identity.Business.Features.Users.Commands.ResetUserPassword;
using InstaConnect.Identity.Business.UnitTests.Features.Users.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;

namespace InstaConnect.Identity.Business.UnitTests.Features.Users.Commands.ResetUserPassword;

public class ResetUserPasswordCommandValidatorUnitTests : BaseUserUnitTest
{
    private readonly ResetUserPasswordCommandValidator _commandValidator;

    public ResetUserPasswordCommandValidatorUnitTests()
    {
        _commandValidator = new ResetUserPasswordCommandValidator();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdIsNull()
    {
        // Arrange
        var command = new ResetUserPasswordCommand(
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
    [InlineData(UserBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(UserBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var command = new ResetUserPasswordCommand(
            Faker.Random.AlphaNumeric(length),
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
        var command = new ResetUserPasswordCommand(
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
    [InlineData(UserBusinessConfigurations.TOKEN_MIN_LENGTH - 1)]
    [InlineData(UserBusinessConfigurations.TOKEN_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForToken_WhenTokenLengthIsInvalid(int length)
    {
        // Arrange
        var command = new ResetUserPasswordCommand(
            UserTestUtilities.ValidName,
            Faker.Random.AlphaNumeric(length),
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
        var command = new ResetUserPasswordCommand(
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
    [InlineData(UserBusinessConfigurations.PASSWORD_MIN_LENGTH - 1)]
    [InlineData(UserBusinessConfigurations.PASSWORD_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForPassword_WhenPasswordLengthIsInvalid(int length)
    {
        // Arrange
        var invalidPassword = Faker.Random.AlphaNumeric(length);
        var command = new ResetUserPasswordCommand(
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
        var command = new ResetUserPasswordCommand(
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
        var command = new ResetUserPasswordCommand(
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
