﻿using FluentValidation.TestHelper;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAllPosts;
using InstaConnect.Posts.Application.UnitTests.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Posts.Application.UnitTests.Features.Posts.Queries.GetAllPosts;

public class GetAllPostsQueryValidatorUnitTests : BasePostUnitTest
{
    private readonly GetAllPostsQueryValidator _queryValidator;

    public GetAllPostsQueryValidatorUnitTests()
    {
        _queryValidator = new(EntityPropertyValidator);
    }

    [Theory]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public void TestValidate_ShouldHaveAnErrorForUserId_WhenUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingPost = CreatePost();
        var query = new GetAllPostsQuery(
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidName,
            existingPost.Title,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

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
        var existingPost = CreatePost();
        var query = new GetAllPostsQuery(
            existingPost.UserId,
            SharedTestUtilities.GetString(length),
            existingPost.Title,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.UserName);
    }

    [Theory]
    [InlineData(PostConfigurations.TitleMinLength - 1)]
    [InlineData(PostConfigurations.TitleMaxLength + 1)]
    public void TestValidate_ShouldHaveAnErrorForTitle_WhenTitleLengthIsInvalid(int length)
    {
        // Arrange
        var existingPost = CreatePost();
        var query = new GetAllPostsQuery(
            existingPost.UserId,
            UserTestUtilities.ValidName,
            SharedTestUtilities.GetString(length),
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.Title);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForSortPropertyName_WhenSortPropertyNameIsNull()
    {
        // Arrange
        var existingPost = CreatePost();
        var query = new GetAllPostsQuery(
            existingPost.UserId,
            UserTestUtilities.ValidName,
            existingPost.Title,
            PostTestUtilities.ValidSortOrderProperty,
            null,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(m => m.SortPropertyName);
    }

    [Fact]
    public void TestValidate_ShouldHaveAnErrorForSortPropertyName_WhenSortPropertyNameDoesNotExist()
    {
        // Arrange
        var existingPost = CreatePost();
        var query = new GetAllPostsQuery(
            existingPost.UserId,
            UserTestUtilities.ValidName,
            existingPost.Title,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.InvalidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

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
        var existingPost = CreatePost();
        var query = new GetAllPostsQuery(
            existingPost.UserId,
            UserTestUtilities.ValidName,
            existingPost.Title,
            PostTestUtilities.ValidSortOrderProperty,
            SharedTestUtilities.GetString(length),
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

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
        var existingPost = CreatePost();
        var query = new GetAllPostsQuery(
            existingPost.UserId,
            UserTestUtilities.ValidName,
            existingPost.Title,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            value,
            PostTestUtilities.ValidPageSizeValue);

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
        var existingPost = CreatePost();
        var query = new GetAllPostsQuery(
            existingPost.UserId,
            UserTestUtilities.ValidName,
            existingPost.Title,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
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
        var existingPost = CreatePost();
        var query = new GetAllPostsQuery(
            existingPost.UserId,
            UserTestUtilities.ValidName,
            existingPost.Title,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var result = _queryValidator.TestValidate(query);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
