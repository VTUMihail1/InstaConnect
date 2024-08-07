using FluentValidation.TestHelper;
using InstaConnect.Posts.Business.Features.Posts.Commands.UpdatePost;
using InstaConnect.Posts.Business.Features.Posts.Utilities;
using InstaConnect.Posts.Business.UnitTests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Business.UnitTests.Features.Posts.Commands.UpdatePost;

public class UpdatePostCommandValidatorUnitTests : BasePostUnitTest
{
    private readonly UpdatePostCommandValidator _commandValidator;

    public UpdatePostCommandValidatorUnitTests()
    {
        _commandValidator = new UpdatePostCommandValidator();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdIsNull()
    {
        // Arrange
        var command = new UpdatePostCommand(
            null!,
            ValidCurrentUserId,
            ValidTitle,
            ValidContent
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Id);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(PostBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var command = new UpdatePostCommand(
            Faker.Random.AlphaNumeric(length),
            ValidCurrentUserId,
            ValidTitle,
            ValidContent
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
        var command = new UpdatePostCommand(
            ValidId,
            null!,
            ValidTitle,
            ValidContent
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.CurrentUserId);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH - 1)]
    [InlineData(PostBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForCurrentUserId_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var command = new UpdatePostCommand(
            ValidId,
            Faker.Random.AlphaNumeric(length),
            ValidTitle,
            ValidContent
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.CurrentUserId);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForTitle_WhenTitleIsNull()
    {
        // Arrange
        var command = new UpdatePostCommand(
            ValidId,
            ValidCurrentUserId,
            null!,
            ValidContent
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Title);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostBusinessConfigurations.TITLE_MIN_LENGTH - 1)]
    [InlineData(PostBusinessConfigurations.TITLE_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForTitle_WhenTitleLengthIsInvalid(int length)
    {
        // Arrange
        var command = new UpdatePostCommand(
            ValidId,
            ValidCurrentUserId,
            Faker.Random.AlphaNumeric(length),
            ValidContent
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Title);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForContent_WhenContentIsNull()
    {
        // Arrange
        var command = new UpdatePostCommand(
            ValidId,
            ValidCurrentUserId,
            ValidTitle,
            null!
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Content);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostBusinessConfigurations.CONTENT_MIN_LENGTH - 1)]
    [InlineData(PostBusinessConfigurations.CONTENT_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForContent_WhenContentLengthIsInvalid(int length)
    {
        // Arrange
        var command = new UpdatePostCommand(
            ValidId,
            ValidCurrentUserId,
            ValidTitle,
            Faker.Random.AlphaNumeric(length)
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Content);
    }
}
