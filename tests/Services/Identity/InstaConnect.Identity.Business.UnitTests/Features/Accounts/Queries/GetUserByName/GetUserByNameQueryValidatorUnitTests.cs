﻿using FluentValidation.TestHelper;
using InstaConnect.Identity.Business.Features.Users.Queries.GetUserByName;
using InstaConnect.Identity.Business.Features.Users.Utilities;
using InstaConnect.Identity.Business.UnitTests.Features.Accounts.Utilities;

namespace InstaConnect.Identity.Business.UnitTests.Features.Accounts.Queries.GetUserByName;

public class GetUserByNameQueryValidatorUnitTests : BaseAccountUnitTest
{
    private readonly GetUserByNameQueryValidator _validator;

    public GetUserByNameQueryValidatorUnitTests()
    {
        _validator = new();
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForName_WhenNameIsNull()
    {
        // Arrange
        var query = new GetUserByNameQuery(null!);

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.UserName);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserBusinessConfigurations.USER_NAME_MIN_LENGTH - 1)]
    [InlineData(UserBusinessConfigurations.USER_NAME_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForName_WhenNameLengthIsInvalid(int length)
    {
        // Arrange
        var query = new GetUserByNameQuery(Faker.Random.AlphaNumeric(length));

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.UserName);
    }

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenModelIsValid()
    {
        // Arrange
        var query = new GetUserByNameQuery(ValidName);

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
