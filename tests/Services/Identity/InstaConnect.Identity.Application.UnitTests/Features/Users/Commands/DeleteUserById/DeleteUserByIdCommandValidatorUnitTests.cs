using FluentValidation.TestHelper;
using InstaConnect.Identity.Application.Features.Users.Commands.DeleteUserById;
using InstaConnect.Identity.Application.UnitTests.Features.Users.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Identity.Application.UnitTests.Features.Users.Commands.DeleteUserById;

public class DeleteUserByIdCommandValidatorUnitTests : BaseUserUnitTest
{
    private readonly DeleteUserByIdCommandValidator _commandValidator;

    public DeleteUserByIdCommandValidatorUnitTests()
    {
        _commandValidator = new DeleteUserByIdCommandValidator();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdIsNull()
    {
        // Arrange
        var command = new DeleteUserByIdCommand(null!);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Id);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(UserBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var command = new DeleteUserByIdCommand(SharedTestUtilities.GetString(length));

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Id);
    }

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenModelIsValid()
    {
        // Arrange
        var command = new DeleteUserByIdCommand(UserTestUtilities.ValidId);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
