using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Posts.Application.Features.PostComments.Commands.Update;

namespace InstaConnect.Posts.Application.UnitTests.Features.PostComments.Commands.Update;

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
        var existingPostComment = CreatePostComment();
        var command = new UpdatePostCommentCommand(
            null,
            existingPostComment.UserId,
            existingPostComment.Content
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Id);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostCommentConfigurations.IdMinLength - 1)]
    [InlineData(PostCommentConfigurations.IdMaxLength + 1)]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingPostComment = CreatePostComment();
        var command = new UpdatePostCommentCommand(
            SharedTestUtilities.GetString(length),
            existingPostComment.UserId,
            existingPostComment.Content
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
        var existingPostComment = CreatePostComment();
        var command = new UpdatePostCommentCommand(
            existingPostComment.Id,
            null,
            existingPostComment.Content
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
        var existingPostComment = CreatePostComment();
        var command = new UpdatePostCommentCommand(
            existingPostComment.Id,
            SharedTestUtilities.GetString(length),
            existingPostComment.Content
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
        var existingPostComment = CreatePostComment();
        var command = new UpdatePostCommentCommand(
            existingPostComment.Id,
            existingPostComment.UserId,
            null
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Content);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostCommentConfigurations.ContentMinLength - 1)]
    [InlineData(PostCommentConfigurations.ContentMaxLength + 1)]
    public void TestValidate_ShouldHaveAnErrorForContent_WhenContentLengthIsInvalid(int length)
    {
        // Arrange
        var existingPostComment = CreatePostComment();
        var command = new UpdatePostCommentCommand(
            existingPostComment.Id,
            existingPostComment.UserId,
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
        var existingPostComment = CreatePostComment();
        var command = new UpdatePostCommentCommand(
            existingPostComment.Id,
            existingPostComment.UserId,
            existingPostComment.Content
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
