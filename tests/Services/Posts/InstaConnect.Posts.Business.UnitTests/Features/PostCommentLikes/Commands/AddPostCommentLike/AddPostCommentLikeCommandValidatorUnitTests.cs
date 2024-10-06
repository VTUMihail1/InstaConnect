using FluentValidation.TestHelper;
using InstaConnect.Posts.Business.Features.PostCommentLikes.Commands.AddPostCommentLike;
using InstaConnect.Posts.Business.UnitTests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Common.Features.PostCommentLikes.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Posts.Business.UnitTests.Features.PostCommentLikes.Commands.AddPostCommentLike;

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
        var command = new AddPostCommentLikeCommand(
            null!,
            PostCommentLikeTestUtilities.ValidPostCommentId);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.CurrentUserId);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostCommentLikeBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH - 1)]
    [InlineData(PostCommentLikeBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForCurrentUserId_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var command = new AddPostCommentLikeCommand(
            SharedTestUtilities.GetString(length)!,
            PostCommentLikeTestUtilities.ValidPostCommentId);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.CurrentUserId);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForPostCommentId_WhenPostCommentIdIsNull()
    {
        // Arrange
        var command = new AddPostCommentLikeCommand(
            PostCommentLikeTestUtilities.ValidCurrentUserId,
            null!);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.PostCommentId);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostCommentLikeBusinessConfigurations.POST_COMMENT_ID_MIN_LENGTH - 1)]
    [InlineData(PostCommentLikeBusinessConfigurations.POST_COMMENT_ID_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForPostCommentId_WhenPostCommentIdLengthIsInvalid(int length)
    {
        // Arrange
        var command = new AddPostCommentLikeCommand(
            PostCommentLikeTestUtilities.ValidCurrentUserId,
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
        var command = new AddPostCommentLikeCommand(
             PostCommentLikeTestUtilities.ValidCurrentUserId,
             PostCommentLikeTestUtilities.ValidPostCommentId);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
