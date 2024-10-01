using FluentValidation.TestHelper;
using InstaConnect.Identity.Business.Features.Users.Commands.SendUserPasswordReset;
using InstaConnect.Identity.Business.UnitTests.Features.Users.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;

namespace InstaConnect.Identity.Business.UnitTests.Features.Users.Commands.SendUserPasswordReset;

public class SendUserPasswordResetCommandValidatorUnitTests : BaseUserUnitTest
{
    private readonly SendUserPasswordResetCommandValidator _commandValidator;

    public SendUserPasswordResetCommandValidatorUnitTests()
    {
        _commandValidator = new SendUserPasswordResetCommandValidator();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForEmail_WhenEmailIsNull()
    {
        // Arrange
        var command = new SendUserPasswordResetCommand(null!);

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
        var command = new SendUserPasswordResetCommand(Faker.Random.AlphaNumeric(length));

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Email);
    }

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenModelIsValid()
    {
        // Arrange
        var command = new SendUserPasswordResetCommand(UserTestUtilities.ValidEmail);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
