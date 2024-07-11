using FluentValidation.TestHelper;
using InstaConnect.Messages.Write.Business.Commands.Messages.AddMessage;
using InstaConnect.Messages.Write.Business.Commands.Messages.DeleteMessage;
using InstaConnect.Messages.Write.Business.Commands.Messages.UpdateMessage;
using InstaConnect.Messages.Write.Business.UnitTests.Utilities;
using InstaConnect.Messages.Write.Business.Utilities;

namespace InstaConnect.Messages.Write.Business.UnitTests.Commands.AddMessage;

public class UpdateMessageCommandValidatorUnitTests : BaseMessageUnitTest
{
    private readonly UpdateMessageCommandValidator _validator;

    public UpdateMessageCommandValidatorUnitTests()
    {
        _validator = new UpdateMessageCommandValidator();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdIsNull()
    {
        // Arrange
        var command = new UpdateMessageCommand
        {
            Id = null!,
            CurrentUserId = ValidCurrentUserId,
        };

        // Act
        var result = _validator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Id);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(MessageBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var command = new UpdateMessageCommand
        {
            Id = Faker.Random.AlphaNumeric(length),
            CurrentUserId = ValidCurrentUserId,
            Content = ValidContent
        };

        // Act
        var result = _validator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Id);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForCurrentUserId_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var command = new UpdateMessageCommand
        {
            Id = ValidId,
            CurrentUserId = null!,
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
        var command = new UpdateMessageCommand
        {
            Id = ValidId,
            CurrentUserId = Faker.Random.AlphaNumeric(length),
            Content = ValidContent
        };

        // Act
        var result = _validator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.CurrentUserId);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForContent_WhenContentIsNull()
    {
        // Arrange
        var command = new UpdateMessageCommand
        {
            Id = ValidId,
            CurrentUserId = ValidCurrentUserId,
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
        var command = new UpdateMessageCommand
        {
            Id = ValidId,
            CurrentUserId = ValidCurrentUserId,
            Content = Faker.Random.AlphaNumeric(length)
        };

        // Act
        var result = _validator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Content);
    }
}
