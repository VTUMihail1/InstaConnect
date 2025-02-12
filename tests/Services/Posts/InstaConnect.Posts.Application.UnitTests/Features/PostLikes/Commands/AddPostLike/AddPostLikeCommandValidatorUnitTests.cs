using FluentValidation.TestHelper;
using InstaConnect.Posts.Application.Features.PostLikes.Commands.AddPostLike;
using InstaConnect.Posts.Application.UnitTests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Common.Features.PostLikes.Utilities;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Posts.Application.UnitTests.Features.PostLikes.Commands.AddPostLike;

public class AddPostLikeCommandValidatorUnitTests : BasePostLikeUnitTest
{
    private readonly AddPostLikeCommandValidator _commandValidator;

    public AddPostLikeCommandValidatorUnitTests()
    {
        _commandValidator = new AddPostLikeCommandValidator();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForCurrentUserId_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var existingUser = CreateUser();
        var existingPost = CreatePost();
        var command = new AddPostLikeCommand(
            null,
            existingPost.Id);

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
        var existingUser = CreateUser();
        var existingPost = CreatePost();
        var command = new AddPostLikeCommand(
            SharedTestUtilities.GetString(length)!,
            existingPost.Id);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.CurrentUserId);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForPostId_WhenPostIdIsNull()
    {
        // Arrange
        var existingUser = CreateUser();
        var existingPost = CreatePost();
        var command = new AddPostLikeCommand(
            existingUser.Id,
            null);

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
        var existingUser = CreateUser();
        var existingPost = CreatePost();
        var command = new AddPostLikeCommand(
            existingUser.Id,
            SharedTestUtilities.GetString(length));

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.PostId);
    }

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenModelIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var existingPost = CreatePost();
        var command = new AddPostLikeCommand(
            existingUser.Id,
            existingPost.Id);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
