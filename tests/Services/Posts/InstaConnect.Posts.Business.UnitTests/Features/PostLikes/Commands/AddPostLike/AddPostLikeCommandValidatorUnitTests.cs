using FluentValidation.TestHelper;
using InstaConnect.Posts.Business.Features.PostLikes.Commands.AddPostLike;
using InstaConnect.Posts.Business.UnitTests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Common.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Business.UnitTests.Features.PostLikes.Commands.AddPostLike;

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
        var command = new AddPostLikeCommand(
            null!,
            PostLikeTestUtilities.ValidPostId);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.CurrentUserId);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostLikeBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH - 1)]
    [InlineData(PostLikeBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForCurrentUserId_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var command = new AddPostLikeCommand(
            Faker.Random.AlphaNumeric(length)!,
            PostLikeTestUtilities.ValidPostId);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.CurrentUserId);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForPostId_WhenPostIdIsNull()
    {
        // Arrange
        var command = new AddPostLikeCommand(
            PostLikeTestUtilities.ValidCurrentUserId,
            null!);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.PostId);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostLikeBusinessConfigurations.POST_ID_MIN_LENGTH - 1)]
    [InlineData(PostLikeBusinessConfigurations.POST_ID_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForPostId_WhenPostIdLengthIsInvalid(int length)
    {
        // Arrange
        var command = new AddPostLikeCommand(
            PostLikeTestUtilities.ValidCurrentUserId,
            Faker.Random.AlphaNumeric(length));

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.PostId);
    }

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenModelIsValid()
    {
        // Arrange
        var command = new AddPostLikeCommand(
            PostLikeTestUtilities.ValidCurrentUserId,
            PostLikeTestUtilities.ValidPostId);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
