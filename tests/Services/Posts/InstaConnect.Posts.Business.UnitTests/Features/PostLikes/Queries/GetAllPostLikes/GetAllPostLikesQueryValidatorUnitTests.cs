using FluentValidation.TestHelper;
using InstaConnect.Posts.Business.Features.PostLikes.Queries.GetAllPostLikes;
using InstaConnect.Posts.Business.UnitTests.Features.PostLikes.Utilities;
using InstaConnect.Shared.Business.Utilities;

namespace InstaConnect.Posts.Business.UnitTests.Features.PostLikes.Queries.GetAllPostLikes;

public class GetAllPostLikesQueryValidatorUnitTests : BasePostLikeUnitTest
{
    private readonly GetAllPostLikesQueryValidator _queryValidator;

    public GetAllPostLikesQueryValidatorUnitTests()
    {
        _queryValidator = new(EntityPropertyValidator);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForSortPropertyName_WhenSortPropertyNameIsNull()
    {
        // Arrange
        var query = new GetAllPostLikesQuery(
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
        var query = new GetAllPostLikesQuery(
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
        var query = new GetAllPostLikesQuery(
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
        var query = new GetAllPostLikesQuery(
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
        var query = new GetAllPostLikesQuery(
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            value);

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.PageSize);
    }
}
