using FluentValidation.TestHelper;
using InstaConnect.Messages.Application.Features.Messages.Commands.AddMessage;
using InstaConnect.Messages.Application.UnitTests.Features.Messages.Utilities;
using InstaConnect.Messages.Common.Features.Messages.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Messages.Application.UnitTests.Features.Messages.Commands.AddMessage;

public class AddMessageCommandValidatorUnitTests : BaseMessageUnitTest
{
    private readonly AddMessageCommandValidator _commandValidator;

    public AddMessageCommandValidatorUnitTests()
    {
        _commandValidator = new AddMessageCommandValidator();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForCurrentUserId_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var command = new AddMessageCommand(
            null!,
            MessageTestUtilities.ValidReceiverId,
            MessageTestUtilities.ValidContent
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.CurrentUserId);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(MessageBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForCurrentUserId_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var command = new AddMessageCommand(
            SharedTestUtilities.GetString(length)!,
            MessageTestUtilities.ValidReceiverId,
            MessageTestUtilities.ValidContent
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.CurrentUserId);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForReceiverId_WhenReceiverIsNull()
    {
        // Arrange
        var command = new AddMessageCommand(
            MessageTestUtilities.ValidCurrentUserId,
            null!,
            MessageTestUtilities.ValidContent
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.ReceiverId);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(MessageBusinessConfigurations.RECEIVER_ID_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.RECEIVER_ID_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForReceiverId_WhenReceiverIdLengthIsInvalid(int length)
    {
        // Arrange
        var command = new AddMessageCommand(
            MessageTestUtilities.ValidCurrentUserId,
            SharedTestUtilities.GetString(length)!,
            MessageTestUtilities.ValidContent
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.ReceiverId);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForContent_WhenContentIsNull()
    {
        // Arrange
        var command = new AddMessageCommand(
            MessageTestUtilities.ValidCurrentUserId,
            MessageTestUtilities.ValidReceiverId,
            null!
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Content);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(MessageBusinessConfigurations.CONTENT_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.CONTENT_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForContent_WhenContentLengthIsInvalid(int length)
    {
        // Arrange
        var command = new AddMessageCommand(
            MessageTestUtilities.ValidCurrentUserId,
            MessageTestUtilities.ValidReceiverId,
            SharedTestUtilities.GetString(length)
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Content);
    }

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenModelIsValid()
    {
        // Arrange
        var command = new AddMessageCommand(
            MessageTestUtilities.ValidCurrentUserId,
            MessageTestUtilities.ValidReceiverId,
            MessageTestUtilities.ValidContent);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
