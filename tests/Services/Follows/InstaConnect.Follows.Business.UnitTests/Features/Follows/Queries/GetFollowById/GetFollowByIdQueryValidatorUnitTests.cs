﻿using FluentValidation.TestHelper;
using InstaConnect.Follows.Business.Features.Follows.Queries.GetFollowById;
using InstaConnect.Follows.Business.Features.Follows.Utilities;
using InstaConnect.Follows.Business.UnitTests.Features.Follows.Utilities;

namespace InstaConnect.Follows.Business.UnitTests.Features.Follows.Queries.GetFollowById;

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
        var query = new GetFollowByIdQuery(null!);

        // Act
        var result = _validator.TestValidate(query);

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
        var query = new GetFollowByIdQuery(Faker.Random.AlphaNumeric(length));

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Id);
    }
}