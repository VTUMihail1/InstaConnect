using FluentValidation.TestHelper;
using InstaConnect.Posts.Business.Features.PostComments.Commands.UpdatePostComment;
using InstaConnect.Posts.Business.UnitTests.Features.PostComments.Utilities;
using InstaConnect.Posts.Common.Features.PostComments.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Posts.Business.UnitTests.Features.PostComments.Commands.UpdatePostComment;

public class UpdatePostCommentCommandValidatorUnitTests : BasePostCommentUnitTest
{
    private readonly UpdatePostCommentCommandValidator _commandValidator;

    public UpdatePostCommentCommandValidatorUnitTests()
    {
        _commandValidator = new UpdatePostCommentCommandValidator();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdIsNull()
    {
        // Arrange
        var command = new UpdatePostCommentCommand(
            null!,
            PostCommentTestUtilities.ValidCurrentUserId,
            PostCommentTestUtilities.ValidContent
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Id);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostCommentBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(PostCommentBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var command = new UpdatePostCommentCommand(
            SharedTestUtilities.GetString(length),
            PostCommentTestUtilities.ValidCurrentUserId,
            PostCommentTestUtilities.ValidContent
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
        var command = new UpdatePostCommentCommand(
            PostCommentTestUtilities.ValidId,
            null!,
            PostCommentTestUtilities.ValidContent
        );

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
        var command = new UpdatePostCommentCommand(
            PostCommentTestUtilities.ValidId,
            SharedTestUtilities.GetString(length),
            PostCommentTestUtilities.ValidContent
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
        var command = new UpdatePostCommentCommand(
            PostCommentTestUtilities.ValidId,
            PostCommentTestUtilities.ValidCurrentUserId,
            null!
        );

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
        var command = new UpdatePostCommentCommand(
            PostCommentTestUtilities.ValidId,
            PostCommentTestUtilities.ValidCurrentUserId,
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
        var command = new UpdatePostCommentCommand(
            PostCommentTestUtilities.ValidId,
            PostCommentTestUtilities.ValidCurrentUserId,
            PostCommentTestUtilities.ValidContent
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
