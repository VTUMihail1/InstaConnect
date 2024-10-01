using FluentValidation.TestHelper;
using InstaConnect.Identity.Business.Features.Users.Commands.ResendUserEmailConfirmation;
using InstaConnect.Identity.Business.UnitTests.Features.Users.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;

namespace InstaConnect.Identity.Business.UnitTests.Features.Users.Commands.ResendUserEmailConfirmation;

public class ResendUserEmailConfirmationCommandValidatorUnitTests : BaseUserUnitTest
{
    private readonly ResendUserEmailConfirmationCommandValidator _commandValidator;

    public ResendUserEmailConfirmationCommandValidatorUnitTests()
    {
        _commandValidator = new ResendUserEmailConfirmationCommandValidator();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForEmail_WhenEmailIsNull()
    {
        // Arrange
        var command = new ResendUserEmailConfirmationCommand(null!);

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
        var command = new ResendUserEmailConfirmationCommand(Faker.Random.AlphaNumeric(length));

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Email);
    }

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenModelIsValid()
    {
        // Arrange
        var command = new ResendUserEmailConfirmationCommand(UserTestUtilities.ValidEmail);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
