using FluentValidation.TestHelper;
using InstaConnect.Messages.Application.Features.Messages.Commands.DeleteMessage;
using InstaConnect.Messages.Application.UnitTests.Features.Messages.Utilities;
using InstaConnect.Messages.Common.Features.Messages.Utilities;
using InstaConnect.Messages.Common.Features.Users.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Messages.Application.UnitTests.Features.Messages.Commands.DeleteMessage;

public class DeleteMessageCommandValidatorUnitTests : BaseMessageUnitTest
{
    private readonly DeleteMessageCommandValidator _commandValidator;

    public DeleteMessageCommandValidatorUnitTests()
    {
        _commandValidator = new DeleteMessageCommandValidator();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdIsNull()
    {
        // Arrange
        var existingMessage = CreateMessage();
        var command = new DeleteMessageCommand(
            null!,
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
        var command = new DeleteMessageCommand(
            SharedTestUtilities.GetString(length),
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
        var command = new DeleteMessageCommand(
            existingMessage.Id,
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
        var command = new DeleteMessageCommand(
            existingMessage.Id,
            SharedTestUtilities.GetString(length)
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.CurrentUserId);
    }

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenModelIsValid()
    {
        // Arrange
        var existingMessage = CreateMessage();
        var command = new DeleteMessageCommand(
            existingMessage.Id,
            existingMessage.SenderId
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
