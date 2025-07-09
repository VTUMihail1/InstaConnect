using InstaConnect.Posts.Application.Features.Posts.Commands.Update;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes;

namespace InstaConnect.Posts.Application.UnitTests.Features.Posts.Commands.Update;

public class UpdatePostCommandValidatorUnitTests : BasePostUnitTest
{
    private readonly UpdatePostCommandBuilder _commandBuilder;
    private readonly UpdatePostCommandValidator _commandValidator;

    public UpdatePostCommandValidatorUnitTests()
    {
        _commandBuilder = new();
        _commandValidator = new();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnError_WhenIdIsNull()
    {
        // Arrange
        var request = _commandBuilder.WithoutId().Create();

        // Act
        var result = _commandValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForId();
    }

    [Theory]
    [PostIdTooShortData]
    [PostIdTooLongData]
    public void TestValidate_ShouldHaveAnError_WhenIdLengthIsInvalid(string id)
    {
        // Arrange
        var request = _commandBuilder.WithId(id).Create();

        // Act
        var result = _commandValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForId();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnError_WhenUserIdIsNull()
    {
        // Arrange
        var request = _commandBuilder.WithoutUserId().Create();

        // Act
        var result = _commandValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForUserId();
    }

    [Theory]
    [UserIdTooShortData]
    [UserIdTooLongData]
    public void TestValidate_ShouldHaveAnError_WhenUserIdLengthIsInvalid(string userId)
    {
        // Arrange
        var request = _commandBuilder.WithUserId(userId).Create();

        // Act
        var result = _commandValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForUserId();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnError_WhenTitleIsNull()
    {
        // Arrange
        var request = _commandBuilder.WithoutTitle().Create();

        // Act
        var result = _commandValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForTitle();
    }

    [Theory]
    [PostTitleTooShortData]
    [PostTitleTooLongData]
    public void TestValidate_ShouldHaveAnError_WhenTitleLengthIsInvalid(string title)
    {
        // Arrange
        var request = _commandBuilder.WithTitle(title).Create();

        // Act
        var result = _commandValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForTitle();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnError_WhenContentIsNull()
    {
        // Arrange
        var request = _commandBuilder.WithoutContent().Create();

        // Act
        var result = _commandValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForContent();
    }

    [Theory]
    [PostContentOutOfBoundsMinData]
    [PostContentTooLongData]
    public void TestValidate_ShouldHaveAnError_WhenContentLengthIsInvalid(string content)
    {
        // Arrange
        var request = _commandBuilder.WithContent(content).Create();

        // Act
        var result = _commandValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForContent();
    }

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenRequestIsValid()
    {
        // Arrange
        var request = _commandBuilder.Create();

        // Act
        var result = _commandValidator.TestValidate(request);

        // Assert
        result.ShouldNotHaveAnyValidationErrorProperties();
    }
}
