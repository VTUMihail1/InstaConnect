using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Posts.Application.Features.PostComments.Commands.Delete;

namespace InstaConnect.Posts.Application.UnitTests.Features.PostComments.Commands.Delete;

public class DeletePostCommentCommandValidatorUnitTests : BasePostCommentUnitTest
{
    private readonly DeletePostCommentCommandValidator _commandValidator;

    public DeletePostCommentCommandValidatorUnitTests()
    {
        _commandValidator = new DeletePostCommentCommandValidator();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdIsNull()
    {
        // Arrange
        var existingPostComment = CreatePostComment();
        var command = new DeletePostCommentCommand(
            null,
            existingPostComment.UserId
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Id);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostConfigurations.IdMinLength - 1)]
    [InlineData(PostConfigurations.IdMaxLength + 1)]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingPostComment = CreatePostComment();
        var command = new DeletePostCommentCommand(
            SharedTestUtilities.GetString(length),
            existingPostComment.UserId
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
        var command = new DeletePostCommentCommand(
            existingPostComment.Id,
            null
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
        var command = new DeletePostCommentCommand(
            existingPostComment.Id,
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
        var existingPostComment = CreatePostComment();
        var command = new DeletePostCommentCommand(
            existingPostComment.Id,
            existingPostComment.UserId
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
