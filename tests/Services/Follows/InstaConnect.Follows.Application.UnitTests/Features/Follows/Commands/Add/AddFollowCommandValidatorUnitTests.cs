using FluentValidation.TestHelper;

using InstaConnect.Follows.Application.Features.Follows.Commands.Add;
using InstaConnect.Follows.Application.UnitTests.Features.Follows.Utilities;
using InstaConnect.Follows.Common.Features.Follows.Utilities;
using InstaConnect.Follows.Common.Features.Users.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Follows.Application.UnitTests.Features.Follows.Commands.Add;

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
        var existingFollower = CreateUser();
        var existingFollowing = CreateUser();
        var command = new AddFollowCommand(
            null,
            existingFollowing.Id);

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
        var existingFollower = CreateUser();
        var existingFollowing = CreateUser();
        var command = new AddFollowCommand(
            SharedTestUtilities.GetString(length)!,
            existingFollowing.Id);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.CurrentUserId);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForFollowingId_WhenFollowingIdIsNull()
    {
        // Arrange
        var existingFollower = CreateUser();
        var existingFollowing = CreateUser();
        var command = new AddFollowCommand(
            existingFollower.Id,
            null);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.FollowingId);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public void TestValidate_ShouldHaveAnErrorForFollwingId_WhenFollowingIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingFollower = CreateUser();
        var existingFollowing = CreateUser();
        var command = new AddFollowCommand(
            existingFollower.Id,
            SharedTestUtilities.GetString(length));

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.FollowingId);
    }

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenModelIsValid()
    {
        // Arrange
        var existingFollower = CreateUser();
        var existingFollowing = CreateUser();
        var command = new AddFollowCommand(
            existingFollower.Id,
            existingFollowing.Id);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
