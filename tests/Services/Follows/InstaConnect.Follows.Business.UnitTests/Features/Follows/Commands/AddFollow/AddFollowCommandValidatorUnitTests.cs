using FluentValidation.TestHelper;
using InstaConnect.Follows.Business.Features.Follows.Commands.AddFollow;
using InstaConnect.Follows.Business.Features.Follows.Utilities;
using InstaConnect.Follows.Business.UnitTests.Features.Follows.Utilities;

namespace InstaConnect.Follows.Business.UnitTests.Features.Follows.Commands.AddFollow;

public class AddFollowCommandValidatorUnitTests : BaseFollowUnitTest
{
    private readonly AddFollowCommandValidator _commandValidator;

    public AddFollowCommandValidatorUnitTests()
    {
        _commandValidator = new AddFollowCommandValidator();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForCurrentUserId_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var command = new AddFollowCommand(
            null!,
            ValidFollowingId);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.CurrentUserId);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(FollowBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH - 1)]
    [InlineData(FollowBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForCurrentUserId_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var command = new AddFollowCommand(
            Faker.Random.AlphaNumeric(length)!,
            ValidFollowingId);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.CurrentUserId);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForFollowingId_WhenFollowingIdIsNull()
    {
        // Arrange
        var command = new AddFollowCommand(
            ValidCurrentUserId,
            null!);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.FollowingId);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(FollowBusinessConfigurations.FOLLOWING_ID_MIN_LENGTH - 1)]
    [InlineData(FollowBusinessConfigurations.FOLLOWING_ID_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForFollwingId_WhenFollowingIdLengthIsInvalid(int length)
    {
        // Arrange
        var command = new AddFollowCommand(
            ValidCurrentUserId,
            Faker.Random.AlphaNumeric(length));

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.FollowingId);
    }
}
