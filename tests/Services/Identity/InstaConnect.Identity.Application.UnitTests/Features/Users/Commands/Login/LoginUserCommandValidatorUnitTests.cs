using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Identity.Application.Features.Users.Commands.Login;
using InstaConnect.Identity.Common.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Application.UnitTests.Features.Users.Commands.Login;

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
            null,
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
        var existingUserClaim = CreateUserClaim();
        var command = new LoginUserCommand(
            existingUserClaim.User.Email,
            null
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
        var existingUserClaim = CreateUserClaim();
        var command = new LoginUserCommand(
            existingUserClaim.User.Email,
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
        var existingUserClaim = CreateUserClaim();
        var command = new LoginUserCommand(
            existingUserClaim.User.Email,
            UserTestUtilities.ValidPassword
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
