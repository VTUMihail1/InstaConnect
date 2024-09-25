using FluentValidation.TestHelper;
using InstaConnect.Identity.Business.Features.Accounts.Commands.SendAccountPasswordReset;
using InstaConnect.Identity.Business.Features.Accounts.Utilities;
using InstaConnect.Identity.Business.UnitTests.Features.Accounts.Utilities;

namespace InstaConnect.Identity.Business.UnitTests.Features.Accounts.Commands.SendAccountPasswordReset;

public class SendAccountPasswordResetCommandValidatorUnitTests : BaseAccountUnitTest
{
    private readonly SendAccountPasswordResetCommandValidator _commandValidator;

    public SendAccountPasswordResetCommandValidatorUnitTests()
    {
        _commandValidator = new SendAccountPasswordResetCommandValidator();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForEmail_WhenEmailIsNull()
    {
        // Arrange
        var command = new SendAccountPasswordResetCommand(null!);

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
        var command = new SendAccountPasswordResetCommand(Faker.Random.AlphaNumeric(length));

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Email);
    }

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenModelIsValid()
    {
        // Arrange
        var command = new SendAccountPasswordResetCommand(ValidEmail);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
