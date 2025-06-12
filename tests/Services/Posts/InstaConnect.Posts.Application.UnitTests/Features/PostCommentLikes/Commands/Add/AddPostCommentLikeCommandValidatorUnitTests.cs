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
        var existingPostCommentLike = CreatePostCommentLikeFactory();
        var command = new AddPostCommentLikeCommand(
            null,
            existingPostCommentLike.PostComment.PostId,
            existingPostCommentLike.PostCommentId);

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
        var existingPostCommentLike = CreatePostCommentLikeFactory();
        var command = new AddPostCommentLikeCommand(
            DataFaker.GetString(length),
            existingPostCommentLike.PostComment.PostId,
            existingPostCommentLike.PostCommentId);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.CurrentUserId);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForPostId_WhenPostIdIsNull()
    {
        // Arrange
        var existingPostCommentLike = CreatePostCommentLikeFactory();
        var command = new AddPostCommentLikeCommand(
            existingPostCommentLike.UserId,
            null!,
            existingPostCommentLike.PostCommentId);

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
        var existingPostCommentLike = CreatePostCommentLikeFactory();
        var command = new AddPostCommentLikeCommand(
            existingPostCommentLike.UserId,
            DataFaker.GetString(length),
            existingPostCommentLike.PostCommentId);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.PostId);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForPostCommentId_WhenPostCommentIdIsNull()
    {
        // Arrange
        var existingPostCommentLike = CreatePostCommentLikeFactory();
        var command = new AddPostCommentLikeCommand(
            existingPostCommentLike.UserId,
            existingPostCommentLike.PostComment.PostId,
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
        var existingPostCommentLike = CreatePostCommentLikeFactory();
        var command = new AddPostCommentLikeCommand(
            existingPostCommentLike.UserId,
            existingPostCommentLike.PostComment.PostId,
            DataFaker.GetString(length));

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.PostCommentId);
    }

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenModelIsValid()
    {
        // Arrange
        var existingPostCommentLike = CreatePostCommentLikeFactory();
        var command = new AddPostCommentLikeCommand(
             existingPostCommentLike.UserId,
             existingPostCommentLike.PostComment.PostId,
             existingPostCommentLike.PostCommentId);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
