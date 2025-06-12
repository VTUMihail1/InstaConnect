using InstaConnect.Posts.Application.Features.PostComments.Commands.Add;

namespace InstaConnect.Posts.Application.UnitTests.Features.PostComments.Commands.Add;

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
        var postComment = CreatePostCommentFactory();
        var command = new AddPostCommentCommand(
            null,
            postComment.PostId,
            PostCommentTestUtilities.ValidAddContent);

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
        var postComment = CreatePostCommentFactory();
        var command = new AddPostCommentCommand(
            DataFaker.GetString(length)!,
            postComment.PostId,
            PostCommentTestUtilities.ValidAddContent);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.CurrentUserId);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForPostId_WhenPostIdIsNull()
    {
        // Arrange
        var postComment = CreatePostCommentFactory();
        var command = new AddPostCommentCommand(
            postComment.UserId,
            null,
            PostCommentTestUtilities.ValidAddContent);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.PostId);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostConfigurations.IdMinLength - 1)]
    [InlineData(PostConfigurations.IdMaxLength + 1)]
    public void TestValidate_ShouldHaveAnErrorForPostId_WhenPostIdLengthIsInvalid(int length)
    {
        // Arrange
        var postComment = CreatePostCommentFactory();
        var command = new AddPostCommentCommand(
            postComment.UserId,
            DataFaker.GetString(length)!,
            PostCommentTestUtilities.ValidAddContent);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.PostId);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForContent_WhenContentIsNull()
    {
        // Arrange
        var postComment = CreatePostCommentFactory();
        var command = new AddPostCommentCommand(
            postComment.UserId,
            postComment.PostId,
            null);

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
        var postComment = CreatePostCommentFactory();
        var command = new AddPostCommentCommand(
            postComment.UserId,
            postComment.PostId,
            DataFaker.GetString(length)!);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Content);
    }

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenModelIsValid()
    {
        // Arrange
        var postComment = CreatePostCommentFactory();
        var command = new AddPostCommentCommand(
            postComment.UserId,
            postComment.PostId,
            PostCommentTestUtilities.ValidAddContent);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
