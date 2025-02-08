using FluentValidation.TestHelper;
using InstaConnect.Identity.Application.Features.Users.Commands.RegisterUser;
using InstaConnect.Identity.Application.UnitTests.Features.Users.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Identity.Application.UnitTests.Features.Users.Commands.RegisterUser;

public class AddUserCommandValidatorUnitTests : BaseUserUnitTest
{
    private readonly AddUserCommandValidator _commandValidator;

    public AddUserCommandValidatorUnitTests()
    {
        _commandValidator = new AddUserCommandValidator();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForName_WhenNameIsNull()
    {
        // Arrange
        var command = new AddUserCommand(
            null!,
            UserTestUtilities.ValidEmail,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidFormFile
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.UserName);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.NameMinLength - 1)]
    [InlineData(UserConfigurations.NameMaxLength + 1)]
    public void TestValidate_ShouldHaveAnErrorForName_WhenNameLengthIsInvalid(int length)
    {
        // Arrange
        var command = new AddUserCommand(
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidEmail,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidFormFile
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
        var command = new AddUserCommand(
            UserTestUtilities.ValidName,
            null!,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidFormFile
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Email);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.EmailMinLength - 1)]
    [InlineData(UserConfigurations.EmailMaxLength + 1)]
    public void TestValidate_ShouldHaveAnErrorForEmail_WhenEmailLengthIsInvalid(int length)
    {
        // Arrange
        var command = new AddUserCommand(
            UserTestUtilities.ValidName,
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidFormFile
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
        var command = new AddUserCommand(
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidEmail,
            null!,
            null!,
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidFormFile
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
        var command = new AddUserCommand(
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidEmail,
            invalidPassword,
            invalidPassword,
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidFormFile
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
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidEmail,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.InvalidPassword,
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidFormFile
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
        var command = new AddUserCommand(
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidEmail,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidPassword,
            null!,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidFormFile
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.FirstName);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.FirstNameMinLength - 1)]
    [InlineData(UserConfigurations.FirstNameMaxLength + 1)]
    public void TestValidate_ShouldHaveAnErrorForFirstName_WhenFirstNameLengthIsInvalid(int length)
    {
        // Arrange
        var command = new AddUserCommand(
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidEmail,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidPassword,
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidFormFile
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
        var command = new AddUserCommand(
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidEmail,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidFirstName,
            null!,
            UserTestUtilities.ValidFormFile
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.LastName);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.LastNameMinLength - 1)]
    [InlineData(UserConfigurations.LastNameMaxLength + 1)]
    public void TestValidate_ShouldHaveAnErrorForLastName_WhenLastNameLengthIsInvalid(int length)
    {
        // Arrange
        var command = new AddUserCommand(
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidEmail,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidFirstName,
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidFormFile
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
        var command = new AddUserCommand(
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidEmail,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidFormFile
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
        var command = new AddUserCommand(
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidEmail,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            null
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
