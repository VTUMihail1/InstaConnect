using FluentValidation.TestHelper;
using InstaConnect.Identity.Business.Features.Users.Commands.DeleteCurrentUser;
using InstaConnect.Identity.Business.Features.Users.Utilities;
using InstaConnect.Identity.Business.UnitTests.Features.Users.Utilities;

namespace InstaConnect.Identity.Business.UnitTests.Features.Users.Commands.DeleteCurrentUser;

public class DeleteCurrentUserCommandValidatorUnitTests : BaseUserUnitTest
{
    private readonly DeleteCurrentUserCommandValidator _commandValidator;

    public DeleteCurrentUserCommandValidatorUnitTests()
    {
        _commandValidator = new();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForCurrentUserId_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var command = new DeleteCurrentUserCommand(null!);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.CurrentUserId);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(UserBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForCurrentUserId_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var command = new DeleteCurrentUserCommand(Faker.Random.AlphaNumeric(length));

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.CurrentUserId);
    }

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenModelIsValid()
    {
        // Arrange
        var command = new DeleteCurrentUserCommand(ValidId);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
