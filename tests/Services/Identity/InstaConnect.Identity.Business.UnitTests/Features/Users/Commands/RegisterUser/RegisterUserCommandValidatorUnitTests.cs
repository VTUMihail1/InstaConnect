using FluentValidation.TestHelper;
using InstaConnect.Identity.Business.Features.Users.Commands.RegisterUser;
using InstaConnect.Identity.Business.Features.Users.Utilities;
using InstaConnect.Identity.Business.UnitTests.Features.Users.Utilities;

namespace InstaConnect.Identity.Business.UnitTests.Features.Users.Commands.RegisterUser;

public class RegisterUserCommandValidatorUnitTests : BaseUserUnitTest
{
    private readonly RegisterUserCommandValidator _commandValidator;

    public RegisterUserCommandValidatorUnitTests()
    {
        _commandValidator = new RegisterUserCommandValidator();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForName_WhenNameIsNull()
    {
        // Arrange
        var command = new RegisterUserCommand(
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
    [InlineData(UserBusinessConfigurations.USER_NAME_MIN_LENGTH - 1)]
    [InlineData(UserBusinessConfigurations.USER_NAME_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForName_WhenNameLengthIsInvalid(int length)
    {
        // Arrange
        var command = new RegisterUserCommand(
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
        var command = new RegisterUserCommand(
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
    [InlineData(UserBusinessConfigurations.EMAIL_MIN_LENGTH - 1)]
    [InlineData(UserBusinessConfigurations.EMAIL_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForEmail_WhenEmailLengthIsInvalid(int length)
    {
        // Arrange
        var command = new RegisterUserCommand(
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
        var command = new RegisterUserCommand(
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
    [InlineData(UserBusinessConfigurations.PASSWORD_MIN_LENGTH - 1)]
    [InlineData(UserBusinessConfigurations.PASSWORD_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForPassword_WhenPasswordLengthIsInvalid(int length)
    {
        // Arrange
        var invalidPassword = Faker.Random.AlphaNumeric(length);
        var command = new RegisterUserCommand(
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
        var command = new RegisterUserCommand(
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
        var command = new RegisterUserCommand(
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
    [InlineData(UserBusinessConfigurations.FIRST_NAME_MIN_LENGTH - 1)]
    [InlineData(UserBusinessConfigurations.FIRST_NAME_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForFirstName_WhenFirstNameLengthIsInvalid(int length)
    {
        // Arrange
        var command = new RegisterUserCommand(
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
        var command = new RegisterUserCommand(
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
    [InlineData(UserBusinessConfigurations.LAST_NAME_MIN_LENGTH - 1)]
    [InlineData(UserBusinessConfigurations.LAST_NAME_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForLastName_WhenLastNameLengthIsInvalid(int length)
    {
        // Arrange
        var command = new RegisterUserCommand(
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
        var command = new RegisterUserCommand(
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
        var command = new RegisterUserCommand(
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
