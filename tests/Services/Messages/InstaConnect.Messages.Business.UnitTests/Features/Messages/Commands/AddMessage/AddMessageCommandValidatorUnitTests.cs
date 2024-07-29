using FluentValidation.TestHelper;
using InstaConnect.Messages.Business.Features.Messages.Commands.AddMessage;
using InstaConnect.Messages.Business.Features.Messages.Utilities;
using InstaConnect.Messages.Business.UnitTests.Utilities;

namespace InstaConnect.Messages.Business.UnitTests.Features.Messages.Commands.AddMessage;

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
            ValidReceiverId,
            ValidContent
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
            Faker.Random.AlphaNumeric(length)!,
            ValidReceiverId,
            ValidContent
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
            ValidCurrentUserId,
            null!,
            ValidContent
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
            ValidCurrentUserId,
            Faker.Random.AlphaNumeric(length)!,
            ValidContent
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
            ValidCurrentUserId,
            ValidReceiverId,
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
            ValidCurrentUserId,
            ValidReceiverId,
            Faker.Random.AlphaNumeric(length)!
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Content);
    }
}
