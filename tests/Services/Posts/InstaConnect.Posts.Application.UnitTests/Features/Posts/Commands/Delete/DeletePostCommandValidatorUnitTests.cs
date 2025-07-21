using InstaConnect.Posts.Application.Features.Posts.Commands.Delete;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Id;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Id;

namespace InstaConnect.Posts.Application.UnitTests.Features.Posts.Commands.Delete;

public class DeletePostCommandValidatorUnitTests : BasePostUnitTest
{
    private readonly DeletePostCommandBuilder _commandBuilder;
    private readonly DeletePostCommandValidator _commandValidator;

    public DeletePostCommandValidatorUnitTests()
    {
        _commandBuilder = new();
        _commandValidator = new();
    }

    [Theory]
    [PostIdNullWithMessageData]
    [PostIdEmptyWithMessageData]
    [PostIdTooShortWithMessageData]
    [PostIdTooLongWithMessageData]
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
