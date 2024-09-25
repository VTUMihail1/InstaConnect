using FluentValidation.TestHelper;
using InstaConnect.Identity.Business.Features.Accounts.Commands.RegisterAccount;
using InstaConnect.Identity.Business.Features.Accounts.Utilities;
using InstaConnect.Identity.Business.UnitTests.Features.Accounts.Utilities;

namespace InstaConnect.Identity.Business.UnitTests.Features.Accounts.Commands.RegisterAccount;

public class RegisterAccountCommandValidatorUnitTests : BaseAccountUnitTest
{
    private readonly RegisterAccountCommandValidator _commandValidator;

    public RegisterAccountCommandValidatorUnitTests()
    {
        _commandValidator = new RegisterAccountCommandValidator();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForName_WhenNameIsNull()
    {
        // Arrange
        var command = new RegisterAccountCommand(
            null!,
            ValidEmail,
            ValidPassword,
            ValidPassword,
            ValidFirstName,
            ValidLastName,
            ValidFormFile
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.UserName);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(AccountBusinessConfigurations.USER_NAME_MIN_LENGTH - 1)]
    [InlineData(AccountBusinessConfigurations.USER_NAME_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForName_WhenNameLengthIsInvalid(int length)
    {
        // Arrange
        var command = new RegisterAccountCommand(
            Faker.Random.AlphaNumeric(length),
            ValidEmail,
            ValidPassword,
            ValidPassword,
            ValidFirstName,
            ValidLastName,
            ValidFormFile
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.UserName);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForEmail_WhenEmailIsNull()
    {
        // Arrange
        var command = new RegisterAccountCommand(
            ValidName,
            null!,
            ValidPassword,
            ValidPassword,
            ValidFirstName,
            ValidLastName,
            ValidFormFile
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Email);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(AccountBusinessConfigurations.EMAIL_MIN_LENGTH - 1)]
    [InlineData(AccountBusinessConfigurations.EMAIL_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForEmail_WhenEmailLengthIsInvalid(int length)
    {
        // Arrange
        var command = new RegisterAccountCommand(
            ValidName,
            Faker.Random.AlphaNumeric(length),
            ValidPassword,
            ValidPassword,
            ValidFirstName,
            ValidLastName,
            ValidFormFile
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Email);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForPassword_WhenPasswordIsNull()
    {
        // Arrange
        var command = new RegisterAccountCommand(
            ValidName,
            ValidEmail,
            null!,
            null!,
            ValidFirstName,
            ValidLastName,
            ValidFormFile
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
        var command = new RegisterAccountCommand(
            ValidName,
            ValidEmail,
            invalidPassword,
            invalidPassword,
            ValidFirstName,
            ValidLastName,
            ValidFormFile
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
        var command = new RegisterAccountCommand(
            ValidName,
            ValidEmail,
            ValidPassword,
            InvalidPassword,
            ValidFirstName,
            ValidLastName,
            ValidFormFile
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.ConfirmPassword);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForFirstName_WhenFirstNameIsNull()
    {
        // Arrange
        var command = new RegisterAccountCommand(
            ValidName,
            ValidEmail,
            ValidPassword,
            ValidPassword,
            null!,
            ValidLastName,
            ValidFormFile
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.FirstName);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(AccountBusinessConfigurations.FIRST_NAME_MIN_LENGTH - 1)]
    [InlineData(AccountBusinessConfigurations.FIRST_NAME_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForFirstName_WhenFirstNameLengthIsInvalid(int length)
    {
        // Arrange
        var command = new RegisterAccountCommand(
            ValidName,
            ValidEmail,
            ValidPassword,
            ValidPassword,
            Faker.Random.AlphaNumeric(length),
            ValidLastName,
            ValidFormFile
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.FirstName);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForLastName_WhenLastNameIsNull()
    {
        // Arrange
        var command = new RegisterAccountCommand(
            ValidName,
            ValidEmail,
            ValidPassword,
            ValidPassword,
            ValidFirstName,
            null!,
            ValidFormFile
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.LastName);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(AccountBusinessConfigurations.LAST_NAME_MIN_LENGTH - 1)]
    [InlineData(AccountBusinessConfigurations.LAST_NAME_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForLastName_WhenLastNameLengthIsInvalid(int length)
    {
        // Arrange
        var command = new RegisterAccountCommand(
            ValidName,
            ValidEmail,
            ValidPassword,
            ValidPassword,
            ValidFirstName,
            Faker.Random.AlphaNumeric(length),
            ValidFormFile
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.LastName);
    }

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenModelIsValid()
    {
        // Arrange
        var command = new RegisterAccountCommand(
            ValidName,
            ValidEmail,
            ValidPassword,
            ValidPassword,
            ValidFirstName,
            ValidLastName,
            ValidFormFile
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenModelIsValidAndProfileImageIsNull()
    {
        // Arrange
        var command = new RegisterAccountCommand(
            ValidName,
            ValidEmail,
            ValidPassword,
            ValidPassword,
            ValidFirstName,
            ValidLastName,
            null
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
