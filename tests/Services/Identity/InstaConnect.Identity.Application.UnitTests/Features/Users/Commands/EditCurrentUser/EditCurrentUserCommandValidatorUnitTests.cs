using FluentValidation.TestHelper;
using InstaConnect.Identity.Application.Features.Users.Commands.EditCurrentUser;
using InstaConnect.Identity.Application.UnitTests.Features.Users.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Identity.Application.UnitTests.Features.Users.Commands.EditCurrentUser;

public class EditCurrentUserCommandValidatorUnitTests : BaseUserUnitTest
{
    private readonly EditCurrentUserCommandValidator _commandValidator;

    public EditCurrentUserCommandValidatorUnitTests()
    {
        _commandValidator = new EditCurrentUserCommandValidator();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForCurrentUserId_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var command = new EditCurrentUserCommand(
            null!,
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidFormFile
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.CurrentUserId);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(UserBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForCurrentUserId_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var command = new EditCurrentUserCommand(
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidFormFile
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
        var command = new EditCurrentUserCommand(
            UserTestUtilities.ValidId,
            null!,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidFormFile
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
        var command = new EditCurrentUserCommand(
            UserTestUtilities.ValidId,
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidName,
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
        var command = new EditCurrentUserCommand(
            UserTestUtilities.ValidId,
            UserTestUtilities.ValidFirstName,
            null!,
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidFormFile
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
        var command = new EditCurrentUserCommand(
            UserTestUtilities.ValidId,
            UserTestUtilities.ValidFirstName,
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidFormFile
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
        var command = new EditCurrentUserCommand(
            UserTestUtilities.ValidId,
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            null!,
            UserTestUtilities.ValidFormFile
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
    public void TestValidate_ShouldHaveAnErrorForUserName_WhenUserNameLengthIsInvalid(int length)
    {
        // Arrange
        var command = new EditCurrentUserCommand(
            UserTestUtilities.ValidId,
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidFormFile
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
        var command = new EditCurrentUserCommand(
            UserTestUtilities.ValidId,
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidName,
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
        var command = new EditCurrentUserCommand(
            UserTestUtilities.ValidId,
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidName,
            null
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
