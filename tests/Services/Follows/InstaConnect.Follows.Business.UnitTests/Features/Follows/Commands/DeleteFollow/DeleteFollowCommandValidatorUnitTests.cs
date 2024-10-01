using FluentValidation.TestHelper;
using InstaConnect.Follows.Business.Features.Follows.Commands.DeleteFollow;
using InstaConnect.Follows.Business.UnitTests.Features.Follows.Utilities;
using InstaConnect.Follows.Common.Features.Follows.Utilities;

namespace InstaConnect.Follows.Business.UnitTests.Features.Follows.Commands.DeleteFollow;

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
        var command = new DeleteFollowCommand(
            null!,
            FollowTestUtilities.ValidCurrentUserId
        );

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Id);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(FollowBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(FollowBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var command = new DeleteFollowCommand(
            Faker.Random.AlphaNumeric(length),
            FollowTestUtilities.ValidCurrentUserId
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
        var command = new DeleteFollowCommand(
            FollowTestUtilities.ValidId,
            null!
        );

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
        var command = new DeleteFollowCommand(
            FollowTestUtilities.ValidId,
            Faker.Random.AlphaNumeric(length)
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
        var command = new DeleteFollowCommand(
            FollowTestUtilities.ValidId,
            FollowTestUtilities.ValidCurrentUserId);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
