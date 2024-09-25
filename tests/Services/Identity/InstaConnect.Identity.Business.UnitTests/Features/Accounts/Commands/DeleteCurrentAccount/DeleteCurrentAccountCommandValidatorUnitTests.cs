using FluentValidation.TestHelper;
using InstaConnect.Identity.Business.Features.Accounts.Commands.DeleteCurrentAccount;
using InstaConnect.Identity.Business.Features.Accounts.Utilities;
using InstaConnect.Identity.Business.UnitTests.Features.Accounts.Utilities;

namespace InstaConnect.Identity.Business.UnitTests.Features.Accounts.Commands.DeleteCurrentAccount;

public class DeleteCurrentAccountCommandValidatorUnitTests : BaseAccountUnitTest
{
    private readonly DeleteCurrentAccountCommandValidator _commandValidator;

    public DeleteCurrentAccountCommandValidatorUnitTests()
    {
        _commandValidator = new();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForCurrentUserId_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var command = new DeleteCurrentAccountCommand(null!);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.CurrentUserId);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(AccountBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(AccountBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForCurrentUserId_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var command = new DeleteCurrentAccountCommand(Faker.Random.AlphaNumeric(length));

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.CurrentUserId);
    }

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenModelIsValid()
    {
        // Arrange
        var command = new DeleteCurrentAccountCommand(ValidId);

        // Act
        var result = _commandValidator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
