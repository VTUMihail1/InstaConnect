using InstaConnect.Posts.Application.Features.Posts.Commands.Update;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Content;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Id;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Title;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Id;

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

    [Theory]
    [PostIdNullData]
    [PostIdEmptyData]
    [PostIdTooShortData]
    [PostIdTooLongData]
    public void TestValidate_ShouldHaveAnError_WhenIdIsInvalid(string id, string errorMessage)
    {
        // Arrange
        var request = _commandBuilder.WithId(id).Create();

        // Act
        var result = _commandValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForId(errorMessage);
    }

    [Theory]
    [UserIdNullData]
    [UserIdEmptyData]
    [UserIdTooShortData]
    [UserIdTooLongData]
    public void TestValidate_ShouldHaveAnError_WhenUserIdIsInvalid(string userId, string errorMessage)
    {
        // Arrange
        var request = _commandBuilder.WithUserId(userId).Create();

        // Act
        var result = _commandValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForUserId(errorMessage);
    }

    [Theory]
    [PostTitleNullData]
    [PostTitleEmptyData]
    [PostTitleTooShortData]
    [PostTitleTooLongData]
    public void TestValidate_ShouldHaveAnError_WhenTitleIsInvalid(string title, string errorMessage)
    {
        // Arrange
        var request = _commandBuilder.WithTitle(title).Create();

        // Act
        var result = _commandValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForTitle(errorMessage);
    }

    [Theory]
    [PostContentNullWithMessageData]
    [PostContentEmptyWithMessageData]
    [PostContentTooShortWithMessageData]
    [PostContentTooLongWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenContentIsInvalid(string content, string errorMessage)
    {
        // Arrange
        var request = _commandBuilder.WithContent(content).Create();

        // Act
        var result = _commandValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForContent(errorMessage);
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
