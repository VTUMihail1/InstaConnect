using FluentValidation.TestHelper;
using InstaConnect.Identity.Business.Features.Accounts.Commands.ResendAccountEmailConfirmation;
using InstaConnect.Identity.Business.Features.Accounts.Utilities;
using InstaConnect.Identity.Business.UnitTests.Features.Accounts.Utilities;

namespace InstaConnect.Identity.Business.UnitTests.Features.Accounts.Commands.ResendAccountEmailConfirmation;

public class ResendAccountEmailConfirmationCommandValidatorUnitTests : BaseAccountUnitTest
{
    private readonly ResendAccountEmailConfirmationCommandValidator _commandValidator;

    public ResendAccountEmailConfirmationCommandValidatorUnitTests()
    {
        _commandValidator = new ResendAccountEmailConfirmationCommandValidator();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForEmail_WhenEmailIsNull()
    {
        // Arrange
        var command = new ResendAccountEmailConfirmationCommand(null!);

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
        var command = new ResendAccountEmailConfirmationCommand(Faker.Random.AlphaNumeric(length));

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Email);
    }

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenModelIsValid()
    {
        // Arrange
        var command = new ResendAccountEmailConfirmationCommand(ValidEmail);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
