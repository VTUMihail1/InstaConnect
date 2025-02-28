using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Commands.Add;

namespace InstaConnect.Identity.Application.UnitTests.Features.EmailConfirmationTokens.Commands.Add;

public class AddEmailConfirmationTokenCommandValidatorUnitTests : BaseEmailConfirmationTokenUnitTest
{
    private readonly AddEmailConfirmationTokenCommandValidator _commandValidator;

    public AddEmailConfirmationTokenCommandValidatorUnitTests()
    {
        _commandValidator = new AddEmailConfirmationTokenCommandValidator();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForEmail_WhenEmailIsNull()
    {
        // Arrange
        var command = new AddEmailConfirmationTokenCommand(null);

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
        var command = new AddEmailConfirmationTokenCommand(SharedTestUtilities.GetString(length));

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
        var command = new AddEmailConfirmationTokenCommand(existingUser.Email);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
