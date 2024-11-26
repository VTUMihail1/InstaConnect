using FluentValidation.TestHelper;
using InstaConnect.Follows.Application.Features.Follows.Queries.GetFollowById;
using InstaConnect.Follows.Application.UnitTests.Features.Follows.Utilities;
using InstaConnect.Follows.Common.Features.Follows.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Follows.Application.UnitTests.Features.Follows.Queries.GetFollowById;

public class GetFollowByIdQueryValidatorUnitTests : BaseFollowUnitTest
{
    private readonly GetFollowByIdQueryValidator _validator;

    public GetFollowByIdQueryValidatorUnitTests()
    {
        _validator = new();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdIsNull()
    {
        // Arrange
        var existingFollowerId = CreateUser();
        var existingFollowingId = CreateUser();
        var existingFollowId = CreateFollow(existingFollowerId, existingFollowingId);
        var query = new GetFollowByIdQuery(null!);

        // Act
        var result = _validator.TestValidate(query);

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
        var existingFollowerId = CreateUser();
        var existingFollowingId = CreateUser();
        var existingFollowId = CreateFollow(existingFollowerId, existingFollowingId);
        var query = new GetFollowByIdQuery(SharedTestUtilities.GetString(length));

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Id);
    }

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenModelIsValid()
    {
        // Arrange
        var existingFollowerId = CreateUser();
        var existingFollowingId = CreateUser();
        var existingFollowId = CreateFollow(existingFollowerId, existingFollowingId);
        var query = new GetFollowByIdQuery(existingFollowId);

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
