using InstaConnect.Identity.Application.Features.Users.Commands.Delete;

namespace InstaConnect.Identity.Application.UnitTests.Features.Users.Commands.Delete;

public class DeleteUserCommandValidatorUnitTests : BaseUserUnitTest
{
    private readonly DeleteUserCommandValidator _commandValidator;

    public DeleteUserCommandValidatorUnitTests()
    {
        _commandValidator = new DeleteUserCommandValidator();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdIsNull()
    {
        // Arrange
        var existingUser = CreateUser();
        var command = new DeleteUserCommand(null);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Id);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUser = CreateUser();
        var command = new DeleteUserCommand(SharedTestUtilities.GetString(length));

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Id);
    }

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenModelIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var command = new DeleteUserCommand(existingUser.Id);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
