using InstaConnect.Posts.Application.Features.PostLikes.Commands.Delete;
using InstaConnect.Posts.Domain.Features.Users.Utilities;

namespace InstaConnect.Posts.Application.UnitTests.Features.PostLikes.Commands.DeletePostLike;

public class DeletePostLikeCommandValidatorUnitTests : BasePostLikeUnitTest
{
    private readonly DeletePostLikeCommandRequestValidator _commandValidator;

    public DeletePostLikeCommandValidatorUnitTests()
    {
        _commandValidator = new DeletePostLikeCommandRequestValidator();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdIsNull()
    {
        // Arrange
        var existingPostLike = CreatePostLike();
        var command = new DeletePostLikeCommand(
            null,
            existingPostLike.PostId,
            existingPostLike.UserId
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Id);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostLikeConfigurations.IdMinLength - 1)]
    [InlineData(PostLikeConfigurations.IdMaxLength + 1)]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingPostLike = CreatePostLike();
        var command = new DeletePostLikeCommand(
            DataFaker.GetString(length),
            existingPostLike.PostId,
            existingPostLike.UserId
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
        var existingPostLike = CreatePostLike();
        var command = new DeletePostLikeCommand(
            existingPostLike.Id,
            existingPostLike.PostId,
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
        var existingPostLike = CreatePostLike();
        var command = new DeletePostLikeCommand(
            existingPostLike.Id,
            existingPostLike.PostId,
            DataFaker.GetString(length)
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.CurrentUserId);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForPostId_WhenPostIdIsNull()
    {
        // Arrange
        var existingPostLike = CreatePostLike();
        var command = new DeletePostLikeCommand(
            existingPostLike.Id,
            existingPostLike.PostId,
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
    public void TestValidate_ShouldHaveAnErrorForPostId_WhenPostIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingPostLike = CreatePostLike();
        var command = new DeletePostLikeCommand(
            existingPostLike.Id,
            existingPostLike.PostId,
            DataFaker.GetString(length)
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
        var existingPostLike = CreatePostLike();
        var command = new DeletePostLikeCommand(
            existingPostLike.Id,
            existingPostLike.PostId,
            existingPostLike.UserId
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
