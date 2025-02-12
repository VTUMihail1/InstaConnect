using FluentValidation.TestHelper;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.DeletePostCommentLike;
using InstaConnect.Posts.Application.UnitTests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Common.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Common.Features.PostComments.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Posts.Application.UnitTests.Features.PostCommentLikes.Commands.DeletePostCommentLike;

public class DeletePostCommentLikeCommandValidatorUnitTests : BasePostCommentLikeUnitTest
{
    private readonly DeletePostCommentLikeCommandValidator _commandValidator;

    public DeletePostCommentLikeCommandValidatorUnitTests()
    {
        _commandValidator = new DeletePostCommentLikeCommandValidator();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdIsNull()
    {
        // Arrange
        var existingPostCommentLike = CreatePostCommentLike();
        var command = new DeletePostCommentLikeCommand(
            null,
            existingPostCommentLike.UserId
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Id);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostCommentLikeConfigurations.IdMinLength - 1)]
    [InlineData(PostCommentLikeConfigurations.IdMaxLength + 1)]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingPostCommentLike = CreatePostCommentLike();
        var command = new DeletePostCommentLikeCommand(
            SharedTestUtilities.GetString(length),
            existingPostCommentLike.UserId
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
        var existingPostCommentLike = CreatePostCommentLike();
        var command = new DeletePostCommentLikeCommand(
            existingPostCommentLike.Id,
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
        var existingPostCommentLike = CreatePostCommentLike();
        var command = new DeletePostCommentLikeCommand(
            existingPostCommentLike.Id,
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
        var existingPostCommentLike = CreatePostCommentLike();
        var command = new DeletePostCommentLikeCommand(
            existingPostCommentLike.Id,
            existingPostCommentLike.UserId
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
