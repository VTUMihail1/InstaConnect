using FluentValidation.TestHelper;
using InstaConnect.Follows.Application.Features.Follows.Queries.GetAllFollows;
using InstaConnect.Follows.Application.UnitTests.Features.Follows.Utilities;
using InstaConnect.Follows.Common.Features.Follows.Utilities;
using InstaConnect.Follows.Common.Features.Users.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Follows.Application.UnitTests.Features.Follows.Queries.GetAllFollows;

public class GetAllFollowsQueryValidatorUnitTests : BaseFollowUnitTest
{
    private readonly GetAllFollowsQueryValidator _queryValidator;

    public GetAllFollowsQueryValidatorUnitTests()
    {
        _queryValidator = new(EntityPropertyValidator);
    }

    [Theory]
    [InlineData(FollowConfigurations.IdMinLength - 1)]
    [InlineData(FollowConfigurations.IdMaxLength + 1)]
    public void TestValidate_ShouldHaveAnErrorForFollowerId_WhenFollowerIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingFollow = CreateFollow();
        var query = new GetAllFollowsQuery(
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidName,
            existingFollow.FollowingId,
            UserTestUtilities.ValidName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.FollowerId);
    }

    [Theory]
    [InlineData(UserConfigurations.NameMinLength - 1)]
    [InlineData(UserConfigurations.NameMaxLength + 1)]
    public void TestValidate_ShouldHaveAnErrorForFollowerName_WhenFollowerNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingFollow = CreateFollow();
        var query = new GetAllFollowsQuery(
            existingFollow.FollowerId,
            SharedTestUtilities.GetString(length),
            existingFollow.FollowingId,
            UserTestUtilities.ValidName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.FollowerName);
    }

    [Theory]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public void TestValidate_ShouldHaveAnErrorForFollowingId_WhenFollowingIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingFollow = CreateFollow();
        var query = new GetAllFollowsQuery(
            existingFollow.FollowerId,
            UserTestUtilities.ValidName,
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.FollowingId);
    }

    [Theory]
    [InlineData(UserConfigurations.NameMinLength - 1)]
    [InlineData(UserConfigurations.NameMaxLength + 1)]
    public void TestValidate_ShouldHaveAnErrorForFollowingName_WhenFollowingNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingFollow = CreateFollow();
        var query = new GetAllFollowsQuery(
            existingFollow.FollowerId,
            UserTestUtilities.ValidName,
            existingFollow.FollowingId,
            SharedTestUtilities.GetString(length),
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.FollowingName);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForSortPropertyName_WhenSortPropertyNameIsNull()
    {
        // Arrange
        var existingFollow = CreateFollow();
        var query = new GetAllFollowsQuery(
            existingFollow.FollowerId,
            UserTestUtilities.ValidName,
            existingFollow.FollowingId,
            UserTestUtilities.ValidName,
            FollowTestUtilities.ValidSortOrderProperty,
            null!,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.SortPropertyName);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForSortPropertyName_WhenSortPropertyNameDoesNotExist()
    {
        // Arrange
        var existingFollow = CreateFollow();
        var query = new GetAllFollowsQuery(
            existingFollow.FollowerId,
            UserTestUtilities.ValidName,
            existingFollow.FollowingId,
            UserTestUtilities.ValidName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.InvalidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

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
        var existingFollow = CreateFollow();
        var query = new GetAllFollowsQuery(
            existingFollow.FollowerId,
            UserTestUtilities.ValidName,
            existingFollow.FollowingId,
            UserTestUtilities.ValidName,
            FollowTestUtilities.ValidSortOrderProperty,
            SharedTestUtilities.GetString(length),
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

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
        var existingFollow = CreateFollow();
        var query = new GetAllFollowsQuery(
            existingFollow.FollowerId,
            UserTestUtilities.ValidName,
            existingFollow.FollowingId,
            UserTestUtilities.ValidName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            value,
            FollowTestUtilities.ValidPageSizeValue);

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
        var existingFollow = CreateFollow();
        var query = new GetAllFollowsQuery(
            existingFollow.FollowerId,
            UserTestUtilities.ValidName,
            existingFollow.FollowingId,
            UserTestUtilities.ValidName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
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
        var existingFollow = CreateFollow();
        var query = new GetAllFollowsQuery(
            existingFollow.FollowerId,
            UserTestUtilities.ValidName,
            existingFollow.FollowingId,
            UserTestUtilities.ValidName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
