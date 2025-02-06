using FluentValidation.TestHelper;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAllPostCommentLikes;
using InstaConnect.Posts.Application.UnitTests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Common.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Common.Features.PostComments.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Posts.Application.UnitTests.Features.PostCommentLikes.Queries.GetAllPostCommentLikes;

public class GetAllPostCommentLikesQueryValidatorUnitTests : BasePostCommentLikeUnitTest
{
    private readonly GetAllPostCommentLikesQueryValidator _queryValidator;

    public GetAllPostCommentLikesQueryValidatorUnitTests()
    {
        _queryValidator = new(EntityPropertyValidator);
    }

    [Theory]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public void TestValidate_ShouldHaveAnErrorForUserId_WhenUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingPostCommentLike = CreatePostCommentLike();
        var query = new GetAllPostCommentLikesQuery(
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidName,
            existingPostCommentLike.PostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.UserId);
    }

    [Theory]
    [InlineData(UserConfigurations.NameMinLength - 1)]
    [InlineData(UserConfigurations.NameMaxLength + 1)]
    public void TestValidate_ShouldHaveAnErrorForUserName_WhenUserNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingPostCommentLike = CreatePostCommentLike();
        var query = new GetAllPostCommentLikesQuery(
            existingPostCommentLike.UserId,
            SharedTestUtilities.GetString(length),
            existingPostCommentLike.PostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.UserName);
    }

    [Theory]
    [InlineData(PostCommentConfigurations.IdMinLength - 1)]
    [InlineData(PostCommentConfigurations.IdMaxLength + 1)]
    public void TestValidate_ShouldHaveAnErrorForPostCommentId_WhenPostCommentIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingPostCommentLike = CreatePostCommentLike();
        var query = new GetAllPostCommentLikesQuery(
            existingPostCommentLike.UserId,
            UserTestUtilities.ValidName,
            SharedTestUtilities.GetString(length),
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.PostCommentId);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForSortPropertyName_WhenSortPropertyNameIsNull()
    {
        // Arrange
        var existingPostCommentLike = CreatePostCommentLike();
        var query = new GetAllPostCommentLikesQuery(
            existingPostCommentLike.UserId,
            UserTestUtilities.ValidName,
            existingPostCommentLike.PostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            null!,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.SortPropertyName);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForSortPropertyName_WhenSortPropertyNameDoesNotExist()
    {
        // Arrange
        var existingPostCommentLike = CreatePostCommentLike();
        var query = new GetAllPostCommentLikesQuery(
            existingPostCommentLike.UserId,
            UserTestUtilities.ValidName,
            existingPostCommentLike.PostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.InvalidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.SortPropertyName);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(SharedConfigurations.SortOrderMinLength - 1)]
    [InlineData(SharedConfigurations.SortOrderMaxLength + 1)]
    public void TestValidate_ShouldHaveAnErrorForSortPropertyName_WhenSortPropertyNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingPostCommentLike = CreatePostCommentLike();
        var query = new GetAllPostCommentLikesQuery(
            existingPostCommentLike.UserId,
            UserTestUtilities.ValidName,
            existingPostCommentLike.PostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            SharedTestUtilities.GetString(length),
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.SortPropertyName);
    }

    [Theory]
    [InlineData(SharedConfigurations.PageMinValue - 1)]
    [InlineData(SharedConfigurations.PageMaxValue + 1)]
    public void TestValidate_ShouldHaveAnErrorForOffset_WhenPageValueIsInvalid(int value)
    {
        // Arrange
        var existingPostCommentLike = CreatePostCommentLike();
        var query = new GetAllPostCommentLikesQuery(
            existingPostCommentLike.UserId,
            UserTestUtilities.ValidName,
            existingPostCommentLike.PostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            value,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Page);
    }

    [Theory]
    [InlineData(SharedConfigurations.PageMinValue - 1)]
    [InlineData(SharedConfigurations.PageMaxValue + 1)]
    public void TestValidate_ShouldHaveAnErrorForLimit_WhenPageSizeValueIsInvalid(int value)
    {
        // Arrange
        var existingPostCommentLike = CreatePostCommentLike();
        var query = new GetAllPostCommentLikesQuery(
            existingPostCommentLike.UserId,
            UserTestUtilities.ValidName,
            existingPostCommentLike.PostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
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
        var existingPostCommentLike = CreatePostCommentLike();
        var query = new GetAllPostCommentLikesQuery(
            existingPostCommentLike.UserId,
            UserTestUtilities.ValidName,
            existingPostCommentLike.PostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
