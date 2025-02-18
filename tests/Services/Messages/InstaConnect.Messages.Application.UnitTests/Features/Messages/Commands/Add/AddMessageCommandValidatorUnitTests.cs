using InstaConnect.Messages.Application.Features.Messages.Commands.Add;

namespace InstaConnect.Messages.Application.UnitTests.Features.Messages.Commands.Add;

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
        var existingReceiver = CreateUser();
        var command = new AddMessageCommand(
            null!,
            existingReceiver.Id,
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
        var existingReceiver = CreateUser();
        var command = new AddMessageCommand(
            SharedTestUtilities.GetString(length)!,
            existingReceiver.Id,
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
        var existingSender = CreateUser();
        var command = new AddMessageCommand(
            existingSender.Id,
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
        var existingSender = CreateUser();
        var command = new AddMessageCommand(
            existingSender.Id,
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
        var existingSender = CreateUser();
        var existingReceiver = CreateUser();
        var command = new AddMessageCommand(
            existingSender.Id,
            existingReceiver.Id,
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
        var existingSender = CreateUser();
        var existingReceiver = CreateUser();
        var command = new AddMessageCommand(
            existingSender.Id,
            existingReceiver.Id,
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
        var existingSender = CreateUser();
        var existingReceiver = CreateUser();
        var command = new AddMessageCommand(
            existingSender.Id,
            existingReceiver.Id,
            MessageTestUtilities.ValidAddContent);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
