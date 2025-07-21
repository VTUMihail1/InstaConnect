using InstaConnect.Common.Models.Enums;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Enums;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Page;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.PageSize;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.SortProperty;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Title;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Id;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Name;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

using Xunit.Sdk;

namespace InstaConnect.Posts.Application.UnitTests.Features.Posts.Queries.GetAll;

public class GetAllPostsQueryValidatorUnitTests : BasePostUnitTest
{
    private readonly GetAllPostsQueryBuilder _queryBuilder;
    private readonly GetAllPostsQueryValidator _queryValidator;

    public GetAllPostsQueryValidatorUnitTests()
    {
        _queryBuilder = new();
        _queryValidator = new();
    }

    [Theory]
    [UserIdTooLongWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenUserIdIsInvalid(string userId, string errorMessage)
    {
        // Arrange
        var request = _queryBuilder.WithUserId(userId).Create();

        // Act
        var result = _queryValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForUserId(errorMessage);
    }

    [Theory]
    [UserNameTooLongWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenUserNameIsInvalid(string userName, string errorMessage)
    {
        // Arrange
        var request = _queryBuilder.WithUserName(userName).Create();

        // Act
        var result = _queryValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForUserName(errorMessage);
    }

    [Theory]
    [PostTitleTooLongWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenTitleIsInvalid(string title, string errorMessage)
    {
        // Arrange
        var request = _queryBuilder.WithTitle(title).Create();

        // Act
        var result = _queryValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForTitle(errorMessage);
    }

    [Theory]
    [SortOrderEmptyWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenSortOrderIsInvalid(SortOrder sortOrder, string errorMessage)
    {
        // Arrange
        var request = _queryBuilder.WithSortOrder(sortOrder).Create();

        // Act
        var result = _queryValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForSortOrder(errorMessage);
    }

    [Theory]
    [PostSortPropertyEmptyWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenSortPropertyIsInvalid(PostSortProperty sortProperty, string errorMessage)
    {
        // Arrange
        var request = _queryBuilder.WithSortProperty(sortProperty).Create();

        // Act
        var result = _queryValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForSortProperty(errorMessage);
    }

    [Theory]
    [PostPageTooSmallWithMessageData]
    [PostPageTooLargeWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenPageIsInvalid(int page, string errorMessage)
    {
        // Arrange
        var request = _queryBuilder.WithPage(page).Create();

        // Act
        var result = _queryValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForPage(errorMessage);
    }

    [Theory]
    [PostPageSizeTooSmallWithMessageData]
    [PostPageSizeTooLargeWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenPageSizeIsInvalid(int pageSize, string errorMessage)
    {
        // Arrange
        var request = _queryBuilder.WithPageSize(pageSize).Create();

        // Act
        var result = _queryValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForPageSize(errorMessage);
    }

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenRequestIsValid()
    {
        // Arrange
        var request = _queryBuilder.Create();

        // Act
        var result = _queryValidator.TestValidate(request);

        // Assert
        result.ShouldNotHaveAnyValidationErrorProperties();
    }
}
