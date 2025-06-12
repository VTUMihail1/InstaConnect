using InstaConnect.Posts.Application.Features.Posts.Commands.Add;

namespace InstaConnect.Posts.Application.UnitTests.Features.Posts.Commands.Add;

public class AddPostCommandValidatorUnitTests : BasePostUnitTest
{
    private readonly AddPostCommandBuilder _commandBuilder;
    private readonly AddPostCommandValidator _commandValidator;

    public AddPostCommandValidatorUnitTests()
    {
        _commandBuilder = new();
        _commandValidator = new();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnError_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var command = _commandBuilder.WithoutUserId().Create();

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorForUserId();
    }

    [Theory]
    [UserIdOutOfBoundsMinData]
    [UserIdOutOfBoundsMaxData]
    public void TestValidate_ShouldHaveAnError_WhenCurrentUserIdLengthIsInvalid(string userId)
    {
        // Arrange
        var command = _commandBuilder.WithUserId(userId).Create();

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorForUserId();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnError_WhenTitleIsNull()
    {
        // Arrange
        var command = _commandBuilder.WithoutTitle().Create();

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorForTitle();
    }

    [Theory]
    [PostTitleOutOfBoundsMinData]
    [PostTitleOutOfBoundsMaxData]
    public void TestValidate_ShouldHaveAnError_WhenTitleLengthIsInvalid(string title)
    {
        // Arrange
        var command = _commandBuilder.WithTitle(title).Create();

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorForTitle();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnError_WhenContentIsNull()
    {
        // Arrange
        var command = _commandBuilder.WithoutContent().Create();

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorForContent();
    }

    [Theory]
    [PostContentOutOfBoundsMinData]
    [PostContentOutOfBoundsMaxData]
    public void TestValidate_ShouldHaveAnError_WhenContentLengthIsInvalid(string content)
    {
        // Arrange
        var command = _commandBuilder.WithContent(content).Create();

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorForContent();
    }

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenCommandIsValid()
    {
        // Arrange
        var command = _commandBuilder.Create();

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrorProperties();
    }
}
