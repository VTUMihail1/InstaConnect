using InstaConnect.Posts.Application.Features.Posts.Commands.Update;

namespace InstaConnect.Posts.Application.UnitTests.Features.Posts.Commands.Update;

public class UpdatePostCommandValidatorUnitTests : BasePostUnitTest
{
    private readonly UpdatePostCommandValidator _commandValidator;

    public UpdatePostCommandValidatorUnitTests()
    {
        _commandValidator = new UpdatePostCommandValidator();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdIsNull()
    {
        // Arrange
        var existingPost = CreatePost();
        var command = new UpdatePostCommand(
            null,
            existingPost.UserId,
            PostTestUtilities.ValidUpdateTitle,
            PostTestUtilities.ValidUpdateContent
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Id);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostConfigurations.IdMinLength - 1)]
    [InlineData(PostConfigurations.IdMaxLength + 1)]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingPost = CreatePost();
        var command = new UpdatePostCommand(
            SharedTestUtilities.GetString(length),
            existingPost.UserId,
            PostTestUtilities.ValidUpdateTitle,
            PostTestUtilities.ValidUpdateContent
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
        var existingPost = CreatePost();
        var command = new UpdatePostCommand(
            existingPost.Id,
            null,
            PostTestUtilities.ValidUpdateTitle,
            PostTestUtilities.ValidUpdateContent
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
        var existingPost = CreatePost();
        var command = new UpdatePostCommand(
            existingPost.Id,
            SharedTestUtilities.GetString(length),
            PostTestUtilities.ValidUpdateTitle,
            PostTestUtilities.ValidUpdateContent
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.CurrentUserId);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForTitle_WhenTitleIsNull()
    {
        // Arrange
        var existingPost = CreatePost();
        var command = new UpdatePostCommand(
            existingPost.Id,
            existingPost.UserId,
            null,
            PostTestUtilities.ValidUpdateContent
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Title);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostConfigurations.TitleMinLength - 1)]
    [InlineData(PostConfigurations.TitleMaxLength + 1)]
    public void TestValidate_ShouldHaveAnErrorForTitle_WhenTitleLengthIsInvalid(int length)
    {
        // Arrange
        var existingPost = CreatePost();
        var command = new UpdatePostCommand(
            existingPost.Id,
            existingPost.UserId,
            SharedTestUtilities.GetString(length),
            PostTestUtilities.ValidUpdateContent
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Title);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForContent_WhenContentIsNull()
    {
        // Arrange
        var existingPost = CreatePost();
        var command = new UpdatePostCommand(
            existingPost.Id,
            existingPost.UserId,
            PostTestUtilities.ValidUpdateTitle,
            null
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Content);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostConfigurations.ContentMinLength - 1)]
    [InlineData(PostConfigurations.ContentMaxLength + 1)]
    public void TestValidate_ShouldHaveAnErrorForContent_WhenContentLengthIsInvalid(int length)
    {
        // Arrange
        var existingPost = CreatePost();
        var command = new UpdatePostCommand(
            existingPost.Id,
            existingPost.UserId,
            PostTestUtilities.ValidUpdateTitle,
            SharedTestUtilities.GetString(length)
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Content);
    }

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenModelIsValid()
    {
        // Arrange
        var existingPost = CreatePost();
        var command = new UpdatePostCommand(
            existingPost.Id,
            existingPost.UserId,
            PostTestUtilities.ValidUpdateTitle,
            PostTestUtilities.ValidUpdateContent
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
