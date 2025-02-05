using FluentValidation.TestHelper;
using InstaConnect.Posts.Application.Features.PostLikes.Commands.DeletePostLike;
using InstaConnect.Posts.Application.UnitTests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Common.Features.PostLikes.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Posts.Application.UnitTests.Features.PostLikes.Commands.DeletePostLike;

public class DeletePostLikeCommandValidatorUnitTests : BasePostLikeUnitTest
{
    private readonly DeletePostLikeCommandValidator _commandValidator;

    public DeletePostLikeCommandValidatorUnitTests()
    {
        _commandValidator = new DeletePostLikeCommandValidator();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdIsNull()
    {
        // Arrange
        var existingPostLike = CreatePostLike();
        var command = new DeletePostLikeCommand(
            null!,
            existingPostLike.UserId
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Id);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostLikeBusinessConfigurations.IdMinLength - 1)]
    [InlineData(PostLikeBusinessConfigurations.IdMaxLength + 1)]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingPostLike = CreatePostLike();
        var command = new DeletePostLikeCommand(
            SharedTestUtilities.GetString(length),
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
            null!
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
        var existingPostLike = CreatePostLike();
        var command = new DeletePostLikeCommand(
            existingPostLike.Id,
            existingPostLike.UserId
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
