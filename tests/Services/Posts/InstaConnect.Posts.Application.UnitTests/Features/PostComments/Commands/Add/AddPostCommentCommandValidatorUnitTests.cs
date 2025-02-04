using FluentValidation.TestHelper;
using InstaConnect.Posts.Application.Features.PostComments.Commands.AddPostComment;
using InstaConnect.Posts.Application.UnitTests.Features.PostComments.Utilities;
using InstaConnect.Posts.Common.Features.PostComments.Utilities;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Posts.Application.UnitTests.Features.PostComments.Commands.AddComment;

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
        var post = CreatePost();
        var user = CreateUser();
        var command = new AddPostCommentCommand(
            null!,
            post.Id,
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
        var post = CreatePost();
        var user = CreateUser();
        var command = new AddPostCommentCommand(
            SharedTestUtilities.GetString(length)!,
            post.Id,
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
        var post = CreatePost();
        var user = CreateUser();
        var command = new AddPostCommentCommand(
            user.Id,
            null!,
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
        var post = CreatePost();
        var user = CreateUser();
        var command = new AddPostCommentCommand(
            user.Id,
            SharedTestUtilities.GetString(length)!,
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
        var post = CreatePost();
        var user = CreateUser();
        var command = new AddPostCommentCommand(
            user.Id,
            post.Id,
            null!);

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
        var post = CreatePost();
        var user = CreateUser();
        var command = new AddPostCommentCommand(
            user.Id,
            post.Id,
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
        var post = CreatePost();
        var user = CreateUser();
        var command = new AddPostCommentCommand(
            user.Id,
            post.Id,
            PostCommentTestUtilities.ValidAddContent);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
