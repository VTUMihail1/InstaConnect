using FluentValidation.TestHelper;
using InstaConnect.Identity.Business.Features.Users.Commands.ConfirmUserEmail;
using InstaConnect.Identity.Business.UnitTests.Features.Users.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Identity.Business.UnitTests.Features.Users.Commands.ConfirmUserEmail;

public class ConfirmUserEmailCommandValidatorUnitTests : BaseUserUnitTest
{
    private readonly ConfirmUserEmailCommandValidator _commandValidator;

    public ConfirmUserEmailCommandValidatorUnitTests()
    {
        _commandValidator = new ConfirmUserEmailCommandValidator();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForUserId_WhenUserIdIsNull()
    {
        // Arrange
        var command = new ConfirmUserEmailCommand(
            null!,
            UserTestUtilities.ValidEmailConfirmationTokenValue);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.UserId);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(UserBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForUserId_WhenUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var command = new ConfirmUserEmailCommand(
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidEmailConfirmationTokenValue);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.UserId);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForTokenId_WhenTokenIdIsNull()
    {
        // Arrange
        var command = new ConfirmUserEmailCommand(
            UserTestUtilities.ValidId,
            null!);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Token);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserBusinessConfigurations.TOKEN_MIN_LENGTH - 1)]
    [InlineData(UserBusinessConfigurations.TOKEN_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForToken_WhenTokenLengthIsInvalid(int length)
    {
        // Arrange
        var command = new ConfirmUserEmailCommand(
            UserTestUtilities.ValidId,
            SharedTestUtilities.GetString(length));

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Token);
    }

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenModelIsValid()
    {
        // Arrange
        var command = new ConfirmUserEmailCommand(
            UserTestUtilities.ValidId,
            UserTestUtilities.ValidEmailConfirmationTokenValue);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
