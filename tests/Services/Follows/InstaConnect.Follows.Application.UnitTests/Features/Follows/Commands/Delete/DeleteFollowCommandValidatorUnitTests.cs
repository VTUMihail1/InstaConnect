using InstaConnect.Follows.Application.Features.Follows.Commands.Delete;

namespace InstaConnect.Follows.Application.UnitTests.Features.Follows.Commands.Delete;

public class DeleteFollowCommandValidatorUnitTests : BaseFollowUnitTest
{
    private readonly DeleteFollowCommandValidator _commandValidator;

    public DeleteFollowCommandValidatorUnitTests()
    {
        _commandValidator = new DeleteFollowCommandValidator();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdIsNull()
    {
        // Arrange
        var existingFollow = CreateFollow();
        var command = new DeleteFollowCommand(
            null,
            existingFollow.FollowerId
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Id);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(FollowConfigurations.IdMinLength - 1)]
    [InlineData(FollowConfigurations.IdMaxLength + 1)]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingFollow = CreateFollow();
        var command = new DeleteFollowCommand(
            SharedTestUtilities.GetString(length),
            existingFollow.FollowerId
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
        var existingFollow = CreateFollow();
        var command = new DeleteFollowCommand(
            existingFollow.Id,
            null
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.CurrentUserId);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(FollowConfigurations.IdMinLength - 1)]
    [InlineData(FollowConfigurations.IdMaxLength + 1)]
    public void TestValidate_ShouldHaveAnErrorForCurrentUserId_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingFollow = CreateFollow();
        var command = new DeleteFollowCommand(
            existingFollow.Id,
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
        var existingFollow = CreateFollow();
        var command = new DeleteFollowCommand(
            existingFollow.Id,
            existingFollow.FollowerId);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
