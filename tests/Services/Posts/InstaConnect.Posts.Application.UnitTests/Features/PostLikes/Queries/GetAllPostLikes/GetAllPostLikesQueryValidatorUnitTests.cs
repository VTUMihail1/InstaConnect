using FluentValidation.TestHelper;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAllPostLikes;
using InstaConnect.Posts.Application.UnitTests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Common.Features.PostLikes.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Posts.Application.UnitTests.Features.PostLikes.Queries.GetAllPostLikes;

public class GetAllPostLikesQueryValidatorUnitTests : BasePostLikeUnitTest
{
    private readonly GetAllPostLikesQueryValidator _queryValidator;

    public GetAllPostLikesQueryValidatorUnitTests()
    {
        _queryValidator = new(EntityPropertyValidator);
    }

    [Theory]
    [InlineData(PostLikeBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH - 1)]
    [InlineData(PostLikeBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForUserId_WhenUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var query = new GetAllPostLikesQuery(
            SharedTestUtilities.GetString(length),
            PostLikeTestUtilities.ValidUserName,
            PostLikeTestUtilities.ValidPostId,
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.UserId);
    }

    [Theory]
    [InlineData(PostLikeBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH - 1)]
    [InlineData(PostLikeBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForUserName_WhenUserNameLengthIsInvalid(int length)
    {
        // Arrange
        var query = new GetAllPostLikesQuery(
            PostLikeTestUtilities.ValidCurrentUserId,
            SharedTestUtilities.GetString(length),
            PostLikeTestUtilities.ValidPostId,
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.UserName);
    }

    [Theory]
    [InlineData(PostLikeBusinessConfigurations.POST_ID_MIN_LENGTH - 1)]
    [InlineData(PostLikeBusinessConfigurations.POST_ID_MAX_LENGTH + 1)]
    public void TestValidate_ShouldHaveAnErrorForPostId_WhenPostIdLengthIsInvalid(int length)
    {
        // Arrange
        var query = new GetAllPostLikesQuery(
            PostLikeTestUtilities.ValidCurrentUserId,
            PostLikeTestUtilities.ValidUserName,
            SharedTestUtilities.GetString(length),
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.PostId);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForSortPropertyName_WhenSortPropertyNameIsNull()
    {
        // Arrange
        var query = new GetAllPostLikesQuery(
            PostLikeTestUtilities.ValidCurrentUserId,
            PostLikeTestUtilities.ValidUserName,
            PostLikeTestUtilities.ValidPostId,
            PostLikeTestUtilities.ValidSortOrderProperty,
            null!,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

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
            PostLikeTestUtilities.ValidCurrentUserId,
            PostLikeTestUtilities.ValidUserName,
            PostLikeTestUtilities.ValidPostId,
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.InvalidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

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
            PostLikeTestUtilities.ValidCurrentUserId,
            PostLikeTestUtilities.ValidUserName,
            PostLikeTestUtilities.ValidPostId,
            PostLikeTestUtilities.ValidSortOrderProperty,
            SharedTestUtilities.GetString(length),
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

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
            PostLikeTestUtilities.ValidCurrentUserId,
            PostLikeTestUtilities.ValidUserName,
            PostLikeTestUtilities.ValidPostId,
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            value,
            PostLikeTestUtilities.ValidPageSizeValue);

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
            PostLikeTestUtilities.ValidCurrentUserId,
            PostLikeTestUtilities.ValidUserName,
            PostLikeTestUtilities.ValidPostId,
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
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
        var query = new GetAllPostLikesQuery(
            PostLikeTestUtilities.ValidCurrentUserId,
            PostLikeTestUtilities.ValidUserName,
            PostLikeTestUtilities.ValidPostId,
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
