﻿using FluentValidation.TestHelper;
using InstaConnect.Identity.Business.Features.Users.Queries.GetCurrentUser;
using InstaConnect.Identity.Business.Features.Users.Utilities;
using InstaConnect.Identity.Business.UnitTests.Features.Accounts.Utilities;

namespace InstaConnect.Identity.Business.UnitTests.Features.Accounts.Queries.GetCurrentUser;

public class GetCurrentUserQueryValidatorUnitTests : BaseAccountUnitTest
{
    private readonly GetCurrentUserQueryValidator _validator;

    public GetCurrentUserQueryValidatorUnitTests()
    {
        _validator = new();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdIsNull()
    {
        // Arrange
        var query = new GetCurrentUserQuery(null!);

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.CurrentUserId);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(UserBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForId_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var query = new GetCurrentUserQuery(Faker.Random.AlphaNumeric(length));

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.CurrentUserId);
    }

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenModelIsValid()
    {
        // Arrange
        var query = new GetCurrentUserQuery(ValidId);

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
