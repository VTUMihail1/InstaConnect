using FluentValidation.TestHelper;
using InstaConnect.Identity.Application.Features.Users.Commands.LoginUser;
using InstaConnect.Identity.Application.UnitTests.Features.Users.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Identity.Application.UnitTests.Features.Users.Commands.LoginUser;

public class LoginUserCommandValidatorUnitTests : BaseUserUnitTest
{
    private readonly LoginUserCommandValidator _commandValidator;

    public LoginUserCommandValidatorUnitTests()
    {
        _commandValidator = new LoginUserCommandValidator();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForEmail_WhenEmailIsNull()
    {
        // Arrange
        var command = new LoginUserCommand(
            null!,
            UserTestUtilities.ValidPassword
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
        var command = new LoginUserCommand(
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidPassword
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
        var command = new LoginUserCommand(
            UserTestUtilities.ValidEmail,
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
        var command = new LoginUserCommand(
            UserTestUtilities.ValidEmail,
            SharedTestUtilities.GetString(length)
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Password);
    }

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenModelIsValid()
    {
        // Arrange
        var command = new LoginUserCommand(
            UserTestUtilities.ValidEmail,
            UserTestUtilities.ValidPassword
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
