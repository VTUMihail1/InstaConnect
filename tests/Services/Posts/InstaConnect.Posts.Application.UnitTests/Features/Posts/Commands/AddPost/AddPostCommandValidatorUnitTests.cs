using FluentValidation.TestHelper;
using InstaConnect.Posts.Application.Features.Posts.Commands.AddPost;
using InstaConnect.Posts.Application.UnitTests.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Posts.Application.UnitTests.Features.Posts.Commands.AddPost;

public class AddPostCommandValidatorUnitTests : BasePostUnitTest
{
    private readonly AddPostCommandValidator _commandValidator;

    public AddPostCommandValidatorUnitTests()
    {
        _commandValidator = new AddPostCommandValidator();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForCurrentUserId_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var command = new AddPostCommand(
            null!,
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidContent);

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
        var command = new AddPostCommand(
            SharedTestUtilities.GetString(length)!,
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidContent);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.CurrentUserId);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForTitle_WhenTitleIsNull()
    {
        // Arrange
        var command = new AddPostCommand(
            PostTestUtilities.ValidCurrentUserId,
            null!,
            PostTestUtilities.ValidContent);

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
        var command = new AddPostCommand(
            PostTestUtilities.ValidCurrentUserId,
            SharedTestUtilities.GetString(length)!,
            PostTestUtilities.ValidContent);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Title);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForContent_WhenContentIsNull()
    {
        // Arrange
        var command = new AddPostCommand(
            PostTestUtilities.ValidCurrentUserId,
            PostTestUtilities.ValidTitle,
            null!);

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
        var command = new AddPostCommand(
            PostTestUtilities.ValidCurrentUserId,
            PostTestUtilities.ValidTitle,
            SharedTestUtilities.GetString(length)!);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Content);
    }

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenModelIsValid()
    {
        // Arrange
        var command = new AddPostCommand(
            PostTestUtilities.ValidCurrentUserId,
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidContent
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
