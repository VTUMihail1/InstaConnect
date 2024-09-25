using FluentValidation.TestHelper;
using InstaConnect.Identity.Business.Features.Accounts.Commands.ConfirmAccountEmail;
using InstaConnect.Identity.Business.Features.Accounts.Utilities;
using InstaConnect.Identity.Business.UnitTests.Features.Accounts.Utilities;

namespace InstaConnect.Identity.Business.UnitTests.Features.Accounts.Commands.ConfirmAccountEmail;

public class ConfirmAccountEmailCommandValidatorUnitTests : BaseAccountUnitTest
{
    private readonly ConfirmAccountEmailCommandValidator _commandValidator;

    public ConfirmAccountEmailCommandValidatorUnitTests()
    {
        _commandValidator = new ConfirmAccountEmailCommandValidator();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForUserId_WhenUserIdIsNull()
    {
        // Arrange
        var command = new ConfirmAccountEmailCommand(
            null!,
            ValidEmailConfirmationTokenValue);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.UserId);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(AccountBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(AccountBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForUserId_WhenUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var command = new ConfirmAccountEmailCommand(
            Faker.Random.AlphaNumeric(length),
            ValidEmailConfirmationTokenValue);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.UserId);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForTokenId_WhenTokenIdIsNull()
    {
        // Arrange
        var command = new ConfirmAccountEmailCommand(
            ValidId,
            null!);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Token);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(AccountBusinessConfigurations.TOKEN_MIN_LENGTH - 1)]
    [InlineData(AccountBusinessConfigurations.TOKEN_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForToken_WhenTokenLengthIsInvalid(int length)
    {
        // Arrange
        var command = new ConfirmAccountEmailCommand(
            ValidId,
            Faker.Random.AlphaNumeric(length));

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Token);
    }

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenModelIsValid()
    {
        // Arrange
        var command = new ConfirmAccountEmailCommand(
            ValidId,
            ValidEmailConfirmationTokenValue);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
