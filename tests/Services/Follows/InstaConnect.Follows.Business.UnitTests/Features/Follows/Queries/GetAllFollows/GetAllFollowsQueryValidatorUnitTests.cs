using FluentValidation.TestHelper;
using InstaConnect.Follows.Business.Features.Follows.Queries.GetAllFollows;
using InstaConnect.Follows.Business.Features.Follows.Utilities;
using InstaConnect.Follows.Business.UnitTests.Features.Follows.Utilities;
using InstaConnect.Shared.Business.Utilities;

namespace InstaConnect.Follows.Business.UnitTests.Features.Follows.Queries.GetAllFollows;

public class GetAllFollowsQueryValidatorUnitTests : BaseFollowUnitTest
{
    private readonly GetAllFollowsQueryValidator _queryValidator;

    public GetAllFollowsQueryValidatorUnitTests()
    {
        _queryValidator = new(EntityPropertyValidator);
    }

    [Theory]
    [InlineData(FollowBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH - 1)]
    [InlineData(FollowBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForFollowerId_WhenFollowerIdLengthIsInvalid(int length)
    {
        // Arrange
        var query = new GetAllFollowsQuery(
            Faker.Random.AlphaNumeric(length),
            ValidUserName,
            ValidFollowingId,
            ValidUserName,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.FollowerId);
    }

    [Theory]
    [InlineData(FollowBusinessConfigurations.FOLLOWING_NAME_MIN_LENGTH - 1)]
    [InlineData(FollowBusinessConfigurations.FOLLOWING_NAME_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForFollowerName_WhenFollowerNameLengthIsInvalid(int length)
    {
        // Arrange
        var query = new GetAllFollowsQuery(
            ValidCurrentUserId,
            Faker.Random.AlphaNumeric(length),
            ValidFollowingId,
            ValidUserName,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.FollowerName);
    }

    [Theory]
    [InlineData(FollowBusinessConfigurations.FOLLOWING_ID_MIN_LENGTH - 1)]
    [InlineData(FollowBusinessConfigurations.FOLLOWING_ID_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForFollowingId_WhenFollowingIdLengthIsInvalid(int length)
    {
        // Arrange
        var query = new GetAllFollowsQuery(
            ValidCurrentUserId,
            ValidUserName,
            Faker.Random.AlphaNumeric(length),
            ValidUserName,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.FollowingId);
    }

    [Theory]
    [InlineData(FollowBusinessConfigurations.FOLLOWING_NAME_MIN_LENGTH - 1)]
    [InlineData(FollowBusinessConfigurations.FOLLOWING_NAME_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForFollowingName_WhenFollowingNameLengthIsInvalid(int length)
    {
        // Arrange
        var query = new GetAllFollowsQuery(
            ValidCurrentUserId,
            ValidUserName,
            ValidFollowingId,
            Faker.Random.AlphaNumeric(length),
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.FollowingName);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForSortPropertyName_WhenSortPropertyNameIsNull()
    {
        // Arrange
        var query = new GetAllFollowsQuery(
            ValidCurrentUserId,
            ValidUserName,
            ValidFollowingId,
            ValidUserName,
            ValidSortOrderProperty,
            null!,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.SortPropertyName);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForSortPropertyName_WhenSortPropertyNameDoesNotExist()
    {
        // Arrange
        var query = new GetAllFollowsQuery(
            ValidCurrentUserId,
            ValidUserName,
            ValidFollowingId,
            ValidUserName,
            ValidSortOrderProperty,
            InvalidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.SortPropertyName);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(SharedBusinessConfigurations.SORT_ORDER_MIN_LENGTH - 1)]
    [InlineData(SharedBusinessConfigurations.SORT_ORDER_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForSortPropertyName_WhenSortPropertyNameLengthIsInvalid(int length)
    {
        // Arrange
        var query = new GetAllFollowsQuery(
            ValidCurrentUserId,
            ValidUserName,
            ValidFollowingId,
            ValidUserName,
            ValidSortOrderProperty,
            Faker.Random.AlphaNumeric(length),
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.SortPropertyName);
    }

    [Theory]
    [InlineData(SharedBusinessConfigurations.PAGE_MIN_VALUE - 1)]
    [InlineData(SharedBusinessConfigurations.PAGE_MAX_VALUE + 1)]
    public void TestValidate_ShouldHaveAnErrorForOffset_WhenPageValueIsInvalid(int value)
    {
        // Arrange
        var query = new GetAllFollowsQuery(
            ValidCurrentUserId,
            ValidUserName,
            ValidFollowingId,
            ValidUserName,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            value,
            ValidPageSizeValue);

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Page);
    }

    [Theory]
    [InlineData(SharedBusinessConfigurations.PAGE_MIN_VALUE - 1)]
    [InlineData(SharedBusinessConfigurations.PAGE_MAX_VALUE + 1)]
    public void TestValidate_ShouldHaveAnErrorForLimit_WhenPageSizeValueIsInvalid(int value)
    {
        // Arrange
        var query = new GetAllFollowsQuery(
            ValidCurrentUserId,
            ValidUserName,
            ValidFollowingId,
            ValidUserName,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            value);

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.PageSize);
    }

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenModelIsValid()
    {
        // Arrange
        var query = new GetAllFollowsQuery(
            ValidCurrentUserId,
            ValidUserName,
            ValidFollowingId,
            ValidUserName,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
