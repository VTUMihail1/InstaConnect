using FluentValidation.TestHelper;
using InstaConnect.Identity.Business.Features.Accounts.Commands.EditCurrentAccount;
using InstaConnect.Identity.Business.Features.Accounts.Utilities;
using InstaConnect.Identity.Business.UnitTests.Features.Accounts.Utilities;

namespace InstaConnect.Identity.Business.UnitTests.Features.Accounts.Commands.EditCurrentAccount;

public class EditCurrentAccountCommandValidatorUnitTests : BaseAccountUnitTest
{
    private readonly EditCurrentAccountCommandValidator _commandValidator;

    public EditCurrentAccountCommandValidatorUnitTests()
    {
        _commandValidator = new EditCurrentAccountCommandValidator();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForCurrentUserId_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var command = new EditCurrentAccountCommand(
            null!,
            ValidFirstName,
            ValidLastName,
            ValidName,
            ValidFormFile
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.CurrentUserId);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(AccountBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(AccountBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForCurrentUserId_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var command = new EditCurrentAccountCommand(
            Faker.Random.AlphaNumeric(length),
            ValidFirstName,
            ValidLastName,
            ValidName,
            ValidFormFile
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.CurrentUserId);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForFirstName_WhenFirstNameIsNull()
    {
        // Arrange
        var command = new EditCurrentAccountCommand(
            ValidId,
            null!,
            ValidLastName,
            ValidName,
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
        var command = new EditCurrentAccountCommand(
            ValidId,
            Faker.Random.AlphaNumeric(length),
            ValidLastName,
            ValidName,
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
        var command = new EditCurrentAccountCommand(
            ValidId,
            ValidFirstName,
            null!,
            ValidName,
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
        var command = new EditCurrentAccountCommand(
            ValidId,
            ValidFirstName,
            Faker.Random.AlphaNumeric(length),
            ValidName,
            ValidFormFile
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.LastName);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForUserName_WhenUserNameIsNull()
    {
        // Arrange
        var command = new EditCurrentAccountCommand(
            ValidId,
            ValidFirstName,
            ValidLastName,
            null!,
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
    public void TestValidate_ShouldHaveAnErrorForUserName_WhenUserNameLengthIsInvalid(int length)
    {
        // Arrange
        var command = new EditCurrentAccountCommand(
            ValidId,
            ValidFirstName,
            ValidLastName,
            Faker.Random.AlphaNumeric(length),
            ValidFormFile
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.UserName);
    }

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenModelIsValid()
    {
        // Arrange
        var command = new EditCurrentAccountCommand(
            ValidId,
            ValidFirstName,
            ValidLastName,
            ValidName,
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
        var command = new EditCurrentAccountCommand(
            ValidId,
            ValidFirstName,
            ValidLastName,
            ValidName,
            null
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
