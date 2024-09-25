using FluentValidation.TestHelper;
using InstaConnect.Identity.Business.Features.Accounts.Commands.ResetAccountPassword;
using InstaConnect.Identity.Business.Features.Accounts.Utilities;
using InstaConnect.Identity.Business.UnitTests.Features.Accounts.Utilities;

namespace InstaConnect.Identity.Business.UnitTests.Features.Accounts.Commands.ResetAccountPassword;

public class ResetAccountPasswordCommandValidatorUnitTests : BaseAccountUnitTest
{
    private readonly ResetAccountPasswordCommandValidator _commandValidator;

    public ResetAccountPasswordCommandValidatorUnitTests()
    {
        _commandValidator = new ResetAccountPasswordCommandValidator();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdIsNull()
    {
        // Arrange
        var command = new ResetAccountPasswordCommand(
            null!,
            ValidForgotPasswordTokenValue,
            ValidPassword,
            ValidPassword
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.UserId);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(AccountBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(AccountBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var command = new ResetAccountPasswordCommand(
            Faker.Random.AlphaNumeric(length),
            ValidForgotPasswordTokenValue,
            ValidPassword,
            ValidPassword
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
        var command = new ResetAccountPasswordCommand(
            ValidName,
            null!,
            ValidPassword,
            ValidPassword
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Token);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(AccountBusinessConfigurations.TOKEN_MIN_LENGTH - 1)]
    [InlineData(AccountBusinessConfigurations.TOKEN_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForToken_WhenTokenLengthIsInvalid(int length)
    {
        // Arrange
        var command = new ResetAccountPasswordCommand(
            ValidName,
            Faker.Random.AlphaNumeric(length),
            ValidPassword,
            ValidPassword
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
        var command = new ResetAccountPasswordCommand(
            ValidName,
            ValidEmail,
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
    [InlineData(AccountBusinessConfigurations.PASSWORD_MIN_LENGTH - 1)]
    [InlineData(AccountBusinessConfigurations.PASSWORD_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForPassword_WhenPasswordLengthIsInvalid(int length)
    {
        // Arrange
        var invalidPassword = Faker.Random.AlphaNumeric(length);
        var command = new ResetAccountPasswordCommand(
            ValidName,
            ValidEmail,
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
        var command = new ResetAccountPasswordCommand(
            ValidName,
            ValidEmail,
            ValidPassword,
            InvalidPassword
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
        var command = new ResetAccountPasswordCommand(
            ValidName,
            ValidEmail,
            ValidPassword,
            ValidPassword
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
