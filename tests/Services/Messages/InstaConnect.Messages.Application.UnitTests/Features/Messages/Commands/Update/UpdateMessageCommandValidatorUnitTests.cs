using FluentValidation.TestHelper;
using InstaConnect.Messages.Application.Features.Messages.Commands.UpdateMessage;
using InstaConnect.Messages.Application.UnitTests.Features.Messages.Utilities;
using InstaConnect.Messages.Common.Features.Messages.Utilities;
using InstaConnect.Messages.Common.Features.Users.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Messages.Application.UnitTests.Features.Messages.Commands.UpdateMessage;

public class UpdateMessageCommandValidatorUnitTests : BaseMessageUnitTest
{
    private readonly UpdateMessageCommandValidator _commandValidator;

    public UpdateMessageCommandValidatorUnitTests()
    {
        _commandValidator = new UpdateMessageCommandValidator();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdIsNull()
    {
        // Arrange
        var existingMessage = CreateMessage();
        var command = new UpdateMessageCommand(
            null!,
            MessageTestUtilities.ValidUpdateContent,
            existingMessage.SenderId
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Id);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(MessageConfigurations.IdMinLength - 1)]
    [InlineData(MessageConfigurations.IdMaxLength + 1)]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingMessage = CreateMessage();
        var command = new UpdateMessageCommand(
            SharedTestUtilities.GetString(length),
            MessageTestUtilities.ValidUpdateContent,
            existingMessage.SenderId
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Id);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForCurrentUserId_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var existingMessage = CreateMessage();
        var command = new UpdateMessageCommand(
            existingMessage.Id,
            MessageTestUtilities.ValidUpdateContent,
            null!
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
        var command = new UpdateMessageCommand(
            existingMessage.Id,
            MessageTestUtilities.ValidUpdateContent,
            SharedTestUtilities.GetString(length)
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.CurrentUserId);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForContent_WhenContentIsNull()
    {
        // Arrange
        var existingMessage = CreateMessage();
        var command = new UpdateMessageCommand(
            existingMessage.Id,
            null!,
            existingMessage.SenderId
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
        var command = new UpdateMessageCommand(
            existingMessage.Id,
            SharedTestUtilities.GetString(length),
            existingMessage.SenderId
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
        var command = new UpdateMessageCommand(
            existingMessage.Id,
            MessageTestUtilities.ValidUpdateContent,
            existingMessage.SenderId
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
