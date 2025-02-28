using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Commands.Add;

namespace InstaConnect.Identity.Application.UnitTests.Features.ForgotPasswordTokens.Commands.Add;

public class AddForgotPasswordTokenCommandValidatorUnitTests : BaseForgotPasswordTokenUnitTest
{
    private readonly AddForgotPasswordTokenCommandValidator _commandValidator;

    public AddForgotPasswordTokenCommandValidatorUnitTests()
    {
        _commandValidator = new AddForgotPasswordTokenCommandValidator();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForEmail_WhenEmailIsNull()
    {
        // Arrange
        var command = new AddForgotPasswordTokenCommand(null);

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
        var command = new AddForgotPasswordTokenCommand(SharedTestUtilities.GetString(length));

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Email);
    }

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenModelIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var command = new AddForgotPasswordTokenCommand(existingUser.Email);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
