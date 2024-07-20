using FluentValidation.TestHelper;
using InstaConnect.Messages.Business.Commands.Messages.AddMessage;
using InstaConnect.Messages.Business.UnitTests.Utilities;
using InstaConnect.Messages.Business.Utilities;

namespace InstaConnect.Messages.Business.UnitTests.Tests.Commands.AddMessage;

public class AddMessageCommandValidatorUnitTests : BaseMessageUnitTest
{
    private readonly AddMessageCommandValidator _validator;

    public AddMessageCommandValidatorUnitTests()
    {
        _validator = new AddMessageCommandValidator();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForCurrentUserId_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var command = new AddMessageCommand
        {
            CurrentUserId = null!,
            ReceiverId = ValidReceiverId,
            Content = ValidContent
        };

        // Act
        var result = _validator.TestValidate(command);

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
        var command = new AddMessageCommand
        {
            CurrentUserId = Faker.Random.AlphaNumeric(length)!,
            ReceiverId = ValidReceiverId,
            Content = ValidContent
        };

        // Act
        var result = _validator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.CurrentUserId);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForReceiverId_WhenReceiverIsNull()
    {
        // Arrange
        var command = new AddMessageCommand
        {
            CurrentUserId = ValidCurrentUserId,
            ReceiverId = null!,
            Content = ValidContent
        };

        // Act
        var result = _validator.TestValidate(command);

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
        var command = new AddMessageCommand
        {
            CurrentUserId = ValidCurrentUserId,
            ReceiverId = Faker.Random.AlphaNumeric(length)!,
            Content = ValidContent
        };

        // Act
        var result = _validator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.ReceiverId);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForContent_WhenContentIsNull()
    {
        // Arrange
        var command = new AddMessageCommand
        {
            CurrentUserId = ValidCurrentUserId,
            ReceiverId = ValidReceiverId,
            Content = null!
        };

        // Act
        var result = _validator.TestValidate(command);

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
        var command = new AddMessageCommand
        {
            CurrentUserId = ValidCurrentUserId,
            ReceiverId = ValidReceiverId,
            Content = Faker.Random.AlphaNumeric(length)!
        };

        // Act
        var result = _validator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Content);
    }
}
