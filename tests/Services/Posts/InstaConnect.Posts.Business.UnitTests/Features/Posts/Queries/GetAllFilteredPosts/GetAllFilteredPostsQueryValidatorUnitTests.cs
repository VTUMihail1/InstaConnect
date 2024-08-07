using FluentValidation.TestHelper;
using InstaConnect.Posts.Business.Features.Posts.Queries.GetAllFilteredPosts;
using InstaConnect.Posts.Business.Features.Posts.Utilities;
using InstaConnect.Posts.Business.UnitTests.Features.Posts.Utilities;
using InstaConnect.Shared.Business.Utilities;

namespace InstaConnect.Posts.Business.UnitTests.Features.Posts.Queries.GetAllFilteredPosts;

public class GetAllFilteredPostsQueryValidatorUnitTests : BasePostUnitTest
{
    private readonly GetAllPostsQueryValidator _queryValidator;

    public GetAllFilteredPostsQueryValidatorUnitTests()
    {
        _queryValidator = new(EntityPropertyValidator);
    }

    [Theory]
    [InlineData(PostBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH - 1)]
    [InlineData(PostBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForUserId_WhenUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var query = new GetAllPostsQuery(
            Faker.Random.AlphaNumeric(length),
            ValidUserName,
            ValidTitle,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.UserId);
    }

    [Theory]
    [InlineData(PostBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH - 1)]
    [InlineData(PostBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForUserName_WhenUserNameLengthIsInvalid(int length)
    {
        // Arrange
        var query = new GetAllPostsQuery(
            ValidCurrentUserId,
            Faker.Random.AlphaNumeric(length),
            ValidTitle,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.UserName);
    }

    [Theory]
    [InlineData(PostBusinessConfigurations.TITLE_MIN_LENGTH - 1)]
    [InlineData(PostBusinessConfigurations.TITLE_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForTitle_WhenTitleLengthIsInvalid(int length)
    {
        // Arrange
        var query = new GetAllPostsQuery(
            ValidCurrentUserId,
            ValidUserName,
            Faker.Random.AlphaNumeric(length),
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Title);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForSortPropertyName_WhenSortPropertyNameIsNull()
    {
        // Arrange
        var query = new GetAllPostsQuery(
            ValidCurrentUserId,
            ValidUserName,
            ValidTitle,
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
        var query = new GetAllPostsQuery(
            ValidCurrentUserId,
            ValidUserName,
            ValidTitle,
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
        var query = new GetAllPostsQuery(
            ValidCurrentUserId,
            ValidUserName,
            ValidTitle,
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
        var query = new GetAllPostsQuery(
            ValidCurrentUserId,
            ValidUserName,
            ValidTitle,
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
        var query = new GetAllPostsQuery(
            ValidCurrentUserId,
            ValidUserName,
            ValidTitle,
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
