using FluentValidation.TestHelper;
using InstaConnect.Messages.Application.Features.Messages.Commands.AddMessage;
using InstaConnect.Messages.Application.UnitTests.Features.Messages.Utilities;
using InstaConnect.Messages.Common.Features.Messages.Utilities;
using InstaConnect.Messages.Common.Features.Users.Utilities;
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
        var existingMessage = CreateMessage();
        var command = new AddMessageCommand(
            null!,
            existingMessage.ReceiverId,
            MessageTestUtilities.ValidAddContent
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.CurrentUserId);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public void TestValidate_ShouldHaveAnErrorForCurrentUserId_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingMessage = CreateMessage();
        var command = new AddMessageCommand(
            SharedTestUtilities.GetString(length)!,
            existingMessage.ReceiverId,
            MessageTestUtilities.ValidAddContent
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
        var existingMessage = CreateMessage();
        var command = new AddMessageCommand(
            existingMessage.SenderId,
            null!,
            MessageTestUtilities.ValidAddContent
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.ReceiverId);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public void TestValidate_ShouldHaveAnErrorForReceiverId_WhenReceiverIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingMessage = CreateMessage();
        var command = new AddMessageCommand(
            existingMessage.SenderId,
            SharedTestUtilities.GetString(length)!,
            MessageTestUtilities.ValidAddContent
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
        var existingMessage = CreateMessage();
        var command = new AddMessageCommand(
            existingMessage.SenderId,
            existingMessage.ReceiverId,
            null!
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Content);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(MessageConfigurations.ContentMinLength - 1)]
    [InlineData(MessageConfigurations.ContentMaxLength + 1)]
    public void TestValidate_ShouldHaveAnErrorForContent_WhenContentLengthIsInvalid(int length)
    {
        // Arrange
        var existingMessage = CreateMessage();
        var command = new AddMessageCommand(
            existingMessage.SenderId,
            existingMessage.ReceiverId,
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
        var existingMessage = CreateMessage();
        var command = new AddMessageCommand(
            existingMessage.SenderId,
            existingMessage.ReceiverId,
            MessageTestUtilities.ValidAddContent);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
