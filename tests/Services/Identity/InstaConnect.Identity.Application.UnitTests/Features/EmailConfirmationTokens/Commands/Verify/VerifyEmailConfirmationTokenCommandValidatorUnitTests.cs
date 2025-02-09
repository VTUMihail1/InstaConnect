using FluentValidation.TestHelper;
using InstaConnect.Identity.Application.Features.Users.Commands.ConfirmUserEmail;
using InstaConnect.Identity.Application.UnitTests.Features.Users.Utilities;
using InstaConnect.Identity.Common.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Identity.Application.UnitTests.Features.Users.Commands.ConfirmUserEmail;

public class VerifyEmailConfirmationTokenCommandValidatorUnitTests : BaseEmailConfirmationTokenUnitTest
{
    private readonly VerifyEmailConfirmationTokenCommandValidator _commandValidator;

    public VerifyEmailConfirmationTokenCommandValidatorUnitTests()
    {
        _commandValidator = new VerifyEmailConfirmationTokenCommandValidator();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForUserId_WhenUserIdIsNull()
    {
        // Arrange
        var existingEmailConfirmationToken = CreateEmailConfirmationToken();
        var command = new VerifyEmailConfirmationTokenCommand(
            null!,
            existingEmailConfirmationToken.Value);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.UserId);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public void TestValidate_ShouldHaveAnErrorForUserId_WhenUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingEmailConfirmationToken = CreateEmailConfirmationToken();
        var command = new VerifyEmailConfirmationTokenCommand(
            SharedTestUtilities.GetString(length),
            existingEmailConfirmationToken.Value);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.UserId);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForTokenId_WhenTokenIdIsNull()
    {
        // Arrange
        var existingEmailConfirmationToken = CreateEmailConfirmationToken();
        var command = new VerifyEmailConfirmationTokenCommand(
            existingEmailConfirmationToken.UserId,
            null!);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Token);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(EmailConfirmationTokenConfigurations.ValueMinLength - 1)]
    [InlineData(EmailConfirmationTokenConfigurations.ValueMaxLength + 1)]
    public void TestValidate_ShouldHaveAnErrorForToken_WhenTokenLengthIsInvalid(int length)
    {
        // Arrange
        var existingEmailConfirmationToken = CreateEmailConfirmationToken();
        var command = new VerifyEmailConfirmationTokenCommand(
            existingEmailConfirmationToken.UserId,
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
        var existingEmailConfirmationToken = CreateEmailConfirmationToken();
        var command = new VerifyEmailConfirmationTokenCommand(
            existingEmailConfirmationToken.UserId,
            existingEmailConfirmationToken.Value);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
