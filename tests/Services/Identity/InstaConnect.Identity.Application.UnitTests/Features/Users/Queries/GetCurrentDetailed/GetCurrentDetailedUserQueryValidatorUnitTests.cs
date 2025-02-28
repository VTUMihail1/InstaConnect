using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentDetailed;

namespace InstaConnect.Identity.Application.UnitTests.Features.Users.Queries.GetCurrentDetailed;

public class GetCurrentDetailedUserQueryValidatorUnitTests : BaseUserUnitTest
{
    private readonly GetCurrentDetailedUserQueryValidator _validator;

    public GetCurrentDetailedUserQueryValidatorUnitTests()
    {
        _validator = new();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdIsNull()
    {
        // Arrange
        var query = new GetCurrentDetailedUserQuery(null);

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.CurrentUserId);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var query = new GetCurrentDetailedUserQuery(SharedTestUtilities.GetString(length));

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.CurrentUserId);
    }

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenModelIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var query = new GetCurrentDetailedUserQuery(existingUser.Id);

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
