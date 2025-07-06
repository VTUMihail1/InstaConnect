using InstaConnect.Posts.Application.Features.Posts.Commands.Delete;

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
    [PostIdOutOfBoundsMinData]
    [PostIdOutOfBoundsMaxData]
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
    [UserIdOutOfBoundsMinData]
    [UserIdOutOfBoundsMaxData]
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
