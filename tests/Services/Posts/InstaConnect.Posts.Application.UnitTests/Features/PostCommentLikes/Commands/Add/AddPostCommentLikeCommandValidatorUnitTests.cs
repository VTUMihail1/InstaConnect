using InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Add;

namespace InstaConnect.Posts.Application.UnitTests.Features.PostCommentLikes.Commands.Add;

public class AddPostCommentLikeCommandValidatorUnitTests : BasePostCommentLikeUnitTest
{
    private readonly AddPostCommentLikeCommandValidator _commandValidator;

    public AddPostCommentLikeCommandValidatorUnitTests()
    {
        _commandValidator = new AddPostCommentLikeCommandValidator();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForCurrentUserId_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var existingPostComment = CreatePostComment();
        var command = new AddPostCommentLikeCommand(
            null,
            existingPostComment.Id);

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
        var command = new AddPostCommentLikeCommand(
            SharedTestUtilities.GetString(length)!,
            existingPostComment.Id);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.CurrentUserId);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForPostCommentId_WhenPostCommentIdIsNull()
    {
        // Arrange
        var existingUser = CreateUser();
        var command = new AddPostCommentLikeCommand(
            existingUser.Id,
            null);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.PostCommentId);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostCommentConfigurations.IdMinLength - 1)]
    [InlineData(PostCommentConfigurations.IdMaxLength + 1)]
    public void TestValidate_ShouldHaveAnErrorForPostCommentId_WhenPostCommentIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUser = CreateUser();
        var command = new AddPostCommentLikeCommand(
            existingUser.Id,
            SharedTestUtilities.GetString(length)!);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.PostCommentId);
    }

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenModelIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var existingPostComment = CreatePostComment();
        var command = new AddPostCommentLikeCommand(
             existingUser.Id,
             existingPostComment.Id);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
