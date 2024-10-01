using FluentValidation.TestHelper;
using InstaConnect.Posts.Business.Features.PostComments.Commands.AddPostComment;
using InstaConnect.Posts.Business.UnitTests.Features.PostComments.Utilities;
using InstaConnect.Posts.Common.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Business.UnitTests.Features.PostComments.Commands.AddComment;

public class AddPostCommentCommandValidatorUnitTests : BasePostCommentUnitTest
{
    private readonly AddPostCommentCommandValidator _commandValidator;

    public AddPostCommentCommandValidatorUnitTests()
    {
        _commandValidator = new AddPostCommentCommandValidator();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForCurrentUserId_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var command = new AddPostCommentCommand(
            null!,
            PostCommentTestUtilities.ValidPostId,
            PostCommentTestUtilities.ValidContent);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.CurrentUserId);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostCommentBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH - 1)]
    [InlineData(PostCommentBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForCurrentUserId_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var command = new AddPostCommentCommand(
            Faker.Random.AlphaNumeric(length)!,
            PostCommentTestUtilities.ValidPostId,
            PostCommentTestUtilities.ValidContent);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.CurrentUserId);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForPostId_WhenPostIdIsNull()
    {
        // Arrange
        var command = new AddPostCommentCommand(
            PostCommentTestUtilities.ValidCurrentUserId,
            null!,
            PostCommentTestUtilities.ValidContent);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.PostId);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostCommentBusinessConfigurations.POST_ID_MIN_LENGTH - 1)]
    [InlineData(PostCommentBusinessConfigurations.POST_ID_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForPostId_WhenPostIdLengthIsInvalid(int length)
    {
        // Arrange
        var command = new AddPostCommentCommand(
            PostCommentTestUtilities.ValidCurrentUserId,
            Faker.Random.AlphaNumeric(length)!,
            PostCommentTestUtilities.ValidContent);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.PostId);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForContent_WhenContentIsNull()
    {
        // Arrange
        var command = new AddPostCommentCommand(
            PostCommentTestUtilities.ValidCurrentUserId,
            PostCommentTestUtilities.ValidPostTitle,
            null!);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Content);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostCommentBusinessConfigurations.CONTENT_MIN_LENGTH - 1)]
    [InlineData(PostCommentBusinessConfigurations.CONTENT_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForContent_WhenContentLengthIsInvalid(int length)
    {
        // Arrange
        var command = new AddPostCommentCommand(
            PostCommentTestUtilities.ValidCurrentUserId,
            PostCommentTestUtilities.ValidPostTitle,
            Faker.Random.AlphaNumeric(length)!);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Content);
    }

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenModelIsValid()
    {
        // Arrange
        var command = new AddPostCommentCommand(
            PostCommentTestUtilities.ValidCurrentUserId,
            PostCommentTestUtilities.ValidPostTitle,
            PostCommentTestUtilities.ValidContent);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
